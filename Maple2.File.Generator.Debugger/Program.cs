// See https://aka.ms/new-console-template for more information

using Maple2.File.Generator.Debugger;

Console.WriteLine("Hello, World!");
var d = new BackingField();
Console.WriteLine($"BEFORE: {d.duplicate}");
d.Field = "updated";
Console.WriteLine($"AFTER: {d.duplicate}");

Enum.Parse<TestEnum>("A");
string s = TestEnum.A.ToString();