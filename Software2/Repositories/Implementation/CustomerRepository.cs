using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public CalendarEntities _db { private get; set; }

        public CustomerRepository(CalendarEntities db)
        {
            _db = db;
        }

        public void Add(customer customer)
        {
            var lastId = _db.customers.Max(p => p.customerId);
            customer.customerId = lastId + 1;
            _db.customers.Add(customer);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = FindOne(id);
            _db.customers.Remove(customer);
            _db.SaveChanges();
        }

        public IEnumerable<customer> FindAll()
        {
            return _db.customers.AsEnumerable();
        }

        public customer FindOne(int id)
        {
            return _db.customers.FirstOrDefault(customer => customer.customerId == id);
        }

        public void Update(customer customer, int id)
        {
            var dbCustomer = FindOne(id);
            dbCustomer = customer;
            _db.SaveChanges();
        }
    }
}
