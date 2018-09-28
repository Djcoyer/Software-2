using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<country> findAll();
        country findOne(int id);
        country findByName(string name);
        void add(country country);
        void update(country country, int id);
        void delete(int id);
    }
}
