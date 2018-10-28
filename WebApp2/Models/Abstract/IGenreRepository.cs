using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApp2.Models.Abstract
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        IEnumerable GetById(Guid id);
        void Create(Genre item);
        void Update(Genre item);
        void Delete(Guid id);
    }
}
