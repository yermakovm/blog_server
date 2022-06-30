using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Database
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public string DbPath { get; }

        public BlogContext()
        {
            DbPath = "BlogDb";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;");
    }
}
