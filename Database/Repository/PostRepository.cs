using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repository
{
    public class PostRepository : IRepository<Post>
    {

        private BlogContext db;

        public PostRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public Post Get(Guid itemId)
        {
            return db.Posts.Find(itemId);
        }

        public void Create(Post newItem)
        {
            db.Posts.Add(newItem);
        }

        public void Update(Guid itemId)
        {
            db.Entry(itemId).State = EntityState.Modified;
        }

        public void Delete(Guid itemId)
        {
            Post post = db.Posts.Find(itemId);
            if (post != null)
                db.Posts.Remove(post);
        }
    }
}