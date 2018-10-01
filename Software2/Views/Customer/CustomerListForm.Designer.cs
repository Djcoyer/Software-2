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
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(24, 80);
            this.customerGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.RowTemplate.Height = 24;
            this.customerGridView.Size = new System.Drawing.Size(728, 347);
            this.customerGridView.TabIndex = 0;
            // 
            // formHeading
            // 
            this.formHeading.AutoSize = true;
            this.formHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formHeading.Location = new System.Drawing.Point(19, 26);
            this.formHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.formHeading.Name = "formHeading";
            this.formHeading.Size = new System.Drawing.Size(116, 25);
            this.formHeading.TabIndex = 1;
            this.formHeading.Text = "Customers";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(635, 26);
            this.addCustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(117, 28);
            this.addCustomerButton.TabIndex = 2;
            this.addCustomerButton.Text = "Add";
            this.addCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addCustomerButton.UseMnemonic = false;
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // editCustomerButton
            // 
            this.editCustomerButton.Location = new System.Drawing.Point(495, 446);
            this.editCustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.editCustomerButton.Name = "editCustomerButton";
            this.editCustomerButton.Size = new System.Drawing.Size(117, 28);
            this.editCustomerButton.TabIndex = 3;
            this.editCustomerButton.Text = "Edit";
            this.editCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.editCustomerButton.UseMnemonic = false;
            this.editCustomerButton.UseVisualStyleBackColor = true;
            this.editCustomerButton.Click += new System.EventHandler(this.editCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(635, 446);
            this.deleteCustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(117, 28);
            this.deleteCustomerButton.TabIndex = 4;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.deleteCustomerButton.UseMnemonic = false;
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(28, 446);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 28);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cancelButton.UseMnemonic = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CustomerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 530);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.editCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.formHeading);
            this.Controls.Add(this.customerGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button cancelButton;
    }
}