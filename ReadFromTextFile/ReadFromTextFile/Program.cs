using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromTextFile
{
    class ReadFromFile
    {
        static void Main()
        {
            string text = File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
            Console.WriteLine("Contents of WriteText.txt = {0}", text);

            string[] lines = File.ReadAllLines(@"C:\Users\Public\TestFolder\Name.txt");
            
            Console.WriteLine("Contents of Name.txt = ");
            foreach (string line in lines)
                Console.WriteLine("\t" + line);
            
            System.Console.ReadKey();
        }
    }
}
