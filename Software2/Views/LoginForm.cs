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

namespace Software2
{

    public delegate void SetUserAuthenticated(Form form, string username);

    public partial class LoginForm : Form
    {
        private UserService userService;
        private SetUserAuthenticated setUserAuthenticated;
        public LoginForm(UserService userService, SetUserAuthenticated setUserAuthenticated):base()
        {
            InitializeComponent();
            passwordTextbox.PasswordChar = '*';
            passwordTextbox.MaxLength = 10;
            this.userService = userService;
            this.setUserAuthenticated = setUserAuthenticated;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextbox.Text;
            var password = passwordTextbox.Text;
            if(userService.ValidateCredentials(username, password))
            {
                this.setUserAuthenticated(this, username);
            }
        }
    }
}
