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
    public partial class MainForm : Form
    {
        private readonly AppUser _currentUser;

        public MainForm(AppUser user)
        {
            _currentUser = user;
            InitializeComponent();

            Text = $"RubyApp — {_currentUser.Username} ({_currentUser.Role})";
            lblWelcome.Text = $"Welcome, {_currentUser.Username}!";
            adminToolStripMenuItem.Visible = _currentUser.Role == UserRole.SuperAdmin;
        }

        private void usersToolStripMenuItem_Click(object? sender, System.EventArgs e)
        {
            using var f = new UsersForm();
            f.ShowDialog(this);
        }

        private void logoutToolStripMenuItem_Click(object? sender, System.EventArgs e)
        {
            // Signal Program.cs to show LoginForm again
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}