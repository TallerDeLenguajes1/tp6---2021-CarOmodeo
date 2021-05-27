using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp6_Ej2
{
    public partial class VentanaCalculadora : Form
    {
        Calculadora calcular = new Calculadora();
        char operador;
        bool hayOperador = false;
        bool hayPunto = false;
        
        public VentanaCalculadora()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            escribirNum("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            escribirNum("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            escribirNum("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            escribirNum("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            escribirNum("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            escribirNum("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            escribirNum("6");
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            escribirNum("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            escribirNum("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            escribirNum("9");
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            escribirPunto();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {   
            escribirOperador("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            escribirOperador("/");
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            escribirOperador("+");
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            escribirOperador("-");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            display.Clear();
            hayPunto = false;
            hayOperador = false;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            obtenerResultado();
        }
        public void escribirNum(string dato)
        {
            display.Text += dato;
        }
        public void escribirOperador(string dato)
        {
            if (!hayOperador)
            {
                display.Text += dato;
                operador = Convert.ToChar(dato);
                hayOperador = true;
                hayPunto = false; 
            }
        }

        public void escribirPunto()
        {
            if (!hayPunto)
            {
                display.Text += ".";
                hayPunto = true;
            }
        }

        public void obtenerResultado()
        {
            string[] calculo = display.Text.Split(operador);
            if (calculo.Length == 1 || calculo[1] == "")
            {
                return;
            }
            calcular.Numero1 = float.Parse(calculo[0]);
            calcular.Numero2 = float.Parse(calculo[1]);

            switch (operador)
            {
                case '+':
                    display.Text = Convert.ToString(calcular.Suma());
                    break;
                case '-':
                    display.Text = Convert.ToString(calcular.Resta());
                    break;
                case '*':
                    display.Text = Convert.ToString(calcular.Multiplicacion());
                    break;
                case '/':
                    if (calcular.Numero2 != 0)
                    {
                        display.Text = Convert.ToString(calcular.Division());
                    }
                    else
                    {
                        display.Text = "Error";
                    }
                    break;
                default:
                    break;

            }

            calcular = new Calculadora();
        }

        private void VentanaCalculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                    escribirNum(Convert.ToString(e.KeyChar));
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                    escribirOperador(Convert.ToString(e.KeyChar));
                    break;
                case '.':
                    escribirPunto();
                    break;
                case '\r':
                    obtenerResultado();
                    break;
                default:
                    break;
               
            }
       
        }
    }
}
