using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Models.Abstract;

namespace WebApp2.Models.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationContext db;
        public GenreRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Genre item)
        {
            db.Genres.Add(item);
            db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Genre genre = db.Genres.FirstOrDefault(g => g.Id == id);
            if(genre != null)
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }

        public Genre Get(Guid id)
        {
            return db.Genres.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public void Update(Genre item)
        {
            var local = db.Set<Genre>().FirstOrDefault(entry => entry.Id.Equals(item.Id));
            if(local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
