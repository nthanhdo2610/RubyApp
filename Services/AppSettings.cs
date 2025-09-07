using System;
using System.IO;
using System.Text.Json;

namespace RubyApp.Services
{
    public class AppSettings
    {
        public string UiCulture { get; set; } = "en-US"; // default English
    }

    public static class SettingsService
    {
        private static readonly JsonSerializerOptions _opts = new() { WriteIndented = true };
        private static AppSettings? _cache;

        public static AppSettings Load()
        {
            Paths.EnsureDirs();
            if (_cache != null) return _cache;

            var file = Paths.SettingsFile;
            if (!File.Exists(file))
            {
                _cache = new AppSettings();
                Save(_cache);
                return _cache;
            }

            try
            {
                var json = File.ReadAllText(file);
                _cache = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            catch
            {
                _cache = new AppSettings();
            }
            return _cache!;
        }

        public static void Save(AppSettings settings)
        {
            Paths.EnsureDirs();
            var json = JsonSerializer.Serialize(settings, _opts);
            File.WriteAllText(Paths.SettingsFile, json);
            _cache = settings;
        }
    }
}
