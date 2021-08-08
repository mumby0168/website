namespace Website.Shared
{
    public record ProjectLink(string Url, string Text)
    {
        public string Url { get; } = Url;
        public string Text { get; } = Text;
    }
}