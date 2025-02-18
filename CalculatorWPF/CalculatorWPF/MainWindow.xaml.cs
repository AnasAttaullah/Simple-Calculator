using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{

    public partial class MainWindow : Window
    {
        string primary_input = "";
        public bool digitInputAllowed = true;
        public string not_allowed = "+-x/%.";

        public MainWindow()
        {
            InitializeComponent();

        }
        // ========
        // METHODS 
        // ========

        // Method to check the last entry is not the same (operator)
        public bool Check_last()
        {
            char value_to_compare = 'z';
            if (!string.IsNullOrWhiteSpace(primary_input))
            {
                value_to_compare = primary_input.Last();
            }
            if (primary_input != "" && !not_allowed.Contains(value_to_compare))
            {
                return true;
            }

            else { return false; }
        }
        //Display Numbers to the primary screen
        public void Display(string digit)
        {
            if (digitInputAllowed)
            {
                primary_input += digit;
                Primary_display.Clear();
                Primary_display.Text += primary_input;
            }
        }

        // Method to check and evaluate 
        public void DisplayAndEvaluate(string op)
        {
            if (Check_last())
            {
                primary_input += op;
                digitInputAllowed = true;
                Primary_display.Clear();
                Secondary_display.Clear();
                Calculator.Parser(primary_input);
                primary_input = "Invalid Input";
                // evaluate when list has two numbers
                if (Calculator.Values.Count == 2)
                {
                    Calculator.Evaluate();
                }
                if (Calculator.Values.Count > 0 && Calculator.Op.Count >= 1)
                {
                    Secondary_display.Text = $"{Calculator.Values[0]} {Calculator.Op[0]}";
                }
                if (op == "%")
                {
                    primary_input = Calculator.Values[0].ToString();
                }
                else
                {
                    primary_input = "";
                }
            }
        }

        // Method for Equal Button Logic 
        public void EqualButtonLogic()
        {
            if (Calculator.Values.Count > 0 && primary_input != "")
            {
                Primary_display.Clear();
                Secondary_display.Clear();
                if (Calculator.Values.Count == 2)
                {
                    Calculator.Evaluate();
                }
                else
                {
                    Calculator.Parser(primary_input);
                    Calculator.Evaluate();
                }
                Primary_display.Text += Calculator.Values[0].ToString();
                primary_input = Calculator.Values[0].ToString();
                Calculator.Values.Clear();
                digitInputAllowed = false;
            }
        }

        // =====================
        // HANDLING MOUSE INPUTS
        // =====================

        private void Clear_buttonClicked(object sender, RoutedEventArgs e)
        {
            Primary_display.Clear();
            Secondary_display.Clear();
            digitInputAllowed = true;
            primary_input = "";
            Calculator.Values.Clear();
            Calculator.Op.Clear();
        }
        private void Del_buttonClicked(object sender, RoutedEventArgs e)
        {
            if (digitInputAllowed)
            {

                if (!string.IsNullOrEmpty(primary_input) && primary_input.Length > 1)
                {
                    primary_input = primary_input.Substring(0, primary_input.Length - 1);
                }
                else
                {
                    primary_input = "";
                }
                this.Primary_display.Text = primary_input;
            }
        }

        private void Percent_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("%");
            Secondary_display.Clear();
            Primary_display.Clear();
            if (Check_last())
            {
                Primary_display.Text = Calculator.Values[0].ToString();
            }
            Calculator.Values.Clear();

        }
        private void Division_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("/");
        }

        private void Multiply_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("x");
        }

        private void Subraction_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("-");
        }

        private void Addition_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("+");
        }

        private void Equal_buttonClicked(object sender, RoutedEventArgs e)
        {
            EqualButtonLogic();
        }

        private void Seven_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("7");
        }

        private void Eight_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("8");
        }

        private void Nine_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("9");
        }

        private void Four_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("4");
        }

        private void Five_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("5");
        }

        private void Six_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("6");
        }

        private void One_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("1");
        }

        private void Two_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("2");
        }

        private void Three_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("3");
        }
        private void Zero_buttonClicked(object sender, RoutedEventArgs e)
        {
            Display("0");
        }
        private void Dot_buttonClicked(object sender, RoutedEventArgs e)
        {
            if (Check_last())
            {
                Display(".");
            }
        }

        // ========================
        // HANDLING KEYBOARD INPUT
        // ========================

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Handling numeric input (0-9), exception of 5 and 8
            if ((e.Key >= Key.D0 && e.Key <= Key.D4) || (e.Key >= Key.D6 && e.Key <= Key.D7) || (e.Key == Key.D9))
            {
                if (digitInputAllowed)
                {
                    primary_input += (e.Key - Key.D0).ToString();
                }
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                if (digitInputAllowed)
                {
                    primary_input += (e.Key - Key.NumPad0).ToString();
                }
            }
            // Handling the '%' operator (Shift + 5)
            else if (e.Key == Key.D5 && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                DisplayAndEvaluate("%");
                e.Handled = true;
            }
            else if (e.Key == Key.Oem5)
            {
                DisplayAndEvaluate("%");
                e.Handled = true;
            }
            // Handling '5' when Shift is NOT pressed
            else if (e.Key == Key.D5)
            {
                if (digitInputAllowed)
                {
                    primary_input += "5";
                }
                e.Handled = true;
            }
            // Handling division
            else if ((e.Key == Key.Divide || e.Key == Key.OemQuestion))
            {
                DisplayAndEvaluate("/");
                e.Handled = true;
            }
            // Handling multiplication (Shift + 8 or Multiply key)
            else if (e.Key == Key.D8 && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                DisplayAndEvaluate("x");
                e.Handled = true;

            }
            else if (e.Key == Key.D8)
            {
                if (digitInputAllowed)
                {
                    primary_input += "8";
                }
                e.Handled = true;
            }
            else if ((e.Key == Key.Multiply || e.Key == Key.X))
            {
                DisplayAndEvaluate("x");
                e.Handled = true;
            }
            // Handling addition
            else if ((e.Key == Key.Add || e.Key == Key.OemPlus))
            {
                DisplayAndEvaluate("+");
                e.Handled = true;
            }
            // Handling subtraction
            else if ((e.Key == Key.Subtract || e.Key == Key.OemMinus))
            {
                DisplayAndEvaluate("-");
                e.Handled = true;
            }
            // Handling clearing
            else if (e.Key == Key.Escape || e.Key == Key.OemClear)
            {
                Primary_display.Clear();
                Secondary_display.Clear();
                digitInputAllowed = true;
                primary_input = "";
                Calculator.Values.Clear();
                Calculator.Op.Clear();
                e.Handled = true;
            }
            // Handling backspace
            else if (e.Key == Key.Back)
            {
                if (!string.IsNullOrEmpty(primary_input) && digitInputAllowed)
                {
                    primary_input = primary_input.Substring(0, primary_input.Length - 1);
                }
                e.Handled = true;
            }
            // Handling decimal
            else if (e.Key == Key.Decimal && Check_last())
            {
                primary_input += ".";
                e.Handled = true;
            }
            // Handling Enter key
            else if (e.Key == Key.Enter)
            {
                EqualButtonLogic();
                e.Handled = true;
            }

            // Update the display
            Primary_display.Text = primary_input;
        }

        // =======================
        // Source Code link button
        // =======================

        private void Code_linkButtonClicked(object sender, MouseButtonEventArgs e)
        {
            string url = "https://github.com/AnasAttaullah/Simple-Calculator";
            // Open the URL in the default web browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

    }
}