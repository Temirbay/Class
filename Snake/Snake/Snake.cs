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
            for (int i = body.Count-1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;

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
    }
}
