using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } 
    }
}