using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
