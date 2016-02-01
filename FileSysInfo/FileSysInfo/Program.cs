using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSysInfo
{
    class FileSysInfo
    {
        static void Main()
        {
            DriveInfo D = new DriveInfo(@"C:\");
            Console.WriteLine(D.TotalFreeSpace);
            Console.WriteLine(D.VolumeLabel);

            DirectoryInfo dirInfo = D.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            FileInfo[] files = dirInfo.GetFiles("*.*");
            foreach (FileInfo f in files)
                Console.WriteLine("{0}: {1}: {2}", f.Name, f.LastAccessTime, f.Length);
            
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
            foreach (DirectoryInfo d in dirInfos)
                Console.WriteLine(d.Name);

            string currentDirName = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);
            
            string[] Files = Directory.GetFiles(currentDirName, "*.txt");

            foreach (string s in Files)
            {
                FileInfo fi = null;
                try
                {
                    fi = new FileInfo(s);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("{0} : {1}", fi.Name, fi.Directory);
            }
            
            if (Directory.Exists(@"C:\Users\Public\TestFolder\"))
                Directory.CreateDirectory(@"C:\Users\Public\TestFolder\");
            
            Directory.SetCurrentDirectory(@"C:\Users\Public\TestFolder\");

            currentDirName = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);
            Console.ReadKey();
        }
    }
}
