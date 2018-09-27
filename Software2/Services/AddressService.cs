using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AddressService
    {
        private IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<address> FindAll()
        {
            return _repository.FindAll();
        }

        public address FindOne(int addressId)
        {
            return _repository.FindOne(addressId);
        }
    }
}
