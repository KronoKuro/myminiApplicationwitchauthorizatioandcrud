using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp2.Models.Abstract;

namespace WebApp2.Models.Repositories
{
    public class MovieRepository : IMovieRepository
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
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            //db.Movies.Update(movie);
            //db.SaveChanges();
            
            var local = db.Set<Movie>().Local.FirstOrDefault(entry => entry.Id.Equals(movie.Id));

            // check if local is not null 
            if (local != null) // I'm using a extension method
            {
                // detach
                db.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            db.Entry(movie).State = EntityState.Modified;

            // save 
            db.SaveChanges();
        }


        public void Delete(Guid id)
        {
            Movie movie = db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }


    }
}
