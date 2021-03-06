﻿using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class AddressRepository: IAddressRepository
    {
        public CalendarEntities _db { private get; set; }

        public void Add(address address)
        {
            var lastId = _db.addresses.Max(a => a.addressId);
            address.addressId = lastId + 1;
            _db.addresses.Add(address);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<address> FindAll()
        {
            return _db.addresses.AsEnumerable();
        }

        public address FindOne(int id)
        {
            return _db.addresses.FirstOrDefault(a => a.addressId == id);
        }

        public void Update(address address, int id)
        {
            var existingAddress = FindOne(id);
            existingAddress = address;
            _db.SaveChanges();
        }
    }
}
