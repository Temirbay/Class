using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyingFiles
{
    public class SimpleFileCopy
    {
        static void Main()
        {
            string fileName = "test.txt";
            string From = @"C:\Users\Public\TestFolder";
            string To = @"C:\Users\Public\TestFolder\SubFolder";

            string sourceFile = Path.Combine(From, fileName);
            string destFile = Path.Combine(To, fileName);

            if (!Directory.Exists(To))
            {
                Directory.CreateDirectory(To);
            }

            File.Copy(sourceFile, destFile, true);

            if (Directory.Exists(From))
            {
                string[] files = Directory.GetFiles(From);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(To, fileName);
                    File.Copy(s, destFile, true);
                }
            }
            else
               Console.WriteLine("Source path does not exist!");
            
            Console.ReadKey();
        }
    }
}
