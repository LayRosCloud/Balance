using Balance.Model;
using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Windows;

namespace Balance.Data
{
    sealed internal class DatabaseContext
    {
        private readonly static SQLiteConnection _connection = 
            new SQLiteConnection("Data Source=ExpensesDohod.db");

        private static bool _isOpen = false;

        public static SQLiteConnection GetConnection => _connection;
        public static void OpenConnection()
        {
            try
            {
                CheckIsOpen(true);
                GetConnection.Open();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Подключение уже открыто!");
            }
        }
        public static void CloseConnection()
        {
            try
            {
                CheckIsOpen(false);
                GetConnection.Close();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Подключение закрыто!");
            }
        }

        private static void CheckIsOpen(bool open)
        {
            if (_isOpen == open)
                throw new InvalidOperationException();

            _isOpen = open;
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
