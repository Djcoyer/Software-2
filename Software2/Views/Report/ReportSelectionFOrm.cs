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

namespace Software2.Views.Report
{
    public partial class ReportSelectionForm : Form
    {
        private FormManager formManager;
        private UserService userService;
        public ReportSelectionForm(FormManager formManager, UserService userService)
        {
            this.formManager = formManager;
            this.userService = userService;
            InitializeComponent();

        }

        private void consultantScheduleButton_Click(object sender, EventArgs e)
        {
            var users = userService.FindAllUsers();
            IEnumerable<string> userNames = users.Select(u => u.userName);
            var form = formManager.GetForm<SelectionPopUp>();
            form.SetSelectionOptions(userNames);
            form.SetSubmitSelection((string selectedOption, Form popupForm) => {
                popupForm.Close();
                var scheduleForm = formManager.GetForm<ConsultantScheduleForm>();
                scheduleForm.SetUsername(selectedOption);
                Hide();
                scheduleForm.Show();
            });
            form.Show();

        }

        private void HandleSelection(string selectedOption, Form form)
        {

        }
    }
}
