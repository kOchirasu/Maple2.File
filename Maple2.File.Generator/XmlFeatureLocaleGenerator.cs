using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    [Generator]
    public class XmlFeatureLocaleGenerator : XmlGenerator {
        private static readonly SourceText featureLocaleFilterSource =
            Assembly.GetExecutingAssembly().LoadSource("FeatureLocaleFilter.cs");
        private static readonly SourceText attributeSource =
            Assembly.GetExecutingAssembly().LoadSource("M2dFeatureLocaleAttribute.cs");
        private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
            "FG00040",
            "M2dFeatureLocaleAttribute can only be applied to IFeatureLocale derived types",
            "Invalid type {0} for M2dFeatureLocaleAttribute in {1}",
            "Maple2.File.Generator",
            DiagnosticSeverity.Error,
            true
        );
        private static readonly DiagnosticDescriptor nameError = new DiagnosticDescriptor(
            "FG00041",
            "M2dFeatureLocaleAttribute can only be applied to a field name that begins with '_'",
            "Unable to determine property name from field name {0}",
            "Maple2.File.Generator",
            DiagnosticSeverity.Error,
            true
        );

        public XmlFeatureLocaleGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dFeatureLocale") { }

        public override void Execute(GeneratorExecutionContext context) {
            context.AddSource("FeatureLocaleFilter", featureLocaleFilterSource);

            base.Execute(context);
        }

        protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
                IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
            var builder = new SourceBuilder(@class.ContainingNamespace);
            builder.Imports.AddRange(new[] {
                "System.Collections.Generic",
                "System.Linq",
                "System.Xml.Serialization",
                "M2dXmlGenerator",
            });
            builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
            builder.Classes.Add(@class.Name);

            // create properties for each field
            builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

            return builder.Build();
        }

        private string ProcessField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
            if (HasFeatureLocale(field.Type)) {
                return ProcessTypeField(context, field, attribute);
            }

            INamedTypeSymbol listSymbol = context.Compilation.GetTypeByMetadataName("System.Collections.Generic.IList`1");
            if (HasFeatureLocaleList(field.Type as INamedTypeSymbol, listSymbol)) {
                return ProcessListField(context, field, attribute);
            }

            context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
            return string.Empty;
        }

        private string ProcessTypeField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
            AttributeData attributeData = field.GetAttribute(attribute);
            string propertyName = attributeData.GetValueOrDefault("Name", field.Name.TrimStart('_'));
            if (string.IsNullOrWhiteSpace(propertyName) || propertyName == field.Name) {
                context.ReportDiagnostic(Diagnostic.Create(nameError, Location.None, field.ToDisplayString()));
                return string.Empty;
            }

            string type = field.Type.ToDisplayString();

            return $@"
private List<{type}> {field.Name}_;
public {type} {propertyName} => {field.Name}_.FirstFeatureLocale();

[XmlElement(""{propertyName}"")]
public List<{type}> _{field.Name} {{
    get => {field.Name}_;
    set => {field.Name}_ = value;
}}";
        }

        private string ProcessListField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
            AttributeData attributeData = field.GetAttribute(attribute);
            string propertyName = attributeData.GetValueOrDefault("Name", field.Name.TrimStart('_'));
            if (string.IsNullOrWhiteSpace(propertyName) || propertyName == field.Name) {
                context.ReportDiagnostic(Diagnostic.Create(nameError, Location.None, field.ToDisplayString()));
                return string.Empty;
            }

            string type = field.Type.ToDisplayString();
            string concreteList = type.Replace("IList", "List");

            string groupSelector = attributeData.GetValueOrDefault("Selector", string.Empty);
            string groupBy = string.IsNullOrEmpty(groupSelector) ? string.Empty : $"select => select.{groupSelector}";

            return $@"
private {concreteList} {field.Name}_;
public {type} {propertyName} => {field.Name}_.FeatureLocale({groupBy}).ToList();

[XmlElement(""{propertyName}"")]
public {concreteList} _{field.Name} {{
    get => {field.Name}_;
    set => {field.Name}_ = value;
}}";
        }

        private static bool HasFeatureLocale(ITypeSymbol type) {
            if (type == null) {
                return false;
            }

            const string interfaceName = "IFeatureLocale";
            // For some reason, interface is set as BaseType when it's the only parent.
            return interfaceName.Equals(type.BaseType?.Name)
                   || type.AllInterfaces.Any(@interface => interfaceName.Equals(@interface.Name));
        }

        private static bool HasFeatureLocaleList(INamedTypeSymbol container, INamedTypeSymbol listSymbol) {
            if (container == null || listSymbol == null) {
                return false;
            }

            bool isList = new[] { container }.Concat(container.AllInterfaces)
                .Any(symbol => SymbolEqualityComparer.Default.Equals(symbol.OriginalDefinition, listSymbol));
            return isList && container.TypeArguments.Any(HasFeatureLocale);
        }
    }
}
