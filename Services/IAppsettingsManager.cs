using Newtonsoft.Json;
using RainyManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RainyManager.Services
{
    public interface IAppSettingsManager
    {
        string GetGameInstallationPath();
        string GetThunderstoreApiUri();
        string GetPluginPath();
        string GetSettingsTemplate();
        void WriteSettings();
    }


    public class AppSettingsManager : IAppSettingsManager
    {
        private bool isFTR;

        public AppSettingsManager(string appSettings, string savePath)
        {
            AppConfigurationModel appConfig;
            if (appSettings != null)
                appConfig = JsonConvert.DeserializeObject<AppConfigurationModel>(appSettings);
            else
            {
                appConfig = new()
                {
                    ThunderstoreApiUri = @"https://thunderstore.io/api/v1/",
                    PluginPath = "Mods/"
                };
                isFTR = true;
            }

            SavePath = string.Format("{0}\\{1}",Directory.GetParent(Assembly.GetExecutingAssembly().Location), savePath);
            InititializeSettings(appConfig);
        }

        private AppConfigurationModel LocalAppConfiguration { get; set; }
        private string SavePath { get; set; }

        private void InititializeSettings(AppConfigurationModel config)
        {
            LocalAppConfiguration = config;
            if (isFTR)
                WriteSettings();
        }

        public void WriteSettings() => File.WriteAllText(SavePath, GetSettingsTemplate());
        public string GetSettingsTemplate() => JsonConvert.SerializeObject(LocalAppConfiguration);
        public string GetGameInstallationPath() => LocalAppConfiguration.GameInstallationPath;
        public string GetThunderstoreApiUri() => LocalAppConfiguration.ThunderstoreApiUri;
        public string GetPluginPath() => LocalAppConfiguration.PluginPath;
    }
}
