using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calc2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            float result = 0;
            switch (operacao.Text)
            {
                case ("+"):
                    result = float.Parse(valor1.Text) + float.Parse(valor2.Text);
                    break;
                case ("-"):
                    result = float.Parse(valor1.Text) - float.Parse(valor2.Text);
                    break;
                case ("*"):
                    result = float.Parse(valor1.Text) * float.Parse(valor2.Text);
                    break;
                case ("/"):
                    result = float.Parse(valor1.Text) / float.Parse(valor2.Text);
                    break;
                default:
                    break;
                    
            }
            lblResult.Text = nome.Text + " o resultado é: " + result.ToString();
        }
    }
}
