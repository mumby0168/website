using Website.Shared;

namespace Client.Helpers
{
    public static class ColorHelpers
    {
        public static string Class(Color color, bool isLight) 
            => $@"is-{color.ToString().ToLower()} {(isLight ? "is-light" : "")}";
    }
}