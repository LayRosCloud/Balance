using Balance.Model;
using System.Windows;
using System.Windows.Input;

namespace Balance.View.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStorage.MainWindow = this;

            InitializeComponent();

            Log.SetLogTextBlock(logs);

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
