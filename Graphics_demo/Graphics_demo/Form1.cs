using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_demo
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            p = new Pen(Color.Red, 3); 
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawLine(p, 10, 10, 100, 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
