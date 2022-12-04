using Balance.View.Windows;
using System.Windows.Controls;

namespace Balance.Model
{
    internal static class WindowStorage
    {
        private static MainWindow _main;

        private static Frame _frame;

        public static MainWindow MainWindow
        {
            get
            {
                return _main;
            }
            set 
            {
                if (_main == null)
                {
                    _main = value;
                }
            }
        }

        public static Frame Frame
        {
            get
            {
                return _frame;
            }
            set
            {
                if (_frame == null)
                {
                    _frame = value;
                }
            }
        }

    }
}
