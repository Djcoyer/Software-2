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
    public partial class ConsultantScheduleForm : Form
    {
        private string username;
        private AppointmentService appointmentService;
        private IEnumerable<AppointmentAggregate> appointments;
        public ConsultantScheduleForm(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
            InitializeComponent();
        }

        public void SetUsername(string username)
        {
            this.username = username;
            appointments = appointmentService.FindAllAggregates();
            SetAppointmentItems();
        }

        private void SetAppointmentItems()
        {
            foreach (var appointment in appointments)
            {
                int fontSize = 10;
                Label label1 = new Label();
                label1.Font = new Font("Arial", fontSize, FontStyle.Bold);
                label1.Text = appointment.Start.ToShortDateString();

                Label label2 = new Label();
                label2.Font = new Font("Arial", 10);
                var margin = label2.Margin;
                margin.Left = 15;
                label2.Text = "Something Else";
                label2.Margin = margin;

                layoutPanel.Controls.Add(label1);
                layoutPanel.Controls.Add(label2);
            }
        }


    }
}
