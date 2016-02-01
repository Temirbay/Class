using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingToTextFile
{
    class WriteTextFile
    {
        static void Main()
        {

            string[] lines = { "Temirbay", "Miras", "Erzhanuly" };
            File.WriteAllLines(@"C:\Users\Public\TestFolder\Name.txt", lines);

            
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);
            
            using (StreamWriter file = new StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("Miras"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
            
        }
    }
}
