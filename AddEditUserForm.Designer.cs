namespace RubyApp
{
    partial class AddEditUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkMustChange;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsername = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            lblRole = new System.Windows.Forms.Label();
            comboRole = new System.Windows.Forms.ComboBox();
            chkActive = new System.Windows.Forms.CheckBox();
            chkMustChange = new System.Windows.Forms.CheckBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            chkShowPassword = new System.Windows.Forms.CheckBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            SuspendLayout();

            // form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit User";
            this.Load += new System.EventHandler(this.AddEditUserForm_Load);

            // username
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(22, 28);
            lblUsername.Text = "Username";
            txtUsername.Location = new System.Drawing.Point(120, 24);
            txtUsername.Size = new System.Drawing.Size(300, 23);

            // role
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(22, 66);
            lblRole.Text = "Role";
            comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboRole.Location = new System.Drawing.Point(120, 62);
            comboRole.Size = new System.Drawing.Size(180, 23);

            // active + must change
            chkActive.AutoSize = true;
            chkActive.Location = new System.Drawing.Point(120, 100);
            chkActive.Text = "Active";

            chkMustChange.AutoSize = true;
            chkMustChange.Location = new System.Drawing.Point(200, 100);
            chkMustChange.Text = "Must change password";

            // password (optional on edit)
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(22, 136);
            lblPassword.Text = "Password";
            txtPassword.Location = new System.Drawing.Point(120, 132);
            txtPassword.Size = new System.Drawing.Size(300, 23);
            txtPassword.UseSystemPasswordChar = true;

            chkShowPassword.AutoSize = true;
            chkShowPassword.Location = new System.Drawing.Point(120, 161);
            chkShowPassword.Text = "Show";
            chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            // buttons
            btnSave.Location = new System.Drawing.Point(230, 200);
            btnSave.Size = new System.Drawing.Size(90, 30);
            btnSave.Text = "Save";
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            btnCancel.Location = new System.Drawing.Point(330, 200);
            btnCancel.Size = new System.Drawing.Size(90, 30);
            btnCancel.Text = "Cancel";
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // add controls
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblRole);
            this.Controls.Add(comboRole);
            this.Controls.Add(chkActive);
            this.Controls.Add(chkMustChange);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(chkShowPassword);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}