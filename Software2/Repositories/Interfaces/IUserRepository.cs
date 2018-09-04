using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<user> FindAll();
        user FindById(int id);
        void AddUser(user user);
        void UpdateUser(user user, int id);
        bool DeleteUser(int id);
        user FindByUsername(string username);
    }
}
