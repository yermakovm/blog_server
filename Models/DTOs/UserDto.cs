using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DTOs
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}