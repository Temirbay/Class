using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string Name;
        public string Surname;
        public double gpa;

        public Student (string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }

        public Student (string Name, string Surname, double gpa)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.gpa = gpa;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " +  gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("Miras", "Temirbay", 4.0);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
