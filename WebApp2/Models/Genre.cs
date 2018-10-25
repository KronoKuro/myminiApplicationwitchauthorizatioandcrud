using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        /*public ICollection<Movie> Movies { get; set; }

        public Genre()
        {
            Movies = new List<Movie>();
        }*/
    }
}
