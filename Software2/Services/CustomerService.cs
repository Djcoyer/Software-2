using Software2.Models;
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
        private AddressService addressService;

        public CustomerService(ICustomerRepository repository, AuthRepository authRepository, AddressService addressService)
        {
            _authRepository = authRepository;
            _repository = repository;
            this.addressService = addressService;
        }

        public List<customer> FindAll()
        {
            return _repository.FindAll().ToList();
        }

        public IEnumerable<CustomerAggregate> FindAllAggregates()
        {
            var customers = FindAll();
            var addressAggregates = addressService.FindAllAggregates();
            var customerAggregates = new List<CustomerAggregate>();

            foreach(var customer in customers)
            {
                var addressId = customer.addressId;
                var addressAggregate = addressAggregates.FirstOrDefault(a => a.AddressId == addressId);
                customerAggregates.Add(new CustomerAggregate()
                {
                    Id = customer.customerId,
                    AddressId = customer.addressId,
                    Address1 = addressAggregate.Address1,
                    Address2 = addressAggregate.Address2,
                    City = addressAggregate.CityName,
                    CityId = addressAggregate.CityId,
                    Country = addressAggregate.CountryName,
                    CountryId = addressAggregate.CountryId,
                    CustomerName = customer.customerName,
                    Phone = addressAggregate.Phone,
                    PostalCode = addressAggregate.PostalCode
                });
            }

            return customerAggregates;
        }

        public customer FindOne(int id)
        {
            var customer = _repository.FindOne(id);
            if (customer == null)
                throw new NotFoundException("Could not locate customer with specified ID");
            return customer;
        }

        public void Add(CustomerAggregate aggregate)
        {
            if (String.IsNullOrWhiteSpace(aggregate.CustomerName))
                throw new InvalidInputException("Must include name");

            var date = DateTime.Now;
            _repository.Add(new customer()
            {
                active = true,
                addressId = aggregate.AddressId,
                createDate = date,
                lastUpdate = date,
                createdBy = _authRepository.Username,
                lastUpdateBy = _authRepository.Username,
                customerName = aggregate.CustomerName,
            });
        }

        public void Update(CustomerAggregate aggregate, int customerId)
        {
            var existingCustomer = FindOne(customerId);

            existingCustomer.lastUpdate = DateTime.Now.ToUniversalTime();
            existingCustomer.lastUpdateBy = _authRepository.Username;
            existingCustomer.customerName = aggregate.CustomerName;
            existingCustomer.addressId = aggregate.AddressId;

            _repository.Update(existingCustomer, customerId);
        }

        public void Delete(int id)
        {
            FindOne(id);
            _repository.Delete(id);
        }
    }
}
