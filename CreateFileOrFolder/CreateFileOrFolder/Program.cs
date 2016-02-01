using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFileOrFolder
{
    public class CreateFileOrFolder
    {
        static void Main()
        {
            string folderName = @"c:\Main Folder";

            string pathString = Path.Combine(folderName, "SubFolder");
            Directory.CreateDirectory(pathString);

            string fileName = Path.Combine(pathString, "MyFile");
            pathString = Path.Combine(pathString, fileName);

            Console.WriteLine("Path to my file: {0}\n", pathString);

            if (!File.Exists(pathString))
            {
                using (FileStream F = File.Create(pathString))
                {
                    for (byte i = 1; i < 100; i+=2)
                        F.WriteByte(i);
                }
            }
   
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                Console.ReadKey();
                return;
            }
            
            try
            {
                byte[] FileBytes = File.ReadAllBytes(pathString);
                foreach (byte i in FileBytes)
                    Console.Write(i + ", ");
                Console.WriteLine();
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
