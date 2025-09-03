using RubyApp.Data;
using RubyApp.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubyApp
{
    public partial class ResetPasswordForm : Form
    {
        private readonly int _userId;

        public ResetPasswordForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNew.Text) || txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using var db = new AppDbContext();
            var u = await db.Users.FindAsync(_userId);
            if (u == null) { DialogResult = DialogResult.Cancel; return; }

            u.PasswordHash = PasswordHasher.Hash(txtNew.Text);
            u.MustChangePassword = true;
            await db.SaveChangesAsync();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShow.Checked;
            txtNew.UseSystemPasswordChar = !show;
            txtConfirm.UseSystemPasswordChar = !show;
        }
    }
}