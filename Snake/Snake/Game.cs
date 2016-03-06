using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static bool GameOver = false;

        public Game() {
            Init();
            Play();
                
        }

        public void Init ()
        {
            food.SetNewPosition();
            wall.LoadLevel(1);
            level = 1;
        }
        

        public void Play ()
        {
            while (!GameOver)
            {
                Draw();
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                    snake.move(0, -1);
                if (button.Key == ConsoleKey.DownArrow)
                    snake.move(0, 1);
                if (button.Key == ConsoleKey.LeftArrow)
                    snake.move(-1, 0);
                if (button.Key == ConsoleKey.RightArrow)
                    snake.move(1, 0);
                
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

        public void Draw ()
        {
            Console.Clear();
            food.Draw();
            snake.Draw();
            wall.Draw();
        }
        public void Save ()
        {
            Console.Clear();
            snake.Save();
            food.Save();
            wall.Save();
        }

        public void Resume ()
        {
            Console.Clear();
            snake.Resume();
            food.Resume();
            wall.Resume();
        }

    }
}
