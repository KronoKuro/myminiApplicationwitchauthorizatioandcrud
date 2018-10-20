using System;
using System.Collections.Generic;

namespace WebApp2.Models.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie Get(Guid id);
        void Create(Movie item);
        void Update(Movie item);
        void Delete(Guid id);
    }
}
