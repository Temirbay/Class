using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Drawer drawer;


        public Form1()
        {
            InitializeComponent();
            drawer = new Drawer(pictureBox1);
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawer.ok = true;
            drawer.prev = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawer.ok = false;
            drawer.SaveLastPath();
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawer.ok)
            {
                drawer.Draw(e.Location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawer.shape = Drawer.Shape.Pencil;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawer.shape = Drawer.Shape.Rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawer.shape = Drawer.Shape.Circle;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawer.shape = Drawer.Shape.Line;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawer.shape = Drawer.Shape.Raser;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            drawer.pen = new Pen(colorDialog1.Color);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawer.g.Clear(Color.White);
            drawer.path.Reset();
            drawer.picture.Refresh();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.OpenImage(openFileDialog1.FileName);
            }  
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG Files (*jpg)| *.jpg| PNG Files (*png)| *.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawer.SaveImage(saveFileDialog1.FileName);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 25;
            drawer.pen.Width = trackBar1.Value;
            drawer.raser.Width = trackBar1.Value;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
