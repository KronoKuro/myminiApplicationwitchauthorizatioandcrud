using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        Genre Get(Guid id);
        void Create(Genre item);
        void Update(Genre item);
        void Delete(Guid id);
    }
}
