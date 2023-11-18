using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhap
{
    public partial class Form1 : Form
    {
        int not = -1;
        DataTable NotNhac = new DataTable();
        System.Media.SoundPlayer C4 = new System.Media.SoundPlayer(Properties.Resources.a84);   //  DO_4
        System.Media.SoundPlayer D4 = new System.Media.SoundPlayer(Properties.Resources.a89);   //  RE_4
        System.Media.SoundPlayer E4 = new System.Media.SoundPlayer(Properties.Resources.a85);   //  MI_4
        System.Media.SoundPlayer F4 = new System.Media.SoundPlayer(Properties.Resources.a73);   //  FA_4
        System.Media.SoundPlayer G4 = new System.Media.SoundPlayer(Properties.Resources.a79);   //  SOL_4
        System.Media.SoundPlayer A4 = new System.Media.SoundPlayer(Properties.Resources.a80);   //  LA_4
        System.Media.SoundPlayer B4 = new System.Media.SoundPlayer(Properties.Resources.a65);   //  SI_4
        System.Media.SoundPlayer C5 = new System.Media.SoundPlayer(Properties.Resources.a83);   //  DO_5
        System.Media.SoundPlayer D5 = new System.Media.SoundPlayer(Properties.Resources.a68);   //  RE_5
        System.Media.SoundPlayer E5 = new System.Media.SoundPlayer(Properties.Resources.a70);   //  MI_5
        System.Media.SoundPlayer F5 = new System.Media.SoundPlayer(Properties.Resources.a71);   //  FA_5
        System.Media.SoundPlayer G5 = new System.Media.SoundPlayer(Properties.Resources.a72);   //  SOL_5
        System.Media.SoundPlayer A5 = new System.Media.SoundPlayer(Properties.Resources.a74);   //  LA_5
        System.Media.SoundPlayer B5 = new System.Media.SoundPlayer(Properties.Resources.a75);   //  SI_5
        System.Media.SoundPlayer C6 = new System.Media.SoundPlayer(Properties.Resources.a76);   //  DO_6
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            NotNhac.Columns.Add("1", typeof(string));
            NotNhac.Columns.Add("2", typeof(string));
            NotNhac.Columns.Add("3", typeof(string));
            NotNhac.Columns.Add("4", typeof(string));
            NotNhac.Columns.Add("5", typeof(string));
            NotNhac.Columns.Add("6", typeof(string));
            NotNhac.Columns.Add("7", typeof(string));
            NotNhac.Columns.Add("8", typeof(string));
            dataGridView1.DataSource = NotNhac;
            dataGridView1.Columns["1"].Width = 50;
            dataGridView1.Columns["2"].Width = 50;
            dataGridView1.Columns["3"].Width = 50;
            dataGridView1.Columns["4"].Width = 50;
            dataGridView1.Columns["5"].Width = 50;
            dataGridView1.Columns["6"].Width = 50;
            dataGridView1.Columns["7"].Width = 50;
            dataGridView1.Columns["8"].Width = 50;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void clear_all_textbox()
        {
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();
            richTextBox10.Clear();
            richTextBox11.Clear();
        }
        private void display_on_textbox(string notnhac)
        {
            clear_all_textbox();
            richTextBox12.Text = notnhac;
            if (not == 2)
                richTextBox11.Text = ".";
            else if (not == 4)
            {
                richTextBox11.Text = ".";
                richTextBox10.Text = ".";
                richTextBox9.Text = ".";
            }
            else if (not == 8)
            {
                richTextBox11.Text = ".";
                richTextBox10.Text = ".";
                richTextBox9.Text = ".";
                richTextBox8.Text = ".";
                richTextBox7.Text = ".";
                richTextBox6.Text = ".";
                richTextBox5.Text = ".";
            }
            else if (not == 0)
            {
                richTextBox12.Text = ".";
                richTextBox11.Text = ".";
                richTextBox10.Text = ".";
                richTextBox9.Text = ".";
                richTextBox8.Text = ".";
                richTextBox7.Text = ".";
                richTextBox6.Text = ".";
                richTextBox5.Text = ".";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            C4.Play();
            display_on_textbox("C4");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            D4.Play();
            display_on_textbox("D4");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            E4.Play();
            display_on_textbox("E4");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            F4.Play();
            display_on_textbox("F4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            G4.Play();
            display_on_textbox("G4");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            A4.Play();
            display_on_textbox("A4");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            B4.Play();
            display_on_textbox("B4");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            C5.Play();
            display_on_textbox("C5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            D5.Play();
            display_on_textbox("D5");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            E5.Play();
            display_on_textbox("E5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            F5.Play();
            display_on_textbox("F5");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            G5.Play();
            display_on_textbox("G5");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            A5.Play();
            display_on_textbox("A5");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            B5.Play();
            display_on_textbox("B5");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            C6.Play();
            display_on_textbox("C6");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q: C4.Play(); break;
                case Keys.W: D4.Play(); break;
                case Keys.E: E4.Play(); break;
                case Keys.R: F4.Play(); break;
                case Keys.T: G4.Play(); break;
                case Keys.A: A4.Play(); break;
                case Keys.S: B4.Play(); break;
                case Keys.D: C5.Play(); break;
                case Keys.F: D5.Play(); break;
                case Keys.G: E5.Play(); break;
                case Keys.Z: F5.Play(); break;
                case Keys.X: G5.Play(); break;
                case Keys.C: A5.Play(); break;
                case Keys.V: B5.Play(); break;
                case Keys.B: C6.Play(); break;
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e) // not tron
        {
            not = 8;
        }
        private void button18_Click(object sender, EventArgs e) // not trang
        {
            not = 4;
        }
        private void button19_Click(object sender, EventArgs e) // not den
        {
            not = 2;
        }
        private void button20_Click(object sender, EventArgs e) // not don
        {
            not = 1;
        }
        private void button23_Click(object sender, EventArgs e) // not lang
        {
            not = 0;
            display_on_textbox(""); // display luon, ko can doi user chon cao do
        }
        private void button16_Click(object sender, EventArgs e) // play button
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            int tempo = Convert.ToInt32(richTextBox3.Text);
            timer1.Interval = tempo;

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
        }

        private void button21_Click(object sender, EventArgs e) // save button
        {
            DataRow row = NotNhac.NewRow();
            row["1"] = richTextBox12.Text;
            row["2"] = richTextBox11.Text;
            row["3"] = richTextBox10.Text;
            row["4"] = richTextBox9.Text;
            row["5"] = richTextBox8.Text;
            row["6"] = richTextBox7.Text;
            row["7"] = richTextBox6.Text;
            row["8"] = richTextBox5.Text;
            NotNhac.Rows.Add(row);
        }
    }
}
