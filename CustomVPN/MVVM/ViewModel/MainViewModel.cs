using CustomVPN.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomVPN.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShootDownWindowCommand { get; set; }
        public RelayCommand MaximazeWindowCommand { get; set; }
        public RelayCommand MinimazeWindowCommand { get; set; }

        public RelayCommand ShowProtectionView { get; set; }
        public RelayCommand ShowSettingsView { get; set; }
        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        private object _currentView;
        public object CurrentView 
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

       
        public MainViewModel()
        {
            ProtectionVM = new ProtectionViewModel();
            SettingsVM = new SettingsViewModel();
            _currentView = ProtectionVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(x => { Application.Current.MainWindow.DragMove(); });

            ShootDownWindowCommand = new RelayCommand(x => { Application.Current.Shutdown(); });

            MinimazeWindowCommand = new RelayCommand(x => 
            {
                Application.Current.MainWindow.WindowState=WindowState.Minimized; 
            });

            MaximazeWindowCommand = new RelayCommand(x => 
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
               
            });

            ShowSettingsView = new RelayCommand(x => { CurrentView = SettingsVM; });
            ShowProtectionView = new RelayCommand(x => { CurrentView = ProtectionVM; });
        }
    }
}
