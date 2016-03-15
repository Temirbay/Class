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
        public static int level;
        public static int prevdx, prevdy;
        public enum Direction {up, down, right, left};
        public static Direction direction;
        public static int speed = 50;

        public static bool GameOver = false;

        public Game()
        {
            Init();
            Play();

        }

        public void Init()
        {
            food.SetNewPosition();
            wall.LoadLevel(1);
            level = 1;
        }


        public void Play()
        {
            Thread t = new Thread (MoveSnake);
            t.Start();
           Draw();
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

                if (button.Key == ConsoleKey.F5)
                {
                    wall.LoadLevel(level + 1);
                }
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();

                GameOver = snake.CollisionWithWall();
                if (GameOver == true) continue;
                GameOver = snake.CollisionWithSnake();
            }
            if (GameOver == true)
            {
                Console.Clear();
                Console.WriteLine("Game Over!!!!");
                Console.ReadKey();
            }
        }

        public static void MoveSnake (object state)
        {

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
            Console.Clear();
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