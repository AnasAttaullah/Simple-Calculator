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
        string primaryInput = "";
        public bool digitInputAllowed = true;
        public string notAllowed = "+-x/%";

        public MainWindow()
        {
            InitializeComponent();

        }
        // ========
        // METHODS 
        // ========

        // Method to check the last entry is not the same (operator)
        public bool CheckLast()
        {
            char value_to_compare = 'z';
            if (!string.IsNullOrWhiteSpace(primaryInput))
            {
                value_to_compare = primaryInput.Last();
            }
            if (primaryInput != "" && !notAllowed.Contains(value_to_compare))
            {
                return true;
            }

            else { return false; }
        }
        //Display Numbers to the primary screen
        public void Display(string digit)
        {
            if (digitInputAllowed && !(primaryInput.Count() > 15)) // allows upto 16 digit number
            {
                primaryInput += digit;
                Primary_display.Clear();
                Primary_display.Text += primaryInput;
            }
        }

        // Method to check and evaluate 
        public void DisplayAndEvaluate(string op)
        {
            if (CheckLast())
            {
                primaryInput += op;
                digitInputAllowed = true;
                Primary_display.Clear();
                Secondary_display.Clear();
                Calculator.Parser(primaryInput);
                primaryInput = "Invalid Input";
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
                    primaryInput = Calculator.Values[0].ToString();
                }
                else
                {
                    primaryInput = "";
                }
            }
        }

        // Method for Equal Button Logic 
        public void EqualButtonLogic()
        {
            if (Calculator.Values.Count > 0 && primaryInput != "")
            {
                Primary_display.Clear();
                Secondary_display.Clear();
                if (Calculator.Values.Count == 2)
                {
                    Calculator.Evaluate();
                }
                else
                {
                    Calculator.Parser(primaryInput);
                    Calculator.Evaluate();
                }
                Primary_display.Text += Calculator.Values[0].ToString();
                primaryInput = Calculator.Values[0].ToString();
                Calculator.Values.Clear();
                digitInputAllowed = false;
            }
        }

        // =====================
        // HANDLING MOUSE INPUTS
        // =====================
        private void Operator_buttonClicked(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var ButtonValue = (btn.Content.ToString());
            DisplayAndEvaluate(ButtonValue);
        }
        private void Number_buttonClicked(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var ButtonValue = (btn.Content.ToString());
            Display(ButtonValue);
        }

        private void Clear_buttonClicked(object sender, RoutedEventArgs e)
        {
            Primary_display.Clear();
            Secondary_display.Clear();
            digitInputAllowed = true;
            primaryInput = "";
            Calculator.Values.Clear();
            Calculator.Op.Clear();
        }
        private void Del_buttonClicked(object sender, RoutedEventArgs e)
        {
            if (digitInputAllowed)
            {

                if (!string.IsNullOrEmpty(primaryInput) && primaryInput.Length > 1)
                {
                    primaryInput = primaryInput.Substring(0, primaryInput.Length - 1);
                }
                else
                {
                    primaryInput = "";
                }
                this.Primary_display.Text = primaryInput;
            }
        }

        private void Percent_buttonClicked(object sender, RoutedEventArgs e)
        {
            DisplayAndEvaluate("%");
            Secondary_display.Clear();
            Primary_display.Clear();
            if (CheckLast())
            {
                Primary_display.Text = Calculator.Values[0].ToString();
            }
            Calculator.Values.Clear();

        }
        private void Dot_buttonClicked(object sender, RoutedEventArgs e)
        {
            if (!primaryInput.Contains('.'))
            {
                Display(".");
            }
        }
        private void Equal_buttonClicked(object sender, RoutedEventArgs e)
        {
            EqualButtonLogic();
        }

        // ========================
        // HANDLING KEYBOARD INPUT
        // ========================

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Handling numeric input (0-9), exception of 5 and 8
            if ((e.Key >= Key.D0 && e.Key <= Key.D4 && !(primaryInput.Count() > 15))
                || (e.Key >= Key.D6 && e.Key <= Key.D7 && !(primaryInput.Count() > 15))
                || (e.Key == Key.D9 && !(primaryInput.Count() > 15)))
            {
                if (digitInputAllowed)
                {
                    primaryInput += (e.Key - Key.D0).ToString();
                }
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 && !(primaryInput.Count() > 15))
            {
                if (digitInputAllowed)
                {
                    primaryInput += (e.Key - Key.NumPad0).ToString();
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
            else if (e.Key == Key.D5 && !(primaryInput.Count() > 15))
            {
                if (digitInputAllowed)
                {
                    primaryInput += "5";
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
            else if (e.Key == Key.D8 && !(primaryInput.Count() > 15))
            {
                if (digitInputAllowed)
                {
                    primaryInput += "8";
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
                primaryInput = "";
                Calculator.Values.Clear();
                Calculator.Op.Clear();
                e.Handled = true;
            }
            // Handling backspace
            else if (e.Key == Key.Back)
            {
                if (!string.IsNullOrEmpty(primaryInput) && digitInputAllowed)
                {
                    primaryInput = primaryInput.Substring(0, primaryInput.Length - 1);
                }
                e.Handled = true;
            }
            // Handling decimal
            else if (e.Key == Key.Decimal && !primaryInput.Contains('.'))
            {
                primaryInput += ".";
                e.Handled = true;
            }
            // Handling Enter key
            else if (e.Key == Key.Enter)
            {
                EqualButtonLogic();
                e.Handled = true;
            }

            // Update the display
            Primary_display.Text = primaryInput;
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