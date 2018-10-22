using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private ApplicationContext db;
        public MovieRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public Movie Get(Guid id)
        {
            return db.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
        }
        
        public void Update(Movie movie)
        {
            if(movie != null)
            { 
               db.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Delete(Guid id)
        {
            Movie movie = db.Movies.FirstOrDefault(m => m.Id == id);
            if(movie != null)
            {
                db.Movies.Remove(movie);
            }
        }

        public int Count(Guid id)
        {
            var elementCount = db.Movies.Count(m => m.Id == id);
            if(elementCount > 0)
            {
                return elementCount;
            }
            else
            {
                return 0;
            }
        }
    }
}
