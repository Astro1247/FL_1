/*
  Клас для матричних операцій
*/

using System;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;

public class Matrix
{
    public int Rows;
    public int Columns;
    public double[,] Values;

    //public Matrix L;
    //public Matrix U;
    //private int[] pi;
    //private double detOfP = 1;

    private const double Eps = 1e-6;

    public Matrix(int iRows, int iCols)         // Matrix Class constructor
    {
        Rows = iRows;
        Columns = iCols;
        Values = new double[Rows, Columns];
    }

    public Boolean IsSquare()
    {
        return (Rows == Columns);
    }

    public double this[int iRow, int iCol]      // Access this matrix as a 2D array
    {
        get { return Values[iRow, iCol]; }
        set {
            if (Math.Abs(value) >= Eps){ 
                Values[iRow, iCol] = value;
                }
            else{
                Values[iRow, iCol] = 0;
            }
        }
    }

    public Matrix GetCol(int k)
    {
        Matrix m = new Matrix(Rows, 1);
        for (int i = 0; i < Rows; i++) m[i, 0] = this[i, k];
        return m;
    }

    public void SetCol(Matrix v, int k)
    {
        for (int i = 0; i < Rows; i++) Values[i, k] = v[i, 0];
    }


    public bool IsZeroMatrix()
    {
        bool res = true; 
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Math.Abs(this[i, j]) >= Eps)
                {
                    res = false;
                }
            }
        }
        return res;

    }

    public Matrix Column(int k)
    {
        Matrix col = new Matrix(Rows, 1);
        for (int i = 0;i < Rows; i++)
        {
            col[i, 0] = this[i, k];
        }
        return col;
    }
    public Matrix GetFirstKCols (int k)
    {
        Matrix res = new Matrix(Rows, k + 1);
        {
            for(int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < k + 1; j++)
                {
                    res[i, j] = this[i, j];
                }
            }
        }
        return res;
    }
    public static Matrix GetA1_plus(Matrix a1)
    {
        Matrix a1Tr = Transpose(a1);
        Matrix prod = Multiply(a1Tr, a1);
        double res = 1.0 / prod[0, 0];
        Matrix a1Plus = Multiply(res, a1Tr);
        return a1Plus;
    }

    public Matrix GetPseudoInverse()
    {
        Matrix matrix = ZeroMatrix(Columns, Rows);
        Matrix a1 = Column(0);

        bool isZero = a1.IsZeroMatrix();
        Matrix a1Plus ;
        if (!isZero) {
            a1Plus = GetA1_plus(a1);
        }
        
        else {
            a1Plus = ZeroMatrix(1, Rows);
        }
        Matrix aPrev = a1Plus.Duplicate();
        for (int k = 1; k < Columns; k++)
        {
            Matrix ak = Column(k);
            Matrix dk = Multiply(aPrev, ak);
            Matrix akMin1 = GetFirstKCols(k - 1);
            Matrix ck = ak - Multiply(akMin1, dk);
            Matrix bk;
            if (!ck.IsZeroMatrix())
            {
                bk = GetA1_plus(ck);
            }
            else
            {
                Matrix dkTr = Transpose(dk);
                Matrix prod = Multiply(dkTr, dk);
                bk = Multiply(Multiply((1.0/(1 + prod[0, 0])),dkTr), aPrev);
            }
            Matrix Bk = aPrev - Multiply(dk, bk);
            Matrix aNext = Combine(Bk, bk); //Multiply(A_prev,)
            aPrev = aNext.Duplicate();
        }
        a1Plus = aPrev;
        return a1Plus;
    }
    public static Matrix Combine(Matrix a, Matrix b)
    {
        Matrix res = new Matrix(a.Rows + 1, a.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
                res[i, j] = a[i, j];
        }
        int t = a.Rows;
        for (int jj = 0; jj < a.Columns; jj++)
        {
            res[t, jj] = b[0, jj];
        }
        return res;
    }

    public Matrix Duplicate()                   // Function returns the copy of this matrix
    {
        Matrix matrix = new Matrix(Rows, Columns);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                matrix[i, j] = this[i, j];
        return matrix;
    }


    public static Matrix ZeroMatrix(int iRows, int iCols)       // Function generates the zero matrix
    {
        Matrix matrix = new Matrix(iRows, iCols);
        for (int i = 0; i < iRows; i++)
            for (int j = 0; j < iCols; j++)
                matrix[i, j] = 0;
        return matrix;
    }

    public static Matrix IdentityMatrix(int iRows, int iCols)   // Function generates the identity matrix
    {
        Matrix matrix = ZeroMatrix(iRows, iCols);
        for (int i = 0; i < Math.Min(iRows, iCols); i++)
            matrix[i, i] = 1;
        return matrix;
    }

    public static Matrix Parse(string ps)                        // Function parses the matrix from string
    {
        string s = NormalizeMatrixString(ps);
        string[] rows = Regex.Split(s, "\r\n");
        string[] nums = rows[0].Split(' ');
        Matrix matrix = new Matrix(rows.Length, nums.Length);
        try
        {
            for (int i = 0; i < rows.Length; i++)
            {
                nums = rows[i].Split(' ');
                for (int j = 0; j < nums.Length; j++) matrix[i, j] = double.Parse(nums[j]);
            }
        }
        catch (FormatException exc) { throw new MException("Wrong input format!"); }
        return matrix;
    }

    /// <summary>
    /// Перегрузка метода ToString() для представления матрицы в соответствующем виде в виде переменной типа string
    /// </summary>
    /// <returns>Матрица в строчном типе переменной</returns>
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++) s += String.Format("{0,5:0.00}", Values[i, j]) + " ";
            s += "\r\n";
        }
        return s;
    }

    /// <summary>
    /// Транспонирование даной матрицы
    /// </summary>
    /// <param name="m">Матрица, для которой должно быть выполнено транспонирование</param>
    /// <returns>Транспонированая матрица (A^T)</returns>
    public static Matrix Transpose(Matrix m)
    {
        Matrix t = new Matrix(m.Columns, m.Rows);
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Columns; j++)
                t[j, i] = m[i, j];
        return t;
    }
  
    /// <summary>
    /// Умножение матриц
    /// </summary>
    /// <param name="m1">Первая матрица умножения</param>
    /// <param name="m2">Матрица, на которую умножается первая матрица</param>
    /// <returns>Производная матрица двух матриц</returns>
    public static Matrix Multiply(Matrix m1, Matrix m2)
    {
        if (m1.Columns != m2.Rows) throw new MException("Wrong dimensions of matrix!");

        Matrix result = ZeroMatrix(m1.Rows, m2.Columns);
        for (int i = 0; i < result.Rows; i++)
            for (int j = 0; j < result.Columns; j++)
                for (int k = 0; k < m1.Columns; k++)
                    result[i, j] += m1[i, k] * m2[k, j];
        return result;
    }

    /// <summary>
    /// Умножение матрицы на константу
    /// </summary>
    /// <param name="constant">Константа</param>
    /// <param name="matrix">Матрица</param>
    /// <returns>Матрица, умноженная на константу</returns>
    private static Matrix Multiply(double constant, Matrix matrix)
    {
        Matrix resultMatrix = new Matrix(matrix.Rows, matrix.Columns);
        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                resultMatrix[i, j] = matrix[i, j] * constant;
        return resultMatrix;
    }

    /// <summary>
    /// Суммирование матриц
    /// </summary>
    /// <param name="m1">Матрица для суммирования</param>
    /// <param name="m2">Матрица для суммирования</param>
    /// <returns>Матрица сумма двух матриц</returns>
    private static Matrix Add(Matrix m1, Matrix m2)
    {
        if (m1.Rows != m2.Rows || m1.Columns != m2.Columns) throw new MException("Matrices must have the same dimensions!");
        Matrix r = new Matrix(m1.Rows, m1.Columns);
        for (int i = 0; i < r.Rows; i++)
            for (int j = 0; j < r.Columns; j++)
                r[i, j] = m1[i, j] + m2[i, j];
        return r;
    }

    public static string NormalizeMatrixString(string matStr)	
    {
        // Remove any multiple spaces
        while (matStr.IndexOf("  ") != -1)
            matStr = matStr.Replace("  ", " ");

        // Remove any spaces before or after newlines
        matStr = matStr.Replace(" \r\n", "\r\n");
        matStr = matStr.Replace("\r\n ", "\r\n");

        // If the data ends in a newline, remove the trailing newline.
        // Make it easier by first replacing \r\n’s with |’s then
        // restore the |’s with \r\n’s
        matStr = matStr.Replace("\r\n", "|");
        while (matStr.LastIndexOf("|") == (matStr.Length - 1))
            matStr = matStr.Substring(0, matStr.Length - 1);

        matStr = matStr.Replace("|", "\r\n");
        return matStr.Trim();
    }

    public static Svd<double> GetSvd(Matrix matr)
    {
        int counter = 0;
        double[] values = new double[matr.Rows*matr.Columns];
        for (int i = 0; i < matr.Rows; i++)
        {
            for (int r = 0; r < matr.Columns; r++)
            {
                values[counter++] = matr.Values[i, r];
            }
        }
        Matrix<double> m = Matrix<double>.Build.Dense(matr.Rows, matr.Columns, values);
        return m.Svd();
    }

    //   O P E R A T O R S

    public static Matrix operator -(Matrix m)
    { return Multiply(-1, m); }

    public static Matrix operator +(Matrix m1, Matrix m2)
    { return Add(m1, m2); }

    public static Matrix operator -(Matrix m1, Matrix m2)
    { return Add(m1, -m2); }

    public static Matrix operator *(Matrix m1, Matrix m2)
    { return Multiply(m1, m2); }

    public static Matrix operator *(double n, Matrix m)
    { return Multiply(n, m); }
}

public class MException : Exception
{
    public MException(string Message)
        : base(Message)
    { }
}