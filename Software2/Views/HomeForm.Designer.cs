namespace Software2
{
    partial class HomeForm
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
            this.headingLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.customersButton = new System.Windows.Forms.Button();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.Location = new System.Drawing.Point(25, 25);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(230, 20);
            this.headingLabel.TabIndex = 0;
            this.headingLabel.Text = "Please Select An Operation";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(127, 115);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(56, 22);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // customersButton
            // 
            this.customersButton.Location = new System.Drawing.Point(20, 115);
            this.customersButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customersButton.Name = "customersButton";
            this.customersButton.Size = new System.Drawing.Size(65, 22);
            this.customersButton.TabIndex = 2;
            this.customersButton.Text = "Customers";
            this.customersButton.UseVisualStyleBackColor = true;
            this.customersButton.Click += new System.EventHandler(this.customersButton_Click);
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Location = new System.Drawing.Point(200, 115);
            this.appointmentsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(87, 22);
            this.appointmentsButton.TabIndex = 5;
            this.appointmentsButton.Text = "Appointments";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            this.appointmentsButton.Click += new System.EventHandler(this.appointmentsButton_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 366);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.customersButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.headingLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HomeForm";
            this.Text = "Calendar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button customersButton;
        private System.Windows.Forms.Button appointmentsButton;
    }
}

