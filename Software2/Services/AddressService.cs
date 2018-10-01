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
            var address = _repository.FindOne(addressId);
            if (address == null)
                throw new NotFoundException("Could not locate address with specified ID");
            return address;
        }

        public void addNewAddress(AddressAggregate addressAggregate)
        {
            ValidateAddressAggregate(addressAggregate);
            var username = _authRepository.Username;
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
                        country1 = addressAggregate.CountryName,
                        lastUpdate = DateTime.Now,
                        createdBy = username,
                        lastUpdateBy = username,
                        createDate = DateTime.Now
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
                        city1 = addressAggregate.CityName,
                        lastUpdateBy = username,
                        createdBy = username,
                        createDate = DateTime.Now,
                        lastUpdate = DateTime.Now
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
                    createdBy = username,
                    lastUpdateBy = username,
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

        public AddressAggregate FindAggregateById(int addressId)
        {
            address address;
            address = FindOne(addressId);
            var cityId = address.cityId;
            var city = cityService.findOne(cityId);
            var countryId = city.countryId;
            var country = countryService.findOne(countryId);

            return new AddressAggregate()
            {
                CityId = cityId,
                CityName = city.city1,
                CountryId = countryId,
                CountryName = country.country1,
                Address1 = address.address1,
                Address2 = address.address2,
                Phone = address.phone,
                PostalCode = address.postalCode,
                AddressId = address.addressId
            };
        }

        public void UpdateAddress(AddressAggregate addressAggregate)
        {
            var countryId = GetUpdatedCountryId(addressAggregate.CountryId, addressAggregate.CountryName);
            var cityId = GetUpdatedCityId(addressAggregate.CityId, addressAggregate.CityName, countryId);

            var existingAddress = FindOne(addressAggregate.AddressId);


            var address = new address()
            {
                cityId = cityId,
                address1 = addressAggregate.Address1,
                address2 = addressAggregate.Address2,
                addressId = addressAggregate.AddressId,
                phone = addressAggregate.Phone,
                postalCode = addressAggregate.PostalCode,
                createdBy = existingAddress.createdBy,
                createDate = existingAddress.createDate,
                lastUpdate = DateTime.Now,
                lastUpdateBy = _authRepository.Username
            };

            _repository.Update(address, address.addressId);
        }

        private int GetUpdatedCountryId(int countryId, string countryName)
        {
            var country = countryService.findOne(countryId);
            if (countryName != country.country1)
            {
                try
                {
                    var otherCountry = countryService.findByName(countryName);
                    return otherCountry.countryId;
                }
                catch (NotFoundException e)
                {
                    countryService.add(new country()
                    {
                        country1 = countryName
                    });
                    var newCountry = countryService.findByName(countryName);
                    return newCountry.countryId;
                }
            }
            else return countryId;
        }

        private int GetUpdatedCityId(int cityId, string cityName, int countryId)
        {
            var city = cityService.findOne(cityId);
            if (cityName != city.city1)
            {
                try
                {
                    var otherCity = cityService.findByNameAndCountryId(cityName, countryId);
                    return otherCity.cityId;
                }
                catch (NotFoundException e)
                {
                    cityService.add(new city()
                    {
                        city1 = cityName,
                        countryId = countryId
                    });
                    var newCity = cityService.findByNameAndCountryId(cityName, countryId);
                    return newCity.cityId;
            }
        }
            else return cityId;
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
