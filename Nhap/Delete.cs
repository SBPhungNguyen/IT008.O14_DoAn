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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhap
{
    public partial class Delete : Form
    {
        //THAY DOI TEN SERVER O CONNECTIONINFO.CS TRUOC KHI CHAY:
        SqlConnection connection;
        string User;
        string sheetdetails;
        string SheetName;
        public Delete(string username)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
            User = username;
        }

        private void comboBoxSheetNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SheetName = comboBoxSheetNames.Text;
        }

        private void LoadSheetNames()
        {
            comboBoxSheetNames.Items.Clear();

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
                MessageBox.Show("Please select a song.", "Selection failed");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the song?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        String sqlQuery = "DELETE FROM [MusicLogin].[dbo].[AccountAccess] WHERE Username = @Username AND SheetName = @SheetName";

                        SqlCommand command = new SqlCommand(sqlQuery, connection);

                        command.Parameters.AddWithValue("@Username", User);
                        command.Parameters.AddWithValue("@SheetName", SheetName);

                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        reader.Close();
                        MessageBox.Show("Song deleted successfully", "Success");
                        LoadSheetNames();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Song deletion failed", "Failure");
                    }
                }
                else
                {
                   
                }
            }
        }
    }
}
