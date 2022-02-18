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
    public class ModVersionModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("version_number")]
        public string VersionNumber { get; set; }

        [JsonProperty("dependencies")]
        public List<object> Dependencies { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("downloads")]
        public int Downloads { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("uuid4")]
        public string Uuid4 { get; set; }

        [JsonProperty("file_size")]
        public int FileSize { get; set; }

        [JsonIgnore]
        public double SizeInMBs { get => Math.Round(FileSize * 0.000001,2); }
    }

}
