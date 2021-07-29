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
        SQLiteConnection sqlConnection = new SQLiteConnection("data source=C:\\Users\\user\\src\\SQLite Course\\MyConsoleApp\\SQLite\\MyPhonebook\\MyPhonebook\\Phonebook.db");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadData();
        }

        private void ReadData()
        {
           
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Create a sql command
            SQLiteCommand sqlCommand = new SQLiteCommand();

            //Fill SQL command parameters
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "Insert into Persons (FirstName,LastName,Email,Phone,Adress,Postcode) Values(@FirstName,@LastName,@Email,@Phone,@Adress,@Postcode)";
            sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            sqlCommand.Parameters.AddWithValue("@Adress", txtAddress.Text);
            sqlCommand.Parameters.AddWithValue("@Postcode", txtPostCode.Text);

            //Execute the command
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Your data is saved!");

            //Refresh data
            ReadData();

        }
    }
}
