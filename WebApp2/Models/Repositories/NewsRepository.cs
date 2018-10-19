using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2.Models.Repositories
{
    public class NewsRepository : IRepository<New>
    {
        private ApplicationContext db;

        public NewsRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(New item)
        {
            db.News.Add(item);
        }

        public void Update(New item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public New Get(Guid id)
        {
            return db.News.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<New> GetAll()
        {
            return db.News;
        }

        public void Delete(Guid id)
        {
            New itemNews = db.News.FirstOrDefault(n => n.Id == id);
            if(itemNews != null)
            {
                db.News.Remove(itemNews);
            }
        }

        public int Count(Guid id)
        {
            var count = db.News.Count(n => n.Id == id);
            if(count > 0)
            {
                return count;
            }else
            {
                return 0;
            }
        }

    }
}
