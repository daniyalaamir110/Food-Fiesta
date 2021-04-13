using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrderingApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox2.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox3.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox4.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox5.Image = FoodOrderingApp.Properties.Resources.star;
            lblStars.Text = "1 Star!";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox2.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox3.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox4.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox5.Image = FoodOrderingApp.Properties.Resources.star;
            lblStars.Text = "2 Stars!";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox2.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox3.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox4.Image = FoodOrderingApp.Properties.Resources.star;
            pictureBox5.Image = FoodOrderingApp.Properties.Resources.star;
            lblStars.Text = "3 Stars!";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox2.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox3.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox4.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox5.Image = FoodOrderingApp.Properties.Resources.star;
            lblStars.Text = "4 Stars!";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox2.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox3.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox4.Image = FoodOrderingApp.Properties.Resources.star2;
            pictureBox5.Image = FoodOrderingApp.Properties.Resources.star2;
            lblStars.Text = "5 Stars!";
        }
    }
}
