using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<city> findAll();
        city findOne(int id);
        void add(city city);
        void update(city city, int id);
        void delete(int id);
        IEnumerable<city> findByName(string name);
    }
}
