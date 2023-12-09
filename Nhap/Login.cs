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

        // Thay doi DATASOURCE = cho phu hop voi may truoc khi chay:

        //static String connString = @"Data Source=F;Initial Catalog=MusicLogin;Integrated Security=True";
        //SqlConnection connection = new SqlConnection(connString);
        bool check = false;

        public Login()
        {
            InitializeComponent();
            connection.Open();
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
            password = GetHash(textBox2.Text); // Hash the entered password

            // Use parameterized query to avoid SQL injection
            String sqlQuery = "SELECT Username, Password FROM [MusicLogin].[dbo].[Account] WHERE Username = @Username AND Password = @Password";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            // Add parameters to the query
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Authentication successful
                MessageBox.Show("Login Successful!");
                reader.Close();
                this.Hide();
                Form Form1 = new Form1();
                Form1.Show();
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Login Failed. Invalid username or password.");
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Signup();
            form.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 20)
            {
                textBox1.Text = textBox1.Text.Substring(0, 20);
            }
        }
    }
}
