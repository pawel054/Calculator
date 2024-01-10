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

        }

        private void BtnOperationCLicked(object sender, EventArgs e)
        {

        }

        private void ClearClick(object sender, EventArgs e)
        {

        }

        private void BtnCommaClicked(object sender, EventArgs e)
        {
            comma = true;
        }

        private void BtnEqualsClicked(object sender, EventArgs e)
        {

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
