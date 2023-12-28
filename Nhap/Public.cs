﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
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
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Username as Creator, SheetName as [Song Name], SheetDetails as [Sheet Details], Likes FROM PublicSong", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Creator"].Width = 75;
            dataGridView1.Columns["Song Name"].Width = 200;
            dataGridView1.Columns["Sheet Details"].Width = 225;
            dataGridView1.Columns["Likes"].Width = 43;
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
            }
        }


        private void Public_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Open Public Song
        {
            Form form = new Form1(User, SheetName, sheetdetails);
            foreach (Form form2 in Application.OpenForms)
            {
                form2.Hide();
            }
            form.Show();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
