using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class SqlOperation
    {
        private SqlConnection connection;
        private SqlCommand command;
        public SqlOperation()
        {
            connection = Connection.GetConnection();
        }
        public bool AddCategory(string name)
        {
            using (command = new SqlCommand($"INSERT INTO CATEGORIES VALUES('{name}')", connection))
            {
                if (command.ExecuteNonQuery() != -1)
                    return true;
            }

            return false;
        }
        public bool DeleteCategory(string name)
        {
            using (command = new SqlCommand($"DELETE FROM CATEGORIES WHERE Name = '{name}'", connection))
            {
                if (command.ExecuteNonQuery() != -1)
                    return true;
            }

            return false;
        }
        public List<string> GetCategories()
        {
            command = new SqlCommand($"SELECT * FROM CATEGORIES", connection);
            List<string> names = new List<string>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add(reader["name"].ToString());
                }
            }
            return names;
        }
        private int GetCategoryId(string categoryName)
        {
            command = new SqlCommand($"SELECT ID FROM CATEGORIES WHERE Name = '{categoryName}'", connection);
            int id = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                }
            }
            return id;
        }
        public bool AddIncome(int count, string categoryName)
        {
            int id = GetCategoryId(categoryName);

            using (command = new SqlCommand($"INSERT INTO _USER VALUES({count}, '{DateTime.Now.ToString("yyyy'-'MM'-'dd")}', {id})", connection))
            {
                if (command.ExecuteNonQuery() != -1)
                    return true;
            }

            return false;
        }
        public bool AddExpense(int count, string categoryName)
        {
            int id = GetCategoryId(categoryName);

            using (command = new SqlCommand($"INSERT INTO _USER VALUES({count}, '{DateTime.Now.ToString("yyyy'-'MM'-'dd")}', {id})", connection))
            {
                if (command.ExecuteNonQuery() != -1)
                    return true;
            }

            return false;
        }
        public IEnumerable<Info> FilterByDate(DateTime date)
        {
            command = new SqlCommand($"SELECT * FROM _USER WHERE Date = '{date.ToString("yyyy'-'MM'-'dd")}'", connection);
            return Filter();
        }
        public IEnumerable<Info> FilterByCost(int from, int to)
        {
            command = new SqlCommand($"SELECT * FROM _USER WHERE Count > {from} AND Count < {to}", connection);
            return Filter();
        }
        public IEnumerable<Info> FilterByCategory(string categoryName)
        {
            int id = GetCategoryId(categoryName);
            command = new SqlCommand($"SELECT * FROM _USER WHERE IdCategory = {id}", connection);
            return Filter();
        }
        private IEnumerable<Info> Filter()
        {
            List<Info> info = new List<Info>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    info.Add(new Info((int)reader["Count"], (DateTime)reader["Date"], (int)reader["IdCategory"]));
                }
            }
            return info;
        }
    }
}