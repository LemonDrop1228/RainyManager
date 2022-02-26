using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainyManager.Misc
{
    public enum ViewType
    {
        DownloadStatus,
        Settings
    }

    [Flags]
    public enum ModDetailSections
    {
        ReadMe=1,
        Deps=2,
        Versions=3
    }
}
