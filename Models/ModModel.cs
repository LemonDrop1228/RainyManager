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
    public class ModModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("package_url")]
        public string PackageUrl { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("date_updated")]
        public DateTime DateUpdated { get; set; }

        [JsonProperty("uuid4")]
        public string Uuid4 { get; set; }

        [JsonProperty("rating_score")]
        public int RatingScore { get; set; }

        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        [JsonProperty("is_deprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("has_nsfw_content")]
        public bool HasNsfwContent { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("versions")]
        public List<ModVersionModel> Versions { get; set; }

        [JsonIgnore]
        public ModVersionModel LatestVersion { get => Versions?.FirstOrDefault(); }
    }


}
