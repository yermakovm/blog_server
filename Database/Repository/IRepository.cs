using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Database.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid itemId);
        void Create(T newItem);
        void Update(Guid itemId);
        void Delete(Guid itemId);
    }
}