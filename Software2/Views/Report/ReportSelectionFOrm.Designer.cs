namespace Software2.Views.Report
{
    partial class ReportSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.consultantScheduleButton = new System.Windows.Forms.Button();
            this.appointmentTypeButton = new System.Windows.Forms.Button();
            this.customerScheduleButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reports";
            // 
            // consultantScheduleButton
            // 
            this.consultantScheduleButton.Location = new System.Drawing.Point(80, 106);
            this.consultantScheduleButton.Name = "consultantScheduleButton";
            this.consultantScheduleButton.Size = new System.Drawing.Size(267, 42);
            this.consultantScheduleButton.TabIndex = 1;
            this.consultantScheduleButton.Text = "Consultant Schedule";
            this.consultantScheduleButton.UseVisualStyleBackColor = true;
            this.consultantScheduleButton.Click += new System.EventHandler(this.consultantScheduleButton_Click);
            // 
            // appointmentTypeButton
            // 
            this.appointmentTypeButton.Location = new System.Drawing.Point(80, 190);
            this.appointmentTypeButton.Name = "appointmentTypeButton";
            this.appointmentTypeButton.Size = new System.Drawing.Size(267, 42);
            this.appointmentTypeButton.TabIndex = 2;
            this.appointmentTypeButton.Text = "Appointment Types";
            this.appointmentTypeButton.UseVisualStyleBackColor = true;
            this.appointmentTypeButton.Click += new System.EventHandler(this.appointmentTypeButton_Click);
            // 
            // customerScheduleButton
            // 
            this.customerScheduleButton.Location = new System.Drawing.Point(80, 272);
            this.customerScheduleButton.Name = "customerScheduleButton";
            this.customerScheduleButton.Size = new System.Drawing.Size(267, 42);
            this.customerScheduleButton.TabIndex = 3;
            this.customerScheduleButton.Text = "Customer Appointments";
            this.customerScheduleButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(80, 358);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(267, 42);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Back";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // ReportSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 429);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.customerScheduleButton);
            this.Controls.Add(this.appointmentTypeButton);
            this.Controls.Add(this.consultantScheduleButton);
            this.Controls.Add(this.label1);
            this.Name = "ReportSelectionForm";
            this.Text = "ReportSelectionFOrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button consultantScheduleButton;
        private System.Windows.Forms.Button appointmentTypeButton;
        private System.Windows.Forms.Button customerScheduleButton;
        private System.Windows.Forms.Button exitButton;
    }
}