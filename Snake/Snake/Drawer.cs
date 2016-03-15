using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point> ();

        public Drawer () { }

        
        public virtual void Draw ()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            { 
                Console.SetCursorPosition(p.x, p.y);
                    Console.Write(sign);
            }
        }
        
        public void Save ()
        {
            string s = "";

            if (sign == 'O') s = "snake.xml";
            if (sign == '#') s = "wall.xml";
            if (sign == '$') s = "food.xml";

            FileStream fs = new FileStream(s, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(GetType());

            xs.Serialize(fs, this);
            fs.Close();
        }



        public void Resume ()
        {
            string s = ""; 
            if (sign == 'O') s = "snake.ser";
            if (sign == '#') s = "wall.xml";
            if (sign == '$') s = "food.xml";

            FileStream fs = new FileStream(s, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(GetType());

            if (sign == '$') Game.food = xs.Deserialize(fs) as Food;
            if (sign == '#') Game.wall = xs.Deserialize(fs) as Wall;
            if (sign == 'O') Game.snake = xs.Deserialize(fs) as Snake;

            File.Delete(s);
            
            fs.Close(); 
        }
    }
}
