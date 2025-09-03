using RubyApp.Data;
using RubyApp.Security;

namespace RubyApp
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNew = new System.Windows.Forms.Label();
            lblConfirm = new System.Windows.Forms.Label();
            txtNew = new System.Windows.Forms.TextBox();
            txtConfirm = new System.Windows.Forms.TextBox();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 200);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new System.Drawing.Point(22, 35);
            lblNew.Text = "New password";
            // 
            // txtNew
            // 
            txtNew.Location = new System.Drawing.Point(140, 31);
            txtNew.Size = new System.Drawing.Size(250, 23);
            txtNew.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new System.Drawing.Point(22, 75);
            lblConfirm.Text = "Confirm password";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new System.Drawing.Point(140, 71);
            txtConfirm.Size = new System.Drawing.Size(250, 23);
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(140, 120);
            btnOk.Size = new System.Drawing.Size(100, 30);
            btnOk.Text = "OK";
            btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(290, 120);
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // add controls
            // 
            this.Controls.Add(lblNew);
            this.Controls.Add(txtNew);
            this.Controls.Add(lblConfirm);
            this.Controls.Add(txtConfirm);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}