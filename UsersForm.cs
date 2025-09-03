using Microsoft.EntityFrameworkCore;
using RubyApp.Data;
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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private async void UsersForm_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            using var db = new AppDbContext();
            var list = await db.Users
                .AsNoTracking()
                .OrderBy(u => u.Username)
                .Select(u => new UserRow
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role.ToString(),
                    IsActive = u.IsActive,
                    MustChangePassword = u.MustChangePassword,
                    LastLoginUtc = u.LastLoginUtc
                })
                .ToListAsync();

            gridUsers.AutoGenerateColumns = false;
            gridUsers.DataSource = list;
        }

        private UserRow? CurrentRow()
        {
            if (gridUsers.CurrentRow?.DataBoundItem is UserRow row)
                return row;
            return null;
        }

        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadUsers();

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using var dlg = new AddEditUserForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
                await LoadUsers();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var row = CurrentRow();
            if (row == null) return;

            using var dlg = new AddEditUserForm(row.Id);
            if (dlg.ShowDialog(this) == DialogResult.OK)
                await LoadUsers();
        }

        private async void btnToggleActive_Click(object sender, EventArgs e)
        {
            var row = CurrentRow();
            if (row == null) return;

            using var db = new AppDbContext();
            var u = await db.Users.FindAsync(row.Id);
            if (u == null) return;

            // prevent locking yourself out if only super admin
            if (u.Role == UserRole.SuperAdmin && u.IsActive && await db.Users.CountAsync(x => x.Role == UserRole.SuperAdmin && x.IsActive) == 1)
            {
                MessageBox.Show("You cannot disable the last active SuperAdmin.");
                return;
            }

            u.IsActive = !u.IsActive;
            await db.SaveChangesAsync();
            await LoadUsers();
        }

        private async void btnResetPw_Click(object sender, EventArgs e)
        {
            var row = CurrentRow();
            if (row == null) return;

            using var dlg = new ResetPasswordForm(row.Id);
            if (dlg.ShowDialog(this) == DialogResult.OK)
                await LoadUsers();
        }

        private class UserRow
        {
            public int Id { get; set; }
            public string Username { get; set; } = "";
            public string Role { get; set; } = "";
            public bool IsActive { get; set; }
            public bool MustChangePassword { get; set; }
            public DateTime? LastLoginUtc { get; set; }
        }
    }
}