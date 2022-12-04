using Balance.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Balance.Model
{
    internal class Expense : IDataAdd, IDataAll<Expense>
    {

        private Category _category;

        #region Constructors
        public Expense()
        {

        }
        public Expense(string name, int category, double price, string path)
            : this(0, name, category, price, path)
        {

        }

        public Expense(int id, string name, int category, double price, string path)
        {
            ID = id;
            Name = name;
            CategoryID = category;
            Price = price;
            Image = path;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ImageRelative 
        {
            get => "/" + Image;
        }
        
        public Category Category {
            get
            {
                if (_category == null)
                {
                    string query = $"SELECT c.Id, c.Name FROM Category c, Expense e WHERE e.CategoryID = c.ID AND c.ID = {CategoryID}";
                    SQLiteCommand CMD = DatabaseContext.GetConnection.CreateCommand();

                    CMD.CommandText = query;

                    SQLiteDataReader reader = CMD.ExecuteReader();
                    if (reader.HasRows == false)
                    {
                        throw new ArgumentException();
                    }
                    reader.Read();
                    _category = new Category(Convert.ToInt32(reader[0]), reader[1].ToString());
                }
                return _category;
            }
        }
        
        #endregion

        #region IDataAdd
        public void Add()
        {
            string query = $"INSERT INTO Expense(Name, CategoryID, Price, Image) VALUES('{Name}',{CategoryID},{Price},{Image}')";
            SQLiteCommand CMD = DatabaseContext.GetConnection.CreateCommand();

            CMD.CommandText = query;

            if (CMD.ExecuteNonQuery() != 1)
            {
                throw new FieldAccessException();
            }
        }

        public void AddRange(List<object> range)
        {
            if (range.Count <= 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (range.FindAll(x => (x is Expense) == false).Count > 0)
            {
                throw new ArgumentException();
            }

            for (int count = 0; count < range.Count; count++)
            {
                var expense = range[count] as Expense;

                string query = $"INSERT INTO Expense(Name, CategoryID, Price, Image) VALUES('{expense.Name}',{expense.CategoryID},{expense.Price},{expense.Image}')";

                SQLiteCommand CMD = DatabaseContext.GetConnection.CreateCommand();

                CMD.CommandText = query;

                if (CMD.ExecuteNonQuery() != 1)
                {
                    throw new FieldAccessException();
                }
            }
        }
        #endregion

        #region IDataAll
        public Expense[] SelectAllRows()
        {
            string query = "SELECT * FROM Expense";

            SQLiteCommand CMD = DatabaseContext.GetConnection.CreateCommand();

            CMD.CommandText = query;

            SQLiteDataReader reader = CMD.ExecuteReader();
            if (reader.HasRows == false)
            {
                throw new IndexOutOfRangeException();
            }

            List<Expense> expenses = new List<Expense>();

            while (reader.Read())
            {
                Expense expense = new Expense(Convert.ToInt32(reader[0]),
                                              reader[1].ToString(), 
                                              Convert.ToInt32(reader[2]), 
                                              Convert.ToDouble(reader[3]),
                                              reader[4].ToString());
                
                expenses.Add(expense);
            }
            return expenses.ToArray();
        }
        #endregion
    }
}
