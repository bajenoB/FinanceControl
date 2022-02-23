using System.Data.SqlClient;

namespace WebApplication2
{
    public class Connection
    {
        private static SqlConnection connection;
        private Connection() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection("Server=savel.database.windows.net;Initial Catalog=bajenob;User ID=bajenob;Password=Savelstan123;");
                connection.Open();
            }

            return connection;
        }
    }
}