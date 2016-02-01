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
        public static void Walk(DirectoryInfo d, int depth)
        {
            FileInfo[] F = d.GetFiles();
            foreach (FileInfo i in F)
            {
                for (int ii = 0; ii < depth; ++ii) Console.Write("  ");
                Console.WriteLine("File Name {0}", i.Name);
            }

            DirectoryInfo[] D = d.GetDirectories();
            foreach (DirectoryInfo i in D)
                Walk(i, depth + 1);
        }

        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"D:\films");
            Console.WriteLine("Directory name: films");
            Walk(d, 0);
            Console.ReadKey();
        }
    }
}
