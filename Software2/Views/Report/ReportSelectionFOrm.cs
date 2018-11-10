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

        public ReportSelectionForm(FormManager formManager, UserService userService, AppointmentService appointmentService)
        {
            this.formManager = formManager;
            this.userService = userService;
            this.appointmentService = appointmentService;
            InitializeComponent();

        }

        private void consultantScheduleButton_Click(object sender, EventArgs e)
        {
            var users = userService.FindAllUsers();
            IEnumerable<string> userNames = users.Select(u => u.userName);
            var form = formManager.GetForm<SelectionPopUp>();
            form.SetSelectionOptions(userNames);
            form.SetSubmitSelection((string selectedOption, Form popupForm) => {
            popupForm.Close();
            var reportForm = formManager.GetForm<ReportForm>();
            reportForm.onDoneClick = ((Form formToClose)=> {
                formToClose.Close();
                Show();
            });
                var appointments = appointmentService.FindAllByContact(selectedOption);
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

        private void HandleSelection(string selectedOption, Form form)
        {

        }
    }
}
