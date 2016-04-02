using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public static Snake snake = new Snake();
        public static Food food = new Food();
        public static Wall wall = new Wall();
        public static int level = 1;
        public static int prevdx, prevdy;
        public enum Direction {up, down, right, left};
        public static Direction direction;
        public static int speed = 100;
        public static Thread t = new Thread(MoveSnake);

        public static bool GameOver = false;

        public Game()
        {
            Init();
            Play();
        }

        public static void Init()
        {
            food.SetNewPosition();
            wall.LoadLevel(level);
        }


        public void Play()
        {
            t.Start();
            while (!GameOver)
            {
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                    direction = Direction.up;
                if (button.Key == ConsoleKey.DownArrow)
                    direction = Direction.down;
                if (button.Key == ConsoleKey.LeftArrow)
                    direction = Direction.left;
                if (button.Key == ConsoleKey.RightArrow)
                    direction = Direction.right;
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();
            }
            
        }

        public static void MoveSnake (object state)
        {
            if (snake.body.Count % 4 == 0) {
                level++;
                Console.Clear();
                wall.body.Clear();
                wall.LoadLevel(level);
                Draw();
                speed -= 50;
            }


            while (!GameOver)
            {
                switch (direction)
                {
                    case Direction.up:
                        snake.move(0, -1);
                        break;
                    case Direction.down:
                        snake.move(0, 1);
                        break;
                    case Direction.left:
                        snake.move(-1, 0);
                        break;
                    case Direction.right:
                        snake.move(1, 0);
                        break;
                    default: break;
                }
                Draw();
                
                Thread.Sleep(speed);
            }

        }

        public static void Draw()
        {
            //Console.Clear();
            food.Draw();
            snake.Draw();
            wall.Draw();
        }
        public void Save()
        {
            Console.Clear();
            snake.Save();
            food.Save();
            wall.Save();
        }

        public void Resume()
        {
            Console.Clear();
            snake.Resume();
            food.Resume();
            wall.Resume();
        }

    }
}