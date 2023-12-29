using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Nhap
{
    public partial class Login : Form
    {
        string username = "";
        string password = "";

        //THAY DOI TEN SERVER O CONNECTIONINFO.CS TRUOC KHI CHAY:
        SqlConnection connection;

        bool check = false;
        Form1 form1 = null;


        Signup signup;
        public Login()
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();
        }

        public Login(Form1 form1)
        {
            InitializeComponent();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connection = new SqlConnection(connectionInfo.ConnectionCommand());
            connection.Open();

            this.form1 = form1;

            ////////
            form1.Hide();
            ///////
        }

        private static string GetHash(string input)
        {
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = GetHash(textBox2.Text); 

            String sqlQuery = "SELECT Username, Password FROM [MusicLogin].[dbo].[Account] WHERE Username = @Username AND Password = @Password";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                this.Hide();


                Form Form1 = new Form1(username);
                Form1.Show();
            }
            else
            {
                MessageBox.Show("Login Failed. Invalid username or password.", "Login Failed.");
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            Form form = new Signup(this);
            form.ShowDialog();

            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 20)
            {
                textBox1.Text = textBox1.Text.Substring(0, 20);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
