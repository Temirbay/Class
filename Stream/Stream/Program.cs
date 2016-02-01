using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    // f("testfolder") = count_of_files + f("sdf") + f("test") + f("test1)
    // f("test1") = count_of_files + f("aaa") 

    class Program
    {
        static void Main(string[] args)
        {
            F3();
            Console.ReadKey();
        }

        static void F3()
        {
            FileStream fread = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fwrite = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader sr = new StreamReader(fread);
            StreamWriter sw = new StreamWriter(fwrite);

            string[] token = sr.ReadLine().Split();
            // token[0] = 1
            // token[1] = 23 ...
            int sum = 0;
            while (sr.Peek() >= 0)
            {
                string s = sr.ReadLine();
                int num = new;

            }
            for (int i = 0; i < token.Length; i++)
            {
                sum += int.Parse(token[i]);
            }
            sw.WriteLine(sum);

            sw.Close();
            sr.Close();
            fwrite.Close();
            fread.Close();
        }
        
    }
}