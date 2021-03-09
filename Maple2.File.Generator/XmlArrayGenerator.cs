using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    [Generator]
    public class XmlArrayGenerator : ISourceGenerator {
        private const string ATTRIBUTE_TEXT = @"
using System;
using System.Xml.Serialization;

namespace M2dXmlGenerator {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class M2dArrayAttribute : XmlIgnoreAttribute {
        public char Delimiter { get; set; } = ',';
    }
}
";

        public void Initialize(GeneratorInitializationContext context) {
            // Register a syntax receiver that will be created for each generation pass
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context) {
            // Register the attribute source
            context.AddSource("M2dArrayAttribute", SourceText.From(ATTRIBUTE_TEXT, Encoding.UTF8));

            if (!(context.SyntaxReceiver is SyntaxReceiver receiver)) {
                return;
            }

            Compilation compilation = context.Compilation.AddSource(ATTRIBUTE_TEXT);
            INamedTypeSymbol attributeSymbol =
                compilation.GetTypeByMetadataName("M2dXmlGenerator.M2dArrayAttribute");

            IEnumerable<IGrouping<ISymbol, IFieldSymbol>> classGroups = receiver.Fields
                .Fields(compilation)
                .WithAttribute(attributeSymbol)
                .GroupBy(field => field.ContainingType, SymbolEqualityComparer.Default);

            foreach (IGrouping<ISymbol, IFieldSymbol> group in classGroups) {
                string classSource = ProcessClass(group.Key, group, attributeSymbol);
                string hintName = $"{group.Key.ContainingNamespace.Name}_{group.Key.Name}_M2dArray.cs";
                context.AddSource(hintName, SourceText.From(classSource, Encoding.UTF8));
            }
        }

        private string ProcessClass(ISymbol classSymbol, IEnumerable<IFieldSymbol> fields, ISymbol attributeSymbol) {
            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default)) {
                return null; //TODO: issue a diagnostic that it must be top level
            }

            string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            // begin building the generated source
            var source = new StringBuilder();
            source.AppendLine("using System;");
            source.AppendLine("using System.Xml.Serialization;");
            source.Append($@"
namespace {namespaceName} {{
    public partial class {classSymbol.Name} {{
");

            // create properties for each field
            foreach (IFieldSymbol fieldSymbol in fields) {
                ProcessField(source, fieldSymbol, attributeSymbol);
            }

            // Close namespace and class
            source.AppendLine("}}");
            return source.ToString();
        }

        private void ProcessField(StringBuilder source, IFieldSymbol fieldSymbol, ISymbol attributeSymbol) {
            // get the AutoNotify attribute from the field, and any associated data
            AttributeData attributeData = fieldSymbol.GetAttribute(attributeSymbol);
            TypedConstant delimiterProperty = attributeData.NamedArguments
                .SingleOrDefault(pair => pair.Key == "Delimiter").Value;
            char delimiter = (delimiterProperty.Value as char?) ?? ',';

            source.Append($@"
[XmlAttribute(""{fieldSymbol.Name}"")]
public string _{fieldSymbol.Name} {{
    get {{
");
            AddSerializer(source, fieldSymbol, delimiter);
            source.Append(@"
    }
    set {");
            AddDeserializer(source, fieldSymbol, delimiter);
            source.AppendLine(@"
    }
}");
        }

        private void AddSerializer(StringBuilder source, IFieldSymbol fieldSymbol, char delimiter) {
            if (!(fieldSymbol.Type is IArrayTypeSymbol)) {
                source.Append($"throw new Exception(\"Invalid type: {fieldSymbol.Type}\");");
                return;
            }

            string fieldName = fieldSymbol.Name;
            source.Append($"return {fieldName} != null ? string.Join('{delimiter}', {fieldName}) : null;");
        }

        private void AddDeserializer(StringBuilder source, IFieldSymbol fieldSymbol, char delimiter) {
            if (!(fieldSymbol.Type is IArrayTypeSymbol arrayType)) {
                source.Append($"throw new Exception(\"Invalid type: {fieldSymbol.Type}\");");
                return;
            }

            string fieldName = fieldSymbol.Name;
            source.Append($@"
string[] split = value.Split('{delimiter}', StringSplitOptions.RemoveEmptyEntries);
{fieldName} = new {arrayType.ElementType}[split.Length];
for (int i = 0; i < split.Length; i++) {{
    ");

            if (arrayType.ElementType.IsValueType) {
                source.AppendLine($@"{fieldName}[i] = {arrayType.ElementType}.Parse(split[i].Trim());");
            } else {
                source.AppendLine($@"{fieldName}[i] = split[i].Trim();");
            }

            source.Append('}');
        }

        private class SyntaxReceiver : ISyntaxReceiver {
            public List<FieldDeclarationSyntax> Fields { get; } = new List<FieldDeclarationSyntax>();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode) {
                // any field with at least one attribute is a candidate for property generation
                if (syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax
                    && fieldDeclarationSyntax.AttributeLists.Count > 0) {
                    Fields.Add(fieldDeclarationSyntax);
                }
            }
        }
    }
}