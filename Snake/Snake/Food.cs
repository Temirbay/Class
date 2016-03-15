using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food : Drawer
    {
        public Food ()
        {
            color = ConsoleColor.Magenta;
            sign = '$';
        }

        public void SetNewPosition ()
        {
            int Width = Console.WindowWidth-1;
            int Height = Console.WindowHeight-1;
            int x = new Random().Next() % Width;
            int y = new Random().Next() % Height;

            while (Game.wall.FoodWallCollision(x, y) == true)
            {
                x = new Random().Next() % Width;
                y = new Random().Next() % Height;
            }

            while (Game.snake.FoodWallCollision(x, y) == true)
            {
                x = new Random().Next() % Width;
                y = new Random().Next() % Height;
            }


            if (body.Count == 0)
                body.Add(new Point(0, 0));
            else
            {
                body[0].x = x;
                body[0].y = y;
            }
        }
    }
}
