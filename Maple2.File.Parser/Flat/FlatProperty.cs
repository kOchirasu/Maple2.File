namespace Maple2.File.Parser.Flat {
    public class FlatProperty {
        public string Name { get; init; }
        public string Type { get; init; }
        public string Id { get; init; }
        public string Value { get; init; }

        public override string ToString() {
            return $"{Type}\t{Name}: \"{Value}\"";
        }
    }
}