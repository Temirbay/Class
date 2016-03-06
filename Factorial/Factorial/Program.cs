using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    public class Function
    {
        public static long Factorial (int n)
        {
            if ((n < 0) || (n > 20)) return -1;

            long Res = 1;
            for (int i = 1; i <= n; i++) Res *= i;
            return Res;
        }
    }

    class Class
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a numeric argument.");
                Console.WriteLine("Usage: Factorial <num>");
                Console.ReadKey();
                return 1;
            }

            int num;
            bool test = int.TryParse(args[0], out num);
            if (test == false)
            {
                Console.WriteLine("Please enter a numeric argument.");
                Console.WriteLine("Usage: Factorial <num>");
                Console.ReadKey();
                return 1;
            }
            
            long result = Function.Factorial(num);

            if (result == -1)
                Console.WriteLine("Input must be >= 0 and <= 20.");
            else
                Console.WriteLine("The Factorial of {0} is {1}.", num, result);

            Console.ReadKey();
            return 0;
        }
    }
}
