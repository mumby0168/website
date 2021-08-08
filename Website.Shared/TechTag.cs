namespace Website.Shared
{
    public record TechTag(string Name, Color Color, bool IsLight = true)
    {
        public string Name { get; } = Name;
        public Color Color { get; } = Color;
        public bool IsLight { get; } = IsLight;
    }
}