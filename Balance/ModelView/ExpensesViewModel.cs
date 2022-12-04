using Balance.Data;
using Balance.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Balance.ModelView
{
    internal class ExpensesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Expense> _expenses;

        public ExpensesViewModel()
        {

            _expenses = new ObservableCollection<Expense>();

            AddExpenseItem = new DelegateCommand(AddExpense);

            DatabaseContext.OpenConnection();

            Expense expenseItem = new Expense();

            try
            {
                foreach (var expense in expenseItem.SelectAllRows())
                {
                    _expenses.Add(expense);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Log log = new Log("Расходов нет");
                log.SendMessage();
            }
        }

        public ObservableCollection<Expense> Expenses => _expenses;

        public ICommand AddExpenseItem { get; private set; }

        private void AddExpense(object obj)
        {
            Expense expense = new Expense();

            _expenses.Add(expense);
        }
    }
}
