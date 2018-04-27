using System;
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
            Svd<double> svd = Matrix.GetSvd(Matrix.Parse(baseMatrixBox.Text));

            //Заполняем координаты сингулярного вектора
            foreach (var row in svd.S)
            {
                singularVectorBox.Text += double.Parse(row.ToString())+"\r\n";
            }

            //Выводим U матрицу в соответствующий бокс
            int i = 0;
            double[] Uvalues = new double[svd.U.ColumnCount*svd.U.RowCount];
            foreach (var vals in svd.U.Storage.Enumerate())
            {
                Uvalues[i++] = double.Parse(vals.ToString());
            }
            i = 0;
            Matrix Umatrix = Matrix.IdentityMatrix(svd.U.RowCount, svd.U.ColumnCount);
            for (int j = 0; j < Umatrix.Rows; j++)
            {
                for (int k = 0; k < Umatrix.Columns; k++)
                {
                    Umatrix[j, k] = Uvalues[i++];
                }
            }
            uMatrixBox.Text = Umatrix.ToString();

            //Аналогично выводим VT и W матрицы
            i = 0;
            double[] VTvalues = new double[svd.VT.ColumnCount * svd.VT.RowCount];
            foreach (var vals in svd.VT.Storage.Enumerate())
            {
                VTvalues[i++] = double.Parse(vals.ToString());
            }
            i = 0;
            Matrix VTmatrix = Matrix.IdentityMatrix(svd.VT.RowCount, svd.VT.ColumnCount);
            for (int j = 0; j < VTmatrix.Rows; j++)
            {
                for (int k = 0; k < VTmatrix.Columns; k++)
                {
                    VTmatrix[j, k] = VTvalues[i++];
                }
            }
            vtMatrixBox.Text = VTmatrix.ToString();

            i = 0;
            double[] Wvalues = new double[svd.W.ColumnCount * svd.W.RowCount];
            foreach (var vals in svd.W.Storage.Enumerate())
            {
                Wvalues[i++] = double.Parse(vals.ToString());
            }
            i = 0;
            Matrix Wmatrix = Matrix.IdentityMatrix(svd.W.RowCount, svd.W.ColumnCount);
            for (int j = 0; j < Wmatrix.Rows; j++)
            {
                for (int k = 0; k < Wmatrix.Columns; k++)
                {
                    Wmatrix[j, k] = Wvalues[i++];
                }
            }
            wMatrixBox.Text = Wmatrix.ToString();
        }

        private void calcPseudo(object sender, EventArgs e)
        {
            Matrix matr1 = Matrix.Parse(baseMatrixBox.Text);
            Matrix invMatr = matr1.GetPseudoInverse();
            pseudoResultMatrixBox.Text = invMatr.ToString();
            Matrix rhs = Matrix.Parse(pseudoRightPartBox.Text);
            Matrix sol = Matrix.Multiply(invMatr, rhs);
            pseudoUnknownVatiablesBox.Text = sol.ToString();
        }
    }
}
