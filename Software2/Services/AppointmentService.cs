using Software2.Models;
using Software2.Models.Exceptions;
using Software2.Repositories.Implementation;
using Software2.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AppointmentService
    {
        private IAppointmentRepository _repository;
        private AuthRepository _authRepository;
        private CustomerService customerService;
        private ReminderService reminderService;

        public AppointmentService(IAppointmentRepository repository, AuthRepository authRepository, CustomerService customerService, ReminderService reminderService)
        {
            _repository = repository;
            _authRepository = authRepository;
            this.customerService = customerService;
            this.reminderService = reminderService;
        }

        public appointment FindOne(int id)
        {
            var appointment = _repository.FindOne(id);
            if (appointment == null)
                throw new NotFoundException("Could not locate appointment with specified ID.");
            return AdjustTimeZone(appointment);
        }

        public void Add(appointment appointment)
        {
            ValidateAppointment(appointment);
            appointment.createdBy = _authRepository.Username;
            appointment.lastUpdateBy = _authRepository.Username;
            appointment.createDate = DateTime.Now.ToUniversalTime();
            appointment.lastUpdate = DateTime.Now.ToUniversalTime();
            _repository.Add(appointment);
            AddReminderForNewAppointment(appointment);
        }

        private void AddReminderForNewAppointment(appointment appointment)
        {
            var dbAppointment = _repository.FindAll().Where(a => a.contact.Equals(appointment.contact) && a.start == appointment.start && a.end == appointment.end).FirstOrDefault();
            var id = dbAppointment.appointmentId;
            var reminderTime = dbAppointment.start.AddMinutes(-15);
            reminderService.Add(reminderTime, id);
        }

        public void Update(appointment appointment)
        {
            ValidateAppointment(appointment);
            appointment.lastUpdate = DateTime.Now;
            appointment.lastUpdateBy = _authRepository.Username;
            _repository.Update(appointment, appointment.appointmentId);
        }

        public IEnumerable<appointment> FindAll()
        {
            return AdjustTimeZone(_repository.FindAll());
        }

        public IEnumerable<AppointmentAggregate> FindAllAggregates()
        {
            var appointments = FindAll();
            var aggregates = new List<AppointmentAggregate>();
            var customers = customerService.FindAll();
            foreach(var appointment in appointments)
            {
                var customer = customers.Where(c => c.customerId == appointment.customerId).FirstOrDefault();
                aggregates.Add(new AppointmentAggregate()
                {
                    Id = appointment.appointmentId,
                    CustomerId = customer.customerId,
                    Contact = appointment.contact,
                    CustomerName = customer.customerName,
                    Description = appointment.description,
                    Start = appointment.start,
                    End = appointment.end,
                    Location = appointment.location,
                    Url = appointment.url,
                    Title = appointment.title
                });
            }
            return aggregates;
        }

        public IEnumerable<appointment> FindAllByCustomerId(int customerId)
        {
            var appointments = _repository.FindAll();
            if (appointments == null || appointments.Count() == 0)
                throw new NotFoundException("No appointments found for customer");
            var customerAppointments = appointments.Where(app => app.customerId == customerId).ToList();
            if (customerAppointments.Count == 0)
                throw new NotFoundException("No appointments found for customer");
            return AdjustTimeZone(customerAppointments);
        }

        public void Delete(int id)
        {
            FindOne(id);
            _repository.Delete(id);
        }

        private void ValidateAppointment(appointment appointment)
        {
            if (String.IsNullOrWhiteSpace(appointment.title))
                throw new InvalidInputException("Name is required");
            if (String.IsNullOrWhiteSpace(appointment.description))
                throw new InvalidInputException("Description is required");
            if (String.IsNullOrWhiteSpace(appointment.location))
                throw new InvalidInputException("Location is required");
            if (String.IsNullOrWhiteSpace(appointment.url))
                throw new InvalidInputException("Url is required");
            if (customerService.FindOne(appointment.customerId) == null)
                throw new InvalidInputException("A valid customer is required");
            if (String.IsNullOrWhiteSpace(appointment.contact))
                throw new InvalidInputException("Contact is required");
            if (appointment.start < DateTime.Now)
                throw new InvalidInputException("Appointment must be a future time");
            if (appointment.end < appointment.start)
                throw new InvalidInputException("End time must be greater than start time");
            
        }


        private IEnumerable<appointment> AdjustTimeZone(IEnumerable<appointment> appointments)
        {
            foreach (var appointment in appointments)
            {
                appointment.start = TimeZoneInfo.ConvertTime(appointment.start, TimeZoneInfo.Local);
                appointment.end = TimeZoneInfo.ConvertTime(appointment.end, TimeZoneInfo.Local);
            }

            return appointments;
        }

        private appointment AdjustTimeZone(appointment appointment)
        {
            appointment.start = TimeZoneInfo.ConvertTime(appointment.start, TimeZoneInfo.Local);
            appointment.end = TimeZoneInfo.ConvertTime(appointment.end, TimeZoneInfo.Local);

            return appointment;
        }
    }
}
