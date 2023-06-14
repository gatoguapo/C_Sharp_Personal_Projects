
namespace Front
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.elipseDashboard = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnNewMail = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // elipseDashboard
            // 
            this.elipseDashboard.BorderRadius = 20;
            this.elipseDashboard.TargetControl = this;
            // 
            // btnNewMail
            // 
            this.btnNewMail.Animated = true;
            this.btnNewMail.BorderRadius = 10;
            this.btnNewMail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNewMail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNewMail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNewMail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNewMail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(123)))), ((int)(((byte)(252)))));
            this.btnNewMail.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold);
            this.btnNewMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(195)))), ((int)(((byte)(3)))));
            this.btnNewMail.Image = global::Front.Properties.Resources.email_icon;
            this.btnNewMail.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNewMail.ImageSize = new System.Drawing.Size(25, 25);
            this.btnNewMail.Location = new System.Drawing.Point(31, 23);
            this.btnNewMail.Name = "btnNewMail";
            this.btnNewMail.Size = new System.Drawing.Size(166, 37);
            this.btnNewMail.TabIndex = 0;
            this.btnNewMail.Text = "New Mail";
            this.btnNewMail.Click += new System.EventHandler(this.btnNewMail_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = " ";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse elipseDashboard;
        private Guna.UI2.WinForms.Guna2Button btnNewMail;
    }
}