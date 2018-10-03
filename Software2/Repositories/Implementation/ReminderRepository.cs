using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class ReminderRepository : IReminderRepository
    {
        public CalendarEntities _db { private get; set; }

        public void Add(reminder reminder)
        {
            _db.reminders.Add(reminder);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var reminderToDelete = FindOne(id);
            if (reminderToDelete == null)
                return;
            _db.reminders.Remove(reminderToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<reminder> FindAll()
        {
            return _db.reminders.AsEnumerable();
        }

        public IEnumerable<reminder> FindAllByAppointmentId(int appointmentId)
        {
            return _db.reminders.Where(r => r.appointmentId == appointmentId)?.AsEnumerable();
        }

        public reminder FindOne(int id)
        {
            return _db.reminders.Find(id);
        }

        public void Update(reminder reminder, int id)
        {
            var reminderToUpdate = FindOne(id);
            if (reminderToUpdate == null)
                return;
            reminderToUpdate = reminder;
            _db.SaveChanges();
        }
    }
}
