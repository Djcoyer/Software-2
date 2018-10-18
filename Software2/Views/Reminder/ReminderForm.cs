using Software2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2.Views.Reminder
{
 
    public partial class ReminderForm : Form
    {
        private ReminderAggregate aggregate;

        public ReminderForm()
        {
            InitializeComponent();
        }

        public void SetAggregate(ReminderAggregate aggregate)
        {
            this.aggregate = aggregate;
            SetFields();
        }

        private void SetFields()
        {
            customerLabel.Text = String.Format("Customer: {0}", aggregate.CustomerName);
            this.locationLabel.Text = string.Format("Location: {0}", aggregate.Location);
            this.timeLabel.Text = string.Format("Start Time: {0}", aggregate.StartTime.ToShortDateString());
        }


    }
}
