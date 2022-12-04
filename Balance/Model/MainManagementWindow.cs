using System.Windows;
using System;

namespace Balance.Model
{
    internal class MainManagementWindow
    {
        private Window _window;

        public MainManagementWindow(Window window) 
        { 
            _window = window;
        }

        public void Exit(object argument = null)
        {
            _window.Close();
        }

        public void Resize(object argument = null)
        {
            if(_window.WindowState == WindowState.Normal) 
            { 
                _window.WindowState = WindowState.Maximized;

                return;
            }

            _window.WindowState = WindowState.Normal;
        }

        public void RollUp(object argument = null)
        {
            if (_window.WindowState == WindowState.Minimized)
            {
                throw new ArgumentException();
            }

            _window.WindowState = WindowState.Minimized;
        }

        public void Show() 
        {
            _window.Show();
        }

        public void Hide()
        {
            _window.Hide();
        }

    }
}
