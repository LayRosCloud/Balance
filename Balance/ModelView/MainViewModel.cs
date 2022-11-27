using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Balance.View.Windows;
using System.Windows.Controls;
using Balance.View.Pages;
using Balance.Model;
using System;

namespace Balance.ModelView
{
    sealed internal class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private MainWindow _mainWindow;

        #region Fields-Pages

        private Page _expenses;
        private Page _settings;

        #endregion

        #endregion

        #region Constructors

        public MainViewModel()
        {
            _settings = new SettingsPage();
            _expenses = new ExpensesPage();

            MainPage = _expenses;
            _mainWindow = WindowStorage.MainWindow;

            ExitFromApplication = new DelegateCommand(ExitApplication);
            ChangeSizeApplication = new DelegateCommand(ChangeSizeApp);
            HideApplication = new DelegateCommand(HideApp);

            ChangePageToExpenses = new DelegateCommand(NavigatePageExpenses, CanNavigateExpenses);
            ChangePageToSettings = new DelegateCommand(NavigatePageSettings, CanNavigateSettings);
        }

        #endregion

        #region Properties
        public object MainPage { get; private set; }

        #region ICommands_Props
        /// <summary>
        /// Command for exit from application (MainWindow.Close())
        /// </summary>
        public ICommand ExitFromApplication { get; private set; }

        /// <summary>
        /// Command to change the size (fullscreen, normal) of the application window mode
        /// </summary>
        public ICommand ChangeSizeApplication { get; private set; }

        /// <summary>
        /// The command to hide the application window (window state = minimal)
        /// </summary>
        public ICommand HideApplication { get; private set; }
        public ICommand ChangePageToExpenses { get; private set; }
        public ICommand ChangePageToSettings { get; private set; }
        #endregion
        #endregion

        #region Button-Methods

        #region bool-methods
        private bool CanNavigateExpenses(object obj)
        {
            return MainPage != _expenses;
        }

        private bool CanNavigateSettings(object obj)
        {
            return MainPage != _settings;
        }
        #endregion

        #region navigate-pages
        private void NavigatePageExpenses(object obj)
        {
            MainPage = _expenses;
            NavigateFrame();
        }

        private void NavigatePageSettings(object obj)
        {
            MainPage = _settings;
            NavigateFrame();
        }

        private void NavigateFrame()
        {
            WindowStorage.Frame.Navigate(MainPage);
        }
        #endregion

        #region upper-button-methods
        private void ExitApplication(object obj)
        {
            _mainWindow.Close();
        }

        private void ChangeSizeApp(object obj)
        {
            if (_mainWindow.WindowState == WindowState.Maximized)
            {
                _mainWindow.WindowState = WindowState.Normal;
                return;
            }
            _mainWindow.WindowState = WindowState.Maximized;
        }

        private void HideApp(object obj)
        {
            if (_mainWindow.WindowState == WindowState.Minimized)
                throw new InvalidOperationException();

            _mainWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        #endregion
    }
}
