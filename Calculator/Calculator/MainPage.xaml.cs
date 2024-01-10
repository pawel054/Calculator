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
        private double width = 0;
        private double height = 0;
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

        }

        private void BtnEqualsClicked(object sender, EventArgs e)
        {

        }

    }
}
