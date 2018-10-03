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

        public appointment FindOne(int id)
        {
            var appointment = _repository.FindOne(id);
            if (appointment == null)
                throw new NotFoundException("Could not locate appointment with specified ID.");
            return appointment;
        }

        public void Add(appointment appointment)
        {
            ValidateAppointment(appointment);
            appointment.createdBy = _authRepository.Username;
            appointment.createDate = DateTime.Now;
            appointment.lastUpdate = DateTime.Now;
            appointment.lastUpdateBy = _authRepository.Username;
            _repository.Add(appointment);
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
            return _repository.FindAll();
        }

        public IEnumerable<appointment> FindAllByCustomerId(int customerId)
        {
            var appointments = _repository.FindAll();
            if (appointments == null || appointments.Count() == 0)
                throw new NotFoundException("No appointments found for customer");
            var customerAppointments = appointments.Where(app => app.customerId == customerId).ToList();
            if (customerAppointments.Count == 0)
                throw new NotFoundException("No appointments found for customer");
            return customerAppointments;
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
            if (appointment.start < DateTime.Now)
                throw new InvalidInputException("Appointment must be a future time");
            if (appointment.end < appointment.start)
                throw new InvalidInputException("End time must be greater than start time");
            
        }
    }
}
