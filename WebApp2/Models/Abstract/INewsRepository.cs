using System.Collections.Generic;

namespace WebApp2.Models.Abstract
{
    public interface INewsRepository
    {

        IEnumerable<New> GetAll();
        New Get(int id);
        void Create(New item);
        void Update(New item);
        void Delete(int id);
    }
}
