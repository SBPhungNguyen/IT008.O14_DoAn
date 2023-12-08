using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhap
{
    public partial class Form1 : Form
    {
        int is_playing = 0;
        int tempo;
        int not = -1;
        string[] notes = new string [10000];
        int lines = 0;
        int timer_playing = 0;
        int editedrowindex = -1;
        int edit = 0;
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
        private RichTextBox check_NoteTextbox_Keydown;

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
            dataGridView1.Columns["1"].Width = 48;
            dataGridView1.Columns["2"].Width = 48;
            dataGridView1.Columns["3"].Width = 48;
            dataGridView1.Columns["4"].Width = 48;
            dataGridView1.Columns["5"].Width = 48;
            dataGridView1.Columns["6"].Width = 48;
            dataGridView1.Columns["7"].Width = 48;
            dataGridView1.Columns["8"].Width = 48;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            richTextBox12.KeyDown += RichTextBox12_KeyDown;
            richTextBox11.KeyDown += RichTextBox12_KeyDown;
            richTextBox10.KeyDown += RichTextBox12_KeyDown;
            richTextBox9.KeyDown += RichTextBox12_KeyDown;
            richTextBox8.KeyDown += RichTextBox12_KeyDown;
            richTextBox7.KeyDown += RichTextBox12_KeyDown;
            richTextBox6.KeyDown += RichTextBox12_KeyDown;
            richTextBox5.KeyDown += RichTextBox12_KeyDown;
            richTextBox3.KeyDown += RichTextBox3_KeyDown;
        }

        private void RichTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void RichTextBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode!=Keys.Back && e.KeyCode!=Keys.A && e.KeyCode!=Keys.B && e.KeyCode!=Keys.C && e.KeyCode!=Keys.D && e.KeyCode!=Keys.E && e.KeyCode != Keys.F && e.KeyCode != Keys.G && e.KeyCode != Keys.A && e.KeyCode != Keys.B && e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.D4 && e.KeyCode != Keys.D5 && e.KeyCode != Keys.D6)
            {
                e.SuppressKeyPress = true;
            }
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

        private void button23_Click(object sender, EventArgs e) // not lang
        {
            display_on_textbox("."); // display luon, ko can doi user chon cao do
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
        
        private void button16_Click(object sender, EventArgs e) // play button
        {
            is_playing++;
            if (is_playing%2==1) // is playing
            {
                dataGridView1.AllowUserToDeleteRows = false;
                button21.Enabled = false;
                //button22.Enabled = false;
                button16.BackgroundImage = Properties.Resources.Pause_Button;
                if (richTextBox3.Text == "")
                    richTextBox3.Text = "120";
                //
                tempo = int.Parse(richTextBox3.Text);
                float exchange = (((float)30 /tempo))*1000;

                timer1.Interval = (int)(exchange);              

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int j=0; j<row.Cells.Count;j++)
                    {
                        if (row.Cells[j].Value!="")
                        {
                            notes[lines] = "" + row.Cells[j].Value;
                            lines++;
                        }
                    }

                }
                timer_playing = 0;
                timer1.Start();

            }
            else //pause
            {
                timer1.Stop();
                dataGridView1.AllowUserToDeleteRows = true;
                button21.Enabled = true;
                //button22.Enabled = true;
                button16.BackgroundImage = Properties.Resources.Play_Button;
                for (int j = 0; j <= lines; j++)
                    notes[lines] = "";
                lines = 0;
                timer_playing = 0;
                Array.Clear(notes, 0, notes.Length);
            }
        }
        private bool check_StringInBox(RichTextBox a)
        {
            if (a.Text == "C4" ||a.Text == "D4" ||a.Text == "E4" || a.Text == "F4" ||a.Text == "G4" || a.Text == "A4" || a.Text == "B4" ||a.Text=="C5"|| a.Text == "D5" || a.Text == "E5" || a.Text == "F5" || a.Text == "G5" || a.Text == "A5" || a.Text == "B5" || a.Text == "C6" || a.Text == "."||a.Text=="")
                return true;
            else if (a.Text == "c4" || a.Text == "d4" || a.Text == "e4" || a.Text == "f4" || a.Text == "g4" || a.Text == "a4" || a.Text == "b4" || a.Text == "c5" || a.Text == "d5" || a.Text == "e5" || a.Text == "f5" || a.Text == "g5" || a.Text == "a5" || a.Text == "b5" || a.Text == "c6" || a.Text == "." || a.Text == "")
                   return true;
            return false;
        }
        private void button21_Click(object sender, EventArgs e) // save button
        {
            if (edit == 0) //them moi binh thuong
            {
                int flag = 0;
                if (check_StringInBox(richTextBox12) && check_StringInBox(richTextBox11) && check_StringInBox(richTextBox10) && check_StringInBox(richTextBox9) && check_StringInBox(richTextBox8) && check_StringInBox(richTextBox7) && check_StringInBox(richTextBox6) && check_StringInBox(richTextBox5))
                    flag = 1;
                if (flag == 0)
                {
                    MessageBox.Show("Khong dung loai, hay kiem tra lai", "Khong the them vao");
                }
                else
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
                    richTextBox12.Text = richTextBox11.Text = richTextBox10.Text = richTextBox9.Text = richTextBox8.Text = richTextBox7.Text = richTextBox6.Text = richTextBox5.Text = "";
                }
            }
            else //sua dong chinh xac
            {
                DataRow row = NotNhac.Rows[editedrowindex];
                row["1"] = richTextBox12.Text;
                row["2"] = richTextBox11.Text;
                row["3"] = richTextBox10.Text;
                row["4"] = richTextBox9.Text;
                row["5"] = richTextBox8.Text;
                row["6"] = richTextBox7.Text;
                row["7"] = richTextBox6.Text;
                row["8"] = richTextBox5.Text;
                richTextBox12.Text = richTextBox11.Text = richTextBox10.Text = richTextBox9.Text = richTextBox8.Text = richTextBox7.Text = richTextBox6.Text = richTextBox5.Text = "";
                edit = 0;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) //xoa dong
        {
            if (e.RowIndex >= 0 && e.RowIndex < NotNhac.Rows.Count)
            {
                NotNhac.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playing%2==1&&timer_playing < lines)
            {
                switch(notes[timer_playing])
                {
                    case "C4": C4.Play(); break;
                    case "D4": D4.Play(); break;
                    case "E4": E4.Play(); break;
                    case "F4": F4.Play(); break;
                    case "G4": G4.Play(); break;
                    case "A4": A4.Play(); break;
                    case "B4": B4.Play(); break;
                    case "C5": C5.Play(); break;
                    case "D5": D5.Play(); break;
                    case "E5": E5.Play(); break;
                    case "F5": F5.Play(); break;
                    case "G5": G5.Play(); break;
                    case "A5": A5.Play(); break;
                    case "B5": B5.Play(); break;
                    case "C6": C6.Play(); break;
                    case "c4": C4.Play(); break;
                    case "d4": D4.Play(); break;
                    case "e4": E4.Play(); break;
                    case "f4": F4.Play(); break;
                    case "g4": G4.Play(); break;
                    case "a4": A4.Play(); break;
                    case "b4": B4.Play(); break;
                    case "c5": C5.Play(); break;
                    case "d5": D5.Play(); break;
                    case "e5": E5.Play(); break;
                    case "f5": F5.Play(); break;
                    case "g5": G5.Play(); break;
                    case "a5": A5.Play(); break;
                    case "b5": B5.Play(); break;
                    case "c6": C6.Play(); break;
                    case "": break;
                }
                timer_playing++;
            }
            else if (timer_playing >= lines)
            {
                is_playing++;
                timer1.Stop();
                dataGridView1.AllowUserToDeleteRows = true;
                button21.Enabled = true;
                //button22.Enabled = true;
                button16.BackgroundImage = Properties.Resources.Play_Button;
                for (int j = 0; j <= lines; j++)
                    notes[lines] = "";
                lines = 0;
                timer_playing = 0;
                Array.Clear(notes, 0, notes.Length);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataRow row;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editedrowindex = dataGridView1.SelectedRows[0].Index;
                DataRow editedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;
                edit = 1;
                richTextBox12.Text = editedRow["1"].ToString();
                richTextBox11.Text = editedRow["2"].ToString();
                richTextBox10.Text = editedRow["3"].ToString();
                richTextBox9.Text = editedRow["4"].ToString();
                richTextBox5.Text = editedRow["5"].ToString();
                richTextBox6.Text = editedRow["6"].ToString();
                richTextBox7.Text = editedRow["7"].ToString();
                richTextBox8.Text = editedRow["8"].ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // File -> Save
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Save Your Sheet";
            saveFileDialog1.FileName = richTextBox4.Text + ".txt";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string filePath = saveFileDialog1.FileName;
                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        for (int i = 0; i < 8; i++)
                            writer.Write(row.Cells[i].Value.ToString());
                        writer.Write("\n");
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) // File -> Open
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"C:\My Documents";
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Open A Sheet";
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            if (File.Exists(filePath))
            {
                // Xoa nhung thu dang co trong dataGridView1
                if (NotNhac.Rows.Count > 0)
                    NotNhac.Rows.Clear();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        DataRow row = NotNhac.NewRow();
                        if (line[0].ToString() == ".") // dau cham doi
                        {
                            row["1"] = ".";
                            int length_of_line = line.Length;
                            for (int i = 1; i < length_of_line; i++)
                                row[i] = line[i].ToString();
                            for (int i = length_of_line; i < 8; i++)
                                row[i] = "";
                            NotNhac.Rows.Add(row);
                        }
                        else // cac not binh thuong
                        {
                            row["1"] = line[0].ToString() + line[1].ToString();
                            int length_of_line = line.Length;
                            for (int i = 2; i < length_of_line; i++)
                                row[i - 1] = line[i].ToString();
                            for (int i = length_of_line; i < 8; i++)
                                row[i] = "";
                            NotNhac.Rows.Add(row);
                        }
                    }
                }
            } 
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            editedrowindex = -1;
            edit = 0;
            richTextBox12.Text = richTextBox11.Text = richTextBox10.Text = richTextBox9.Text = richTextBox8.Text = richTextBox7.Text = richTextBox6.Text = richTextBox5.Text = "";
        }
    }
}
