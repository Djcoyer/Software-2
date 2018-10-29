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
        private List<CustomerAggregate> customers;
        private IFormManager _formManager;
        private BindingSource customerBindingSource;
        public CustomerListForm(CustomerService customerService, IFormManager formManager)
        {
            this.customerService = customerService;
            _formManager = formManager;
            customers = customerService.FindAllAggregates()?.ToList();
            InitializeComponent();
            customerBindingSource = new BindingSource();
            InitBindingSource();
            customerGridView.DataSource = customerBindingSource; 
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


        private CustomerAggregate GetItemFromSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count <= 0) return null;
            if (gridView.SelectedRows.Count > 1) { }
            var selectedRow = gridView.SelectedRows[0];
            var rowCustomer = selectedRow.DataBoundItem as CustomerRow;
            if (rowCustomer == null)
                return null;
            int id = rowCustomer.Id;
            return customers.FirstOrDefault(p => p.Id == id);
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            var customerAggregate = GetItemFromSelectedRow(customerGridView);
            if (customerAggregate == null)
                return;
            var customerForm = _formManager.GetForm<CustomerForm>();
            customerForm.SetCustomer(customerAggregate);
            customerForm.Show();
            this.Close();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            var _customer = GetItemFromSelectedRow(customerGridView);
            if (_customer == null)
                return;
            var customerId = _customer.Id;
            customerService.Delete(customerId);

            customers.Remove(_customer);
            InitBindingSource();
            customerBindingSource.ResetBindings(false);
        }

        private void InitBindingSource()
        {
            //Select certain fields with lambda expression to form new object, similar to a ViewModel
            customerBindingSource.DataSource = customers.Select(c => new
            CustomerRow
            {
                Id = c.Id,
                Name = c.CustomerName,
                Address = String.Format("{0} {1}", c.Address1, c.Address2),
                Phone = c.Phone,
                AddressId = c.AddressId
            }).ToList();
        }
    }
}
