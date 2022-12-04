using Balance.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Balance.Model
{
    internal class Category : IDataAdd, IDataAll<Category>
    {
        
        public Category() : this (0, null)
        {

        }

        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Category> AllCategories
        {
            get
            {
                Category[] collection = SelectAllRows();

                return ConvertArrayToObservableCollection(collection);
            }

        }
        private ObservableCollection<Category> ConvertArrayToObservableCollection(Category[] array)
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();

            try
            {
                foreach (var category in array)
                {
                    categories.Add(category);
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Категорий нет");
            }

            return categories;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<object> range)
        {
            throw new NotImplementedException();
        }

        public Category[] SelectAllRows()
        {
            string query = "SELECT * FROM Category";

            SQLiteCommand CMD = DatabaseContext.GetConnection.CreateCommand();

            CMD.CommandText = query;

            SQLiteDataReader reader = CMD.ExecuteReader();

            if (reader.HasRows == false)
            {
                throw new IndexOutOfRangeException();
            }

            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                Category expense = new Category(Convert.ToInt32(reader[0]), reader[1].ToString());

                categories.Add(expense);
            }

            return categories.ToArray();
        }
    }
}
