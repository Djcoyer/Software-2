using Software2.Models;
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
    public delegate void Done(Form form);
    public partial class ReportForm : Form
    {
        public Done onDoneClick;
        private IEnumerable<ReportBase> reportItems;

        public ReportForm()
        {
            InitializeComponent();
        }

        public void SetReportItems(IEnumerable<ReportBase> reportItems)
        {
            this.reportItems = reportItems;
            InitializeReportItems();
        }

        private void InitializeReportItems()
        {
            foreach (var reportItem in reportItems)
            {
                int fontSize = 12;
                Label reportItemLabel = new Label();
                reportItemLabel.Font = new Font("Arial", fontSize, FontStyle.Bold);
                reportItemLabel.Text = reportItem.Title;
                var itemMargin = reportItemLabel.Margin;
                itemMargin.Top = 15;
                itemMargin.Left = 0;
                reportItemLabel.Margin = itemMargin;

                layoutPanel.Controls.Add(reportItemLabel);


                Dictionary<string, string> properties = reportItem.Properties;
                properties.Keys.ToList().ForEach(key =>
                {
                    var itemLabel = new Label();
                    itemLabel.Width = 250;
                    itemLabel.UseCompatibleTextRendering = true;
                    itemLabel.Font = new Font("Arial", 10);
                    var margin = itemLabel.Margin;
                    margin.Left = 8;
                    itemLabel.Text = String.Format("{0}: {1}", key, properties[key]);
                    itemLabel.Margin = margin;
                    layoutPanel.Controls.Add(itemLabel);
                });
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            onDoneClick(this);
        }
    }
}
