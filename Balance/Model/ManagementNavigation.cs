using System;
using System.Windows.Controls;

namespace Balance.Model
{
    internal class ManagementNavigation
    {
        private Frame _frame;

        private Page _page;
        public ManagementNavigation(Page page)
        {
            _frame = WindowStorage.Frame;
            _page = page;
        }

        public Page Page
        {
            get => _page; 
            set => _page = value;
        }

        public void Navigate()
        {
            _frame.Navigate(_page);
        }
        public bool CanNavigate(object argument = null) 
        { 
            return _frame.Content != _page;
        }
    }
}
