using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.Repository;

namespace Blog.Database
{
    public interface IUnitOfWork
    {
        void Save();
        PostRepository Posts { get; }
        UserRepository Users { get; }
    }
}