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
        private CustomerService customerService;
        private List<customer> customers;
        private AuthRepository _authRepository;
        private IFormManager _formManager;

        public AppointmentForm(AppointmentService appointmentService, CustomerService customerService, IFormManager formManager, AuthRepository authRepository)
        {
            this.appointmentService = appointmentService;
            this.customerService = customerService;
            _formManager = formManager;
            _authRepository = authRepository;
            customers = customerService.FindAllCustomers();

            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            source.AddRange(customers.Select(c => c.customerName).ToArray());
            customerTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerTextBox.AutoCompleteCustomSource = source;
            customerTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            datePicker.MinDate = DateTime.Now;
            startTimePicker.MinDate = DateTime.Now.Date;
            endTimePicker.MinDate = DateTime.Now.Date;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Visible = false;
                AddAppointment();
            }catch(InvalidInputException ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
            
        }

        private void AddAppointment()
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

            var appointment = new appointment()
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

            appointmentService.Add(appointment);
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            _formManager.ShowForm<HomeForm>();
        }
    }
}
