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
    public delegate void SubmitSelection(string selectedOption, Form form);
    public partial class SelectionPopUp : Form
    {
        private IEnumerable<string> SelectionOptions;
        private SubmitSelection submitSelection;
        public bool IsDateSelection { get; set; }
        public SelectionPopUp()
        {
            InitializeComponent();
            datePicker.Visible = false;
            datePicker.Enabled = false;
        }

        public void SetSelectionOptions(IEnumerable<string> selectionOptions)
        {
            SelectionOptions = selectionOptions; 
            selectionComboBox.Items.AddRange(selectionOptions.ToArray());
            selectionComboBox.SelectedIndex = (selectionOptions.Count() > 0 ? 0 : -1);
        }

        public void SetDateSelection(bool isDateSelection)
        {
            datePicker.Visible = isDateSelection;
            datePicker.Enabled = isDateSelection    ;
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "MM/yyyy";
            selectionComboBox.Enabled = !isDateSelection;
            selectionComboBox.Visible = !isDateSelection;
            IsDateSelection = isDateSelection;
        }

        public void SetSubmitSelection(SubmitSelection submitSelection)
        {
            this.submitSelection = submitSelection;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string selectedOption = IsDateSelection ? datePicker.Value.ToShortDateString() : selectionComboBox.SelectedItem.ToString();
            submitSelection(selectedOption, this);
        }
    }
}
