using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFromStream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fread = new FileStream(@"C:\PT_labs\TestFolder\input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fwrite = new FileStream(@"C:\PT_labs\TestFolder\output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader fr = new StreamReader(fread);
            StreamWriter fw = new StreamWriter(fwrite);

            int MAX = -1000000000;
            int MIN = 1000000000;

            while (fr.Peek() >= 0)
            {
                string s = fr.ReadLine();
                int num = int.Parse(s);

                if (num < MIN) MIN = num;
                if (num > MAX) MAX = num; 
            }

            fw.WriteLine(MAX);
            fw.WriteLine(MIN);

            fr.Close();
            fw.Close();
            fread.Close();
            fwrite.Close();
        }
    }
}
