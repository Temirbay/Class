using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessing
{
    class Program
    {
          static void Main(string[] args)
            {
                System.Console.WriteLine("Number of command line parameters = {0}", args.Length);

                foreach (string s in args)
                    System.Console.WriteLine(s);

            Console.ReadKey();
            }
        }
    
}
