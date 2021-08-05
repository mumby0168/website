using System;

namespace Website.Shared
{
    public class Class1
    {
    }

    public record Test(string Id)
    {
        public string Id { get; } = Id;
    }
}