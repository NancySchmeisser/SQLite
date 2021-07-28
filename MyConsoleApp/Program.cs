namespace MyConsoleApp
{
    using System;
    using System.Data.SQLite;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            //Connection to SQLite
            SQLiteConnection sqlConnection = new SQLiteConnection();
            sqlConnection.ConnectionString = "data source=C:\\Users\\user\\Desktop\\SQLite Course\\MyConsoleApp\\Test.db";
            sqlConnection.Open();

            //Create a SQL Command
            SQLiteCommand sqlCommand = new SQLiteCommand();

            //Fill SQL command parameters
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "Insert Into Customers (Name, Phone) Values('Ford', '03117722443')";


            //Execute the command
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            //Check the results
            ReadData();

            Console.ReadKey();
        }

        internal static void ReadData()
        {
            //Connection to SQLite
            SQLiteConnection sqlConnection = new SQLiteConnection();
            sqlConnection.ConnectionString = "data source=C:\\Users\\user\\Desktop\\SQLite Course\\MyConsoleApp\\Test.db";
            sqlConnection.Open();

            //Create a SQL Command
            SQLiteCommand sqlCommand = new SQLiteCommand();

            //Fill SQL command parameters
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select * from Customers";

            //Execute the command
            SQLiteDataReader dataReader = sqlCommand.ExecuteReader();

            //Read data and show to the console
            while (dataReader.Read())
            {
                Console.WriteLine("ID: {0}, Name: {1}, Phone: {2}", dataReader.GetInt16(0), dataReader.GetString(1), dataReader.GetString(2));
            }

            Console.Write(sqlConnection.State);
            Console.ReadKey();
        }
    }
}
