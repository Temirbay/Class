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
        public enum Shape { Pencil, Circle, Rectangle, Line, Raser, Triangle, Brush};

        public Graphics g;
        public GraphicsPath path;

        public Point prev;
        public Bitmap b;
        public Pen pen;
        public Pen raser;
        public bool ok = false;
        public PictureBox picture;
        public Shape shape;
        public Queue<Point> q = new Queue<Point>();
        public bool[,] used;
        public Color color;

        public Drawer (PictureBox p)
        {
            picture = p;
            b = new Bitmap(picture.Width, picture.Height);
            pen = new Pen(Color.Blue);
            raser = new Pen(Color.White, 5);

            used = new bool[picture.Width+1, picture.Height+1];
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
            int x, y;
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
                    x = prev.X;
                    y = prev.Y;

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
                case Shape.Triangle:
                    path = new GraphicsPath();

                    if (prev.X > cur.X && prev.Y > cur.Y)
                    {
                        path.AddLine(cur.X, cur.Y, prev.X, prev.Y);
                        path.AddLine(prev.X, prev.Y, cur.X, prev.Y);
                        path.AddLine(cur.X, cur.Y, cur.X, prev.Y);

                    }

                    else if (prev.X < cur.X && prev.Y > cur.Y)
                    {
                        path.AddLine(prev.X, cur.Y, prev.X, prev.Y);
                        path.AddLine(prev.X, prev.Y, cur.X, prev.Y);
                        path.AddLine(cur.X, prev.Y, prev.X, cur.Y);
                    }

                    else if (prev.X > cur.X && prev.Y < cur.Y)
                    {
                        path.AddLine(cur.X, prev.Y, cur.X, cur.Y);
                        path.AddLine(cur.X, cur.Y, prev.X, cur.Y);
                        path.AddLine(prev.X, cur.Y, cur.X, prev.Y);
                    }

                    else
                    {
                        path.AddLine(prev.X, prev.Y, cur.X, cur.Y);
                        path.AddLine(cur.X, cur.Y, prev.X, cur.Y);
                        path.AddLine(prev.X, prev.Y, prev.X, cur.Y);
                    }
                    break;
                    
                default: break;
            }
            picture.Refresh();
        }

        public void fill (Point cur)
        {
            Color clicked_color = b.GetPixel (cur.X, cur.Y);
            check(cur.X, cur.Y, clicked_color);
            color = pen.Color;

            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                    used[i, j] = false;

            
            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                check(p.X + 1, p.Y, clicked_color);
                check(p.X - 1, p.Y, clicked_color);
                check(p.X, p.Y + 1, clicked_color);
                check(p.X, p.Y - 1, clicked_color);
            }
            
            picture.Refresh();
        }

        public void check (int x, int y, Color col)
        {
            if (x > 0 && y > 0 && x < picture.Width && y < picture.Height &&
                    used[x, y] == false && b.GetPixel(x, y) == col)
            {
                used[x, y] = true;
                q.Enqueue(new Point(x, y));
                b.SetPixel(x, y, color);
            }
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
