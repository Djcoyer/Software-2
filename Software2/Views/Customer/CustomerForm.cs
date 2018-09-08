using Software2.Models.Exceptions;
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

namespace Software2.Views.Customer
{
    public partial class CustomerForm : Form
    {
        private CustomerService customerService;
        private AddressService addressService;
        private customer customer;
        private List<address> addresses;
        private int customerId;

        public CustomerForm(CustomerService customerService, AddressService addressService)
        {
            this.customerService = customerService;
            this.addressService = addressService;
            addresses = addressService.FindAll().ToList();
            InitializeComponent();
            var source = new AutoCompleteStringCollection();
            source.AddRange(addresses.Select(a => a.address1).ToArray());
            addressTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            addressTextBox.AutoCompleteCustomSource = source;
            addressTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        public void SetId(int id)
        {
            customerId = id;
            customer = customerService.FindOne(id);
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            if (this.customer == null)
                AddCustomer();
            else
                UpdateCustomer();
        }

        private void AddCustomer()
        {
            var customer = new customer();
            updateFields(customer);
            customerService.Add(customer);
        }

        private void UpdateCustomer()
        {
            updateFields(customer);
            customerService.Update(customer, customerId);
        }

        private void updateFields(customer customer)
        {
            var addressValue = addressTextBox.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var existingAddress = addresses.FirstOrDefault(a => a.address1.Equals(addressValue));
            if (existingAddress == null)
                throw new NotFoundException("Must input a valid address or create a new address");
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
                throw new Exception("Must input first and last name");
            customer.addressId = existingAddress.addressId;
            customer.customerName = String.Format("{0} {1}", firstName, lastName);
        }
    }
}
