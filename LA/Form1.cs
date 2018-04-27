using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace LA
{
    public partial class MatrixForm : Form
    {
        public MatrixForm()
        {
            InitializeComponent();
        }

        public void GetTransMatrix(object sender, EventArgs e)
        {
            baseMatrixBox.Text = Matrix.Parse(baseMatrixBox.Text).ToString();
            var baseMatrix = Matrix.Parse(baseMatrixBox.Text);
            transposedMatrixBox.Text = Matrix.Transpose(baseMatrix).ToString();
            //Matrix.GetSvd(baseMatrix);
        }

        private void MultiplyBaseMatrixWithTrans(object sender, EventArgs e)
        {
            Matrix matr1 = Matrix.Parse(baseMatrixBox.Text);
            Matrix matr2 = Matrix.Parse(transposedMatrixBox.Text);
            Matrix resultMatrix = Matrix.Multiply(matr1, matr2);
            multipliedBaseTrans.Text = resultMatrix.ToString();
        }

        private void DoSvd(object sender, EventArgs e)
        {
            MathNet.Numerics.LinearAlgebra.Factorization.Svd<double> svd = Matrix.GetSvd(Matrix.Parse(baseMatrixBox.Text));

            //Заполняем координаты сингулярного вектора
            double[] singularVectorCoordinates = new double[3];
            int i = 0;
            foreach (var row in svd.S)
            {
                singularVectorBox.Text += double.Parse(row.ToString())+"\r\n";
            }
            //singularVectorBox.Text = singularVectorCoordinates.ToString();

            //Заполняем U матрицу
            i = 0;
            double[] values = new double[svd.U.ColumnCount*svd.U.RowCount];
            string valuesStr = "";
            foreach (var vals in svd.U.Storage.Enumerate())
            {
                values[i++] = double.Parse(vals.ToString());
            }
            i = 0;
            Matrix Umatrix = Matrix.IdentityMatrix(svd.U.RowCount, svd.U.ColumnCount);
            for (int j = 0; j < Umatrix.Columns; j++)
            {
                for (int k = 0; k < Umatrix.Rows; k++)
                {
                    Umatrix[j, k] = values[i++];
                }
            }
            uMatrixBox.Text = Umatrix.ToString();
        }
    }
}
