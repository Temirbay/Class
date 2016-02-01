using System;
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
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                System.Console.WriteLine("Usage: Factorial <num>");
                return 1;
            }

            // Try to convert the input arguments to numbers. This will throw
            // an exception if the argument is not a number.
            // num = int.Parse(args[0]);
            int num;
            bool test = int.TryParse(args[0], out num);
            if (test == false)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                System.Console.WriteLine("Usage: Factorial <num>");
                return 1;
            }

            // Calculate factorial.
            long result = Function.Factorial(num);

            // Print result.
            if (result == -1)
                System.Console.WriteLine("Input must be >= 0 and <= 20.");
            else
                System.Console.WriteLine("The Factorial of {0} is {1}.", num, result);

            return 0;
            Console.ReadKey();
        }
    }
}
