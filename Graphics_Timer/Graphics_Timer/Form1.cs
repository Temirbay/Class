using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Graphics_Timer
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        float x = 50, y = 50;
        float dx = 5;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen = new Pen(Color.Red, 5);
            timer1.Start();
            timer1.Interval = 20;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawRectangle(pen, x + 25, y - 25, 50, 25);
            g.DrawRectangle(pen, x, y, 100, 40);
            g.DrawEllipse(pen, x, y + 40, 30, 30);
            g.DrawEllipse(pen, x + 70, y + 40, 30, 30);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x + 100 > Width || x < 0) dx *= -1;

            x += dx;
            Refresh();
        }
    }
}
