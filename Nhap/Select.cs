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
        SqlConnection connection;
        string User;
        string sheetdetails;
        string SheetName;
        int status = 0;

        public Select(string usermame, int STATUS)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
            User = usermame;
            status = STATUS;
            if (status == 0)
                label1.Text = "Select the Song you want to Edit: ";
            else if (status == 1)
                label1.Text = "Select the Song you want to Upload to Public: ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SheetName = comboBoxSheetNames.Text;
        }

        private void LoadSheetNames()
        {
            comboBoxSheetNames.Items.Clear(); // Clear existing items

            String loadSheetNamesQuery = "SELECT DISTINCT SheetName FROM [MusicLogin].[dbo].[AccountAccess] WHERE Username = @Username";

            try
            {
                using (SqlConnection connection = new SqlConnection(new ConnectionInfo().ConnectionCommand()))
                {
                    connection.Open();

                    using (SqlCommand loadSheetNamesCommand = new SqlCommand(loadSheetNamesQuery, connection))
                    {
                        loadSheetNamesCommand.Parameters.AddWithValue("@Username", User);

                        using (SqlDataReader reader = loadSheetNamesCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxSheetNames.Items.Add(reader["SheetName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sheet names: " + ex.Message);
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
                using (SqlCommand command = new SqlCommand("SELECT SheetDetails FROM [MusicLogin].[dbo].[AccountAccess] WHERE Username = @Username AND SheetName = @SheetName", connection))
                {
                    command.Parameters.AddWithValue("@Username", User);
                    command.Parameters.AddWithValue("@SheetName", SheetName);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            if (reader["SheetDetails"] != DBNull.Value)
                            {
                                sheetdetails = reader["SheetDetails"].ToString();

                                if (status == 0) // Edit
                                {
                                    Form form = new Form1(User, SheetName, sheetdetails);
                                    foreach (Form form2 in Application.OpenForms)
                                    {
                                        form2.Hide();
                                    }
                                    form.Show();
                                }
                                else if (status == 1) // Upload to Public
                                {
                                    reader.Close();

                                    // Check if the song already exists in PublicSong
                                    if (SongExistsInPublicSong(User, SheetName))
                                    {
                                        MessageBox.Show("You have already uploaded a song with this name to Public Songs.", "Upload Failed");
                                    }
                                    else
                                    {
                                        // Insert the song into PublicSong
                                        InsertSongIntoPublicSong(User, SheetName, sheetdetails);
                                    }
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
                        }
                    }
                }
            }
        }

        private bool SongExistsInPublicSong(string username, string sheetName)
        {
            string checkSongExistsQuery = "SELECT COUNT(*) FROM [MusicLogin].[dbo].[PublicSong] WHERE Username = @Username AND SheetName = @SheetName";

            using (SqlCommand checkSongExistsCommand = new SqlCommand(checkSongExistsQuery, connection))
            {
                checkSongExistsCommand.Parameters.AddWithValue("@Username", username);
                checkSongExistsCommand.Parameters.AddWithValue("@SheetName", sheetName);

                int count = (int)checkSongExistsCommand.ExecuteScalar();
                return count > 0;
            }
        }

        private void InsertSongIntoPublicSong(string username, string sheetName, string sheetDetails)
        {
            using (SqlCommand insertPublicSongCommand = new SqlCommand("INSERT INTO [MusicLogin].[dbo].[PublicSong] (Username, SheetName, SheetDetails, Likes, LikesHistory) VALUES (@Username, @SheetName, @SheetDetails, 0, ' ')", connection))
            {
                insertPublicSongCommand.Parameters.AddWithValue("@Username", username);
                insertPublicSongCommand.Parameters.AddWithValue("@SheetName", sheetName);
                insertPublicSongCommand.Parameters.AddWithValue("@SheetDetails", sheetDetails);

                try
                {
                    int rowsAffected = insertPublicSongCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Song successfully uploaded to Public Songs.", "Upload Successful");
                        this.Hide();
                        LoadSheetNames();
                    }
                    else
                    {
                        MessageBox.Show("Failed to upload song to Public Songs.", "Upload Failed");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Unique constraint violation
                    {
                        MessageBox.Show("You have already uploaded a song with this name to Public Songs.", "Upload Failed");
                    }
                    else
                    {
                        MessageBox.Show("Error uploading song to Public Songs: " + ex.Message, "Upload Failed");
                    }
                }
            }
        }

    }
}