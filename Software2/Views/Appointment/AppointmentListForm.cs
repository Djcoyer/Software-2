﻿using Software2.Models;
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
    public partial class AppointmentListForm : Form
    {
        private IFormManager _formManager;
        private AppointmentService appointmentService;
        private IEnumerable<AppointmentAggregate> appointments;
        private BindingSource appointmentBindingSource;
        private ReminderService reminderService;

        public AppointmentListForm(IFormManager formManager, AppointmentService appointmentService, ReminderService reminderService)
        {
            _formManager = formManager;
            this.appointmentService = appointmentService;
            this.reminderService = reminderService;
            appointments = appointmentService.FindAllAggregates();
            InitializeComponent();
            appointmentBindingSource = new BindingSource();
            initBindingSource(appointments);
            appointmentGridView.DataSource = appointmentBindingSource;
        }

        private AppointmentAggregate GetItemFromSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count <= 0) return null;
            if (gridView.SelectedRows.Count > 1) { }
            var selectedRow = gridView.SelectedRows[0];
            var rowAppointment= selectedRow.DataBoundItem as AppointmentRow;
            if (rowAppointment == null)
                return null;
            return new AppointmentAggregate()
            {
                Contact = rowAppointment.Contact,
                CustomerName = rowAppointment.CustomerName,
                Id = rowAppointment.Id
            };
        }

        private void editAppointmentButton_Click(object sender, EventArgs e)
        {
            var rowAggregate = GetItemFromSelectedRow(appointmentGridView);
            if (rowAggregate == null)
                return;
            var aggregate = appointments.Where(a => a.Id == rowAggregate.Id).FirstOrDefault();
            var appointmentForm = _formManager.GetForm<AppointmentForm>();
            appointmentForm.SetAggregate(aggregate);
            appointmentForm.Show();
            Close();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            _formManager.ShowForm<AppointmentForm>();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _formManager.ShowForm<HomeForm>();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            var selectedAppointment = GetItemFromSelectedRow(appointmentGridView);
            if (selectedAppointment == null)
                return;
            var id = selectedAppointment.Id;
            appointmentService.Delete(id);
            reminderService.DeleteByAppointmentId(id);
            List<AppointmentAggregate> newAppointmentList = appointments.ToList();
            newAppointmentList.Remove(appointments.First(p => p.Id == id));
            initBindingSource(newAppointmentList);
            appointmentBindingSource.ResetBindings(false);
        }

        private void initBindingSource(IEnumerable<AppointmentAggregate> appointments)
        {
            appointmentBindingSource.DataSource = appointments.Select(a =>
            new AppointmentRow()
            {
                Id = a.Id,
                Title = a.Title,
                Contact = a.Contact,
                StartDate = a.Start.ToShortDateString(),
                Location = a.Location,
                CustomerName = a.CustomerName
            }).ToList();
        }
    }
}
