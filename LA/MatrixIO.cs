using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MatrixCalculator
{
    class MatrixIO : DataGridView
    {
        //input output grid handler class for a matrix with doubles
        //

        #region Private fields

        private const int cDefaultSize = 3; //default row and col size

        //array for the data in the grid
        private double[,] MData;

        // Boolean flag used to determine when a character other than a number is entered.
        private bool NumberEntered = false;

        #endregion

        #region Constructors
        public MatrixIO()
        {
            InitializeDataGridView(cDefaultSize, cDefaultSize);
        }

        public MatrixIO(int nRows, int nCols)
        {
            InitializeDataGridView(nRows, nCols);
        }

        public MatrixIO(Point location, int nRows, int nCols)
        {
            InitializeDataGridView(nRows, nCols);
            this.Location = location;
        }
        #endregion

        #region Initialisation of the DataGridView

        private void InitializeDataGridView(int rows, int columns)
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.EditMode = DataGridViewEditMode.EditOnKeystroke;

            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "dataGridView1";
            this.Size = new System.Drawing.Size(250, 125);
            this.TabIndex = 0;
            this.RowHeadersWidth = 55;
            //used to attach event-handlers to the events of the editing control(nice name!)
            this.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.MatrixIO_EditingControlShowing);

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            for (int i = 0; i < columns; i++)
            {
                AddAColumn(i);
            }
            this.RowHeadersDefaultCellStyle.Padding = new Padding(3);//helps to get rid of the selection triangle?
            for (int i = 0; i < rows; i++)
            {
                AddARow(i);
            }

            this.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            this.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro;

            this.ShowEditingIcon = false;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void AddARow(int i)
        {
            DataGridViewRow Arow = new DataGridViewRow();
            Arow.HeaderCell.Value = "R" + i.ToString();
            this.Rows.Add(Arow);
        }

        private void AddAColumn(int i)
        {
            DataGridViewTextBoxColumn Acolumn = new DataGridViewTextBoxColumn();
            Acolumn.HeaderText = "C" + i.ToString();
            Acolumn.Name = "Column" + i.ToString();
            Acolumn.Width = 60;
            Acolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //make a Style template to be used in the grid
            DataGridViewCell Acell = new DataGridViewTextBoxCell();
            Acell.Style.BackColor = Color.LightCyan;
            Acell.Style.SelectionBackColor = Color.FromArgb(128, 255, 255);
            Acolumn.CellTemplate = Acell;
            this.Columns.Add(Acolumn);
        }

        public void MakeMatrixTitle(string Title)
        {
            this.TopLeftHeaderCell.Value = Title;
            this.TopLeftHeaderCell.Style.BackColor = Color.AliceBlue;
        }

        #endregion

        #region Properties and property utility functions

        public MMatrix TheMatrix
        {
            get
            {
                MData = new double[this.RowCount, this.ColumnCount];
                ExtractTextboxes();
                return new MMatrix(MData);
            }
            set
            {
                MData = value.array;
                this.Rows.Clear();
                this.Columns.Clear();
                InitializeDataGridView(value.Rows, value.Cols);
                FillTextboxes();
            }
        }

        public double[,] TheData
        {
            get
            {
                MData = new double[this.RowCount, this.ColumnCount];
                ExtractTextboxes();
                return MData;
            }
            set
            {
                int _rows = value.GetUpperBound(0) + 1;
                int _cols = value.GetUpperBound(1) + 1;
                MData = new double[_rows, _cols];
                MData = value;
                ResizeOurself(_rows, _cols);
                FillTextboxes();
            }
        }

        private void ResizeOurself(int r, int c)
        {
            //adjust rows and cols, do nothing if they equal 
            //
            while (r < this.RowCount)
            {
                this.Rows.RemoveAt(this.RowCount - 1);
            }
            while (r > this.RowCount)
            {
                AddARow(this.RowCount);
            }
            while (c < this.ColumnCount)
            {
                this.Columns.RemoveAt(this.ColumnCount - 1);
            }
            while (c > this.ColumnCount)
            {
                AddAColumn(this.ColumnCount);
            }
        }

        private void FillTextboxes()     //fill the textboxes
        {
            for (int r = 0; r < this.RowCount; r++)
            {
                for (int c = 0; c < this.ColumnCount; c++)
                {
                    this[c, r].Value = MData[r, c]; //notice r, c
                }
            }
        }

        private void ExtractTextboxes()
        {
            for (int r = 0; r < this.RowCount; r++)
            {
                for (int c = 0; c < this.ColumnCount; c++)
                {
                    try
                    {
                        string str = this[c, r].Value.ToString();
                        MData[r, c] = Convert.ToDouble(str.Replace('.', ','));   //notice r, c 
                    }
                    catch (Exception)
                    {
                        MData[r, c] = 0.0;  //assume for the moment this if the cell is not filled
                        //throw;
                    }

                }
            }
        }
        #endregion

        #region Key and keyboard processing
        //Check if key entered is "numeric"
        private bool CheckKey(Keys K, bool isDecimalPoint, bool isMinus)
        {
            if (K == Keys.Back) //backspace?
                return true;
            else if (K == Keys.OemPeriod || K == Keys.Decimal)  //decimal point?
                return isDecimalPoint ? false : true;       //or: return !isDecimalPoint
            else if (K == Keys.OemMinus)
                return !isMinus;
            else if ((K >= Keys.D0) && (K <= Keys.D9))      //digit from top of keyboard?
                return true;
            else if ((K >= Keys.NumPad0) && (K <= Keys.NumPad9))    //digit from keypad?
                return true;
            else
                return false;   //no "numeric" key
        }

        // Handle the KeyDown event to determine the type of character entered into the control.
        // The method here should be registered as KeyEventHandler to the EditingControl 
        // of the DataGridView in order for it to work (took me some time to figure that out...)
        private void MatrixIO_KeyDown(object sender, KeyEventArgs e)
        {
            //we know we have columns of type DataGridViewTextBoxColumn so :
            TextBox Tbx = (TextBox)sender;
            bool decimalTyped = Tbx.Text.Contains(".");
            bool minusTyped = Tbx.Text.Contains("-");
            // Initialize the flag.
            NumberEntered = CheckKey(e.KeyCode, decimalTyped, minusTyped);
        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void MatrixIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (NumberEntered == false)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void MatrixIO_KeyUp(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                NumberEntered = false;
            }
        }

        private void MatrixIO_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Unsubscribe from the event in case it is subscribed

            this.EditingControl.KeyPress -= new KeyPressEventHandler(MatrixIO_KeyPress);
            this.EditingControl.KeyDown -= new KeyEventHandler(this.MatrixIO_KeyDown);

            this.EditingControl.KeyPress += new KeyPressEventHandler(MatrixIO_KeyPress);
            this.EditingControl.KeyDown += new KeyEventHandler(this.MatrixIO_KeyDown);
        }
        #endregion
    }

}
//        Here is the code you need to make the Enter key move the focus to the right:

//public class dgv : DataGridView
//{
//    protected override bool ProcessDialogKey(Keys keyData)
//    {
//        Keys key = (keyData & Keys.KeyCode);
//        if (key == Keys.Enter)
//        {
//            return this.ProcessRightKey(keyData);
//        }
//        return base.ProcessDialogKey(keyData);
//    }
//    protected override bool ProcessDataGridViewKey(KeyEventArgs e)
//    {
//        if (e.KeyCode == Keys.Enter)
//        {
//            return this.ProcessRightKey(e.KeyData);
//        }
//        return base.ProcessDataGridViewKey(e);
//    }
//}

