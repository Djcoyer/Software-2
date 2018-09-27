using Software2.Models;
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

namespace Software2.Views.Customer
{
    public partial class CustomerListForm : Form
    {
        private CustomerService customerService;
        private List<customer> customers;
        private IFormManager _formManager;
        public CustomerListForm(CustomerService customerService, IFormManager formManager)
        {
            this.customerService = customerService;
            _formManager = formManager;
            customers = customerService.FindAllCustomers();
            InitializeComponent();
            customerGridView.DataSource = customers.Select(c => new 
            CustomerRow {
                Id = c.customerId,
                Name = c.customerName,
                AddressId = c.addressId,
                Created = c.createDate,
                Updated = c.lastUpdate
            }).ToList();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Close();
            _formManager.ShowForm<CustomerForm>();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            _formManager.ShowForm<HomeForm>();
        }


        public static customer GetItemFromSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count <= 0) return null;
            if (gridView.SelectedRows.Count > 1) { }
            var selectedRow = gridView.SelectedRows[0];
            var rowCustomer = selectedRow.DataBoundItem as CustomerRow;
            return new customer()
            {
                customerId = rowCustomer.Id,
                customerName = rowCustomer.Name,
                createDate = rowCustomer.Created,
                lastUpdate = rowCustomer.Updated,
                addressId = rowCustomer.AddressId
            };
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            var _customer = GetItemFromSelectedRow(customerGridView);
            if (_customer == null)
                return;
            var customerForm = _formManager.GetForm<CustomerForm>();
            customerForm.SetCustomer(_customer);
            customerForm.Show();
            this.Close();
        }
    }
}
