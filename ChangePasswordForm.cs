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
    public partial class ChangePasswordForm : Form
    {
        private readonly int _userId;
        public ChangePasswordForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            var p1 = txtNew.Text;
            var p2 = txtConfirm.Text;
            if (string.IsNullOrWhiteSpace(p1) || p1 != p2)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using var db = new Data.AppDbContext();
            var user = await db.Users.FindAsync(_userId);
            if (user == null) { DialogResult = DialogResult.Cancel; return; }

            user.PasswordHash = PasswordHasher.Hash(p1);
            user.MustChangePassword = false;
            await db.SaveChangesAsync();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
