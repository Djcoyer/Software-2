﻿using Software2.Repositories.Implementation;
using Software2.Views.City;
using Software2.Views.Customer;
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

namespace Software2
{

    public delegate void CloseForm(Form form);

    public partial class HomeForm : Form
    {
        public bool isLoggedIn = false;
        private IFormManager _formManager;
        public AuthRepository _authRepository { get; set; }

        public HomeForm(IFormManager formManager, AuthRepository authRepository)
        {
            _authRepository = authRepository;
            this._formManager = formManager;
            InitializeComponent();
            if(!_authRepository.UserAuthenticated)
            {
                customersButton.Hide();
                addressButton.Hide();
                citiesButton.Hide();
                customersButton.Hide();
                appointmentsButton.Hide();
                loginButton.Show();
            }
            else
            {
                customersButton.Show();
                addressButton.Show();
                citiesButton.Show();
                customersButton.Show();
                appointmentsButton.Show();
                loginButton.Hide();
            }
        }

        private void SetUserAuthenticated(string username)
        {
            _authRepository.EmailAddress = username;
            _authRepository.UserAuthenticated = true;
            customersButton.Show();
            addressButton.Show();
            citiesButton.Show();
            customersButton.Show();
            appointmentsButton.Show();
            loginButton.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var loginForm = _formManager.GetForm<LoginForm>() as LoginForm;

            loginForm.setUserAuthenticated = (Form form, string username) =>
            {
                SetUserAuthenticated(username);
                form.Close();
                Show();
            };

            loginForm.Show();
            this.Hide();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _formManager.ShowForm<CustomerListForm>();
        }

        private void citiesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            _formManager.ShowForm<CityListForm>();
        }
    }
}
