namespace Maple2.File.Generator.Debugger;

public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Hello, World!");
        var d = new BackingField();
        Console.WriteLine($"BEFORE: {d.duplicate}");
        d.Field = "updated";
        Console.WriteLine($"AFTER: {d.duplicate}");

        Enum.Parse<TestEnum>("A");
        string s = TestEnum.A.ToString();
    }
}
