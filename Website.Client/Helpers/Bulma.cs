using Website.Shared;

namespace Website.Client.Helpers
{
    public static class Bulma
    {
        internal static class Colors
        {
            public static string Is(Color color, bool isLight) 
                => $@"is-{color.ToString().ToLower()} {(isLight ? "is-light" : "")}";
        
            public static string HasBackground(Color color, bool isLight) 
                => $@"has-background-{color.ToString().ToLower()} {(isLight ? "is-light" : "")}";
        
            public static string Text(Color color, bool isLight) 
                => $@"has-text-{color.ToString().ToLower()} {(isLight ? "is-light" : "")}";
        }
        
    }
}