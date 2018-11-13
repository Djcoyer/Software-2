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
    public class CityService
    {
        private ICityRepository _repository;
        private AuthRepository _authRepository;

        public CityService(ICityRepository repository, AuthRepository authRepository)
        {
            _authRepository = authRepository;
            _repository = repository;
        }

        public List<city> findAll()
        {
            var cities = _repository.FindAll();
            if (cities == null)
            {
                return new List<city>();
            }
            return cities.ToList();
        }

        public city findOne(int id)
        {
            var city = _repository.FindOne(id);
            if (city == null)
                throw new NotFoundException("Could not locate city with specified ID.");
            return city;
        }

        public void add(city city)
        {
            if (String.IsNullOrWhiteSpace(city.city1))
                throw new InvalidInputException("Must include city name");
            try
            {
                var existingCity = findByNameAndCountryId(city.city1, city.countryId);
                throw new DataIntegrityViolationException("City already exists");
            }catch(NotFoundException e)
            {
                _repository.Add(city);
            }
        }

        public void delete(int id)
        {
            var city = findOne(id);
            _repository.Delete(id);
        }

        public void update(city city, int id)
        {
            findOne(id);

            //Validation logic

            _repository.Update(city, id);
        }

        public List<city> findAllByName(string name)
        {
            return _repository.FindByName(name).ToList();
        }

        public city findByNameAndCountryId(string name, int countryId)
        {
            var cities = _repository.FindByName(name);
            if (cities == null || cities.Count() == 0)
                throw new NotFoundException("City does not exist");
            var cityToReturn = cities.Where(c => c.countryId == countryId).FirstOrDefault();
            if (cityToReturn == null)
                throw new NotFoundException("City does not exist");
            return cityToReturn;
        }
    }
}
