using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhonebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtSum = txtNumber1 + txtNumber2;
            // txtSum.Text = (Convert.ToInt16(txtNumber1.Text) + Convert.ToInt16(txtNumber2.Text)).ToString();
            int Number1 = Convert.ToInt16(txtNumber1.Text);
            int Number2 = Convert.ToInt16(txtNumber2.Text);
            int sum;
            sum = Number1 + Number2;
            txtSum.Text = sum.ToString();

        }
    }
}
