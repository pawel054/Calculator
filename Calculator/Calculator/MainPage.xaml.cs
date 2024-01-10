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
        private EnumOpertion operation = EnumOpertion.None;
        private bool btnEqualsClicked = false;
        private bool comma = false;
        private double a = 0;
        private double b = 0;
        private double result = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnNumberClicked(object sender, EventArgs e)
        {
            try
            {
                if (operation == EnumOpertion.None)
                {
                    if (comma && !a.ToString().Contains("."))
                        a = double.Parse(a.ToString() + "." + ((Button)sender).Text);
                    else
                        a = double.Parse(a.ToString() + ((Button)sender).Text);
                    comma = false;
                }
                else
                {
                    if (comma && !b.ToString().Contains("."))
                        b = double.Parse(b.ToString() + "." + ((Button)sender).Text);
                    else
                        b = double.Parse(b.ToString() + ((Button)sender).Text);
                    comma = false;
                }
                Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnOperationCLicked(object sender, EventArgs e)
        {
            comma = false;
            if (operation != EnumOpertion.None)
                return;
            switch (((Button)sender).Text)
            {
                case "+":
                    operation = EnumOpertion.Add;
                    break;
                case "-":
                    operation = EnumOpertion.Subtract;
                    break;
                case "x":
                    operation = EnumOpertion.Multiply;
                    break;
                case "/":
                    operation = EnumOpertion.Divide;
                    break;
                case "x^2":
                    operation = EnumOpertion.Square;
                    result = a * a;
                    break;
                case "sqrt":
                    operation = EnumOpertion.SquareRoot;
                    result = Math.Sqrt(a);
                    break;
                case "1/x":
                    operation = EnumOpertion.Inverse;
                    result = 1 / a;
                    break;
            }
            Print();
        }

        private void ClearClick(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            result = 0;
            operation = EnumOpertion.None;
            comma = false;
            btnEqualsClicked = false;
            Print();
        }

        private void BtnCommaClicked(object sender, EventArgs e)
        {
            comma = true;
        }

        private void BtnEqualsClicked(object sender, EventArgs e)
        {
            if (operation == EnumOpertion.None)
                return;
            switch (operation)
            {
                case EnumOpertion.Add:
                    result = a + b;
                    break;
                case EnumOpertion.Subtract:
                    result = a - b;
                    break;
                case EnumOpertion.Multiply:
                    result = a * b;
                    break;
                case EnumOpertion.Divide:
                    result = a / b;
                    break;
            }
            btnEqualsClicked = true;
            Print();
            btnEqualsClicked = false;
            a = result;
            b = 0;
            result = 0;
            comma = false;
            operation = EnumOpertion.None;
        }

        private void Print()
        {
            if (operation == EnumOpertion.None)
            {
                labelWynik2.Text = a.ToString();
                labelWynik1.Text = "";
                return;
            }
            switch (operation)
            {
                case EnumOpertion.Add:
                case EnumOpertion.Subtract:
                case EnumOpertion.Multiply:
                case EnumOpertion.Divide:
                    if (btnEqualsClicked)
                    {
                        labelWynik1.Text = a.ToString() + " " + GetSignByOperation(operation) + " " + b.ToString() + " =";
                        labelWynik2.Text = result.ToString();
                    }
                    else
                    {
                        labelWynik1.Text = a.ToString() + " " + GetSignByOperation(operation);
                        labelWynik1.Text = b.ToString();
                    }
                    return;
                case EnumOpertion.Square:
                    labelWynik1.Text = "sqr(" + a.ToString() + ")";
                    break;
                case EnumOpertion.SquareRoot:
                    labelWynik1.Text = "sqrt(" + a.ToString() + ")";
                    break;
                case EnumOpertion.Inverse:
                    labelWynik1.Text = "1/" + a.ToString();
                    break;
            }
            labelWynik2.Text = result.ToString();
            a = result;
            b = 0;
            result = 0;
            comma = false;
            operation = EnumOpertion.None;
        }

        private string GetSignByOperation(EnumOpertion operation)
        {
            switch (operation)
            {
                case EnumOpertion.Add:
                    return "+";
                case EnumOpertion.Subtract:
                    return "-";
                case EnumOpertion.Multiply:
                    return "x";
                case EnumOpertion.Divide:
                    return "/";
            }
            return "";
        }

    }
}
