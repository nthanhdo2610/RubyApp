using RubyApp.Data;
using RubyApp.Localization;
using RubyApp.Security;
using RubyApp.Services;
using System;
using System.Windows.Forms;

namespace RubyApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Bootstrapper.EnsureDatabase();

            // load preferred language
            var settings = SettingsService.Load();
            I18n.SetCulture(settings.UiCulture);

            bool exitApp = false;

            while (!exitApp)
            {
                using var login = new LoginForm();
                var loginResult = login.ShowDialog();

                if (loginResult == DialogResult.OK && login.LoggedInUser is not null)
                {
                    using var main = new MainForm(login.LoggedInUser);
                    var mainResult = main.ShowDialog();

                    if (mainResult == DialogResult.Abort) continue; // logout => back to login
                    exitApp = true;
                }
                else
                {
                    exitApp = true;
                }
            }
        }
    }
}
