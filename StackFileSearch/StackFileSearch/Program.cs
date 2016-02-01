using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFileSearch
{
    public class myPair
    {
        private string name;
        private int depth;
        public myPair(string name, int depth)
        {
            this.name = name;
            this.depth = depth;
        }
        public myPair()
        {
            name = "";
            depth = 0;
        }
        public string getName()
        {
            return this.name;
        }
        public int getDepth()
        {
            return this.depth;
        }
    }

    class Program
    {
        public static void Walk (string d)
        {
            Stack<myPair> stack = new Stack <myPair> ();

            string[] files;
            string[] directories;
            myPair temp;
            stack.Push( new myPair(d,0));
            while (stack.Count > 0)
            {
                temp = stack.Pop();
                int depth = temp.getDepth();
                files = Directory.GetFiles(temp.getName());
                foreach (string file in files)
                {
                    for (int i = 0; i < depth; ++i) Console.Write ("  ");
                    FileInfo f = new FileInfo(file);
                    Console.WriteLine("File name: {0} Size: {1}, Creation Time: {2}", f.Name, f.Length, f.CreationTime);
                    Console.ReadKey();
                   
                }

                directories = Directory.GetDirectories(temp.getName());
                foreach (string directory in directories)
                    stack.Push (new myPair (directory, depth + 1));
                
            }
        }

        static void Main(string[] args)
        {
            string f = @"D:\films";
            Walk(f);
            Console.ReadKey();
        }
    }
}
