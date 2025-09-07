using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using RubyApp.Services;

namespace RubyApp.Localization
{
    public static class I18n
    {
        private static string _culture = "en-US";
        private static readonly Dictionary<string, Dictionary<string, string>> _dicts = new();

        public static void SetCulture(string culture)
        {
            _culture = culture;
            var ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            EnsureLoaded(culture);
        }

        public static string Culture => _culture;

        public static string T(string key)
        {
            if (_dicts.TryGetValue(_culture, out var map) &&
                map.TryGetValue(key, out var val) &&
                !string.IsNullOrWhiteSpace(val))
            {
                return val;
            }
            return key; // fallback: show key itself
        }

        public static string Tf(string key, params object[] args) =>
            string.Format(T(key), args);

        private static void EnsureLoaded(string culture)
        {
            if (_dicts.ContainsKey(culture)) return;

            var dict = LoadFromFile(Paths.ExeLangDir, culture) ??
                       LoadFromFile(Paths.LangDirGlobal, culture) ??
                       new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            _dicts[culture] = dict;
        }

        private static Dictionary<string, string>? LoadFromFile(string dir, string culture)
        {
            try
            {
                if (!Directory.Exists(dir)) return null;

                var file = Path.Combine(dir, $"{culture}.json");
                if (!File.Exists(file)) return null;

                var json = File.ReadAllText(file);
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                return dict == null
                    ? null
                    : new Dictionary<string, string>(dict, StringComparer.OrdinalIgnoreCase);
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<string> AvailableCultures()
        {
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var dir in new[] { Paths.ExeLangDir, Paths.LangDirGlobal })
            {
                if (!Directory.Exists(dir)) continue;
                foreach (var f in Directory.GetFiles(dir, "*.json"))
                {
                    var code = Path.GetFileNameWithoutExtension(f);
                    if (seen.Add(code))
                        yield return code;
                }
            }

            if (seen.Count == 0)
                yield return "en-US"; // safe fallback
        }
    }
}
