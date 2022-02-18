using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainyManager.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AppConfigurationModel
    {
        [JsonProperty("GameInstallationPath")]
        public string GameInstallationPath { get; set; }

        [JsonProperty("ThunderstoreApiUri")]
        public string ThunderstoreApiUri { get; set; }

        [JsonProperty("PluginPath")] 
        public string PluginPath { get; set; }
    }
}
