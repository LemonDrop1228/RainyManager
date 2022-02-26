using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RainyManager.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : BaseView
    {
        public SettingsView()
        {
            ViewMenuData = new()
            {
                ViewLabel = "Settings",
                ViewIcon = MaterialDesignThemes.Wpf.PackIconKind.Gear,
                ViewType = Misc.ViewType.Settings
            };
            InitializeComponent();
        }

        public override ViewMenuData ViewMenuData { get; set; }
    }
}
