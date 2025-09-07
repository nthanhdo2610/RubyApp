using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using RubyApp.Data;
using RubyApp.Security;
using RubyApp.Localization;
using RubyApp.Services;

namespace RubyApp
{
    public partial class LoginForm : Form
    {
        public AppUser? LoggedInUser { get; private set; }

        public LoginForm() => InitializeComponent();

        private void ApplyTexts()
        {
            Text = $"{I18n.T("App_Title")} - {I18n.T("Login_Button")}";
            lblTitle.Text = I18n.T("Login_Title");
            lblUser.Text = I18n.T("Login_Username");
            lblPassword.Text = I18n.T("Login_Password");
            lblLanguage.Text = I18n.T("Login_Language");
            btnLogin.Text = I18n.T("Login_Button");
        }

        private void LoadLanguages()
        {
            cboLanguage.Items.Clear();

            // get cultures from files; if none, fall back to English
            var codes = RubyApp.Localization.I18n.AvailableCultures().ToList();
            if (codes.Count == 0)
                codes.Add("en-US"); // safe fallback – UI will show keys if file missing

            foreach (var code in codes)
            {
                string display = code switch
                {
                    "en-US" => "English",
                    "vi-VN" => "Tiếng Việt",
                    _ => code
                };
                cboLanguage.Items.Add(new ComboItem(display, code));
            }

            // pick current culture if present, else first item (only if there is one)
            int idx = -1;
            for (int i = 0; i < cboLanguage.Items.Count; i++)
            {
                if (((ComboItem)cboLanguage.Items[i]).Value.Equals(
                        RubyApp.Localization.I18n.Culture,
                        StringComparison.OrdinalIgnoreCase))
                {
                    idx = i; break;
                }
            }

            if (cboLanguage.Items.Count > 0)
                cboLanguage.SelectedIndex = idx >= 0 ? idx : 0;   // OK now; list has items
            else
                cboLanguage.SelectedIndex = -1;                   // defensive (shouldn’t happen)
        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(I18n.T("Login_EnterBoth"));
                return;
            }

            using var db = new AppDbContext();
            var user = await db.Users.AsNoTracking()
                                     .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
            if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
            {
                MessageBox.Show(I18n.T("Login_Invalid"));
                return;
            }

            // Update last login (optional)
            var tracked = await db.Users.FirstAsync(u => u.Id == user.Id);
            tracked.LastLoginUtc = DateTime.UtcNow;
            await db.SaveChangesAsync();

            if (user.MustChangePassword)
            {
                using var dlg = new ChangePasswordForm(user.Id);
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
            }

            LoggedInUser = user;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadLanguages();
            ApplyTexts();
            txtUser.Focus();
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLanguage.SelectedIndex < 0) return; // nothing selected / empty list
            if (cboLanguage.SelectedItem is not ComboItem item) return;

            RubyApp.Localization.I18n.SetCulture(item.Value);

            var settings = RubyApp.Services.SettingsService.Load();
            settings.UiCulture = item.Value;
            RubyApp.Services.SettingsService.Save(settings);

            ApplyTexts();
        }

        private record ComboItem(string Text, string Value)
        {
            public override string ToString() => Text;
        }
    }
}
