using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
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
            Matrix resultMatrix = matr1 * matr2;
            if (resultMatrix == null) throw new ArgumentNullException(nameof(resultMatrix));
            multipliedBaseTrans.Text = resultMatrix.ToString();
        }

        private void DoSvd(object sender, EventArgs e)
        {
            Svd<double> svd = Matrix.GetSvd(Matrix.Parse(baseMatrixBox.Text));

            //Заполняем координаты сингулярного вектора
            foreach (var row in svd.S)
            {
                singularVectorBox.Text += double.Parse(row.ToString(CultureInfo.CurrentCulture))+Environment.NewLine;
            }

            //Выводим U матрицу в соответствующий бокс
            int i = 0;
            double[] uValues = new double[svd.U.ColumnCount*svd.U.RowCount];
            foreach (var vals in svd.U.Storage.Enumerate())
            {
                uValues[i++] = double.Parse(vals.ToString(CultureInfo.CurrentCulture));
            }
            i = 0;
            Matrix uMatrix = Matrix.IdentityMatrix(svd.U.RowCount, svd.U.ColumnCount);
            for (int j = 0; j < uMatrix.Rows; j++)
            {
                for (int k = 0; k < uMatrix.Columns; k++)
                {
                    uMatrix[j, k] = uValues[i++];
                }
            }
            uMatrixBox.Text = uMatrix.ToString();

            //Аналогично выводим VT и W матрицы
            i = 0;
            double[] vTvalues = new double[svd.VT.ColumnCount * svd.VT.RowCount];
            foreach (var vals in svd.VT.Storage.Enumerate())
            {
                vTvalues[i++] = double.Parse(vals.ToString(CultureInfo.CurrentCulture));
            }
            i = 0;
            Matrix vTmatrix = Matrix.IdentityMatrix(svd.VT.RowCount, svd.VT.ColumnCount);
            for (int j = 0; j < vTmatrix.Rows; j++)
            {
                for (int k = 0; k < vTmatrix.Columns; k++)
                {
                    vTmatrix[j, k] = vTvalues[i++];
                }
            }
            vtMatrixBox.Text = vTmatrix.ToString();

            i = 0;
            double[] wValues = new double[svd.W.ColumnCount * svd.W.RowCount];
            foreach (var vals in svd.W.Storage.Enumerate())
            {
                wValues[i++] = double.Parse(vals.ToString(CultureInfo.CurrentCulture));
            }
            i = 0;
            Matrix wMatrix = Matrix.IdentityMatrix(svd.W.RowCount, svd.W.ColumnCount);
            for (int j = 0; j < wMatrix.Rows; j++)
            {
                for (int k = 0; k < wMatrix.Columns; k++)
                {
                    wMatrix[j, k] = wValues[i++];
                }
            }
            wMatrixBox.Text = wMatrix.ToString();
        }

        private void CalcPseudo(object sender, EventArgs e)
        {
            Matrix matr1 = Matrix.Parse(baseMatrixBox.Text);
            Matrix invMatr = matr1.GetPseudoInverse();
            pseudoResultMatrixBox.Text = invMatr.ToString();
            Matrix rightPart = Matrix.Parse(pseudoRightPartBox.Text);
            Matrix solutionMatrix = invMatr * rightPart;
            pseudoUnknownVatiablesBox.Text = solutionMatrix.ToString();
        }

        private void GetEigenNumbersButton_Click(object sender, EventArgs e)
        {
            Matrix matr1 = Matrix.Parse(baseMatrixBox.Text);
            if (!matr1.IsSquare())
            {
                MessageBox.Show("Матрица должна быть квадратной!");
                return;
            }
            double[] values = new double[matr1.Rows*matr1.Columns];
            int counter = 0;
            for (int i = 0; i < matr1.Rows; i++)
            {
                for (int j = 0; j < matr1.Columns; j++)
                {
                    values[counter++] = matr1.Values[i, j];
                }
            }
            Evd<double> evd = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Dense(matr1.Rows, matr1.Columns, values).Evd();
            eigenNumbersBox.Text = "";
            double[] eigenNumbers = new double[matr1.Rows];
            counter = 0;
            foreach (var eigenvalue in evd.EigenValues.AsEnumerable())
            {
                //if (eigenvalue.Magnitude.CoerceZero() < 0.001) eigenNumbers[counter++] = 0;
                //else eigenNumbers[counter++] = eigenvalue.Real;
                eigenNumbersBox.Text += eigenvalue.Magnitude.CoerceZero(0.00001) + "\r\n";
            }
        }
    }
}
