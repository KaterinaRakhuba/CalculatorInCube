using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace СalculatorInСube
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private double a = 0;
        private double b = 0;
        private char? sign = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DigitTextBox(double x)
        {
            if (a == 0)
            {
                Exampl.Text = null;
                a = x;
            }
            else if (a != 0 && sign == null)
                a = a * 10 + x;

            else if (a != 0 && sign != null && b == 0)
                b = x;

            else if (a != 0 && sign != null && b != 0)
                b = b * 10 + x;

            Exampl.Text += x;
        }
        private void SignTextBox(char s)
        {
            if (s == 'D')
            {
                Exampl.Text = null;
                sign = null;
                a = b = 0;
            }
            else if (a != 0 && sign == null && (s == '+' || s == '-' || s == '*' || s == '/'))
            {
                sign = s;
                Exampl.Text += s;
            }
            else if (a != 0 && sign == null && s == '√')
            {
                a = Math.Sqrt(a);
                Exampl.Text += s;
            }
            else if (a != 0 && sign != null && b != 0 && s == '√')
            {
                b = Math.Sqrt(b);
                Exampl.Text += s;
            }
            //в случяе вычисления корня
            else if (a != 0 && sign == null && s == '=')
                Exampl.Text = a.ToString();
            else if (a != 0 && sign != null && b != 0 && s == '%')
            {
                b = a / 100 * b;
                Exampl.Text += s;
            }
            else if (a != 0 && sign != null && b != 0 && s == '=')
            {
                double res = 0;
                switch (sign)
                {
                    case '+':
                        res = a + b;
                        break;
                    case '-':
                        res = a - b;
                        break;
                    case '*':
                        res = a * b;
                        break;
                    case '/':
                        if (b == 0)
                        {
                            MessageBox.Show("ERROR");
                            Exampl.Text = null;
                            sign = null;
                            a = b = 0;
                            return;
                        }
                        else
                            res = a / b;
                        break;
                }
                Exampl.Text = res.ToString();
                sign = null;
                a = b = 0;
            }
            else
            {
                MessageBox.Show("ERROR");
                Exampl.Text = null;
                sign = null;
                a = b = 0;
                return;
            }
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(1);
        }
        private void Tow_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(2);
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(3);
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(4);
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(5);
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(6);
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(7);
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(8);
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(9);
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            DigitTextBox(0);
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('+');
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('-');
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('*');
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('/');
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('=');
        }
        private void Pct_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('%');
        }
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('√');
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            SignTextBox('D');
        }
    }
}
