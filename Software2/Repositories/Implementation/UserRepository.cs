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
            _db.users.Add(user);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _db.users.Remove(_db.users.Find(id));
        }

        public IEnumerable<user> FindAll()
        {
            return _db.users.AsEnumerable();
        }

        public user FindById(int id)
        {
            return _db.users.Find(id);
        }

        public user FindByUsername(string username)
        {
            return _db.users.FirstOrDefault(p => p.userName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
        }

        public void UpdateUser(user user, int id)
        {
            var _user = FindById(id);
            _user = user;
            _db.SaveChanges();
        }
    }
}
