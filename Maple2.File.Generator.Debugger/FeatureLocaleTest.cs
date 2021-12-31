using M2dXmlGenerator;

namespace Maple2.File.Generator.Debugger;

public enum TestEnum {
    A,
    B,
}

public interface Test {
    string Str { get; }
}

public class FeatureLocaleTest : HashSet<string>, IEnumerable<string> {

}

public partial class AnotherTest : Test, IFeatureLocale {
    public string hello = "hello";

    public string _test = string.Empty;

    public string Str => _test;

    public partial class NestedTest : IFeatureLocale {
        public string nested = "nested";
    }
}

public class BackingField {
    public string duplicate = string.Empty;

    private string _field;
    public string Field {
        get => _field;
        set {
            _field = value;
            Console.WriteLine($"DURING VALUE: {value}");
            duplicate = value;
            Console.WriteLine($"DURING DUPLICATE: {duplicate}");
        }
    }
}