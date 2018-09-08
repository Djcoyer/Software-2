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
            {
                Id = c.customerId,
                Name = c.customerName,
                AddressId = c.addressId,
                Created = c.createDate,
                Updated = c.lastUpdate
            }).ToList();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Hide();
            _formManager.ShowForm<CustomerForm>();
        }
    }
}
