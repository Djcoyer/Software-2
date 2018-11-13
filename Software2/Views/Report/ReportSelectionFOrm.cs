using Software2.Models;
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

namespace Software2.Views.Report
{
    public partial class ReportSelectionForm : Form
    {
        private FormManager formManager;
        private UserService userService;
        private AppointmentService appointmentService;
        private CustomerService customerService;

        public ReportSelectionForm(FormManager formManager, UserService userService, AppointmentService appointmentService, CustomerService customerService)
        {
            this.formManager = formManager;
            this.userService = userService;
            this.appointmentService = appointmentService;
            this.customerService = customerService;
            InitializeComponent();

        }

        private void consultantScheduleButton_Click(object sender, EventArgs e)
        {
            var users = userService.FindAllUsers();
            IEnumerable<string> userNames = users.Select(u => u.userName);
            var form = formManager.GetForm<SelectionPopUp>();
            form.SetSelectionOptions(userNames);


            form.SetSubmitSelection((string selectedOption, Form popupForm) =>
            {
                popupForm.Close();
                var reportForm = formManager.GetForm<ReportForm>();

                reportForm.onDoneClick = ((Form formToClose) =>
                {
                    formToClose.Close();
                    Show();
                });
                var appointments = appointmentService.FindAllByContact(selectedOption).OrderBy(p => p.Start);
                if (appointments.Count() == 0)
                    return;
                var reportItems = new List<ReportBase>();
                foreach (var appointment in appointments)
                {
                    var reportItem = new ReportBase();
                    reportItem.Title = appointment.Start.ToShortDateString();
                    Dictionary<string, string> properties = new Dictionary<string, string>();
                    properties.Add("Customer", appointment.CustomerName);
                    properties.Add("Start", appointment.Start.ToShortTimeString());
                    properties.Add("End", appointment.End.ToShortTimeString());
                    reportItem.Properties = properties;
                    reportItems.Add(reportItem);
                }
                reportForm.SetReportItems(reportItems);
                Hide();
                reportForm.Show();

            });
            form.Show();
        }

        private void appointmentTypeButton_Click(object sender, EventArgs e)
        {
            var form = formManager.GetForm<SelectionPopUp>();
            form.SetDateSelection(true);

            form.SetSubmitSelection((string selectedOption, Form selectionForm) =>
            {
                selectionForm.Close();
                var reportForm = formManager.GetForm<ReportForm>();
                reportForm.onDoneClick = ((Form formToClose) =>
                {
                    formToClose.Close();
                    Show();
                });

                var appointmentTypeDictionary = appointmentService.FindTypesByMonth(DateTime.Parse(selectedOption).Month);
                var reportItems = new List<ReportBase>();
                appointmentTypeDictionary.Keys.ToList().ForEach(p =>
                {
                    var properties = new Dictionary<string, string>();
                    properties.Add("Count", appointmentTypeDictionary[p].ToString());
                    reportItems.Add(new ReportBase()
                    {
                        Title = p,
                        Properties = properties
                    });
                });

                reportForm.SetReportItems(reportItems);
                reportForm.Show();
            });
            Hide();
            form.Show();
        }

        private void customerScheduleButton_Click(object sender, EventArgs e)
        {
            var customers = customerService.FindAll();
            var form = formManager.GetForm<SelectionPopUp>();
            form.SetSelectionOptions(customers.Select(c => c.customerName));
            form.SetSubmitSelection((string selectedOption, Form selectionForm) =>
            {
                var customer = customers.Find(c => c.customerName.Equals(selectedOption));
                var appointments = appointmentService.FindAllAggregatesByCustomerId(customer.customerId).OrderBy(p => p.Start);
                var reportForm = formManager.GetForm<ReportForm>();
                reportForm.onDoneClick = ((Form formToClose) =>
                {
                    formToClose.Close();
                    Show();
                });

                var reportItems = new List<ReportBase>();
                foreach (var appointment in appointments)
                {
                    Dictionary<string, string> properties = new Dictionary<string, string>();
                    properties.Add("Customer", appointment.CustomerName);
                    properties.Add("Start", appointment.Start.ToShortTimeString());
                    properties.Add("End", appointment.End.ToShortTimeString());

                    reportItems.Add(new ReportBase()
                    {
                        Title = appointment.Start.ToShortDateString(),
                        Properties = properties
                    });
                }
                reportForm.SetReportItems(reportItems);


                form.Close();
                reportForm.Show();
            });

            form.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var form = formManager.GetForm<HomeForm>();
            form.Show();
            Close();
        }

       
    }
}
