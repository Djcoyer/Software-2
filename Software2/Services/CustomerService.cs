using Software2.Models.Exceptions;
using Software2.Repositories.Implementation;
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
        private AuthRepository _authRepository;

        public CustomerService(ICustomerRepository repository, AuthRepository authRepository)
        {
            _authRepository = authRepository;
            _repository = repository;
        }

        public List<customer> FindAllCustomers()
        {
            return _repository.FindAll().ToList();
        }

        public customer FindOne(int id)
        {
            var customer = _repository.FindOne(id);
            if (customer == null)
                throw new NotFoundException("Could not locate customer with specified ID");
            return customer;
        }

        public void Add(customer customer)
        {
            if (String.IsNullOrWhiteSpace(customer.customerName))
                throw new InvalidInputException("Must include name");
            customer.createdBy = "Devyn Coyer";
            customer.lastUpdateBy = "Devyn Coyer";
            _repository.Add(customer);
        }

        public void Update(customer customer, int customerId)
        { 
            customer.lastUpdate = DateTime.Now;
            customer.lastUpdateBy = _authRepository.Username;
            _repository.Update(customer, customerId);
        }

        public void Delete(int id)
        {
            FindOne(id);
            _repository.Delete(id);
        }
    }
}
