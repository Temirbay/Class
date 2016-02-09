﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : Drawer
    {
        public Snake ()
        {
            color = ConsoleColor.Green;
            sign = 'O';
            body.Add(new Point (0, 0));
        }

        public void move (int dx, int dy)
        {
            if (0 - Game.prevdx == dx && 0 - Game.prevdy == dy && body.Count > 1)
                return;

            Game.prevdx = dx;
            Game.prevdy = dy;
            
            for (int i = body.Count-1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (body[0].x + dx < 0) body[0].x = Console.WindowWidth - 1;
            else if (body[0].x + dx > Console.WindowWidth - 1) body[0].x = 0;
            else body[0].x += dx;

            if (body[0].y + dy < 0) body[0].y = Console.WindowHeight - 1;
            else if (body[0].y + dy > Console.WindowHeight - 1) body[0].y = 0;
            else body[0].y += dy;

            if (body[0].x == Game.food.body[0].x &&
                body[0].y == Game.food.body[0].y)
            {
                body.Add(new Point(0, 0));
                Game.food.SetNewPosition();
            }
     
        }
        public bool CollisionWithWall ()
        {
            foreach (Point p in Game.wall.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollisionWithSnake ()
        {
            for (int i = body.Count - 1; i > 1; --i)
                if (body[0].x == body[i].x && body[0].y == body[i].y) return true;
            return false;
        }
    }
}
