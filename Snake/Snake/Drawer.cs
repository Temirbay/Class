using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
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
            string fileName = "";
            switch (sign)
            {
                case '#':
                    fileName = "wall.ser";
                    break;
                case '$':
                    fileName = "food.ser";
                    break;
                case 'o':
                    fileName = "snake.ser";
                    break;
            }

            BinaryFormatter b = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            b.Serialize(fs, this);

            fs.Close();
        }



        public void Resume()
        {
            string fileName = "";
            switch (sign)
            {
                case '#':
                    fileName = "wall.ser";
                    break;
                case '$':
                    fileName = "food.ser";
                    break;
                case 'o':
                    fileName = "snake.ser";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            switch (sign)
            {
                    case '#':
                        Game.wall.body.Clear();
                        Game.wall = b.Deserialize(fs) as Wall;
                        break;
                    case '$':
                        Game.food.body.Clear();
                        Game.food = b.Deserialize(fs) as Food;
                        break;
                    case 'o':
                        Game.snake.body.Clear();
                        Game.snake = b.Deserialize(fs) as Snake;
                        break;
            }
            


                fs.Close();


        }
    }
}
