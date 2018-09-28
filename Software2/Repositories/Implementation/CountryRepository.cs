using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        public CalendarEntities _db { private get; set; }

        public CountryRepository(CalendarEntities db)
        {
            _db = db;
        }

        public void add(country country)
        {
            var lastCountryId = _db.countries.Max(c => c.countryId);
            country.countryId = lastCountryId + 1;
            _db.countries.Add(country);
            _db.SaveChanges();
        }

        public void delete(int id)
        {
            var country = findOne(id);
            _db.countries.Remove(country);
        }

        public IEnumerable<country> findAll()
        {
            return _db.countries.AsEnumerable();
        }

        public country findByName(string name)
        {
            return _db.countries.Where(c => c.country1.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public country findOne(int id)
        {
            return _db.countries.Find(id);
        }

        public void update(country country, int id)
        {
            var dbCountry = findOne(id);
            dbCountry = country;
            _db.SaveChanges();
        }
    }
}
