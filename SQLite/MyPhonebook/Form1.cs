using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhonebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Connection to SQLite
            SQLiteConnection sqlConnection = new SQLiteConnection();
            sqlConnection.ConnectionString = "data source=C:\\Users\\user\\src\\SQLite Course\\MyConsoleApp\\SQLite\\MyPhonebook\\MyPhonebook\\Phonebook.db";

            //Define Select statement
            string commandText = "Select * from Persons";

            //Create a datatable to save data in memory
            var datatable = new DataTable();

            //Create a data adapter 
            //The DataAdapter can perform Select , Insert , Update and Delete SQL operations in the Data Source.
            //The Insert, Update and Delete SQL operations, we are using the continuation of the Select command 
            //perform by the DataAdapter. That is the DataAdapter uses the Select statements to fill a DataSet 
            //and use the other three SQL commands(Insert, Update, delete) to transmit changes back to the Database.

            SQLiteDataAdapter myDataAdapter = new SQLiteDataAdapter(commandText, sqlConnection);

            sqlConnection.Open();

            //Fill data from database into a datatable
            myDataAdapter.Fill(datatable);
            sqlConnection.Close();

            dataGridView.DataSource = datatable;
        }

    }
}
