using PropertyChanged;
using RainyManager.Misc;
using RainyManager.Models;
using RainyManager.Services;
using RainyManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RainyManager
{
    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window
    {
        private readonly IThundersoreAPIService thundersoreAPIService;
        private readonly ILoggerService logger;
        private readonly IControllerService controller;
        private string modSearchText;

        public string ModInteractionText { get; set; }
        public ModDetailSections CurrentMDS { get; set; }
        public IBaseView CurrentDiag { get; set; }
        public ObservableCollection<ModModel> ModList { get; private set; }
        public ObservableCollection<ModModel> DisplayModList { get; private set; }
        public string ModSearchText
        {
            get => modSearchText; 
            set
            {
                modSearchText = value;
                FilterModList();
            }
        }

        public ModModel FocusedMod { get; private set; }

        public MainWindow(IThundersoreAPIService thundersoreAPIService,
            ILoggerService logger,
            IControllerService controller)
        {
            this.DataContext = this;
            InitializeComponent();
            this.thundersoreAPIService = thundersoreAPIService;
            this.logger = logger;
            this.controller = controller;
            logger.InitializeConsole(ConsoleTB);
            CurrentMDS = ModDetailSections.ReadMe;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaxButton_Click_(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var modListResults = await thundersoreAPIService.GetMods();
            DisplayModList = ModList = modListResults.ToObservableCollection();
        }

        private void FilterModList()
        {
            if (ModSearchText.NullOrEmpty())
                DisplayModList = ModList;
            else
                DisplayModList = ModList.Where(m => m.Name.ToLower().Contains(ModSearchText.ToLower()))?.ToObservableCollection() ?? ModList;

            if(DisplayModList.Count > 0)
                ModListBox.SelectedIndex = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FocusedMod = (ModModel)ModListBox.SelectedItem;
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentDiag = controller.GetView(ViewType.Settings);
            MainDialogHost.IsOpen = true;
        }
    }
}
