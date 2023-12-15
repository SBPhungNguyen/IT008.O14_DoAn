using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhap
{
    public partial class Select : Form
    {
        //THAY DOI TEN SERVER O CONNECTIONINFO.CS TRUOC KHI CHAY:
        SqlConnection connection;
        string User;
        string sheetdetails;
        string SheetName;
        public Select(string usermame)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
            User = usermame;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SheetName = comboBoxSheetNames.Text;
        }
       
        private void LoadSheetNames()
        {
            comboBoxSheetNames.Items.Clear(); // Clear existing items

            String loadSheetNamesQuery = "SELECT DISTINCT SheetName FROM [MusicLogin].[dbo].[AccountAccess] WHERE Username = @Username";
            SqlCommand loadSheetNamesCommand = new SqlCommand(loadSheetNamesQuery, connection);
            loadSheetNamesCommand.Parameters.AddWithValue("@Username", User);
            SqlDataReader reader = loadSheetNamesCommand.ExecuteReader();
            try
            {

                while (reader.Read())
                {
                    comboBoxSheetNames.Items.Add(reader["SheetName"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sheet names: " + ex.Message);
                reader.Close();
            }
        }

        private void comboBoxSheetNames_Click(object sender, EventArgs e)
        {
            LoadSheetNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SheetName == null)
            {
                MessageBox.Show("Please Select a Song.", "Selection Failed");
            }
            else
            {
                String sqlQuery = "SELECT SheetDetails FROM [MusicLogin].[dbo].[AccountAccess] WHERE Username = @Username AND SheetName = @SheetName";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.AddWithValue("@Username", User);
                command.Parameters.AddWithValue("@SheetName", SheetName);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    if (reader["SheetDetails"] != DBNull.Value)
                    {
                        sheetdetails = reader["SheetDetails"].ToString();
                        Form form = new Form1(User, SheetName, sheetdetails);
                        foreach (Form form2 in Application.OpenForms)
                        {
                            form2.Hide();
                        }
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("SheetDetails column is DBNull.", "Data Error");
                    }
                }
                else
                {
                    MessageBox.Show("No data found for the specified Username and SheetName.", "Data Not Found");
                }

                reader.Close();
            }
        }
        
    }
}
