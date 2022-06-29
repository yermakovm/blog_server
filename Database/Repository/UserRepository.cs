using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repository
{
    public class UserRepository : IRepository<User>
    {
        private BlogContext db;

        public UserRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(Guid itemId)
        {
            return db.Users.Find(itemId);
        }

        public void Create(User newItem)
        {
            db.Users.Add(newItem);
        }

        public void Update(Guid itemId)
        {
            db.Entry(itemId).State = EntityState.Modified;
        }

        public void Delete(Guid itemId)
        {
            User User = db.Users.Find(itemId);
            if (User != null)
                db.Users.Remove(User);
        }
    }
}