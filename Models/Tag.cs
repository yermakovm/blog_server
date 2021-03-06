using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } 
    }
}