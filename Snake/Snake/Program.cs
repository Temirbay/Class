using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake
{
    class Program
    {
        public static int[] x = new int[1000];
        public static int[] y = new int[1000];
        public static int foodX,foodY;
        public static int len;

        public static void KeyReader()
        {
            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.UpArrow)
            {
                if (y[0] > 0)
                    y[0]--;
                else
                    y[0] = Console.WindowHeight - 2;
            }
            if (button.Key == ConsoleKey.DownArrow)
            {
                if (y[0] < Console.WindowHeight - 2)
                    y[0]++;
                else
                    y[0] = 0;
            }
            if (button.Key == ConsoleKey.LeftArrow)
            {
                if (x[0] > 0)
                    x[0]--;
                else
                    x[0] = Console.WindowWidth - 2;
            }
            if (button.Key == ConsoleKey.RightArrow)
            {
                if (x[0] < Console.WindowWidth - 2)
                    x[0]++;
                else
                    x[0] = 0;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void Drawer()
        {

            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < len; i++)
            {
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write("*");
            }
            for (int i = len - 1; i >= 1; i--)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }
        }
        public static bool GetFood(){
            bool res = false;
            if (foodX == x[0] && foodY == y[0])
            {
                res = true;
            }
            return res;
        }
        public static void Food (bool newFood)
        {
            bool ok = true;
            if(newFood)
                while (ok)
                {
                    ok = false;
                    Random rnd = new Random();
                    foodX = rnd.Next() % (Console.WindowWidth - 1);
                    foodY = rnd.Next() % (Console.WindowHeight - 1);
                    for (int i = 0; i < len; ++i)
                    {
                        if (foodX == x[i] && foodY == y[i]) ok = true;
                    }             
                }
            
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(foodX, foodY);
            Console.Write("o");
        }


        static void Main(string[] args)
        {

            len = 1;
            bool GameIN = true;
            int level = 1;
            // x = {1, 2, 3}
            // y = {1, 1, 1}
            // x = {1  1  2}
            // y = {2  1  1}
            //int k = 0;
            Food(true);
            while (GameIN)
            {
                if (level == 1)
                {
                    Drawer();
                    Food(false);
                    KeyReader();
                    if (GetFood())
                    {
                        len++;
                        Food(true);
                    }
                    if (len == 5)
                    {
                        level++;
                        len = 0;
                    }
                }
                //  k++;
                //if (k % 5 == 0)
                //  len++;
                if (level == 2)
                {
                    GameIN = false;

                }
            }
        }
    }
}