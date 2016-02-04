using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPrimeFromNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fread = new FileStream(@"C:\PT_labs\TestFolder\input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fwrite = new FileStream(@"C:\PT_labs\TestFolder\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader fr = new StreamReader(fread);
            StreamWriter fw = new StreamWriter(fwrite);

            int MIN = 1000000000;

            while (fr.Peek() >= 0)
            {
                string s = fr.ReadLine();
                int num = int.Parse(s);

                bool ok = true;
                for (int i = 2; i*i <= num; ++i)
                {
                    if (num % i == 0) ok = false;
                }
                if (ok == true)
                {
                    if (num < MIN) MIN = num;
                }
            }

            fw.WriteLine(MIN);

            fr.Close();
            fw.Close();
            fread.Close();
            fwrite.Close();

        }
    }
}
