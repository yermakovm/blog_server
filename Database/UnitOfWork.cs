using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Database.Repository;

namespace Blog.Database
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private BlogContext db = new BlogContext();
        private PostRepository postRepository;
        private UserRepository userRepository;


        public PostRepository Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }

                public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}