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
    public partial class AddEditUserForm : Form
    {
        private readonly int? _userId;

        // Create
        public AddEditUserForm()
        {
            _userId = null;
            InitializeComponent();
        }

        // Edit
        public AddEditUserForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void AddEditUserForm_Load(object sender, EventArgs e)
        {
            comboRole.Items.Clear();
            comboRole.Items.Add(UserRole.SuperAdmin.ToString());
            comboRole.Items.Add(UserRole.User.ToString());
            comboRole.SelectedIndex = 1; // default: User

            if (_userId.HasValue)
            {
                Text = "Edit User";
                using var db = new AppDbContext();
                var u = await db.Users.AsNoTracking().FirstAsync(x => x.Id == _userId.Value);
                txtUsername.Text = u.Username;
                comboRole.SelectedItem = u.Role.ToString();
                chkActive.Checked = u.IsActive;
                chkMustChange.Checked = u.MustChangePassword;
                // no password fields shown unless “reset on save” checked
            }
            else
            {
                Text = "Add User";
                chkActive.Checked = true;
                chkMustChange.Checked = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required."); return;
            }

            var role = (comboRole.SelectedItem?.ToString() ?? "User") == "SuperAdmin"
                ? UserRole.SuperAdmin
                : UserRole.User;

            using var db = new AppDbContext();

            if (_userId is null)
            {
                // ensure unique name
                if (await db.Users.AnyAsync(x => x.Username == username))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                var password = txtPassword.Text;
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required for new users.");
                    return;
                }

                db.Users.Add(new AppUser
                {
                    Username = username,
                    PasswordHash = PasswordHasher.Hash(password),
                    Role = role,
                    IsActive = chkActive.Checked,
                    MustChangePassword = chkMustChange.Checked
                });
                await db.SaveChangesAsync();
            }
            else
            {
                var u = await db.Users.FirstAsync(x => x.Id == _userId.Value);

                // prevent disabling last SuperAdmin via edit if needed
                if (u.Role == UserRole.SuperAdmin && !chkActive.Checked &&
                    await db.Users.CountAsync(x => x.Role == UserRole.SuperAdmin && x.IsActive) == 1)
                {
                    MessageBox.Show("You cannot disable the last active SuperAdmin.");
                    return;
                }

                // handle username change uniqueness
                if (!string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) &&
                    await db.Users.AnyAsync(x => x.Username == username))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                u.Username = username;
                u.Role = role;
                u.IsActive = chkActive.Checked;
                u.MustChangePassword = chkMustChange.Checked;

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    u.PasswordHash = PasswordHasher.Hash(txtPassword.Text);
                }

                await db.SaveChangesAsync();
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !show;
        }
    }
}