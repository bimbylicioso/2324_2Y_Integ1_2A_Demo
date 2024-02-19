using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace _2324_2Y_Integ1_2A_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable = new DataTable();
        Button[] btnNums = new Button[10];
        int num1 = 0;
        int num2 = 0;
        int ope = -1;

        public MainWindow()
        {
            InitializeComponent();

            btnNums[0] = btn0;
            btnNums[1] = btn1;
            btnNums[2] = btn2;
            btnNums[3] = btn3;
            btnNums[4] = btn4;
            btnNums[5] = btn5;
            btnNums[6] = btn6;
            btnNums[7] = btn7;
            btnNums[8] = btn8;
            btnNums[9] = btn9;

            for (int x = 0; x < btnNums.Length; x++)
                btnNums[x].Content = x;

            btnAdd.Content = "+";
            btnMin.Content = "-";
            btnMult.Content = "x";
            btnDiv.Content = "/";
            btnEnter.Content = "=";
            this.KeyDown += Window_KeyDown;
        }


        private void numberEnter(string input)
        {
            string currentText = tbCalc.Text;

            if (currentText.Length > 12)
                currentText = currentText.Substring(1);

            if (string.IsNullOrEmpty(currentText))
                currentText = "0";

            if (ope == -1)
                num1 = int.Parse(currentText + input);
            else
                num2 = int.Parse(currentText + input);

            tbCalc.Text += input;
        }

        #region KeypadEvents
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("9");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("8");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("7");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("6");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("5");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("4");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("3");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("2");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            numberEnter("1");
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            numberEnter("0");

        }
        #endregion

        #region OperationEvents
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ope = 0;
            tbCalc.Text = "";
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            ope = 1;
            tbCalc.Text = "";
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            ope = 2;
            tbCalc.Text = "";
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            ope = 3;
            tbCalc.Text = "";
        }
        #endregion

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Evaluate the expression using DataTable.Compute
                var result = dataTable.Compute(tbCalc.Text, "");
                tbCalc.Text = result.ToString();
            }
            catch (Exception ex)
            {
                // Handle the case where the expression is invalid
                tbCalc.Text = "Error";
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbCalc.Text = "";
        }


        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!tbCalc.Text.Contains("."))
            {
                tbCalc.Text += ".";
            }
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (tbCalc.Text.Length > 0)
            {
                tbCalc.Text = tbCalc.Text.Substring(0, tbCalc.Text.Length - 1);
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                int number = (int)(e.Key - Key.D0);
                numberEnter(number.ToString());
            }
            else if (e.Key == Key.Decimal)
            {
                btnDot_Click(sender, e);
            }
            else if (e.Key == Key.Add)
            {
                btnAdd_Click(sender, e);
            }
            else if (e.Key == Key.Subtract)
            {
                btnMin_Click(sender, e);
            }
            else if (e.Key == Key.Multiply)
            {
                btnMult_Click(sender, e);
            }
            else if (e.Key == Key.Divide)
            {
                btnDiv_Click(sender, e);
            }
            else if (e.Key == Key.Enter)
            {
                btnEnter_Click(sender, e);
            }
            else if (e.Key == Key.Back)
            {
                btnBackspace_Click(sender, e);
            }
        }
    }
}
