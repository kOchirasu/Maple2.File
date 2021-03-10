using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    [Generator]
    public class XmlArrayGenerator : ISourceGenerator {
        private const string ATTRIBUTE_NAMESPACE = "M2dXmlGenerator";
        private const string ATTRIBUTE_TAG = "M2dArray";
        private const string ATTRIBUTE_NAME = "M2dArrayAttribute";

        private static readonly SourceText attributeSource =
            Assembly.GetExecutingAssembly().LoadSource($"{ATTRIBUTE_NAME}.cs");
        private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
            "FG00010",
            "M2dArrayAttribute can only be applied to value array types",
            "Invalid type {0} for M2dArrayAttribute in {1}",
            "Maple2.File.Generator",
            DiagnosticSeverity.Error,
            true
        );

        public void Initialize(GeneratorInitializationContext context) {
            // Register a syntax receiver that will be created for each generation pass
            context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context) {
            // Register the attribute source
            context.AddSource(ATTRIBUTE_NAME, attributeSource);

            if (!(context.SyntaxReceiver is AttributeSyntaxReceiver receiver)) {
                return;
            }

            Compilation compilation = context.Compilation.AddSource(attributeSource.ToString());
            INamedTypeSymbol attributeSymbol =
                compilation.GetTypeByMetadataName($"{ATTRIBUTE_NAMESPACE}.{ATTRIBUTE_NAME}");

            IEnumerable<IGrouping<ISymbol, IFieldSymbol>> classGroups = receiver.Fields
                .Fields(compilation)
                .WithAttribute(attributeSymbol)
                .GroupBy(field => field.ContainingType, SymbolEqualityComparer.Default);

            foreach (IGrouping<ISymbol, IFieldSymbol> group in classGroups) {
                var hintName = new StringBuilder($"[{group.Key.ContainingNamespace.Name}]");
                foreach (INamedTypeSymbol containingType in group.Key.ContainingTypes()) {
                    hintName.Append($"{containingType.Name}.");
                }

                hintName.Append($"{group.Key.Name}_{ATTRIBUTE_TAG}.cs");

                string classSource = ProcessClass(context, group.Key, group, attributeSymbol);
                context.AddSource(hintName.ToString(), SourceText.From(classSource, Encoding.UTF8));
            }
        }

        private string ProcessClass(GeneratorExecutionContext context, ISymbol classSymbol,
                IEnumerable<IFieldSymbol> fields, ISymbol attributeSymbol) {
            var builder = new SourceBuilder(classSymbol.ContainingNamespace);
            builder.Imports.AddRange(new[] {
                "System",
                "System.Xml.Serialization",
            });
            builder.Classes.AddRange(classSymbol.ContainingTypes().Select(symbol => symbol.Name));
            builder.Classes.Add(classSymbol.Name);

            // create properties for each field
            builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attributeSymbol)));

            return builder.Build();
        }

        private string ProcessField(GeneratorExecutionContext context, IFieldSymbol fieldSymbol,
                ISymbol attributeSymbol) {
            AttributeData attributeData = fieldSymbol.GetAttribute(attributeSymbol);
            string attributeName = attributeData.GetValueOrDefault("Name", fieldSymbol.Name);
            char delimiter = attributeData.GetValueOrDefault<char>("Delimiter", ',');

            var source = new StringBuilder();
            source.Append($@"
[XmlAttribute(""{attributeName}"")]
public string _{attributeName} {{
    get {{
");
            AddSerializer(context, source, fieldSymbol, delimiter);
            source.Append(@"
    }
    set {");
            AddDeserializer(context, source, fieldSymbol, delimiter);
            source.AppendLine(@"
    }
}");
            return source.ToString();
        }

        private void AddSerializer(GeneratorExecutionContext context, StringBuilder source, IFieldSymbol field,
                char delimiter) {
            if (!(field.Type is IArrayTypeSymbol)) {
                context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type,
                    field.ToDisplayString()));
                return;
            }

            string fieldName = $"this.{field.FieldName()}";
            source.Append($"return {fieldName} != null ? string.Join('{delimiter}', {fieldName}) : null;");
        }

        private void AddDeserializer(GeneratorExecutionContext context, StringBuilder source, IFieldSymbol field,
                char delimiter) {
            if (!(field.Type is IArrayTypeSymbol arrayType)) {
                context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type,
                    field.ToDisplayString()));
                return;
            }

            string fieldName = $"this.{field.FieldName()}";
            source.AppendLine($@"
string[] split = value.Split('{delimiter}', StringSplitOptions.RemoveEmptyEntries);
{fieldName} = new {arrayType.ElementType}[split.Length];
for (int i = 0; i < split.Length; i++) {{");
            source.AppendLine(arrayType.ElementType.IsValueType
                ? $"{fieldName}[i] = {arrayType.ElementType}.Parse(split[i].Trim());"
                : $"{fieldName}[i] = split[i].Trim();");
            source.Append('}');
        }
    }
}