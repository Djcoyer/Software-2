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
        public ReminderService(
            IReminderRepository reminderRepository, 
            IncrementService incrementService, 
            AuthRepository authRepository, 
            AppointmentService appointmentService)
        {
            _reminderRepository = reminderRepository;
            _authRepository = authRepository;
            this.incrementService = incrementService;
            this.appointmentService = appointmentService;
        }


        #region REMINDER

        #region GET

        public reminder FindOne(int id)
        {
            var reminder = _reminderRepository.FindOne(id);
            if (reminder == null)
                throw new NotFoundException("Could not locate reminder with specified ID");
            return AdjustTimeZone(reminder);
        }

        public List<reminder> FindAll()
        {
            return AdjustTimeZone(_reminderRepository.FindAll())?.ToList();
        }

        public List<reminder> FindAllByAppointmentId(int appointmentId)
        {
            return _reminderRepository.FindAllByAppointmentId(appointmentId)?.ToList();
        }

        #endregion

        #region ADD


        public void Add(reminder reminder)
        {
            Validate(reminder);
            _reminderRepository.Add(reminder);
        }

        public void Add(DateTime reminderDateTime, int appointmentId)
        {
            var incrementTypeId = incrementService.FindDefaultIncrement()?.incrementTypeId;

            var reminder = new reminder()
            {
                appointmentId = appointmentId,
                createdBy = _authRepository.Username,
                createdDate = DateTime.Now,
                reminderDate = reminderDateTime,
                snoozeIncrement = 5,
                snoozeIncrementTypeId = incrementTypeId.HasValue ? incrementTypeId.Value : 1
            };
            Validate(reminder);
            _reminderRepository.Add(reminder);
        }

        #endregion

        #region UPDATE

        public void Update(reminder reminder, int id)
        {
            Validate(reminder);
            FindOne(id);
            _reminderRepository.Update(reminder, id);
        }

        #endregion

        #region DELETE
        public void Delete(int id)
        {
            FindOne(id);
            _reminderRepository.Delete(id);
        }

        public void DeleteByAppointmentId(int appointmentId)
        {
            var reminders = FindAllByAppointmentId(appointmentId);
            if (reminders == null || reminders.Count == 0)
                return;
            _reminderRepository.DeleteMany(reminders.Select(r => r.reminderId).ToList());
        }

        #endregion


        #endregion

        #region AGGREGATE

        #region GET

        public reminder FindByAppointmentId(int appointmentId)
        {
            var appointmentAggregate = appointmentService.FindOneAggregate(appointmentId);
            var reminder = FindAll().Where(r => r.appointmentId == appointmentId).FirstOrDefault();
            if (reminder == null)
                throw new NotFoundException("No reminders exist with specified appointment ID.");
            return reminder;
        }

        public ReminderAggregate FindAggregateByAppointmentId(int appointmentId)
        {
            var appointmentAggregate = appointmentService.FindOneAggregate(appointmentId);
            var reminder = FindAll().Where(r => r.appointmentId == appointmentId).FirstOrDefault();
            return ConvertToAggregate(reminder, appointmentAggregate);
        }
    
        public IEnumerable<ReminderAggregate> FindRemindersInNextHour()
        { 
            var reminders = FindAll().Where(r => (r.reminderDate - DateTime.Now).TotalHours < 1 && (r.reminderDate - DateTime.Now).TotalHours > 0).ToList();
            if (reminders.Count == 0)
                return null;
            List<ReminderAggregate> aggregates = new List<ReminderAggregate>();
            IEnumerable<AppointmentAggregate> appointmentAggregates = appointmentService.FindAllAggregates();
            foreach(var reminder in reminders)
            {
                var aggregate = appointmentAggregates.Where(a => a.Id == reminder.appointmentId).FirstOrDefault();
                if (aggregate == null)
                    break;
                aggregates.Add(ConvertToAggregate(reminder, aggregate));
            }

            return aggregates;
        }

        #endregion


        #region ADD

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

        #endregion

        #endregion

        #region HELPERS


        private IEnumerable<reminder> AdjustTimeZone(IEnumerable<reminder> reminders)
        {
            foreach (var reminder in reminders)
            {
                reminder.reminderDate = TimeZoneInfo.ConvertTime(reminder.reminderDate, TimeZoneInfo.Local);
            }

            return reminders;
        }

        private reminder AdjustTimeZone(reminder reminder)
        {
            reminder.reminderDate = TimeZoneInfo.ConvertTime(reminder.reminderDate, TimeZoneInfo.Local);
            return reminder;
        }


        private void Validate(reminder reminder)
        {
            if (reminder.reminderDate == null || reminder.reminderDate < DateTime.Now)
                throw new InvalidInputException("Reminder date must be in the future");
            if (reminder.snoozeIncrement <= 0)
                throw new InvalidInputException("Snooze increment value must be greater than 0");
            if (String.IsNullOrWhiteSpace(reminder.remindercol))
                reminder.remindercol = "Reminder";

            //Throws not found exception if not found
            incrementService.FindOne(reminder.snoozeIncrementTypeId);
        }

        private ReminderAggregate ConvertToAggregate(reminder reminder, AppointmentAggregate appointmentAggregate)
        {
            return new ReminderAggregate()
            {
                AppointmentId = appointmentAggregate.Id,
                CustomerName = appointmentAggregate.CustomerName,
                Location = appointmentAggregate.Location,
                ReminderId = reminder.reminderId,
                ReminderDate = reminder.reminderDate,
                StartTime  = appointmentAggregate.Start,
                EndTime = appointmentAggregate.End
            };
        }

        #endregion

    }
}
