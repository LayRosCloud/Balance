using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using Balance.View.Pages;
using Balance.Model;
using System.Runtime.CompilerServices;
using System;

namespace Balance.ModelView
{
    sealed internal class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// field of INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private MainManagementWindow _management;
        private ManagementNavigation _navigation;
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
            MainPage = new Uri($"/View/Pages/{_expenses.Title}.xaml", UriKind.Relative);

            _management = new MainManagementWindow(WindowStorage.MainWindow);

            _navigation = new ManagementNavigation(_expenses);
            
            
            ExitFromApplication = new DelegateCommand(_management.Exit);
            ChangeSizeApplication = new DelegateCommand(_management.Resize);
            HideApplication = new DelegateCommand(_management.RollUp);

            ChangePageToExpenses = new DelegateCommand(NavigateToExpenses);
            ChangePageToSettings = new DelegateCommand(NavigateToSettings);
        }

        #endregion

        #region Properties
        public Uri MainPage { get; set; }

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

        /// <summary>
        /// The command to change page to expenses
        /// </summary>
        public ICommand ChangePageToExpenses { get; private set; }

        /// <summary>
        /// The command to change page to Settings
        /// </summary>
        public ICommand ChangePageToSettings { get; private set; }
        #endregion

        #endregion

        private void NavigateToSettings(object arg)
        {
            MainPage = new Uri($"/View/Pages/{_settings.Title}.xaml", UriKind.Relative);
            Log.SendMessage("Успех! вы перешли в настройки");
        }
        private void NavigateToExpenses(object arg)
        {
            MainPage = new Uri($"/View/Pages/{_expenses.Title}.xaml", UriKind.Relative);
            Log.SendMessage("Успех! вы перешли в expenses");
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
