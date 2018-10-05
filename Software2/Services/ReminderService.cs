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
    public class ReminderService
    {
        private IReminderRepository _reminderRepository;
        private AuthRepository _authRepository;
        private IncrementService incrementService;
        private AppointmentService appointmentService;

        public ReminderService(IReminderRepository reminderRepository, IncrementService incrementService, AuthRepository authRepository, AppointmentService appointmentService)
        {
            _reminderRepository = reminderRepository;
            _authRepository = authRepository;
            this.incrementService = incrementService;
            this.appointmentService = appointmentService;
        }


        public reminder FindOne(int id)
        {
            var reminder = _reminderRepository.FindOne(id);
            if (reminder == null)
                throw new NotFoundException("Could not locate reminder with specified ID");
            return reminder;
        }

        public List<reminder> FindAll()
        {
            return _reminderRepository.FindAll()?.ToList();
        }

        public List<reminder> FindAllByAppointmentId(int appointmentId)
        {
            return _reminderRepository.FindAllByAppointmentId(appointmentId)?.ToList();
        }

        public void Add(reminder reminder)
        {
            Validate(reminder);
            _reminderRepository.Add(reminder);
        }

        public void Add(DateTime reminderDateTime, int appointmentId)
        {
            var incrementTypeId = incrementService.FindDefaultIncrement()?.incrementTypeId;

            var reminder = new reminder() {
                appointmentId = appointmentId,
                createdBy = _authRepository.Username,
                createdDate = DateTime.Now,
                reminderDate = reminderDateTime,
                snoozeIncrement = 5,
                snoozeIncrementTypeId = incrementTypeId.HasValue ? incrementTypeId.Value : 1
            };

            _reminderRepository.Add(reminder);
        }


        //Validation will take place in the other Add method's Validate method
        //And in IncrementService validate
        public void Add(ReminderAggregate reminderAggregate)
        {
            var reminder = new reminder()
            {
                reminderDate = reminderAggregate.ReminderDate,
                remindercol = reminderAggregate.ReminderCol,
                createdBy = _authRepository.Username
            };

            var incrementType = new incrementtype()
            {
                incrementTypeDescription = reminderAggregate.IncrementDescription
            };

            var incrementId = incrementService.Add(incrementType);

            reminder.snoozeIncrementTypeId = incrementId;

            Add(reminder);
        }

        public void Update(reminder reminder, int id)
        {
            Validate(reminder);
            FindOne(id);
            _reminderRepository.Update(reminder, id);
        }

        public void Delete(int id)
        {
            FindOne(id);
            _reminderRepository.Delete(id);
        }

        private void Validate(reminder reminder)
        {
            if (reminder.reminderDate == null || reminder.reminderDate < DateTime.Now)
                throw new InvalidInputException("Reminder date must be in the future");
            if (String.IsNullOrWhiteSpace(reminder.remindercol))
                throw new InvalidInputException("Reminder col is required");
            if (reminder.snoozeIncrement <= 0)
                throw new InvalidInputException("Snooze increment value must be greater than 0");
            
            //Throws not found exception if not found
            incrementService.FindOne(reminder.snoozeIncrementTypeId);
            appointmentService.FindOne(reminder.appointmentId);
        }
    }
}
