﻿using Software2.Models;
using Software2.Models.Exceptions;
using Software2.Repositories.Implementation;
using Software2.Services;
using Software2.Views.manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2.Views.Appointment
{
    public partial class AppointmentForm : Form
    {
        private AppointmentService appointmentService;
        private ReminderService reminderService;
        private CustomerService customerService;
        private List<customer> customers;
        private List<user> users;
        private AuthRepository _authRepository;
        private UserService userService;

        private IFormManager _formManager;
        private AppointmentAggregate appointmentAggregate;
        public AppointmentForm(
            AppointmentService appointmentService, 
            CustomerService customerService, 
            IFormManager formManager, 
            AuthRepository authRepository, 
            ReminderService reminderService,
            UserService userService
            )
        {
            this.userService = userService;
            this.appointmentService = appointmentService;
            this.customerService = customerService;
            this.reminderService = reminderService;
            _formManager = formManager;
            _authRepository = authRepository;
            customers = customerService.FindAll();
            users = userService.FindAllUsers();

            InitializeComponent();
            var customerSource = new AutoCompleteStringCollection();
            customerSource.AddRange(customers.Select(c => c.customerName).ToArray());
            customerTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerTextBox.AutoCompleteCustomSource = customerSource;
            customerTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;

            var contactSource = new AutoCompleteStringCollection();
            contactSource.AddRange(users.Select(u => u.userName).ToArray());
            contactTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            contactTextBox.AutoCompleteCustomSource = contactSource;
            contactTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;

            datePicker.MinDate = DateTime.Now;
            startTimePicker.MinDate = DateTime.Now.Date;
            endTimePicker.MinDate = DateTime.Now.Date;
        }

        public void SetAggregate(AppointmentAggregate aggregate)
        {
            var minDate = aggregate.Start < DateTime.Now ? aggregate.Start : DateTime.Now;
            datePicker.MinDate = minDate;
            appointmentAggregate = aggregate;
            titleTextBox.Text = aggregate.Title;
            contactTextBox.Text = aggregate.Contact;
            customerTextBox.Text = aggregate.CustomerName;
            locationTextBox.Text = aggregate.Location;
            UrlTextBox.Text = aggregate.Url;
            descriptionTextBox.Text = aggregate.Description;
            datePicker.Value = aggregate.Start;
            startTimePicker.Value = aggregate.Start;
            endTimePicker.Value = aggregate.End;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Visible = false;
                if (appointmentAggregate == null)
                    AddAppointment();
                else
                    UpdateAppointment();
                Close();
                _formManager.ShowForm<AppointmentListForm>();
            }catch(InvalidInputException ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
            
        }

        private void AddAppointment()
        {
            var appointment = GetAppointmentFromFields();
            int id = appointmentService.Add(appointment);
            AddReminder(appointment.start, id);
        }

        private void UpdateAppointment()
        {
            var updatedAppointment = GetAppointmentFromFields();
            var date = updatedAppointment.start;
            updatedAppointment.appointmentId = appointmentAggregate.Id;
            updatedAppointment.createDate = appointmentAggregate.CreateDate;
            updatedAppointment.createdBy = appointmentAggregate.CreatedBy;
            appointmentService.Update(updatedAppointment);

            var reminder = reminderService.FindByAppointmentId(appointmentAggregate.Id);
            reminder.reminderDate = date.AddMinutes(-5) < DateTime.Now ?
                date.AddMinutes(-(updatedAppointment.start - DateTime.Now).TotalMinutes + 1) 
                : date.AddMinutes(-5);

            reminderService.Update(reminder, reminder.reminderId);
        }

        private appointment GetAppointmentFromFields()
        {
            var title = titleTextBox.Text;
            var customerName = customerTextBox.Text;
            var contact = contactTextBox.Text;
            var location = locationTextBox.Text;
            var url = UrlTextBox.Text;
            var description = descriptionTextBox.Text;

            var date = datePicker.Value.Date;
            var startTime = startTimePicker.Value.TimeOfDay;
            var endTime = endTimePicker.Value.TimeOfDay;
            var startDateTime = date + startTime;
            var endDateTime = date + endTime;

            if (String.IsNullOrWhiteSpace(customerName))
                throw new InvalidInputException("Must supply customer name");
            var customer = GetCustomerByName(customerName);
            if (customer == null) { }
            var user = GetUserByName(contact);

            return new appointment()
            {
                title = title,
                contact = contact,
                createdBy = _authRepository.Username,
                customerId = customer.customerId,
                start = startDateTime,
                end = endDateTime,
                location = location,
                url = url,
                description = description
            };
        }

        private void AddReminder(DateTime startTime, int id)
        {
            var reminderTime = (startTime.AddMinutes(-15) > DateTime.Now ? startTime.AddMinutes(-15) : DateTime.Now.AddMinutes(1));
            reminderService.Add(reminderTime, id);
        }

        public customer GetCustomerByName(string customerName)
        {
            var customers = this.customers.Where(c => c.customerName == customerName).ToList();
            if (customers == null || customers.Count() == 0)
                throw new InvalidInputException("Must select a valid customer");
            else if (customers.Count() > 1)
            {
                return null;
            }
            else return customers[0];
        }

        public user GetUserByName(string userName)
        {
            var users = this.users.Where(u => u.userName.Equals(userName)).ToList();
            if (users == null || users.Count() == 0)
                throw new InvalidInputException("Must select a valid user for contact");
            else if (users.Count() > 1)
            {
                return null;
            }
            else return users[0];
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            _formManager.ShowForm<AppointmentListForm>();
        }
    }
}
