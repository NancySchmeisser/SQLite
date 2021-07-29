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
        SQLiteConnection sqlConnection = new SQLiteConnection("data source=C:\\Users\\Alireza\\Desktop\\SqliteCourse\\Phonebook.db");
        string selectedID = "0";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadData();
            btnCancel.Enabled = false;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (selectedID == "0")
                NewData();
            else
                UpdateData();
        }

        private void NewData()
        {
            //Create a sql command
            SQLiteCommand sqlCommand = new SQLiteCommand();

            //Fill SQL command parameters
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "Insert Into Persons (FirstName,LastName,Email,Phone,Address,PostCode) Values(@FirstName,@LastName,@Email,@Phone,@Address,@PostCode)";
            sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            sqlCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
            sqlCommand.Parameters.AddWithValue("@PostCode", txtPostCode.Text);

            //Execute the command
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Your data is saved!");

            //Refresh data 
            ReadData();
        }

        private void MnuEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 )
            {
                selectedID = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

                //Define Select statement
                string commandText = "Select * from Persons where ID=" + selectedID;

                //Create a datatable to save data in memory
                var datatable = new DataTable();
                SQLiteDataAdapter myDataAdapter = new SQLiteDataAdapter(commandText, sqlConnection);

                sqlConnection.Open();

                //Fill data from database into a datatable
                myDataAdapter.Fill(datatable);

                //Fill data from datatable into form controls
                txtFirstName.Text = datatable.Rows[0]["FirstName"].ToString();
                txtLastName.Text = datatable.Rows[0]["LastName"].ToString();
                txtEmail.Text = datatable.Rows[0]["Email"].ToString();
                txtPhone.Text = datatable.Rows[0]["Phone"].ToString();
                txtAddress.Text = datatable.Rows[0]["Address"].ToString();
                txtPostCode.Text = datatable.Rows[0]["PostCode"].ToString();

                sqlConnection.Close();
                btnCancel.Enabled = true;
            }
        }

        private void UpdateData()
        {
            //Create a sql command
            SQLiteCommand sqlCommand = new SQLiteCommand();

            //Fill SQL command parameters
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "Update Persons SET FirstName=@FirstName,LastName=@LastName,Email=@Email,Phone=@Phone,Address=@Address,PostCode=@PostCode Where ID=@ID";
            sqlCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
            sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
            sqlCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
            sqlCommand.Parameters.AddWithValue("@PostCode", txtPostCode.Text);
            sqlCommand.Parameters.AddWithValue("@ID", selectedID);

            //Execute the command
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Your data is updated!");

            //Refresh data 
            ReadData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            selectedID = "0";

            //Fill data from datatable into form controls
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPostCode.Text = string.Empty;

            btnCancel.Enabled = false;
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var ID = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

                if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Create a sql command
                    SQLiteCommand sqlCommand = new SQLiteCommand();

                    //Fill SQL command parameters
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "Delete From Persons Where ID=@ID";
                    sqlCommand.Parameters.AddWithValue("@ID", ID);

                    //Execute the command
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    MessageBox.Show("Selected row is deleted!");
                    ReadData();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Define Select statement
            //Select * From Persons where FirstName = 'John'
            //Select * From Persons where FirstName like '%John%'
            string commandText = "Select * From Persons where " + cboFields.Text + " like '%" + txtSearch.Text + "%'";

            //Create a datatable to save data in memory
            var datatable = new DataTable();
            SQLiteDataAdapter myDataAdapter = new SQLiteDataAdapter(commandText, sqlConnection);

            sqlConnection.Open();

            //Fill data from database into a datatable
            myDataAdapter.Fill(datatable);
            sqlConnection.Close();

            dataGridView.DataSource = datatable;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ReadData();
        }
    }
}
