using System;
using System.Collections.Generic;
using Microsoft.Azure.CosmosRepository;

namespace Website.Shared
{
    public class Post : Entity
    {
        public Post()
        {
            Id = string.Empty;
        }
        
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public List<TechTag> Tags { get; set; } = new();

        public bool IsPublished { get; set; }

        public string GistUrl { get; set; } = "";
        
        public string GistFile { get; set; } = "";  
        
        public int RenderedHeightInPixels { get; set; }
        
        public DateTime CreatedUtc { get; set; }
    }
}