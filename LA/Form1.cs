using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix m = Matrix.Parse(txtMatrix.Text);
            Matrix pinv = m.GetPseudoInverse();
            txtPInv.Text = pinv.ToString();
            Matrix rhs = Matrix.Parse(txtB.Text);
            Matrix sol = Matrix.Multiply(pinv, rhs);
            txtSolution.Text = sol.ToString();
        }
    }
}
