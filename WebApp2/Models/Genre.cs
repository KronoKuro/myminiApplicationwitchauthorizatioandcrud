using System;
using System.Collections.Generic;

namespace WebApp2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GenreMovie> GenreMovie { get; } = new List<GenreMovie>();

    }
}
