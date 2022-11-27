using Balance.Model;
using System.Windows;

namespace Balance.View.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStorage.MainWindow = this;
            
            InitializeComponent();

            WindowStorage.Frame = mainFrame;
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }
    }
}
