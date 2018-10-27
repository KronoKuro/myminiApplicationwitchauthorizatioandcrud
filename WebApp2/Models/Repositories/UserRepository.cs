using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp2.Models.Abstract;

namespace WebApp2.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext db;
        public UserRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            User item = db.Users.FirstOrDefault(g => g.Id == id);
            if (item != null)
            {
                db.Users.Remove(item);
                db.SaveChanges();
            }
        }

        public User Get(string id)
        {
            return db.Users.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            var local = db.Set<User>().FirstOrDefault(entry => entry.Id.Equals(item.Id));
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
