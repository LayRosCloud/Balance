using Balance.Data;
using Balance.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Balance.ModelView
{
    internal class ExpensesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Expense> expenses;

        public ExpensesViewModel()
        {

            expenses = new ObservableCollection<Expense>();

            AddExpenseItem = new DelegateCommand(AddExpense);

            DatabaseContext.OpenConnection();
            Expense expenseItem = new Expense();

            try
            {
                foreach (var expense in expenseItem.SelectAllRows())
                {
                    expenses.Add(expense);
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Расходов нет");
            }
        }
        public ObservableCollection<Expense> Expenses => expenses;
        public ICommand AddExpenseItem { get; private set; }

        private void AddExpense(object obj)
        {
            Expense expense = new Expense();
            expenses.Add(expense);
        }
    }
}
