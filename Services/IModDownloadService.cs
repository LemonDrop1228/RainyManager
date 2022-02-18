using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainyManager.Services
{
    public interface IModDownloadService
    {
        void InitializeModService();
    }

    public class ModDownloadService : IModDownloadService
    {
        private readonly IAppSettingsManager appSettingsManager;

        public ModDownloadService(IAppSettingsManager appSettingsManager)
        {
            this.appSettingsManager = appSettingsManager;
        }

        public void InitializeModService()
        {
            
        }
    }

}
