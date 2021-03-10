using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    [Generator]
    public class XmlNullableGenerator : ISourceGenerator {
        private const string ATTRIBUTE_NAMESPACE = "M2dXmlGenerator";
        private const string ATTRIBUTE_TAG = "M2dNullable";
        private const string ATTRIBUTE_NAME = "M2dNullableAttribute";

        private static readonly SourceText attributeSource =
            Assembly.GetExecutingAssembly().LoadSource($"{ATTRIBUTE_NAME}.cs");
        private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
            "FG00020",
            "M2dNullableAttribute can only be applied to nullable value types",
            "Invalid type {0} for M2dNullableAttribute in {1}",
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
                IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
            var builder = new SourceBuilder(classSymbol.ContainingNamespace);
            builder.Imports.AddRange(new[] {
                "System.ComponentModel",
                "System",
                "System.Xml.Serialization",
            });
            builder.Classes.AddRange(classSymbol.ContainingTypes().Select(symbol => symbol.Name));
            builder.Classes.Add(classSymbol.Name);

            // create properties for each field
            builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

            return builder.Build();
        }

        private string ProcessField(GeneratorExecutionContext context, IFieldSymbol fieldSymbol,
                INamedTypeSymbol attribute) {
            AttributeData attributeData = fieldSymbol.GetAttribute(attribute);
            string attributeName = attributeData.GetValueOrDefault("Name", fieldSymbol.Name);

            var builder = new StringBuilder();
            builder.Append($@"
[XmlAttribute(""{attributeName}""), DefaultValue(null)]
public string _{attributeName} {{
    get => ");
            AddSerializer(context, builder, fieldSymbol);
            builder.Append(@"
    set => ");
            AddDeserializer(context, builder, fieldSymbol);
            builder.AppendLine(@"
}");

            return builder.ToString();
        }

        private void AddSerializer(GeneratorExecutionContext context, StringBuilder source, IFieldSymbol field) {
            if (!IsNullableValue(field)) {
                context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type,
                    field.ToDisplayString()));
                return;
            }

            source.Append($"{field.Name}?.ToString();");
        }

        private void AddDeserializer(GeneratorExecutionContext context, StringBuilder source, IFieldSymbol field) {
            if (!IsNullableValue(field)) {
                context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type,
                    field.ToDisplayString()));
                return;
            }

            string fieldName = $"{field.Name}";
            string valueType = field.Type.ToDisplayString().TrimEnd('?');
            source.Append(
                $"{fieldName} = {valueType}.TryParse(value, out {valueType} n) ? ({field.Type}) n : null;");
        }

        private static bool IsNullableValue(IFieldSymbol field) {
            return field.Type.IsValueType && field.NullableAnnotation == NullableAnnotation.Annotated;
        }
    }
}