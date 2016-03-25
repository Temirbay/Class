using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class Calculate
    {
        public double first;
        public double second;
        private double result;
        public string operation;
        public double memory = 0;

        public void Calc()
        {
            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                case "sqrt":
                    result = Math.Sqrt(first);
                    break;
                case "x^y":
                    result = Math.Pow(first, second);
                    break;
                case "x^2":
                    result = first * first;
                    break;
                case "x!":
                    result = factorial(first);
                    break;
                case "%":
                    result = (100 * second) / first;
                    break;
                case "mod":
                    result = first % second;
                    break;
                case "sin":
                    result = Math.Sin(first);
                    break;
                case "cos":
                    result = Math.Cos(first);
                    break;
                case "tan":
                    result = Math.Tan(first);
                    break;
                case "arcsin":
                    result = Math.Asin(first);
                    break;
                case "arccos":
                    result = Math.Acos(first);
                    break;
                case "arctan":
                    result = Math.Atan(first);
                    break;
                case "log":
                    result = Math.Log10(first);
                    break;
                case "10^x":
                    result = Math.Pow (10, first);
                    break;
                default:
                    break;
            }
        }
        public double Result
        {
            get { return result; }
            set { result = value; }
        }

        public double factorial(double num) 
        {
            double ans = 1;
            for (int i = 1; i <= num; ++i) 
                ans *= i;

            return ans;
        }
    }
}
