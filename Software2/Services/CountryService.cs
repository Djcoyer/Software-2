﻿using Software2.Models.Exceptions;
using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class CountryService
    {
        private ICountryRepository _repository;

        public CountryService(ICountryRepository repository)
        {
            _repository = repository;
        }

        public country findOne(int id)
        {
            var country = _repository.findOne(id);
            if (country == null)
                throw new NotFoundException("");
            return country;
        }

        public List<country> findAll()
        {
            return _repository.findAll().ToList();
        }

        public country findByName(string name)
        {
            var country = _repository.findByName(name);
            if (country == null)
                throw new NotFoundException("");
            return country;
        }

        public void delete(int id)
        {
            _repository.delete(id);
        }

        public void add(country country)
        {
            _repository.add(country);
        }
    }
}