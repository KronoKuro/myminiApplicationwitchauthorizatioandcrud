using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp2.Models
{
    public class GenreMovie
    {
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
