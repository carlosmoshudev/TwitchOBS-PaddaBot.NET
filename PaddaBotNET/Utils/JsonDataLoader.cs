using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace PaddaBotNET.Utils {
    public static class JsonDataLoader {
        private static bool isProduction
            = Boolean.Parse(ConfigurationManager.AppSettings.Get("Production"));
        private static string PREPath = isProduction ? "" : "..\\..\\";
        public static Dictionary<string, string> ParseJson(string fileName) {
            var file = Path.Combine(Environment.CurrentDirectory, PREPath, "Config", fileName);
            using (StreamReader r = new StreamReader(file)) {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }
    }
}
