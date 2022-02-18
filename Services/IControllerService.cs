using RainyManager.Misc;
using RainyManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainyManager.Services
{
    public interface IControllerService
    {
        void InitializeViews(IEnumerable<IBaseView> views);
    }

    public class ControllerService : IControllerService
    {
        ObservableCollection<IBaseView> ViewCollection { get; set; }

        public void InitializeViews(IEnumerable<IBaseView> views)
        {
            if(views.Count() == 0)
                return;
            ViewCollection = new ObservableCollection<IBaseView>();
            ViewCollection.AddRange(views.OrderBy(v => v.ViewMenuData.ViewIndex).ToArray());
        }
    }

}
