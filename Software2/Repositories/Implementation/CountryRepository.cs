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

        public void Add(country country)
        {
            var lastCountryId = _db.countries.Max(c => c.countryId);
            country.countryId = lastCountryId + 1;
            _db.countries.Add(country);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var country = FindOne(id);
            _db.countries.Remove(country);
        }

        public IEnumerable<country> FindAll()
        {
            return _db.countries.AsEnumerable();
        }

        public country FindByName(string name)
        {
            return _db.countries.Where(c => c.country1.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public country FindOne(int id)
        {
            return _db.countries.Find(id);
        }

        public void Update(country country, int id)
        {
            var dbCountry = FindOne(id);
            dbCountry = country;
            _db.SaveChanges();
        }
    }
}
