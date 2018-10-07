﻿using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public CalendarEntities _db { private get; set; }

        public void Add(appointment appointment)
        {
            var lastId = 0;
            if (_db.appointments.Count() > 0)
                lastId = _db.appointments.Max(app => app.appointmentId);
            //If 0, first Id will be 1.
            appointment.appointmentId = lastId + 1;
            _db.appointments.Add(appointment);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = FindOne(id);
            if (appointment == null)
                return;
            _db.appointments.Remove(appointment);
            _db.SaveChanges();
        }

        public IEnumerable<appointment> FindAll()
        {
            return _db.appointments.AsEnumerable();
        }

        public appointment FindOne(int id)
        {
            return _db.appointments.Find(id);
        }

        public void Update(appointment appointment, int id)
        {
            var existingAppointment = FindOne(id);
            if (existingAppointment == null)
                return;
            existingAppointment = appointment;
            _db.SaveChanges();
        }
    }
}
