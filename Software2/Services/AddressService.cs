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
    public class AddressService
    {
        private IAddressRepository _repository;
        private CityService cityService;
        private CountryService countryService;
        private AuthRepository _authRepository;

        public AddressService(IAddressRepository repository, CityService cityService, CountryService countryService, AuthRepository authRepository)
        {
            _authRepository = authRepository;
            _repository = repository;
            this.cityService = cityService;
            this.countryService = countryService;
        }

        public IEnumerable<address> FindAll()
        {
            return _repository.FindAll();
        }

        public address FindOne(int addressId)
        {
            return _repository.FindOne(addressId);
        }

        public void addNewAddress(AddressAggregate addressAggregate)
        {
            ValidateAddressAggregate(addressAggregate);
            try
            {
                var existingAddress = FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                //Already exists
                throw new DataIntegrityViolationException("Address already exists");
            }
            catch (NotFoundException e)
            {

                try
                {
                    var country = countryService.findByName(addressAggregate.CountryName);
                    addressAggregate.CountryId = country.countryId;
                }
                catch (NotFoundException ex)
                {
                    countryService.add(new country()
                    {
                        country1 = addressAggregate.CountryName
                    });

                    var country = countryService.findByName(addressAggregate.CountryName);
                    addressAggregate.CountryId = country.countryId;
                }


                try
                {
                    var city = cityService.findByNameAndCountryId(addressAggregate.CityName, addressAggregate.CountryId);
                    addressAggregate.CityId = city.cityId;
                }
                catch (NotFoundException ex)
                {
                    cityService.add(new city()
                    {
                        countryId = addressAggregate.CountryId,
                        city1 = addressAggregate.CityName
                    });

                    var city = cityService.findByNameAndCountryId(addressAggregate.CityName, addressAggregate.CountryId);
                    addressAggregate.CityId = city.cityId;
                }

                _repository.Add(new address()
                {
                    cityId = addressAggregate.CityId,
                    address1 = addressAggregate.Address1,
                    address2 = addressAggregate.Address2,
                    createDate = DateTime.Now,
                    lastUpdate = DateTime.Now,
                    createdBy = _authRepository.Username,
                    lastUpdateBy = _authRepository.Username,
                    phone = addressAggregate.Phone,
                    postalCode = addressAggregate.PostalCode
                });
            }
        }

        public address FindByAddressAndPostalCode(string address1, string address2, string postalCode)
        {
            if (String.IsNullOrEmpty(address1) || String.IsNullOrEmpty(postalCode))
                throw new InvalidInputException("Must supply address and postal code");
            var addresses = _repository.FindAll();
            var existingAddress = addresses.Where(a => a.address1.Equals(address1, StringComparison.CurrentCultureIgnoreCase)
            && a.address2.Equals(address2, StringComparison.CurrentCultureIgnoreCase) && a.postalCode.Equals(postalCode)).FirstOrDefault();
            if (existingAddress == null)
                throw new NotFoundException("Could not find specified address");
            return existingAddress;
        }

        private void ValidateAddressAggregate(AddressAggregate addressAggregate)
        {
            if (String.IsNullOrEmpty(addressAggregate.CityName))
                throw new InvalidInputException("Must include city value");
            if (String.IsNullOrEmpty(addressAggregate.CountryName))
                throw new InvalidInputException("Must include country value");
            if (String.IsNullOrEmpty(addressAggregate.Address1))
                throw new InvalidInputException("Must include address value");
            if (String.IsNullOrEmpty(addressAggregate.PostalCode))
                throw new InvalidInputException("Must include postal code value");
            if (String.IsNullOrEmpty(addressAggregate.Phone))
                throw new InvalidInputException("Must include phone number value");
        }

    }
}
