using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = string.Empty;
        private string previousInput = string.Empty;
        private string currentOperator = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            UpdateDisplay();
        }

        private void BtnOperationCLicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperator = button.Text;
            previousInput = currentInput;
            currentInput = string.Empty;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if(labelWynik1.Text.Contains($"{currentOperator}"))
                labelWynik1.Text = $"{previousInput} {currentOperator} {currentInput} =";
            else
                labelWynik1.Text = $"{previousInput} {currentOperator} =";

            labelWynik2.Text = currentInput;
        }


        private double Operation(double nr1, double nr2, string operation)
        {
            switch(operation)
            {
                case "+": return nr1 + nr2;
                case "-": return nr1 - nr2;
                case "x": return nr1 * nr2;
                case "/": if (nr2 != 0) return nr1 / nr2; else return 0;
                case "x^2": return Math.Pow(nr1, 2);
                case "SQRT": return Math.Sqrt(nr1);
                case "1/x": if (nr1 != 0) return 1 / nr1; else return 0;
                default: return 0;
            }
        }

    }
}
