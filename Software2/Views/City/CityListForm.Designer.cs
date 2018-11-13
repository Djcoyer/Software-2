namespace Software2.Views.City
{
    partial class CityListForm
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
            this.cityGridView = new System.Windows.Forms.DataGridView();
            this.titleLabel = new System.Windows.Forms.Label();
            this.addCityButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteCityButton = new System.Windows.Forms.Button();
            this.editCityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cityGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cityGridView
            // 
            this.cityGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cityGridView.Location = new System.Drawing.Point(35, 67);
            this.cityGridView.Name = "cityGridView";
            this.cityGridView.RowTemplate.Height = 24;
            this.cityGridView.Size = new System.Drawing.Size(726, 351);
            this.cityGridView.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(32, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(67, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Cities";
            // 
            // addCityButton
            // 
            this.addCityButton.Location = new System.Drawing.Point(644, 18);
            this.addCityButton.Margin = new System.Windows.Forms.Padding(4);
            this.addCityButton.Name = "addCityButton";
            this.addCityButton.Size = new System.Drawing.Size(117, 28);
            this.addCityButton.TabIndex = 3;
            this.addCityButton.Text = "Add";
            this.addCityButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addCityButton.UseMnemonic = false;
            this.addCityButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(37, 429);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 28);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.cancelButton.UseMnemonic = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // deleteCityButton
            // 
            this.deleteCityButton.Location = new System.Drawing.Point(644, 429);
            this.deleteCityButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteCityButton.Name = "deleteCityButton";
            this.deleteCityButton.Size = new System.Drawing.Size(117, 28);
            this.deleteCityButton.TabIndex = 7;
            this.deleteCityButton.Text = "Delete";
            this.deleteCityButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.deleteCityButton.UseMnemonic = false;
            this.deleteCityButton.UseVisualStyleBackColor = true;
            // 
            // editCityButton
            // 
            this.editCityButton.Location = new System.Drawing.Point(504, 429);
            this.editCityButton.Margin = new System.Windows.Forms.Padding(4);
            this.editCityButton.Name = "editCityButton";
            this.editCityButton.Size = new System.Drawing.Size(117, 28);
            this.editCityButton.TabIndex = 6;
            this.editCityButton.Text = "Edit";
            this.editCityButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.editCityButton.UseMnemonic = false;
            this.editCityButton.UseVisualStyleBackColor = true;
            // 
            // CityListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 523);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteCityButton);
            this.Controls.Add(this.editCityButton);
            this.Controls.Add(this.addCityButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cityGridView);
            this.Name = "CityListForm";
            this.Text = "CityListForm";
            ((System.ComponentModel.ISupportInitialize)(this.cityGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cityGridView;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button addCityButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteCityButton;
        private System.Windows.Forms.Button editCityButton;
    }
}