using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApp2.Models.Abstract;

namespace WebApp2.Models.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private ApplicationContext db;
        public NewsRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<New> GetAll()
        {
            return db.News;
        }

        public New Get(int id)
        {
            return db.News.FirstOrDefault(m => m.Id == id);
        }

        public void Create(New movie)
        {
            db.News.Add(movie);
            db.SaveChanges();
        }

        public void Update(New news)
        {
            //db.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //db.News.Update(news);
            var local = db.Set<New>().Local.FirstOrDefault(entry => entry.Id.Equals(news.Id));

            // check if local is not null 
            if (local != null) // I'm using a extension method
            {
                // detach
                db.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            db.Entry(news).State = EntityState.Modified;

            // save 
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            New movie = db.News.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                db.News.Remove(movie);
                db.SaveChanges();
            }
        }

    }
}
