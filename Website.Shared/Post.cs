using System;
using System.Collections.Generic;

namespace Website.Shared
{
    public class Post
    {
        public string Id { get; set; } = "";

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public List<TechTag> Tags { get; set; } = new();

        public string GistUrl { get; set; } = "";
        
        public int RenderedHeightInPixels { get; set; }
        
        public DateTime CreatedUtc { get; set; }
    }
}