using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhap
{
    public partial class Public : Form
    {
        SqlConnection connection;
        string User;
        string sheetdetails;
        string SheetName;
        string creator;
        DataTable dataTable;
        string LikesHistory = "";
        public Public(string username)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
            User = username;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Public_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Username as Creator, SheetName as [Song Name], Likes, SheetDetails as [Sheet Details] FROM PublicSong", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Creator"].Width = 75;
            dataGridView1.Columns["Song Name"].Width = 435;
            dataGridView1.Columns["Sheet Details"].Width = 0;
            dataGridView1.Columns["Likes"].Width = 53;

            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dataGridView1.Rows.Count > 0)
            {
                int rowIndex = 0;
                creator = dataGridView1.Rows[rowIndex].Cells["Creator"].Value.ToString();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                SheetName = dataGridView1.Rows[e.RowIndex].Cells["Song Name"].Value.ToString();
                sheetdetails = dataGridView1.Rows[e.RowIndex].Cells["Sheet Details"].Value.ToString();
                creator = dataGridView1.Rows[e.RowIndex].Cells["Creator"].Value.ToString();
                label7.Text = SheetName;
                label5.Text = creator;
                string queryString = "SELECT LikesHistory FROM PublicSong WHERE Username = @Username AND SheetName = @SheetName";
                // Create a new SqlDataAdapter with the query and connection
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                // Define parameters and add them to the adapter's SelectCommand.Parameters collection
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar, 20)).Value = creator;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@SheetName", SqlDbType.VarChar, 100)).Value = SheetName;
                DataTable dataTableLike = new DataTable();
                adapter.Fill(dataTableLike);
                if (dataTableLike.Rows.Count > 0)
                {
                    string likesHistory = dataTableLike.Rows[0][0].ToString();
                    richTextBox1.Text = likesHistory;
                    LikesHistory = richTextBox1.Text;
                }
                else
                {
                    // No rows found, handle accordingly
                    richTextBox1.Text = "No data found";
                }
            }
        }


        private void Public_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Open Public Song
        {
            if (User == null || SheetName == null || sheetdetails == null)
            {
                MessageBox.Show("Please Select a Song first.", "Opening Song Failed!");
            }
            else
            {
                Form form = new Form1(User, SheetName, sheetdetails);
                foreach (Form form2 in Application.OpenForms)
                {
                    form2.Hide();
                }
                form.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.ControlDarkDark;
            Task.Delay(500);
            button3.BackColor = SystemColors.ControlDark;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserPublicSettings settings = new UserPublicSettings(User);
            settings.Show();
        }

        private void button4_Click(object sender, EventArgs e) //Like Song
        {
            if (User == null || SheetName == null || sheetdetails == null)
            {
                MessageBox.Show("Please Select a Song first.", "Liking Song Failed!");
            }
            else
            {
                if (richTextBox1.Text != "")
                    LikesHistory = LikesHistory + '\n';
                LikesHistory = LikesHistory + User + " liked this!";
                using (SqlCommand LikesUpdate = new SqlCommand("UPDATE [MusicLogin].[dbo].[PublicSong] SET Likes = Likes + 1, LikesHistory = @NewLikesHistory WHERE Username = @Username AND SheetName = @SheetName;", connection))
                {
                    LikesUpdate.Parameters.AddWithValue("@Username", creator);
                    LikesUpdate.Parameters.AddWithValue("@SheetName", SheetName);
                    LikesUpdate.Parameters.AddWithValue("@NewLikesHistory", LikesHistory);

                    try
                    {
                        int rowsAffected = LikesUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            LoadData();
                            richTextBox1.Text = LikesHistory;
                        }
                        else
                        {
                            MessageBox.Show("Like Failed.", "Like Failed");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error liking public song: " + ex.Message, "Upload Failed");
                    }
                }

            }
        }
    }
}