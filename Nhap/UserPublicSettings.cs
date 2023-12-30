using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhap
{
    public partial class UserPublicSettings : Form
    {
        SqlConnection connection;
        string User;
        string sheetdetails;
        string SheetName;
        string creator;
        DataTable dataTable;
        int rowIndex = -1;
        public UserPublicSettings(string username)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
            User = username;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }
        private void LoadData()
        {
            SqlParameter usernameParameter = new SqlParameter("@username", SqlDbType.VarChar);
            usernameParameter.Value = User; 

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT SheetName as [Song Name], Likes, SheetDetails as [Sheet Details] FROM PublicSong Where Username = @username", connection);
            adapter.SelectCommand.Parameters.Add(usernameParameter); 

            dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Set the DataTable as the DataSource for the DataGridView
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Song Name"].Width = 400;
            dataGridView1.Columns["Sheet Details"].Width = 0;
            dataGridView1.Columns["Likes"].Width = 67;
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (dataGridView1.Rows.Count > 0)
            {

            }
        }

        private void UserPublicSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                SheetName = dataGridView1.Rows[e.RowIndex].Cells["Song Name"].Value.ToString();
                sheetdetails = dataGridView1.Rows[e.RowIndex].Cells["Sheet Details"].Value.ToString();
                rowIndex = e.RowIndex;
                label5.Text = SheetName;
                rowIndex = e.RowIndex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                string songName = selectedRow.Cells["Song Name"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to remove the song from public?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM PublicSong WHERE Username = @username AND SheetName = @sheetName", connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@username", User);
                        deleteCommand.Parameters.AddWithValue("@sheetName", songName);
                        deleteCommand.ExecuteNonQuery();
                    }

                    dataGridView1.Rows.Remove(selectedRow);
                    rowIndex = -1;
                    label5.Text = " ";
                }
            }
            else
            {
                MessageBox.Show("Please select a song before removing it from public.", "Remove from public failed");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Select select = new Select(User, 1);
            select.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
