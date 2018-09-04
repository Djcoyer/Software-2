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
        private IFormManager _formManager;
        public bool isLoggedIn = false;

        public HomeForm(IFormManager formManager)
        {
            this._formManager = formManager;
            InitializeComponent();
            if(!isLoggedIn)
            {
                this.Hide();
                _formManager.ShowForm<LoginForm>();
            }
        }


    }
}
