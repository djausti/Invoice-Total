using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice_Total
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show("Subtotal is a required field. Please enter a valid number.", "Entry Error");
                }
                else if (decimal.Parse(txtSubtotal.Text) > 0 && decimal.Parse(txtSubtotal.Text) < 10000 )
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    decimal discountPercent = .25m;
                    decimal discountAmount = Math.Round(subtotal * discountPercent, 2);
                    decimal invoiceTotal = Math.Round(subtotal - discountAmount, 2);

                    txtDiscountPercent.Text = discountPercent.ToString("p1");
                    txtDiscountAmount.Text = discountAmount.ToString("c");
                    txtTotal.Text = invoiceTotal.ToString("c");
                }
                else if (decimal.Parse(txtSubtotal.Text) <= 0 || decimal.Parse(txtSubtotal.Text) >= 10000)
                {
                    MessageBox.Show("Subtotal value must be greater than 0, but less than 10,000.");
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number for the Subtotal field.", "Entry Error");
            }
            
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
