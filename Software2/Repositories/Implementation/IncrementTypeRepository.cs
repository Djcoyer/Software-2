using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class IncrementTypeRepository : IIncrementRepository
    {
        public CalendarEntities _db { private get; set; }

        public int Add(incrementtype incrementType)
        {
            var lastId = _db.incrementtypes.Max(i => i.incrementTypeId);
            incrementType.incrementTypeId = lastId + 1;
            _db.incrementtypes.Add(incrementType);
            _db.SaveChanges();
            return incrementType.incrementTypeId;
        }

        public void Delete(int id)
        {
            var incrementTypeToDelete = FindOne(id);
            if (incrementTypeToDelete == null)
                return;
            _db.incrementtypes.Remove(incrementTypeToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<incrementtype> FindAll()
        {
            return _db.incrementtypes.AsEnumerable();
        }

        public incrementtype FindOne(int id)
        {
            return _db.incrementtypes.Find(id);
        }

        public void Update(incrementtype incrementType, int id)
        {
            var incrementTypeToUpdate = FindOne(id);
            if (incrementTypeToUpdate == null)
                return;
            incrementTypeToUpdate = incrementType;
            _db.SaveChanges();
        }
    }
}
