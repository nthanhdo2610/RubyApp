using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyApp.Services
{
    public static class Paths
    {
        public static string ProductName => "RubyApp";
        public static string ProgramDataRoot =>
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); // %ProgramData%
        public static string AppDataDir => Path.Combine(ProgramDataRoot, ProductName);
        public static string DbFile => Path.Combine(AppDataDir, "app.db");

        public static void EnsureDirs() => Directory.CreateDirectory(AppDataDir);
    }
}