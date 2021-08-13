namespace Website.Shared
{
    public class TechTag : Entity
    {
        public Color Color { get; set; }
        public bool IsLight { get; set; }

        public TechTag(string id, Color color, bool isLight = true)
        {
            Id = id;
            Color = color;
            IsLight = isLight;
        }

        public TechTag() { }
    }
}