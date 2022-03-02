using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuiswerkRekenmachine
{
    public partial class Form1 : Form
    {
        bool operandPerformed = false;
        string operand = "";
        double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void NumEvent(object sender, EventArgs e)
        {
            if (txtAntwoord.Text == "0" || operandPerformed)
                txtAntwoord.Clear();
            Button btn = (Button)sender;
            txtAntwoord.Text += btn.Text;
            operandPerformed = false;
        }

        private void OperandEvent(object sender, EventArgs e)
        {
            operandPerformed = true;
            Button btn = (Button)sender;
            String newOperand = btn.Text;

            lblAntwoord.Text = lblAntwoord.Text + " " + txtAntwoord.Text + " " + newOperand;

            switch(operand)
            {
                case "+": txtAntwoord.Text = (result + Double.Parse(txtAntwoord.Text)).ToString();break;
                case "-": txtAntwoord.Text = (result - Double.Parse(txtAntwoord.Text)).ToString(); break;
                case "*": txtAntwoord.Text = (result * Double.Parse(txtAntwoord.Text)).ToString(); break;
                case "/": txtAntwoord.Text = (result / Double.Parse(txtAntwoord.Text)).ToString(); break;
                default:break;
            }
            result = Double.Parse(txtAntwoord.Text);
            operand = newOperand;
        }
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            txtAntwoord.Text = "0";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtAntwoord.Text = "0";
            lblAntwoord.Text = "";
            result = 0;
            operand = "";
        }

        private void btnIs_Click(object sender, EventArgs e)
        {
            lblAntwoord.Text = "";
            operandPerformed = true;

            switch (operand)
            {
                case "+": txtAntwoord.Text = (result + Double.Parse(txtAntwoord.Text)).ToString(); break;
                case "-": txtAntwoord.Text = (result - Double.Parse(txtAntwoord.Text)).ToString(); break;
                case "*": txtAntwoord.Text = (result * Double.Parse(txtAntwoord.Text)).ToString(); break;
                case "/": txtAntwoord.Text = (result / Double.Parse(txtAntwoord.Text)).ToString(); break;
                default: break;
            }

            result = Double.Parse(txtAntwoord.Text);
            txtAntwoord.Text = result.ToString();
            result = 0;
            operand = "";
        }

        private void btnKomma_Click(object sender, EventArgs e)
        {
            if (!operandPerformed && !txtAntwoord.Text.Contains(","))
            {
                txtAntwoord.Text += ",";
            }
            else if (operandPerformed)
            {
                txtAntwoord.Text = "0";
            }

            if (!txtAntwoord.Text.Contains(","))
            {
                txtAntwoord.Text += ",";
            }

            operandPerformed = false;
        }
    }
}
