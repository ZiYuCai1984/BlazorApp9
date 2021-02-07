using System;

namespace ZiYuCai1984.Blog.DocumentIndex.Proxy.Abstractions
{
    public class Document
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreateTime { get; set; }

        public int Order { get; set; }

        public string Path { get; set; } = string.Empty;

        public string[] Keywords { get; set; } = new string[0];
        
        public bool IsLocked { get; set; }
        
        public string ContentRaw { get; set; } = string.Empty;
        
        public string Summary { get; set; } = string.Empty;


    }
}