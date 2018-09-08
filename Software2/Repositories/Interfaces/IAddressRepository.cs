using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<address> FindAll();
        address FindOne(int id);
        void Add(address address);
        void Update(address address, int id);
        void Delete(int id);
    }
}
