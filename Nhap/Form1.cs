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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            C4.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            D4.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            E4.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            F4.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            G4.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            A4.Play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            B4.Play();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            C5.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            D5.Play();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            E5.Play();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            F5.Play();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            G5.Play();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            A5.Play();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            B5.Play();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            C6.Play();
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
    }
}
