namespace RubyApp
{
    partial class UsersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnResetPw;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMustChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridUsers = new System.Windows.Forms.DataGridView();
            btnRefresh = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnToggleActive = new System.Windows.Forms.Button();
            btnResetPw = new System.Windows.Forms.Button();

            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colMustChange = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)(gridUsers)).BeginInit();
            SuspendLayout();

            // form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 420);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.UsersForm_Load);

            // gridUsers
            gridUsers.AllowUserToAddRows = false;
            gridUsers.AllowUserToDeleteRows = false;
            gridUsers.AllowUserToResizeRows = false;
            gridUsers.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridUsers.Location = new System.Drawing.Point(12, 12);
            gridUsers.MultiSelect = false;
            gridUsers.Name = "gridUsers";
            gridUsers.ReadOnly = true;
            gridUsers.RowHeadersVisible = false;
            gridUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new System.Drawing.Size(796, 340);
            gridUsers.TabIndex = 0;

            // columns
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Width = 60;

            colUsername.DataPropertyName = "Username";
            colUsername.HeaderText = "Username";
            colUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;

            colRole.DataPropertyName = "Role";
            colRole.HeaderText = "Role";
            colRole.Width = 120;

            colActive.DataPropertyName = "IsActive";
            colActive.HeaderText = "Active";
            colActive.Width = 60;

            colMustChange.DataPropertyName = "MustChangePassword";
            colMustChange.HeaderText = "Must Change";
            colMustChange.Width = 90;

            colLastLogin.DataPropertyName = "LastLoginUtc";
            colLastLogin.HeaderText = "Last Login (UTC)";
            colLastLogin.Width = 150;

            gridUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                colId, colUsername, colRole, colActive, colMustChange, colLastLogin
            });

            // btns
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnRefresh.Location = new System.Drawing.Point(12, 365);
            btnRefresh.Size = new System.Drawing.Size(90, 32);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAdd.Location = new System.Drawing.Point(120, 365);
            btnAdd.Size = new System.Drawing.Size(90, 32);
            btnAdd.Text = "Add";
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEdit.Location = new System.Drawing.Point(228, 365);
            btnEdit.Size = new System.Drawing.Size(90, 32);
            btnEdit.Text = "Edit";
            btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            btnToggleActive.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnToggleActive.Location = new System.Drawing.Point(336, 365);
            btnToggleActive.Size = new System.Drawing.Size(130, 32);
            btnToggleActive.Text = "Enable / Disable";
            btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);

            btnResetPw.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnResetPw.Location = new System.Drawing.Point(484, 365);
            btnResetPw.Size = new System.Drawing.Size(120, 32);
            btnResetPw.Text = "Reset Password";
            btnResetPw.Click += new System.EventHandler(this.btnResetPw_Click);

            // add controls
            this.Controls.Add(gridUsers);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnToggleActive);
            this.Controls.Add(btnResetPw);

            ((System.ComponentModel.ISupportInitialize)(gridUsers)).EndInit();
            ResumeLayout(false);
        }
    }
}