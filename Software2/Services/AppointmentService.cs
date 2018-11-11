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

        public AppointmentService(IAppointmentRepository repository, AuthRepository authRepository, CustomerService customerService)
        {
            _repository = repository;
            _authRepository = authRepository;
            this.customerService = customerService;
        }

        public IEnumerable<AppointmentAggregate> FindAllByContact(string contact)
        {
            return FindAllAggregates()?.Where(app => app.Contact.Equals(contact, StringComparison.CurrentCultureIgnoreCase));
        }

        public Dictionary<string, int> FindDistinctByTypeForMonth(string type, int month)
        {
            var aggregates = FindAllAggregates()?.Where(app => app.Start.Month == month);
            List<string> types = aggregates.Select(a => a.Title).ToList();
            Dictionary<string, int> appointmentTypesCount = new Dictionary<string, int>();
            foreach(var _type in types)
            {
                int count = aggregates.Count(a => a.Title.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                appointmentTypesCount.Add(_type, count);
            };

            return appointmentTypesCount;
        }

        public appointment FindOne(int id)
        {
            var appointment = _repository.FindOne(id);
            if (appointment == null)
                throw new NotFoundException("Could not locate appointment with specified ID.");
            return AdjustTimeZone(appointment);
        }

        public AppointmentAggregate FindOneAggregate(int id)
        {
            var appointment = FindOne(id);
            var customer = customerService.FindOne(appointment.customerId);
            return new AppointmentAggregate()
            {
                Contact = appointment.contact,
                CustomerId = appointment.customerId,
                CustomerName = customer.customerName,
                Description = appointment.description,
                Start = appointment.start,
                End = appointment.end,
                Id = id,
                Location = appointment.location,
                Title = appointment.title,
                Url = appointment.url
            };
        }

        public int Add(appointment appointment)
        {
            ValidateAppointment(appointment);
            appointment.createdBy = _authRepository.Username;
            appointment.lastUpdateBy = _authRepository.Username;
            appointment.createDate = DateTime.Now.ToUniversalTime();
            appointment.lastUpdate = DateTime.Now.ToUniversalTime();
            return _repository.Add(appointment);
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
                    Title = appointment.title,
                    CreateDate = appointment.createDate,
                    CreatedBy = appointment.createdBy
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
