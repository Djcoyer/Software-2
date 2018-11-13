namespace Software2.Views.Appointment
{
    partial class AppointmentForm
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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.s = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.s.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(21, 85);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(207, 22);
            this.titleTextBox.TabIndex = 1;
            // 
            // s
            // 
            this.s.Controls.Add(this.label10);
            this.s.Controls.Add(this.descriptionTextBox);
            this.s.Controls.Add(this.cancelButton);
            this.s.Controls.Add(this.saveButton);
            this.s.Controls.Add(this.errorLabel);
            this.s.Controls.Add(this.label9);
            this.s.Controls.Add(this.label8);
            this.s.Controls.Add(this.endTimePicker);
            this.s.Controls.Add(this.label7);
            this.s.Controls.Add(this.startTimePicker);
            this.s.Controls.Add(this.label2);
            this.s.Controls.Add(this.datePicker);
            this.s.Controls.Add(this.label6);
            this.s.Controls.Add(this.label5);
            this.s.Controls.Add(this.UrlTextBox);
            this.s.Controls.Add(this.contactTextBox);
            this.s.Controls.Add(this.label4);
            this.s.Controls.Add(this.locationTextBox);
            this.s.Controls.Add(this.label3);
            this.s.Controls.Add(this.customerTextBox);
            this.s.Controls.Add(this.label1);
            this.s.Controls.Add(this.titleTextBox);
            this.s.Location = new System.Drawing.Point(45, 32);
            this.s.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(599, 548);
            this.s.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Description*";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(23, 318);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(545, 56);
            this.descriptionTextBox.TabIndex = 6;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(23, 469);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 28);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(457, 469);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 28);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(294, 505);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(54, 18);
            this.errorLabel.TabIndex = 19;
            this.errorLabel.Text = "label10";
            this.errorLabel.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "Appointment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(459, 391);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "End";
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "hh:mm tt";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(457, 411);
            this.endTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(111, 22);
            this.endTimePicker.TabIndex = 9;
            this.endTimePicker.Value = new System.DateTime(2018, 10, 2, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 391);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Start";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "hh:mm tt";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(312, 411);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(111, 22);
            this.startTimePicker.TabIndex = 8;
            this.startTimePicker.Value = new System.DateTime(2018, 10, 2, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 391);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Date*";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(21, 411);
            this.datePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datePicker.MaxDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(2018, 10, 2, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(148, 22);
            this.datePicker.TabIndex = 7;
            this.datePicker.Value = new System.DateTime(2018, 10, 2, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 224);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "URL*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contact*";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(23, 244);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(545, 22);
            this.UrlTextBox.TabIndex = 5;
            // 
            // contactTextBox
            // 
            this.contactTextBox.Location = new System.Drawing.Point(21, 167);
            this.contactTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.Size = new System.Drawing.Size(207, 22);
            this.contactTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Location*";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(312, 167);
            this.locationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(256, 22);
            this.locationTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer*";
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(308, 85);
            this.customerTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(260, 22);
            this.customerTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name*";
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 628);
            this.Controls.Add(this.s);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.s.ResumeLayout(false);
            this.s.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Panel s;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.TextBox contactTextBox;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}