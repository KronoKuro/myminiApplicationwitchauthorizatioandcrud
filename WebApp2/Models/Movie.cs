using System;
using System.Collections.Generic;

namespace WebApp2.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        /*public virtual ICollection<Genre> Genres { get; set; }

        public Movie()
        {
            Genres = new List<Genre>();
        }*/
    }
}
