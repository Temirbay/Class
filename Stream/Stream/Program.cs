using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Function();
            Console.ReadKey();
        }

        static void Function()
        {
            FileStream fread = new FileStream(@"C:\Users\Public\TestFolder\input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fwrite = new FileStream(@"C:\Users\Public\TestFolder\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(fread);
            StreamWriter sw = new StreamWriter(fwrite);

            int sum = 0;
            while (sr.Peek() >= 0)
            {
                string s = sr.ReadLine();
                int num = int.Parse(s);
                sum += num;
            }

            sw.WriteLine(sum);

            sw.Close();
            sr.Close();
            fwrite.Close();
            fread.Close();
        }
    }
}