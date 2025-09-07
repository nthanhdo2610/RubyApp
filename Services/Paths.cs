using System;
using System.IO;

namespace RubyApp.Services
{
    public static class Paths
    {
        public static string ProductName => "RubyApp";

        // Portable lang folder (next to exe)
        public static string ExeLangDir => Path.Combine(AppContext.BaseDirectory, "lang");

        // Global lang folder
        public static string ProgramDataRoot =>
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public static string AppDataDir => Path.Combine(ProgramDataRoot, ProductName);
        public static string LangDirGlobal => Path.Combine(AppDataDir, "lang");

        // Settings & DB remain the same
        public static string LocalAppDataRoot =>
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string LocalAppDataDir => Path.Combine(LocalAppDataRoot, ProductName);

        public static string DbFile => Path.Combine(AppDataDir, "app.db");
        public static string SettingsFile => Path.Combine(LocalAppDataDir, "settings.json");

        public static void EnsureDirs()
        {
            Directory.CreateDirectory(AppDataDir);
            Directory.CreateDirectory(LocalAppDataDir);
        }
    }
}
