using RubyApp.Security;

namespace RubyApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Bootstrapper.EnsureDatabase();

            bool exitApp = false;

            while (!exitApp)
            {
                using var login = new LoginForm();
                var loginResult = login.ShowDialog();

                if (loginResult == DialogResult.OK && login.LoggedInUser is not null)
                {
                    using var main = new MainForm(login.LoggedInUser);
                    var mainResult = main.ShowDialog();

                    if (mainResult == DialogResult.Abort)
                    {
                        // User clicked Logout → show LoginForm again
                        continue;
                    }
                    else
                    {
                        // MainForm closed normally → exit app
                        exitApp = true;
                    }
                }
                else
                {
                    // Login cancelled/closed → exit app
                    exitApp = true;
                }
            }
        }
    }
}
