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
            var reminderId = 0;
            if (_db.reminders.Count() > 0)
                reminderId = _db.reminders.Max(r => r.reminderId);
            reminder.reminderId = reminderId + 1;
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

        public void DeleteMany(List<int> ids)
        {
            foreach(int id in ids)
            {
                var dbReminder = FindOne(id);
                _db.reminders.Remove(dbReminder);
            }
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
