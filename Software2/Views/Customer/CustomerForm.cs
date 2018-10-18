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
        private CustomerAggregate customer;
        private IFormManager _formManager;

        public CustomerForm(CustomerService customerService, AddressService addressService, IFormManager formManager)
        {
            _formManager = formManager;
            this.customerService = customerService;
            this.addressService = addressService;
            InitializeComponent();
        }

        public void SetCustomer(CustomerAggregate customerAggregate)
        {
            customer = customerAggregate;
            var address = addressService.FindOne(customer.AddressId);
            SetFields();
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (customer == null)
                {
                    AddCustomer();
                }

                else
                {
                    UpdateCustomer();
                }
            } catch (Exception ex)
            {
                if(ex.GetType() == typeof(NotFoundException) || ex.GetType() == typeof(InvalidInputException))
                {
                    errorLabel.Text = ex.Message;
                    errorLabel.Show();
                    return;
                }
            }
            errorLabel.Hide();
            _formManager.ShowForm<CustomerListForm>();
            this.Close();
        }

        private void AddCustomer()
        {
            customer = new CustomerAggregate();
            UpdateFields();
            validateFields();

            var addressId = UpdateAddress();

            customer.AddressId = addressId;
            customerService.Add(customer);
        }
        private void UpdateCustomer()
        {
            UpdateFields();
            validateFields();
            int addressId = UpdateAddress();
            customer.AddressId = addressId;
            customerService.Update(customer, customer.Id);
        }

        private void UpdateFields()
        {
            UpdateAddressFields();
            UpdateCustomerFields();
        }

        private void SetFields()
        {
            string[] fullName = customer.CustomerName.Split(' ');
            firstNameTextBox.Text = fullName[0];
            lastNameTextBox.Text = fullName[1];
            address1TextBox.Text = customer.Address1;
            address2TextBox.Text = customer.Address2;
            postalTextBox.Text = customer.PostalCode;
            phoneTextBox.Text = customer.Phone;
            cityTextBox.Text = customer.City;
            countryTextBox.Text = customer.Country;
        }

        private int UpdateAddress()
        {
            address address;
            var addressAggregate = new AddressAggregate()
            {
                Address1 = customer.Address1,
                Address2 = customer.Address2,
                PostalCode = customer.PostalCode,
                CountryName = customer.Country,
                CityName = customer.City,
                Phone = customer.Phone
            };

            try
            {
                address = addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                addressAggregate.CityId = address.cityId;
                addressAggregate.AddressId = address.addressId;
                addressService.UpdateAddress(addressAggregate);
            }
            catch (NotFoundException e)
            {
                addressService.addNewAddress(addressAggregate);
                address = addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
            }

            return address.addressId;
        }

        private void validateFields()
        {
            if (String.IsNullOrWhiteSpace(customer.Address1))
                throw new InvalidInputException("Must supply valid address");
            if (String.IsNullOrWhiteSpace(customer.CustomerName))
                throw new InvalidInputException("Must supply customer name");
            if (String.IsNullOrWhiteSpace(customer.City))
                throw new InvalidInputException("Must supply city");
            if (String.IsNullOrWhiteSpace(customer.Country))
                throw new InvalidInputException("Must supply country");
            if (String.IsNullOrWhiteSpace(customer.PostalCode))
                throw new InvalidInputException("Must supply postal code");
        }

        private void UpdateCustomerFields()
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            customer.CustomerName = String.Format("{0} {1}", firstName, lastName);
        }

        private void UpdateAddressFields()
        {
            var address1 = address1TextBox.Text;
            var address2 = address2TextBox.Text;
            var postalCode = postalTextBox.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var city = cityTextBox.Text;
            var country = countryTextBox.Text;
            var phone = phoneTextBox.Text;
            customer.Address1 = address1;
            customer.Address2 = address2;
            customer.Country = country;
            customer.City = city;
            customer.PostalCode = postalCode;
            customer.Phone = phone;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _formManager.ShowForm<CustomerListForm>();
        }
    }
}
