using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Complex
    {
        public int a;
        public int b;

        public Complex (int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public Complex ()
        {

        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            int d = c1.a * c2.b + c2.a * c1.b;
            int n = c1.b * c2.b;
            int g = gcd(d, n);
            d = d / g;
            n = n / g;
            return new Complex(d, n);
        }

        public static int gcd (int a, int b)
        {
            if (b == 0) return a;
            return gcd (b, a % b);
        }

        public override string ToString()
        {
            return a + "/" + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s1, s2, s3, s4;

            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
            s3 = Console.ReadLine();
            s4 = Console.ReadLine();
            
            int a = int.Parse(s1);
            int b = int.Parse(s2);
            int c = int.Parse(s3);
            int d = int.Parse(s4);

            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);

            Complex ans = new Complex();
            ans = c1 + c2;

            Console.WriteLine(ans);
            Console.ReadKey();
        }
    }
}
