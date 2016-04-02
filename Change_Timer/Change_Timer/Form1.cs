using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Change_Timer
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            brush = new SolidBrush(Color.Red);
            timer1.Start();
            timer1.Interval = 200;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            brush.Color = brush.Color == Color.Red ? Color.Blue : Color.Red;
            g.FillRectangle(brush, 0, 0, Width, Height);

        }
    }
}
