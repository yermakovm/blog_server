using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repository
{
    public class TagRepository : IRepository<Tag>
    {

        private BlogContext db;

        public TagRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public Tag Get(Guid itemId)
        {
            return db.Tags.Find(itemId);
        }

        public void Create(Tag newItem)
        {
            db.Tags.Add(newItem);
        }

        public void Update(Guid itemId)
        {
            db.Entry(itemId).State = EntityState.Modified;
        }

        public void Delete(Guid itemId)
        {
            Tag tag = db.Tags.Find(itemId);
            if (tag != null)
                db.Tags.Remove(tag);
        }
    }
}