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

namespace Paint
{
    class Drawer
    {
        public enum Shape { Pencil, Circle, Rectangle, Line, Raser};

        public Graphics g;
        public GraphicsPath path;

        public Point prev, cur;
        public Bitmap b;
        public Pen pen;
        public Pen raser;
        public bool ok = false;
        public PictureBox picture;
        public Shape shape;

        public Drawer (PictureBox p)
        {
            picture = p;
            b = new Bitmap(picture.Width, picture.Height);
            pen = new Pen(Color.Red, 5);
            raser = new Pen(Color.White, 5);
       
            g = Graphics.FromImage(b);
            picture.Image = b;

            shape = Shape.Pencil;

            picture.Paint += Picture_Paint;

            OpenImage("");
        }

        public void Picture_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        public void SaveLastPath ()
        {
            if (path != null)
            {
                g.DrawPath(pen, path);
            }
        }

        public void Draw (Point cur) 
        {
            switch (shape)
            {
                case Shape.Pencil:
                    g.DrawLine(pen, prev, cur);
                    prev = cur;
                    break;
                case Shape.Rectangle:
                    path = new GraphicsPath();

                    int Height = Math.Abs(cur.X - prev.X);
                    int Width = Math.Abs(cur.Y - prev.Y);
                    int x = prev.X, y = prev.Y;

                    if (prev.X > cur.X && prev.Y > cur.Y) {x = cur.X; y = cur.Y;}
                    if (prev.X < cur.X && prev.Y > cur.Y) {x = prev.X; y = cur.Y;}      
                    if (prev.X > cur.X && prev.Y < cur.Y) {x = cur.X; y = prev.Y;}
                    
                    path.AddRectangle(new Rectangle(x, y, Height, Width)); 
                    break;
                case Shape.Circle:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle(prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y));
                    break;
                case Shape.Line:
                    path = new GraphicsPath();
                    path.AddLine(prev, cur);
                    break;
                case Shape.Raser:
                    g.DrawLine(raser, prev, cur);
                    prev = cur;
                    break;

                default: break;
            }
            picture.Refresh();
        }

        public void SaveImage (string filename)
        {
            b.Save(filename);
        }

        public void OpenImage (string filename)
        {
            b = filename == "" ? new Bitmap(picture.Width, picture.Height)
                : new Bitmap(filename);

            g = Graphics.FromImage(b);
            picture.Image = b;
        }

    }
}
