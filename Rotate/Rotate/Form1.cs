using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rotate
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            p = new Pen(Color.Red, 5);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(30, 30, 150, 80);

            g.TranslateTransform(r.Left + (r.Width / 2), r.Top + (r.Height / 2));
            g.RotateTransform(45);
            g.DrawRectangle(p, r);
        }
    }
}
