using MaterialDesignThemes.Wpf;
using PropertyChanged;
using RainyManager.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RainyManager.Views
{
    public interface IBaseView
    {
        void CloseView();
        ViewMenuData ViewMenuData { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public abstract class BaseView : UserControl, IBaseView
    {
        public virtual void CloseView()
        {

        }

        public abstract ViewMenuData ViewMenuData { get; set; }
    }

    public record ViewMenuData
    {
        public string ViewLabel { get; set; }
        public PackIconKind ViewIcon { get; set; }
        public ViewType ViewType { get; set; }
    }
}
