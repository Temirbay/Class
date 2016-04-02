using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureHouse
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        Pen p2;
        SolidBrush b;

        public Form1()
        {
            InitializeComponent();
            b = new SolidBrush(Color.Orange);
            p = new Pen(Color.Black);
            p.Width = 2;
            p2 = new Pen(Color.Black);
            p2.Width = 4;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Point[] Triangle =
            {
                new Point (100, 5),
                new Point(33, 108),
                new Point(167, 108),
            };
            g.DrawPolygon(p, Triangle);
            g.FillPolygon(b, Triangle);

            g.DrawRectangle(p, 33, 108, 134, 100);
            g.FillRectangle(b, 33, 108, 134, 100);
            
            g.FillEllipse(new SolidBrush(Color.Red), 85, 68, 30, 30);

            Point[] Door =
            {
                new Point(124, 167),
                new Point(124, 208),
                new Point(167, 167),
                new Point (167, 208),
            };
            g.DrawRectangle(p, 124, 167, 42, 41);
            g.FillRectangle(new SolidBrush (Color.Gray), 124, 167, 42, 41);

            g.DrawLine(p, 145, 190, 150, 190);

            g.DrawRectangle(p, 33, 130, 35, 35);
            g.FillRectangle(new SolidBrush(Color.White), 33, 130, 35, 35);
            g.DrawLine(p, 33, 148, 68, 148);
            g.DrawLine(p, 51, 130, 51, 165);

            g.DrawLine(p2, 334, 210, 334, 165);

            Point[] PolyPoints =
            {
                new Point (334, 165),
                new Point (334, 125),
                new Point (354, 136),
                new Point (354, 156),
                new Point (334, 165),
                new Point (314, 156),
                new Point (314, 136),
                new Point (334, 125),
            };
            g.DrawPolygon(p, PolyPoints);
            g.FillPolygon(new SolidBrush(Color.Yellow), PolyPoints);
            g.DrawPolygon(new Pen(Color.Red, 3), PolyPoints);

            g.DrawLine(new Pen (Color.Red, 3), 314, 136, 354, 156);
            g.DrawLine(new Pen(Color.Red, 3), 314, 156, 354, 136);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location);
        }
    }
}
