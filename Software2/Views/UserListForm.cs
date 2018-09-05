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

namespace Software2.Views
{
    public partial class UserListForm : Form
    {
        private UserService userService;
        private List<user> users;

        public UserListForm(UserService userService)
        {
            this.userService = userService;
            this.users = userService.FindAllUsers();
            InitializeComponent();
        }
    }
}
