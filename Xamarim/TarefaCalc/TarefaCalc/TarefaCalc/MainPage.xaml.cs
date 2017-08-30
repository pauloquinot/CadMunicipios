using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TarefaCalc
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        Calculadora calculo = new Calculadora();

        public void btn1_Clicked(object sender, EventArgs e)
        {
            display.Text += "1";
        }
        public void btn2_Clicked(object sender, EventArgs e)
        {
            display.Text += "2";
        }
        public void btn3_Clicked(object sender, EventArgs e)
        {
            display.Text += "3";
        }
        public void btn4_Clicked(object sender, EventArgs e)
        {
            display.Text += "4";
        }
      
        private void btn5_Clicked(object sender, EventArgs e)
        {
            display.Text += "5";
        }

        private void btn6_Clicked(object sender, EventArgs e)
        {
            display.Text += "6";
        }

        private void btn7_Clicked(object sender, EventArgs e)
        {
            display.Text += "7";
        }

        private void btn8_Clicked(object sender, EventArgs e)
        {
            display.Text += "8";
        }

        private void btn9_Clicked(object sender, EventArgs e)
        {
            display.Text += "9";
        }

        private void btn0_Clicked(object sender, EventArgs e)
        {
            display.Text += "0";
        }
        private void btnPonto_Clicked(object sender, EventArgs e)
        {
            display.Text += ".";
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            if(display.Text.Length > 0) display.Text = display.Text.Substring(0, display.Text.Length - 1);
        }

        private void btnC_Clicked(object sender, EventArgs e)
        {
            display.Text = "";
        }

        private void btnMais_Clicked(object sender, EventArgs e)
        {
            calculo.valor1 = float.Parse(display.Text);
            calculo.operador = '+';
            display.Text = "";
        }

        private void btnMenos_Clicked(object sender, EventArgs e)
        {
            calculo.valor1 = float.Parse(display.Text);
            calculo.operador = '-';
            display.Text = "";
        }

        private void btnMult_Clicked(object sender, EventArgs e)
        {
            calculo.valor1 = float.Parse(display.Text);
            calculo.operador = '*';
            display.Text = "";
        }

        private void btnDiv_Clicked(object sender, EventArgs e)
        {
            calculo.valor1 = float.Parse(display.Text);
            calculo.operador = '/';
            display.Text = "";
        }

        private void btnIgual_Clicked(object sender, EventArgs e)
        {
            calculo.valor2 = float.Parse(display.Text);
            display.Text = calcular(calculo.valor1, calculo.valor2, calculo.operador);
            calculo.operador = ' ';
        }

        private string calcular(float vlr1, float vlr2, char oper)
        {
            string ret = "*** ERRO ***";
            switch(oper)
                {
                case ('+'):
                    ret = (vlr1 + vlr2).ToString();
                    break;
                case ('-'):
                    ret = (vlr1 - vlr2).ToString();
                    break;
                case ('*'):
                    ret = (vlr1 * vlr2).ToString();
                    break;
                case ('/'):
                    ret = (vlr1 / vlr2).ToString();
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
