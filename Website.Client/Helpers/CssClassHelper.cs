using System;

namespace Website.Client.Helpers
{
    public static class CssClassHelper
    {
        public static string Class(params string[] strings) => String.Join(" ", strings);
    }
}