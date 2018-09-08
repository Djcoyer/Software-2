namespace Software2.Views.Customer
{
    partial class CustomerListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.formHeading = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.editCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(18, 65);
            this.customerGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.RowTemplate.Height = 24;
            this.customerGridView.Size = new System.Drawing.Size(546, 282);
            this.customerGridView.TabIndex = 0;
            // 
            // formHeading
            // 
            this.formHeading.AutoSize = true;
            this.formHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formHeading.Location = new System.Drawing.Point(14, 21);
            this.formHeading.Name = "formHeading";
            this.formHeading.Size = new System.Drawing.Size(95, 20);
            this.formHeading.TabIndex = 1;
            this.formHeading.Text = "Customers";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(476, 21);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(88, 23);
            this.addCustomerButton.TabIndex = 2;
            this.addCustomerButton.Text = "Add";
            this.addCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addCustomerButton.UseMnemonic = false;
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // editCustomerButton
            // 
            this.editCustomerButton.Location = new System.Drawing.Point(371, 362);
            this.editCustomerButton.Name = "editCustomerButton";
            this.editCustomerButton.Size = new System.Drawing.Size(88, 23);
            this.editCustomerButton.TabIndex = 3;
            this.editCustomerButton.Text = "Edit";
            this.editCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.editCustomerButton.UseMnemonic = false;
            this.editCustomerButton.UseVisualStyleBackColor = true;
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(476, 362);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(88, 23);
            this.deleteCustomerButton.TabIndex = 4;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.deleteCustomerButton.UseMnemonic = false;
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            // 
            // CustomerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 431);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.editCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.formHeading);
            this.Controls.Add(this.customerGridView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerListForm";
            this.Text = "CustomerListForm";
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.Label formHeading;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button editCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
    }
}