using Microsoft.EntityFrameworkCore;
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
    public partial class LoginForm : Form
    {
        public AppUser? LoggedInUser { get; private set; }

        public LoginForm() => InitializeComponent();

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter username and password.");
                return;
            }

            using var db = new AppDbContext();
            var user = await db.Users.AsNoTracking()
                                     .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
            if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
            {
                MessageBox.Show("Invalid credentials.");
                return;
            }

            // Update last login (optional)
            var tracked = await db.Users.FirstAsync(u => u.Id == user.Id);
            tracked.LastLoginUtc = DateTime.UtcNow;
            await db.SaveChangesAsync();

            if (user.MustChangePassword)
            {
                using var dlg = new ChangePasswordForm(user.Id);
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return; // force password change before logging in
            }

            LoggedInUser = user;
            DialogResult = DialogResult.OK; // Program.cs will open MainForm
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e) => txtUser.Focus();
    }
}