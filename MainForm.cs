using System.Windows.Forms;
using RubyApp.Data;
using RubyApp.Localization;

namespace RubyApp
{
    public partial class MainForm : Form
    {
        private readonly AppUser _currentUser;

        public MainForm(AppUser user)
        {
            _currentUser = user;
            InitializeComponent();

            // apply i18n strings
            Text = I18n.T("App_Title");
            adminToolStripMenuItem.Text = I18n.T("Menu_Admin");
            usersToolStripMenuItem.Text = I18n.T("Menu_Users");
            sessionToolStripMenuItem.Text = I18n.T("Menu_Session");
            logoutToolStripMenuItem.Text = I18n.T("Menu_Logout");

            lblWelcome.Text = I18n.Tf("Main_Welcome", _currentUser.Username);

            // role-based visibility
            adminToolStripMenuItem.Visible = _currentUser.Role == UserRole.SuperAdmin;
        }

        private void usersToolStripMenuItem_Click(object? sender, System.EventArgs e)
        {
            using var f = new UsersForm();
            f.ShowDialog(this);
        }

        private void logoutToolStripMenuItem_Click(object? sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
