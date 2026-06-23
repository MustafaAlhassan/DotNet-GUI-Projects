using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmipleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox activeTextBox = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            tbNumber1.Select();
            activeTextBox = tbNumber1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbNumber1.Text = string.Empty;
            tbNumber2.Text = string.Empty;
            lblResult.Text = "0";
            activeTextBox = tbNumber1;
            tbNumber1.Focus();
            lblOpeartion.Text = "+";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            tbNumber2.Focus();
            activeTextBox = tbNumber2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (activeTextBox.Text != null && activeTextBox.Text.Length > 0)
            {
                activeTextBox.Text = activeTextBox.Text.Substring(0, activeTextBox.Text.Length - 1);
                activeTextBox.Focus();
                activeTextBox.SelectionStart = activeTextBox.Text.Length;
            }
        }

        private void tbNumber1_TextClick(object sender, EventArgs e)
        {
            activeTextBox = tbNumber1;
        }

        private void tbNumber2_TextClick(object sender, EventArgs e)
        {
            activeTextBox = tbNumber2;
        }

        private void Operation_Sign_Click(object sender, EventArgs e)
        {
            Button btnClick = (Button)sender;
            lblOpeartion.Text = btnClick.Tag.ToString();
        }

        private void btnPrecent_Click(object sender, EventArgs e)
        {
            if (activeTextBox.Text != null && activeTextBox.Text.Length > 0)
            {
                float num = float.Parse(activeTextBox.Text);
                activeTextBox.Text = (num / 100).ToString();
            }
        }

        private void Numbers_Click(object sender, EventArgs e)
        {
            Button btnNumber = (Button)sender;
            activeTextBox.Text += btnNumber.Tag.ToString();
        }

        void calculation()
        {
            if (tbNumber1.Text != null && tbNumber1.Text.Length > 0 && tbNumber2.Text != null && tbNumber2.Text.Length > 0)
            {
                float num1 = float.Parse(tbNumber1.Text);
                float num2 = float.Parse(tbNumber2.Text);
                float result = 0;

                switch (lblOpeartion.Text)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "x":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                }

                lblResult.Text = result.ToString();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calculation();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (activeTextBox != null)
            {
                if (string.IsNullOrEmpty(activeTextBox.Text))
                {
                    activeTextBox.Text = "0.";
                }
                else
                {
                    if (!activeTextBox.Text.Contains("."))
                    {
                        activeTextBox.Text += ".";
                    }
                }

                activeTextBox.Focus();
                activeTextBox.SelectionStart = activeTextBox.Text.Length;
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void tbNumber1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbNumber2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void tbNumber2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calculation();
                e.SuppressKeyPress = true;
            }      
        }
    }
}
