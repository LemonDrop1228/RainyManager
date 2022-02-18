using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RainyManager.Models;
using RestSharp;

namespace RainyManager.Services
{
    public interface IThundersoreAPIService
    {
        Task<List<ModModel>> GetMods();
    }

    public class ThundersoreAPIService : IThundersoreAPIService
    {
        private readonly IAppSettingsManager appSettingsManager;

        string modListJson { get; set; }
        const string modPackageUrlToken = @"package/";

        RestClient apiClient { get; set; }

        public ThundersoreAPIService(IAppSettingsManager appSettingsManager)
        {
            this.appSettingsManager = appSettingsManager;
            apiClient = new RestClient();
        }

        public async Task<List<ModModel>> GetMods()
        {
            string url = appSettingsManager.GetThunderstoreApiUri() + modPackageUrlToken;
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(url);
                var json = await res.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ModModel>>(json);
            }

            //return await apiClient.GetJsonAsync<List<ModModel>>(url).ConfigureAwait(false); 
        }

    }

}
