using Software2.Models.Exceptions;
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

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public List<city> findAll()
        {
            var cities = _repository.findAll();
            if (cities == null)
            {
                return new List<city>();
            }
            return cities.ToList();
        }

        public city findOne(int id)
        {
            var city = _repository.findOne(id);
            if (city == null)
                throw new NotFoundException("");
            return city;
        }

        public void add(city city)
        {

        }

        public void delete(int id)
        {
            var city = findOne(id);
            _repository.delete(id);
        }

        public void update(city city, int id)
        {
            findOne(id);

            //Validation logic

            _repository.update(city, id);
        }
    }
}
