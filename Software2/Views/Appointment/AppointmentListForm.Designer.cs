namespace Software2.Views.Appointment
{
    partial class AppointmentListForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.editAppointmentButton = new System.Windows.Forms.Button();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.formHeading = new System.Windows.Forms.Label();
            this.appointmentGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(72, 480);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 28);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cancelButton.UseMnemonic = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Location = new System.Drawing.Point(787, 480);
            this.deleteAppointmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(117, 28);
            this.deleteAppointmentButton.TabIndex = 10;
            this.deleteAppointmentButton.Text = "Delete";
            this.deleteAppointmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.deleteAppointmentButton.UseMnemonic = false;
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // editAppointmentButton
            // 
            this.editAppointmentButton.Location = new System.Drawing.Point(647, 480);
            this.editAppointmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.editAppointmentButton.Name = "editAppointmentButton";
            this.editAppointmentButton.Size = new System.Drawing.Size(117, 28);
            this.editAppointmentButton.TabIndex = 9;
            this.editAppointmentButton.Text = "Edit";
            this.editAppointmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.editAppointmentButton.UseMnemonic = false;
            this.editAppointmentButton.UseVisualStyleBackColor = true;
            this.editAppointmentButton.Click += new System.EventHandler(this.editAppointmentButton_Click);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(787, 32);
            this.addAppointmentButton.Margin = new System.Windows.Forms.Padding(4);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(117, 28);
            this.addAppointmentButton.TabIndex = 8;
            this.addAppointmentButton.Text = "Add";
            this.addAppointmentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addAppointmentButton.UseMnemonic = false;
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // formHeading
            // 
            this.formHeading.AutoSize = true;
            this.formHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formHeading.Location = new System.Drawing.Point(63, 32);
            this.formHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.formHeading.Name = "formHeading";
            this.formHeading.Size = new System.Drawing.Size(144, 25);
            this.formHeading.TabIndex = 7;
            this.formHeading.Text = "Appointments";
            // 
            // appointmentGridView
            // 
            this.appointmentGridView.AllowUserToAddRows = false;
            this.appointmentGridView.AllowUserToDeleteRows = false;
            this.appointmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentGridView.Location = new System.Drawing.Point(68, 86);
            this.appointmentGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.appointmentGridView.Name = "appointmentGridView";
            this.appointmentGridView.ReadOnly = true;
            this.appointmentGridView.RowTemplate.Height = 24;
            this.appointmentGridView.Size = new System.Drawing.Size(836, 368);
            this.appointmentGridView.TabIndex = 6;
            // 
            // AppointmentListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 593);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.editAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.formHeading);
            this.Controls.Add(this.appointmentGridView);
            this.Name = "AppointmentListForm";
            this.Text = "AppointmentListForm";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button editAppointmentButton;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Label formHeading;
        private System.Windows.Forms.DataGridView appointmentGridView;
    }
}