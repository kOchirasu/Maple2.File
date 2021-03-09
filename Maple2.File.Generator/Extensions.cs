using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator {
    internal static class Extensions {
        public static Compilation AddSource(this Compilation compilation, string source) {
            var options = (compilation as CSharpCompilation)?.SyntaxTrees[0].Options as CSharpParseOptions;
            SyntaxTree attributeSyntaxTree =
                CSharpSyntaxTree.ParseText(SourceText.From(source, Encoding.UTF8), options);
            return compilation.AddSyntaxTrees(attributeSyntaxTree);
        }

        public static AttributeData GetAttribute(this IFieldSymbol fieldSymbol, ISymbol attribute) {
            return fieldSymbol.GetAttributes()
                .SingleOrDefault(data => SymbolEqualityComparer.Default.Equals(data.AttributeClass, attribute));
        }

        public static IEnumerable<IFieldSymbol> Fields(this IEnumerable<FieldDeclarationSyntax> fields,
                Compilation compilation) {
            return fields.SelectMany(field => {
                SemanticModel model = compilation.GetSemanticModel(field.SyntaxTree);
                return field.Declaration.Variables
                    .Select(variable => ModelExtensions.GetDeclaredSymbol(model, variable) as IFieldSymbol);
            });
        }

        public static IEnumerable<IFieldSymbol> WithAttribute(this IEnumerable<IFieldSymbol> symbols,
                INamedTypeSymbol attributeSymbol) {
            return symbols.Where(symbol => symbol.GetAttribute(attributeSymbol) != null);
        }
    }
}