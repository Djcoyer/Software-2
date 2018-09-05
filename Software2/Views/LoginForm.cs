using Software2.Services;
using Software2.Views.manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2
{

    public delegate void SetUserAuthenticated(Form form, string username);

    public partial class LoginForm : Form
    { 
        public SetUserAuthenticated setUserAuthenticated;
        private UserService userService;
        public LoginForm(UserService userService) : base()
        {
            InitializeComponent();
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.MaxLength = 10;
            this.userService = userService;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextbox.Text;
            var password = passwordTextbox.Text;
            try
            {
                userService.ValidateCredentials(username, password);
                errorLabel.Hide();
                setUserAuthenticated(this, username);

            } catch(Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Show();
            }
        }
    }
}
