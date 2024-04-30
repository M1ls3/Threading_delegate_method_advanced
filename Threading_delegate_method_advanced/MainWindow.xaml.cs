using System;
using System.Collections.Generic;
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

namespace Threading_delegate_method_advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void FormatNumber(double number , double calcNumber);
        delegate double CalcNumber(double a, double b);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FormatNumberAsCurrency(double number, double calcNumber)
        {
            MessageBox.Show(string.Format("Answer is " + " A Currency: {0:C}" + '\n' + "Calc = {1}", number, calcNumber));
        }
        private void FormatNumberWithCommas(double number, double calcNumber)
        {
            MessageBox.Show(string.Format("Answer is " + " With Commas: {0:N}" + '\n' + "Calc = {1}", number, calcNumber));
        }
        private void FormatNumberWithTwoPlaces(double number, double calcNumber)
        {
            MessageBox.Show(string.Format("Answer is " + " With 3 places: {0:.###}" + '\n' + "Calc = {1}", number, calcNumber));
        }

        private double Add(double a, double b) { return a + b; }
        private double Subtract (double a, double b) { return a - b; }
        private double Multiply(double a, double b) { return a * b; }
        private double Divide(double a, double b) { return a / b; }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(textBox.Text, out double number) &&
                double.TryParse(textBox_Copy.Text, out double a) &&
                double.TryParse(textBox_Copy1.Text, out double b))
            {
                FormatNumber format = null;
                CalcNumber calcNumber = null;
                if (comboBox.SelectedIndex == 0)
                    format = FormatNumberAsCurrency;
                else if (comboBox.SelectedIndex == 1)
                    format = FormatNumberWithCommas;
                else if (comboBox.SelectedIndex == 2)
                    format = FormatNumberWithTwoPlaces;

                if (comboBox_Copy.SelectedIndex == 0)
                    calcNumber = Add;
                else if (comboBox_Copy.SelectedIndex == 1)
                    calcNumber = Subtract;
                else if (comboBox_Copy.SelectedIndex == 2)
                    calcNumber = Multiply;
                else if (comboBox_Copy.SelectedIndex == 3) 
                    calcNumber = Divide;

                if (format != null)
                    format(number, calcNumber(a,b));

            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
