namespace LoginApp
{
    partial class EmployeeForm
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
            this.btnAddAdvertisment = new System.Windows.Forms.Button();
            this.btnEditAdvertisment = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAdvertisment
            // 
            this.btnAddAdvertisment.Location = new System.Drawing.Point(170, 81);
            this.btnAddAdvertisment.Name = "btnAddAdvertisment";
            this.btnAddAdvertisment.Size = new System.Drawing.Size(186, 23);
            this.btnAddAdvertisment.TabIndex = 0;
            this.btnAddAdvertisment.Text = "Add an Advertisment";
            this.btnAddAdvertisment.UseVisualStyleBackColor = true;
            this.btnAddAdvertisment.Click += new System.EventHandler(this.btnAddAdvertisment_Click);
            // 
            // btnEditAdvertisment
            // 
            this.btnEditAdvertisment.Location = new System.Drawing.Point(170, 139);
            this.btnEditAdvertisment.Name = "btnEditAdvertisment";
            this.btnEditAdvertisment.Size = new System.Drawing.Size(186, 23);
            this.btnEditAdvertisment.TabIndex = 1;
            this.btnEditAdvertisment.Text = "Edit/Delete an Advertisment";
            this.btnEditAdvertisment.UseVisualStyleBackColor = true;
            this.btnEditAdvertisment.Click += new System.EventHandler(this.btnEditAdvertisment_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(405, 230);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 19);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(301, 230);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(100, 19);
            this.btnChangePass.TabIndex = 6;
            this.btnChangePass.Text = "Change password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 261);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnEditAdvertisment);
            this.Controls.Add(this.btnAddAdvertisment);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddAdvertisment;
        private System.Windows.Forms.Button btnEditAdvertisment;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePass;
    }
}