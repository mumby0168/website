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
}