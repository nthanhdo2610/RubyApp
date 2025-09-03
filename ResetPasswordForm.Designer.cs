namespace RubyApp
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.CheckBox chkShow;
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
            chkShow = new System.Windows.Forms.CheckBox();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            SuspendLayout();

            // form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 200);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reset Password";

            // labels + fields
            lblNew.AutoSize = true;
            lblNew.Location = new System.Drawing.Point(22, 35);
            lblNew.Text = "New password";

            txtNew.Location = new System.Drawing.Point(140, 31);
            txtNew.Size = new System.Drawing.Size(250, 23);
            txtNew.UseSystemPasswordChar = true;

            lblConfirm.AutoSize = true;
            lblConfirm.Location = new System.Drawing.Point(22, 75);
            lblConfirm.Text = "Confirm password";

            txtConfirm.Location = new System.Drawing.Point(140, 71);
            txtConfirm.Size = new System.Drawing.Size(250, 23);
            txtConfirm.UseSystemPasswordChar = true;

            chkShow.AutoSize = true;
            chkShow.Location = new System.Drawing.Point(140, 100);
            chkShow.Text = "Show";
            chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);

            btnOk.Location = new System.Drawing.Point(140, 135);
            btnOk.Size = new System.Drawing.Size(100, 30);
            btnOk.Text = "OK";
            btnOk.Click += new System.EventHandler(this.btnOk_Click);

            btnCancel.Location = new System.Drawing.Point(290, 135);
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // add
            this.Controls.Add(lblNew);
            this.Controls.Add(txtNew);
            this.Controls.Add(lblConfirm);
            this.Controls.Add(txtConfirm);
            this.Controls.Add(chkShow);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}