using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    }
}