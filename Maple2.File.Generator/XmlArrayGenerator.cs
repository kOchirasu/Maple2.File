using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    [Generator]
    public class XmlArrayGenerator : XmlGenerator {
        private static readonly SourceText attributeSource =
            Assembly.GetExecutingAssembly().LoadSource("M2dArrayAttribute.cs");
        private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
            "FG00010",
            "M2dArrayAttribute can only be applied to value array types",
            "Invalid type {0} for M2dArrayAttribute in {1}",
            "Maple2.File.Generator",
            DiagnosticSeverity.Error,
            true
        );

        public XmlArrayGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dArray") { }

        protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
                IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
            var builder = new SourceBuilder(@class.ContainingNamespace);
            builder.Imports.AddRange(new[] {
                "System",
                "System.Xml.Serialization",
            });
            builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
            builder.Classes.Add(@class.Name);

            // create properties for each field
            builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

            return builder.Build();
        }

        private string ProcessField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
            if (!(field.Type is IArrayTypeSymbol)) {
                context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
            }

            AttributeData attributeData = field.GetAttribute(attribute);
            string xmlAttributeName = attributeData.GetValueOrDefault("Name", field.Name);
            char delimiter = attributeData.GetValueOrDefault<char>("Delimiter", ',');

            var source = new StringBuilder();
            source.Append($@"
[XmlAttribute(""{xmlAttributeName}"")]
public string _{xmlAttributeName} {{
    get {{
");
            AddSerializer(source, field, delimiter);
            source.Append(@"
    }
    set {");
            AddDeserializer(source, field, delimiter);
            source.AppendLine(@"
    }
}");
            return source.ToString();
        }

        private void AddSerializer(StringBuilder source, IFieldSymbol field,
                char delimiter) {
            string fieldName = $"this.{field.FieldName()}";
            source.Append($"return {fieldName} != null ? string.Join('{delimiter}', {fieldName}) : null;");
        }

        private void AddDeserializer(StringBuilder source, IFieldSymbol field,
                char delimiter) {
            var arrayType = field.Type as IArrayTypeSymbol;

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