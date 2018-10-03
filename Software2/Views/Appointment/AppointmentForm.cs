using Software2.Services;
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

        public AppointmentForm(AppointmentService appointmentService, CustomerService customerService)
        {
            this.appointmentService = appointmentService;
            this.customerService = customerService;
            customers = customerService.FindAllCustomers();
            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            source.AddRange(customers.Select(c => c.customerName).ToArray());
            customerTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerTextBox.AutoCompleteCustomSource = source;
            customerTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

    }
}
