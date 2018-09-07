using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<customer> FindAll();
        customer FindOne(int id);
        void Update(customer customer, int id);
        void Add(customer customer);
        void Delete(int id);

    }
}
