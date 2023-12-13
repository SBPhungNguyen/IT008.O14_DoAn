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
    public partial class Guide : Form
    {
        int current_image_index = 0;
        Image[] images = new Image[7];

        public Guide()
        {
            InitializeComponent();
        }

        private void Guide_Load(object sender, EventArgs e)
        {
            images[0] = Properties.Resources.Guide_1_LogIn;
            images[1] = Properties.Resources.Guide_2_NameYourSong;
            images[2] = Properties.Resources.Guide_34_ChooseNotNhac;
            images[3] = Properties.Resources.Guide_5_SaveNotNhac;
            images[4] = Properties.Resources.Guide_6_PlayYourSong;
            images[5] = Properties.Resources.Guide_7_SaveYourSong;
            images[6] = Properties.Resources.Guide_8_OtherOptions;
            pictureBox1.Image = images[current_image_index];
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (current_image_index > 0)
            {
                current_image_index--;
                pictureBox1.Image = images[current_image_index];
            }
            else
                PreviousButton.IsAccessible = false;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (current_image_index < 6)
            {
                current_image_index++;
                pictureBox1.Image = images[current_image_index];
            }
            else
                NextButton.IsAccessible = false;
        }
    }
}
