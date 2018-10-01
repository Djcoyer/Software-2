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
        private AddressAggregate addressAggregate;
        private customer customer;
        private int customerId;
        private IFormManager _formManager;

        public CustomerForm(CustomerService customerService, AddressService addressService, IFormManager formManager)
        {
            _formManager = formManager;
            this.customerService = customerService;
            this.addressService = addressService;
            addressAggregate = new AddressAggregate();
            InitializeComponent();
        }

        public void SetCustomer(customer customer)
        {
            this.customer = customer;
            var address = addressService.FindOne(customer.addressId);
            addressAggregate = addressService.FindAggregateById(customer.addressId);
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
                    return;
                }
            }
            errorLabel.Hide();
            _formManager.ShowForm<CustomerListForm>();
            this.Close();
        }

        private void AddCustomer()
        {
            var addressAggregate = GetAddressAggregateFromFields();
            var customer = new customer();
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            customer.customerName = String.Format("{0} {1}", firstName, lastName);

            validateFields(customer, addressAggregate);

            var addressId = UpdateAddress(addressAggregate);

           

            customer.addressId = addressId;
            customerService.Add(customer);
        }
        private void UpdateCustomer()
        {
            var addressAggregate = GetAddressAggregateFromFields();
            validateFields(customer, addressAggregate);
            int addressId = UpdateAddress(addressAggregate);
            customer.addressId = addressId;
            customerService.Update(customer, customer.customerId);
        }

        private void SetFields()
        {
            string[] fullName = customer.customerName.Split(' ');
            firstNameTextBox.Text = fullName[0];
            lastNameTextBox.Text = fullName[1];
            address1TextBox.Text = addressAggregate.Address1;
            address2TextBox.Text = addressAggregate.Address2;
            postalTextBox.Text = addressAggregate.PostalCode;
            phoneTextBox.Text = addressAggregate.Phone;
            cityTextBox.Text = addressAggregate.CityName;
            countryTextBox.Text = addressAggregate.CountryName;
        }

        private int UpdateAddress(AddressAggregate addressAggregate)
        {

            address address;
            try
            {
                address = addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
                addressService.UpdateAddress(addressAggregate);
            }
            catch (NotFoundException e)
            {
                addressService.addNewAddress(addressAggregate);
                address = addressService.FindByAddressAndPostalCode(addressAggregate.Address1, addressAggregate.Address2, addressAggregate.PostalCode);
            }

            return address.addressId;
        }

        private void validateFields(customer customer, AddressAggregate addressAggregate)
        {
            if (String.IsNullOrWhiteSpace(addressAggregate.Address1))
                throw new InvalidInputException("Must supply valid address");
            if (String.IsNullOrWhiteSpace(customer.customerName))
                throw new InvalidInputException("Must supply customer name");
            if (String.IsNullOrWhiteSpace(addressAggregate.CityName))
                throw new InvalidInputException("Must supply city");
            if (String.IsNullOrWhiteSpace(addressAggregate.CountryName))
                throw new InvalidInputException("Must supply country");
            if (String.IsNullOrWhiteSpace(addressAggregate.PostalCode))
                throw new InvalidInputException("Must supply postal code");
        }

        private AddressAggregate GetAddressAggregateFromFields()
        {
            var address1 = address1TextBox.Text;
            var address2 = address2TextBox.Text;
            var postalCode = postalTextBox.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var city = cityTextBox.Text;
            var country = countryTextBox.Text;
            var phone = phoneTextBox.Text;

            return new AddressAggregate()
            {
                Address1 = address1,
                Address2 = address2,
                CountryName = country,
                CityName = city,
                PostalCode = postalCode,
                Phone = phone,
                AddressId = addressAggregate.AddressId,
                CountryId = addressAggregate.CountryId,
                CityId = addressAggregate.CityId
            };
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _formManager.ShowForm<CustomerListForm>();
        }
    }
}
