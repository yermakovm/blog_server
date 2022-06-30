using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } 

        public string Content { get; set; }

        public string Title { get; set; }

        public ICollection<Tag> Tags { get; set; } 

        public Category Category { get; set; }

        public string AuthorName { get; set; }

        public DateTime Date { get; set; }

    }
}