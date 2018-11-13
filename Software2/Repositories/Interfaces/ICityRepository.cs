using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<city> FindAll();
        city FindOne(int id);
        void Add(city city);
        void Update(city city, int id);
        void Delete(int id);
        IEnumerable<city> FindByName(string name);
    }
}
