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
    public static class Calculator
    {
        // Global Variables 
        public static List<Double> Values = new List<Double>();
        public static List<string> Op = new List<string>();
        private static readonly List<char> op_list = new List<char> { '+', '-', 'x', '/' };
        private static bool Percentage_status = false;
        private static double result = 0;


        // ======================
        // String Parsing Method
        // ======================

        public static void Parser(string input)
        {
            string currentNumber = "";

            foreach (char c in input.ToArray())
            {
                if (char.IsDigit(c) || c == '.')
                {
                    currentNumber += c;
                }
                else if (op_list.Contains(c))
                {
                    Op.Add(c.ToString());
                }
                else if (c.Equals('%'))
                {
                    if (Values.Count == 1)
                    {
                        Percentage_status = true;
                    }
                }
            }

            Values.Add(double.Parse(currentNumber));
        }

        // ==================
        // Evaluation Method
        // ==================

        public static void Evaluate()
        {
            if (Values.Count == 2)
            {
                // If percentage is applied, convert the second value into percentage of the first value
                if (Percentage_status)
                {
                    Values[1] = (Values[0] * Values[1]) / 100;
                }

                // Perform the calculation based on the first operator
                switch (Op[0])
                {
                    case "+":
                        result = Values[0] + Values[1];
                        break;
                    case "-":
                        result = Values[0] - Values[1];
                        break;
                    case "x":
                        result = Values[0] * Values[1];
                        break;
                    case "/":
                        if (Values[1] == 0)
                        {
                            MessageBox.Show("Division by zero is not allowed", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                            result = Values[0];
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
                result = Math.Round(result, 3);

                // Remove the Operator from stack after evaluation
                if (Percentage_status)
                {
                    Op.Clear();
                    Percentage_status = false;
                }
                else
                {
                    Op.RemoveAt(0);
                }

                Values.Clear();
                Values.Add(result);

            }
        }
    }
}
