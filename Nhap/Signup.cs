using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nhap
{
    public partial class Signup : Form
    {
        string username = "";
        string password = "";
        string password2 = "";

        //Thay doi DATASOURCE cho phu hop voi may truoc khi chay:
        
        //static String connString = @"Data Source=F;Initial Catalog=MusicLogin;Integrated Security=True";
        //SqlConnection connection = new SqlConnection(connString);

        public Signup()
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
            password = textBox2.Text;
            password2 = textBox3.Text;

            if (password == password2)
            {
                // Hash the password before storing it
                string hashedPassword = GetHash(password);

                // Use parameterized query to avoid SQL injection
                String signUpQuery = "INSERT INTO [MusicLogin].[dbo].[Account] (Username, Password) VALUES (@Username, @Password)";

                SqlCommand signUpCommand = new SqlCommand(signUpQuery, connection);
                // Add parameters to the query
                signUpCommand.Parameters.AddWithValue("@Username", username);
                signUpCommand.Parameters.AddWithValue("@Password", hashedPassword);

                try
                {
                    signUpCommand.ExecuteNonQuery();
                    MessageBox.Show("Sign-up Successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sign-up Failed. Error: " + ex.Message);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Password is not the same with Confirm Password.");
            }
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
