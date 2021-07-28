using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
