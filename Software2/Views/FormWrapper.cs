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
    public partial class FormWrapper : Form
    {
        private CalendarEntities _db;
        private bool authenticated = false;
        private HomeForm homeForm;
        private LoginForm loginForm;
        private UserService userService;

        public FormWrapper(CalendarEntities db, UserService userService)
        {
            InitializeComponent();
            this._db = db;
            this.userService = userService;
            this.loginForm = new LoginForm(userService, SetUserAuthenticated);

            this.homeForm = new HomeForm();
            if (!this.authenticated)
            {
                loginForm.Show();
                this.Hide();
            }
        }


        public void SetUserAuthenticated(Form form, string username)
        {
            form.Close();
            Console.WriteLine(username);
            this.authenticated = true;
            homeForm.Show();
        }
    }
}
