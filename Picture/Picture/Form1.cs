using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush;
        Pen p;
        Pen pnr = new Pen(Color.Yellow);


        public Form1()
        {
            InitializeComponent();
            brush = new SolidBrush(Color.Blue);
            p = new Pen(Color.Black);
            p.Width = 10;
            pnr.Width = 7;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(brush, 0, 0, Width, Height);

            Point[] YellowPoints =
            {
               new Point(350,225),
               new Point(300,250),
               new Point(300,300),
               new Point(350,325),
               new Point(400,300),
               new Point(400,250),
            };

            g.FillPolygon(new SolidBrush(Color.Yellow), YellowPoints);
            
            Point[] GreenPoints =
            {
                new Point(350,250),
                new Point(325,275),
                new Point(340,275),
                new Point(340,300),
                new Point(360,300),
                new Point(360,275),
                new Point(375,275)
            };
            g.FillPolygon(new SolidBrush(Color.Green), GreenPoints);

            g.FillEllipse(new SolidBrush(Color.White), 70, 70, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 100, 390, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 290, 50, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 445, 135, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 710, 210, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 620, 310, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 700, 435, 25, 25);
            g.FillEllipse(new SolidBrush(Color.White), 290, 350, 25, 25);

            Point[] Star1Points =
            {
                new Point(165,85),
                new Point(153,105),
                new Point(130,106),
                new Point(145,120),
                new Point(135,140),
                new Point(155,140),
                new Point(165,155),
                new Point(175,139),
                new Point(195,139),
                new Point(185,120),
                new Point(200,105),
                new Point(177,105),

            };
            g.FillPolygon(new SolidBrush(Color.Red), Star1Points);

            Point[] Star2Points =
           {
                new Point(165+50,85+140),
                new Point(153+50,105+140),
                new Point(130+50,106+140),
                new Point(145+50,120+140),
                new Point(135+50,140+140),
                new Point(155+50,140+140),
                new Point(165+50,155+140),
                new Point(175+50,139+140),
                new Point(195+50,139+140),
                new Point(185+50,120+140),
                new Point(200+50,105+140),
                new Point(177+50,105+140),
            };
            g.FillPolygon(new SolidBrush(Color.Red), Star2Points);

            Point[] Star3Points =
            {
                new Point(165+350,85),
                new Point(153+350,105),
                new Point(130+350,106),
                new Point(145+350,120),
                new Point(135+350,140),
                new Point(155+350,140),
                new Point(165+350,155),
                new Point(175+350,139),
                new Point(195+350,139),
                new Point(185+350,120),
                new Point(200+350,105),
                new Point(177+350,105),

            };
            g.FillPolygon(new SolidBrush(Color.Red), Star3Points);

            Point[] Star4Points =
            {
                new Point(165+400,85+240),
                new Point(153+400,105+240),
                new Point(130+400,106+240),
                new Point(145+400,120+240),
                new Point(135+400,140+240),
                new Point(155+400,140+240),
                new Point(165+400,155+240),
                new Point(175+400,139+240),
                new Point(195+400,139+240),
                new Point(185+400,120+240),
                new Point(200+400,105+240),
                new Point(177+400,105+240),
            };

            g.FillPolygon(new SolidBrush(Color.Red), Star4Points);

            g.FillEllipse(new SolidBrush(Color.Green), 375, 225, 25, 8);
            g.FillEllipse(new SolidBrush(Color.Green), 383, 216, 8, 25);
            
            g.FillRectangle(new SolidBrush(Color.White), 540, 20, 220, 40);
             g.DrawRectangle(pnr, 540, 20, 220, 40);

            
            using (Font font = new Font("Arial", 12, FontStyle.Italic))
            {
                Rectangle rect = new Rectangle(545, 30, 220, 75);
                g.DrawString("Level: 1 Score 200 Live: ***", font, Brushes.Black, rect);
            }
            
            g.DrawRectangle(p, 5, 5, 770, 485);
            
        }
    }
}
