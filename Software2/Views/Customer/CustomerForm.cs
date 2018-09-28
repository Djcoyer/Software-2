using Software2.Models;
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
        private int customerId;
        private IFormManager _formManager;

        public CustomerForm(CustomerService customerService, AddressService addressService, IFormManager formManager)
        {
            _formManager = formManager;
            this.customerService = customerService;
            this.addressService = addressService;
            InitializeComponent();
        }

        public void SetCustomer(customer customer)
        {
            this.customer = customer;
            string[] fullName = customer.customerName.Split(' ');
            firstNameTextBox.Text = fullName[0];
            lastNameTextBox.Text = fullName[1];
            var address = addressService.FindOne(customer.addressId);
            address1TextBox.Text = address.address1;
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
            var address1 = address1TextBox.Text;
            var address2 = address2TextBox.Text;
            var postalCode = postalTextBox.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            address address;
            try
            {
                address = addressService.FindByAddressAndPostalCode(address1, address2, postalCode);
            }catch(NotFoundException e)
            {
                var addressAggregate = new AddressAggregate()
                {
                    Address1 = address1,
                    Address2 = address2,
                    CityName = cityTextBox.Text,
                    CountryName = countryTextBox.Text,
                    Phone = phoneTextBox.Text,
                    PostalCode = postalCode
                };
                addressService.addNewAddress(addressAggregate);
                address = addressService.FindByAddressAndPostalCode(address1, address2, postalCode);
            } catch(InvalidInputException e)
            {
                errorLabel.Text = e.Message;
                return;
            }
            customer.addressId = address.addressId;
            customer.customerName = String.Format("{0} {1}", firstName, lastName);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _formManager.ShowForm<CustomerListForm>();
        }
    }
}
