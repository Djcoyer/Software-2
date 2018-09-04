using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    class UserRepository : IUserRepository
    {
        public CalendarEntities _db { private get; set; }
        
        public UserRepository(CalendarEntities db)
        {
            this._db= db;
        }
        public void AddUser(user user)
        {
            this._db.users.Add(user);
            this._db.SaveChanges();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<user> FindAll()
        {
            return this._db.users.AsEnumerable();
        }

        public user FindById(int id)
        {
            return this._db.users.Find(id);
        }

        public user FindByUsername(string username)
        {
            return this._db.users.FirstOrDefault(p => p.userName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
        }

        public void UpdateUser(user user, int id)
        {
            throw new NotImplementedException();
        }
    }
}
