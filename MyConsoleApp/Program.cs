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
            sqlConnection.ConnectionString = "data source=C:\\Users\\user\\Desktop\\SQLite Course\\Test.db";
            sqlConnection.Open();

            //Create a SQL Command

            //Fill SQL command parameters

            //Execute the command

            //Read data and show to the console

            Console.Write(sqlConnection.State);
            Console.ReadKey();
        }
    }
}
