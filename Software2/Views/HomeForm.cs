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
    public partial class HomeForm : Form
    {
        public bool isLoggedIn = false;
        private LoginForm loginForm;
        private CustomerListForm customerListForm;

        public HomeForm(LoginForm loginForm, CustomerListForm customerListForm)
        {
            this.loginForm = loginForm;
            this.customerListForm = customerListForm;
            InitializeComponent();
            if(!isLoggedIn)
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
            customersButton.Show();
            addressButton.Show();
            citiesButton.Show();
            customersButton.Show();
            appointmentsButton.Show();
            loginButton.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginForm.setUserAuthenticated = (Form form, string username) =>
            {
                this.SetUserAuthenticated(username);
                form.Close();
                this.Show();
            };

            loginForm.Show();
            this.Hide();
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerListForm.Show();
        }
    }
}
