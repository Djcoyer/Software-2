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
        public SelectionPopUp()
        {
            InitializeComponent();
        }

        public void SetSelectionOptions(IEnumerable<string> selectionOptions)
        {
            this.SelectionOptions = selectionOptions; 
            selectionComboBox.Items.AddRange(selectionOptions.ToArray());
        }

        public void SetSubmitSelection(SubmitSelection submitSelection)
        {
            this.submitSelection = submitSelection;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string selectedOption = selectionComboBox.SelectedItem.ToString();
            submitSelection(selectedOption, this);
        }
    }
}
