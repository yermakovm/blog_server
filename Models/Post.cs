using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public Guid Id { get; set; } 

        public string Content { get; set; }

        public string Title { get; set; }

        public List<Tag> Tags { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }

        public DateTime Date { get; set; }

    }
}