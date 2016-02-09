using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Wall : Drawer
    {
        public Wall ()
        {
            color = ConsoleColor.Red;
            sign = '#';
        }

        public void LoadLevel (int level)
        {
            string s = string.Format("level{0}.txt", level);
            FileStream fs = new FileStream(s, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            body.Clear();
            string[] array = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < array.Length; ++i)
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if (array[i][j] == '#')
                        body.Add(new Point(j, i)); 
                }
        }

        public bool FoodWallCollision (int a, int b)
        {
            foreach (Point p in body)
                if (p.x == a && p.y == b)
                    return true;

            return false;
        }
    }
}
