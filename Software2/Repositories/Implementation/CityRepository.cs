using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class CityRepository : ICityRepository
    {
        public CalendarEntities _db { private get; set; }

        public void Add(city city)
        {
            var lastId = _db.cities.Max(p => p.cityId);
            city.cityId = lastId + 1;
            _db.cities.Add(city);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var city = _db.cities.Find(id);
            _db.cities.Remove(city);
            _db.SaveChanges();
        }

        public IEnumerable<city> FindAll()
        {
            return _db.cities.AsEnumerable();
        }

        public IEnumerable<city> FindByName(string name)
        {
            return _db.cities.Where(c => c.city1.Equals(name, StringComparison.CurrentCultureIgnoreCase)).AsEnumerable();
        }

        public city FindOne(int id)
        {
            return _db.cities.Find(id);
        }

        public void Update(city city, int id)
        {
            var dbCity = _db.cities.Find(id);
            dbCity = city;
            _db.SaveChanges();
        }
    }
}
