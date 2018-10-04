using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<country> FindAll();
        country FindOne(int id);
        country FindByName(string name);
        void Add(country country);
        void Update(country country, int id);
        void Delete(int id);
    }
}
