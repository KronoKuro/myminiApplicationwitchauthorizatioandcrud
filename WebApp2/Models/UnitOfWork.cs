using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models.Repositories;

namespace WebApp2.Models
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext db;
        public UnitOfWork(ApplicationContext context)
        {
            this.db = context;
        }

        public UnitOfWork()
        {

        }

        private NewsRepository newsRepoitory;
        private MovieRepository movieRepository;

        public NewsRepository News
        {
            get
            {
                if (newsRepoitory == null)
                    newsRepoitory = new NewsRepository(db);
                return newsRepoitory;
            }
        }

        public MovieRepository Movies
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository(db);
                return movieRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
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
