using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorWPF
{
    public class Calculator_logic
    {
        public static List<Double> Values = new List<Double>();
        public static Nullable<Char> Op;
        public static List<char> op_list = new List<char> { '+', '-', 'x', '/' };

        private static double result = 0;

        private static bool Percentage_status = false;


        // String Parsing Method
        public static void Parser(string input)
        {
            string current_number = "";

            foreach (char c in input.ToArray())
            {
                if (char.IsDigit(c) || c == '.')
                {
                    current_number += c;
                }
                else if (op_list.Contains(c))
                {
                    Op = c;
                }
                else if (c.Equals('%'))
                {
                    if (Values.Count == 1)
                    {
                        Percentage_status = true;
                    }
                }
            }

            if (IsValidNumber(current_number))
            {
                Values.Add(double.Parse(current_number));
            }
            else
            {
                MessageBox.Show("Number contains more than one decimal point", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            current_number = "";
        }
        // Check if the number has 0 or 1 decimal points
        private static bool IsValidNumber(string number)
        {
            return number.Count(c => c == '.') <= 1;
        }

        // Evaluation Method
        public static void Evaluate()
        {
            if (Values.Count == 2)
            {

                if (Percentage_status)
                {
                    Values[1] = (Values[0] * Values[1]) / 100;
                    //Percentage_status = false;
                }

                switch (Op)
                {

                    case '+':
                        result = Values[0] + Values[1];
                        break;
                    case '-':
                        result = Values[0] - Values[1];
                        break;
                    case 'x':
                        result = Values[0] * Values[1];
                        break;
                    case '/':
                        if (Values[1] == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                            result = 0;
                        }
                        else
                        {
                            result = Values[0] / Values[1];
                        }
                        break;
                    default:
                        result = double.NaN;
                        break;
                }
                if (Percentage_status)
                {
                    Op = null;
                    Percentage_status = false;
                }

                Values.Clear();
                Values.Add(result);
            }
        }
    }
}
