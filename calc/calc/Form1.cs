using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        private bool answered = false;
        private Calculate calc = new Calculate();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void num_click(object sender, EventArgs e)
        {
            if (answered) { display.Text = ""; answered = false; }
            if (display.Text == "0") display.Text = "";
            Button b = sender as Button;
            display.Text += b.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            calc.first = double.Parse(display.Text);
            calc.operation = b.Text;
            display.Text = "";
        }

        private void result_click(object sender, EventArgs e)
        {
            calc.second = double.Parse(display.Text);
            calc.Calc();
            display.Text = calc.Result.ToString();
            answered = true;
        }
        
        private void dot_click(object sender, EventArgs e)
        {
            if (!display.Text.Contains(","))
                display.Text += ",";
        }

        private void memory_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            
            switch (b.Text)
            {
                case "M+" :
                    calc.memory += double.Parse(display.Text);
                    display.Text = "0";
                    break;
                case "M-":
                    calc.memory -= double.Parse(display.Text);
                    display.Text = "0";
                    break;
                case "MS" :
                    calc.memory = double.Parse(display.Text);
                    display.Text = "0";
                    break;    
                case "MC" :
                    calc.memory = 0;
                    display.Text = "0";
                    break;
                case "MR":
                    display.Text = calc.memory.ToString();
                    answered = true;
                    break;
                default: break;
            }
        }

        private void operation_for_once_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            double num = double.Parse(display.Text);
            calc.first = num;
            calc.operation = b.Text;
            calc.Calc();
            display.Text = calc.Result.ToString();
            answered = true;
        }

        private void sign_click(object sender, EventArgs e)
        {
            double num = double.Parse(display.Text);
            num *= -1;
            display.Text = num.ToString();
        }

        private void clear_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.Text == "Back" && display.Text == "0") return;
            switch (b.Text)
            {
                case "CE":
                    calc.first = 0;
                    calc.second = 0;
                    display.Text = "0";
                    break;
                case "C":
                    display.Text = "0";
                    break;
                case "Back":
                    display.Text = display.Text.Substring(0, display.Text.Length - 1);
                    break;
                default: break;
            }
        }
    }
}
