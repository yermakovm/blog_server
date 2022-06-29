using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; } 

        public string Content { get; set; }

        public string Title { get; set; }

        public List<string> TagNames { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }
    }
}