using Software2.Models.Exceptions;
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
    public partial class CustomerForm : Form
    {
        private CustomerService customerService;
        private AddressService addressService;
        private customer customer;
        private List<address> addresses;
        private int customerId;
        private IFormManager _formManager;

        public CustomerForm(CustomerService customerService, AddressService addressService, IFormManager formManager)
        {
            _formManager = formManager;
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

        public void SetCustomer(customer customer)
        {
            this.customer = customer;
            string[] fullName = customer.customerName.Split(' ');
            firstNameTextBox.Text = fullName[0];
            lastNameTextBox.Text = fullName[1];
            var address = addressService.FindOne(customer.addressId);
            addressTextBox.Text = address.address1;
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
            try
            {
                updateFields(customer);
                customerService.Update(customer, customerId);
            }
            catch (Exception e)
            {
                if(e.GetType() == typeof(NotFoundException) || e.GetType() == typeof(InvalidInputException))
                {
                    string message = e.Message;
                }

            }
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
                throw new InvalidInputException("Must input first and last name");
            customer.addressId = existingAddress.addressId;
            customer.customerName = String.Format("{0} {1}", firstName, lastName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _formManager.ShowForm<CustomerListForm>();
        }
    }
}
