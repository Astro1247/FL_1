/*
  Клас для матричних операцій
*/

using System;
using System.Text.RegularExpressions;


public class Matrix
{
    public int rows;
    public int cols;
    public double[,] mat;

    //public Matrix L;
    public Matrix U;
    private int[] pi;
    private double detOfP = 1;

    private double eps = 1e-6;

    public Matrix(int iRows, int iCols)         // Matrix Class constructor
    {
        rows = iRows;
        cols = iCols;
        mat = new double[rows, cols];
    }

    public Boolean IsSquare()
    {
        return (rows == cols);
    }

    public double this[int iRow, int iCol]      // Access this matrix as a 2D array
    {
        get { return mat[iRow, iCol]; }
        set {
            if (Math.Abs(value) >= eps){ 
                mat[iRow, iCol] = value;
                }
            else{
                mat[iRow, iCol] = 0;
            }
        }
    }

    public Matrix GetCol(int k)
    {
        Matrix m = new Matrix(rows, 1);
        for (int i = 0; i < rows; i++) m[i, 0] = this[i, k];
        return m;
    }

    public void SetCol(Matrix v, int k)
    {
        for (int i = 0; i < rows; i++) mat[i, k] = v[i, 0];
    }


    public bool isZeroMatrix()
    {
        bool res = true; 
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (Math.Abs(this[i, j]) >= eps)
                {
                    res = false;
                }
            }
        }
        return res;

    }

    public Matrix Column(int k)
    {
        Matrix col = new Matrix(rows, 1);
        for (int i = 0;i < rows; i++)
        {
            col[i, 0] = this[i, k];
        }
        return col;
    }
    public Matrix GetFirstKCols (int k)
    {
        Matrix res = new Matrix(rows, k + 1);
        {
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < k + 1; j++)
                {
                    res[i, j] = this[i, j];
                }
            }
        }
        return res;
    }
    public static Matrix GetA1_plus(Matrix A1)
    {
        Matrix A1_tr = Transpose(A1);
        Matrix prod = Multiply(A1_tr, A1);
        double res = 1.0 / prod[0, 0];
        Matrix A1_plus = Multiply(res, A1_tr);
        return A1_plus;
    }

    public Matrix GetPseudoInverse()
    {
        Matrix matrix = ZeroMatrix(cols, rows);
        Matrix a1 = this.Column(0);

        bool isZero = a1.isZeroMatrix();
        Matrix A1_plus ;
        if (!isZero) {
            A1_plus = GetA1_plus(a1);
        }
        
        else {
            A1_plus = ZeroMatrix(1, rows);
        }
        Matrix A_prev = A1_plus.Duplicate();
        for (int k = 1; k < cols; k++)
        {
            Matrix ak = Column(k);
            Matrix dk = Multiply(A_prev, ak);
            Matrix Ak_min_1 = GetFirstKCols(k - 1);
            Matrix ck = ak - Multiply(Ak_min_1, dk);
            Matrix bk;
            if (!ck.isZeroMatrix())
            {
                bk = GetA1_plus(ck);
            }
            else
            {
                Matrix dk_tr = Transpose(dk);
                Matrix prod = Multiply(dk_tr, dk);
                bk = Multiply(Multiply((1.0/(1 + prod[0, 0])),dk_tr), A_prev);
            }
            Matrix Bk = A_prev - Multiply(dk, bk);
            Matrix A_next = Combine(Bk, bk); //Multiply(A_prev,)
            A_prev = A_next.Duplicate();
        }
        A1_plus = A_prev;
        return A1_plus;
    }
    public static Matrix Combine(Matrix a, Matrix b)
    {
        Matrix res = new Matrix(a.rows + 1, a.cols);
        for (int i = 0; i < a.rows; i++)
        {
            for (int j = 0; j < a.cols; j++)
                res[i, j] = a[i, j];
        }
        int t = a.rows;
        for (int jj = 0; jj < a.cols; jj++)
        {
            res[t, jj] = b[0, jj];
        }
        return res;
    }

    public Matrix Duplicate()                   // Function returns the copy of this matrix
    {
        Matrix matrix = new Matrix(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
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

    public override string ToString()                           // Function returns matrix as a string
    {
        string s = "";
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) s += String.Format("{0,5:0.00}", mat[i, j]) + " ";
            s += "\r\n";
        }
        return s;
    }

    public static Matrix Transpose(Matrix m)              // Matrix transpose, for any rectangular matrix
    {
        Matrix t = new Matrix(m.cols, m.rows);
        for (int i = 0; i < m.rows; i++)
            for (int j = 0; j < m.cols; j++)
                t[j, i] = m[i, j];
        return t;
    }
  

    public static Matrix Multiply(Matrix m1, Matrix m2)                  // matrix multiplication
    {
        if (m1.cols != m2.rows) throw new MException("Wrong dimensions of matrix!");

        Matrix result = ZeroMatrix(m1.rows, m2.cols);
        for (int i = 0; i < result.rows; i++)
            for (int j = 0; j < result.cols; j++)
                for (int k = 0; k < m1.cols; k++)
                    result[i, j] += m1[i, k] * m2[k, j];
        return result;
    }
    private static Matrix Multiply(double n, Matrix m)                          // Multiplication by constant n
    {
        Matrix r = new Matrix(m.rows, m.cols);
        for (int i = 0; i < m.rows; i++)
            for (int j = 0; j < m.cols; j++)
                r[i, j] = m[i, j] * n;
        return r;
    }
    private static Matrix Add(Matrix m1, Matrix m2)         // Sčítání matic
    {
        if (m1.rows != m2.rows || m1.cols != m2.cols) throw new MException("Matrices must have the same dimensions!");
        Matrix r = new Matrix(m1.rows, m1.cols);
        for (int i = 0; i < r.rows; i++)
            for (int j = 0; j < r.cols; j++)
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

    //   O P E R A T O R S

    public static Matrix operator -(Matrix m)
    { return Matrix.Multiply(-1, m); }

    public static Matrix operator +(Matrix m1, Matrix m2)
    { return Matrix.Add(m1, m2); }

    public static Matrix operator -(Matrix m1, Matrix m2)
    { return Matrix.Add(m1, -m2); }

    public static Matrix operator *(Matrix m1, Matrix m2)
    { return Matrix.Multiply(m1, m2); }

    public static Matrix operator *(double n, Matrix m)
    { return Matrix.Multiply(n, m); }
}

//  The class for exceptions

public class MException : Exception
{
    public MException(string Message)
        : base(Message)
    { }
}