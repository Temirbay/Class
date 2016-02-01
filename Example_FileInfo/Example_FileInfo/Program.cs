using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_FileInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"D:\films");
            FileInfo[] F = d.GetFiles();
            foreach (FileInfo i in F)
            {
                Console.WriteLine(i.Name);
            }
            Console.ReadKey();
        }
    }
}
