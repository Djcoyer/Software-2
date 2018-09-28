using Software2.Models;
using Software2.Models.Exceptions;
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

        public AddressService(IAddressRepository repository, CityService cityService, CountryService countryService)
        {
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
            if (String.IsNullOrEmpty(addressAggregate.CityName))
                throw new Exception("");
            if (String.IsNullOrEmpty(addressAggregate.CountryName))
                throw new Exception("");

            try
            {
                var existingAddress = FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                //Already exists
                throw new Exception("");
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
                    //createdBy = authRepository.Username,
                    //lastUpdateBy = authRepository.Username,
                    phone = addressAggregate.Phone,
                    postalCode = addressAggregate.PostalCode
                });
            }
        }

        public address FindByAddressAndPostalCode(string address1, string address2, string postalCode)
        {
            var addresses = _repository.FindAll();
            var existingAddress = addresses.Where(a => a.address1.Equals(address1, StringComparison.CurrentCultureIgnoreCase)
            && a.address2.Equals(address2, StringComparison.CurrentCultureIgnoreCase) && a.postalCode.Equals(postalCode)).FirstOrDefault();
            if (existingAddress == null)
                throw new NotFoundException("");
            return existingAddress;
        }

    }
}
