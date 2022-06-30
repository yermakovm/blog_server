using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database.Repository
{
    public class CategoryRepository : IRepository<Category>
    {

        private BlogContext db;

        public CategoryRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(Guid itemId)
        {
            return db.Categories.Find(itemId);
        }

        public void Create(Category newItem)
        {
            db.Categories.Add(newItem);
        }

        public void Update(Guid itemId)
        {
            db.Entry(itemId).State = EntityState.Modified;
        }

        public void Delete(Guid itemId)
        {
            Category Category = db.Categories.Find(itemId);
            if (Category != null)
                db.Categories.Remove(Category);
        }
    }
}