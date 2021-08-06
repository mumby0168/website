using System;
using System.Collections.Generic;

namespace Website.Shared
{
    public class Project
    {
        public string Id { get; set; } = "";

        public string Title { get; set; } = "";

        public string Kind { get; set; } = "";

        public string Description { get; set; } = "";

        public string ImagePath { get; set; } = "";

        public DateTime StartedAt { get; set; } 
        
        public ProjectLink? Link { get; set; }

        public List<TechTag> Tags { get; set; } = new();
    }

    public record ProjectLink(string Url, string Text)
    {
        public string Url { get; } = Url;
        public string Text { get; } = Text;
    }
    
    public enum Color
    {
        Info,
        Primary,
        Link,
        Success,
        Light,
        White,
        Black,
        Dark,
        Warning,
        Danger,
    }
    
    public record TechTag(string Id, string Name, Color Color, bool IsLight = true)
    {
        public string Name { get; } = Name;
        public string Id { get; } = Id;
        public Color Color { get; } = Color;
        public bool IsLight { get; } = IsLight;
    }
}