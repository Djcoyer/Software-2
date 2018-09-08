using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class CustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<customer> FindAllCustomers()
        {
            return _repository.FindAll().ToList();
        }

        public customer FindOne(int id)
        {
            return _repository.FindOne(id);
        }

        public void Add(customer customer)
        {
            customer.createdBy = "Devyn Coyer";
            customer.lastUpdateBy = "Devyn Coyer";
            _repository.Add(customer);
        }

        public void Update(customer customer, int customerId)
        { 
            customer.lastUpdate = DateTime.Now;
            customer.lastUpdateBy = "Devyn Coyer";
            _repository.Update(customer, customerId);
        }
    }
}
