using Software2.Models;
using Software2.Repositories.Implementation;
using Software2.Services;
using Software2.Views.Appointment;
using Software2.Views.Customer;
using Software2.Views.manager;
using Software2.Views.Reminder;
using Software2.Views.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{
    

    public partial class HomeForm : Form
    {
        public bool isLoggedIn = false;
        private IFormManager _formManager;
        public AuthRepository _authRepository { get; set; }
        private ReminderService reminderService;

        public HomeForm(IFormManager formManager, AuthRepository authRepository, ReminderService reminderService)
        {
            _authRepository = authRepository;
            this._formManager = formManager;
            this.reminderService = reminderService;
            InitializeComponent();
            if(!_authRepository.UserAuthenticated)
            {
                ShowLoginForm();
            }
            else
            {
                customersButton.Show();
                customersButton.Show();
                appointmentsButton.Show();
            }
        }

        private async void ShowLoginForm()
        {
            var loginForm = _formManager.GetForm<LoginForm>();
            //Delegate implementation
            loginForm.setUserAuthenticated = SetUserAuthenticated;

            await Task.Delay(10);
            loginForm.Show();
            Hide();
        }

        private void SetUserAuthenticated(Form loginForm, string username)
        {
            SetUserAuthenticated(username);
            UpdateLoginRecord(username);
            SetRemindersForSession();
            loginForm.Close();
            Show();
        }

        private void UpdateLoginRecord(string username)
        {
            string fileName = string.Format("{0}/LoginRecord.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            StreamWriter objWriter = File.AppendText(fileName);

            DateTime loginTime = DateTime.Now;

            objWriter.WriteLine(String.Format("{0} logged in on {1} at {2}", username, loginTime.ToShortDateString(), loginTime.ToShortTimeString()));
            objWriter.Close();
        }

        private void SetUserAuthenticated(string username)
        {
            _authRepository.Username = username;
            _authRepository.UserAuthenticated = true;
            customersButton.Show();
            customersButton.Show();
            appointmentsButton.Show();
        }

        private void SetRemindersForSession()
        {
            var reminderAggregates = reminderService.FindRemindersInNextHour();
            if (reminderAggregates == null || reminderAggregates.Count() == 0)
                return;
            foreach (var aggregate in reminderAggregates)
            {
                TimeSpan timeUntilReminder = aggregate.ReminderDate - DateTime.Now;
                if (timeUntilReminder < TimeSpan.Zero)
                    return;

                var timer = new System.Windows.Forms.Timer();
                timer.Interval = timeUntilReminder.Seconds * 1000;
                timer.Enabled = true;
                timer.Tick += new EventHandler((object sender, EventArgs e) =>
                {
                    timer.Enabled = false;
                    var reminderForm = _formManager.GetForm<ReminderForm>();
                    reminderForm.SetAggregate(aggregate);
                    reminderForm.Show();
                });

            }
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            Hide();
            _formManager.ShowForm<CustomerListForm>();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            Hide();
            _formManager.ShowForm<AppointmentListForm>();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            Hide();
            _formManager.ShowForm<ReportSelectionForm>();
        }
    }
}
