using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse (Console.ReadLine ());
            int[] array = new int[n + 1];
            for (int i = 1; i <= n; ++i)
                array[i] = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; ++i)
            {
                bool ok = true;
                for (int j = 2; j * j <= array[i]; ++j)
                    if (array[i] % j == 0)
                        ok = false;
                if (ok == true)
                    Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}
