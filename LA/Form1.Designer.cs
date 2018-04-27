namespace LA
{
    partial class MatrixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseMatrixBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.transponovanaButton = new System.Windows.Forms.Button();
            this.transposedMatrixBox = new System.Windows.Forms.TextBox();
            this.lblPseudoInverse = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.multipliedBaseTrans = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.singularVectorBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uMatrixBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vtMatrixBox = new System.Windows.Forms.TextBox();
            this.wMatrixBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baseMatrixBox
            // 
            this.baseMatrixBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseMatrixBox.Location = new System.Drawing.Point(12, 43);
            this.baseMatrixBox.Multiline = true;
            this.baseMatrixBox.Name = "baseMatrixBox";
            this.baseMatrixBox.Size = new System.Drawing.Size(305, 247);
            this.baseMatrixBox.TabIndex = 0;
            this.baseMatrixBox.Text = " 1 -1   2  0\r\n-1  2  -3  1\r\n 0  1  -1  1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Матриця системи";
            // 
            // transponovanaButton
            // 
            this.transponovanaButton.Location = new System.Drawing.Point(10, 505);
            this.transponovanaButton.Name = "transponovanaButton";
            this.transponovanaButton.Size = new System.Drawing.Size(301, 23);
            this.transponovanaButton.TabIndex = 6;
            this.transponovanaButton.Text = "Обчислити транспоньовану матрицю";
            this.transponovanaButton.UseVisualStyleBackColor = true;
            this.transponovanaButton.Click += new System.EventHandler(this.GetTransMatrix);
            // 
            // transposedMatrixBox
            // 
            this.transposedMatrixBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transposedMatrixBox.Location = new System.Drawing.Point(12, 323);
            this.transposedMatrixBox.Multiline = true;
            this.transposedMatrixBox.Name = "transposedMatrixBox";
            this.transposedMatrixBox.ReadOnly = true;
            this.transposedMatrixBox.Size = new System.Drawing.Size(299, 176);
            this.transposedMatrixBox.TabIndex = 7;
            // 
            // lblPseudoInverse
            // 
            this.lblPseudoInverse.AutoSize = true;
            this.lblPseudoInverse.Location = new System.Drawing.Point(13, 298);
            this.lblPseudoInverse.Name = "lblPseudoInverse";
            this.lblPseudoInverse.Size = new System.Drawing.Size(150, 13);
            this.lblPseudoInverse.TabIndex = 8;
            this.lblPseudoInverse.Text = "Транспонированая матрица";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 716);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Умножить транспонированую матрицу на изначальную";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MultiplyBaseMatrixWithTrans);
            // 
            // multipliedBaseTrans
            // 
            this.multipliedBaseTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multipliedBaseTrans.Location = new System.Drawing.Point(10, 534);
            this.multipliedBaseTrans.Multiline = true;
            this.multipliedBaseTrans.Name = "multipliedBaseTrans";
            this.multipliedBaseTrans.ReadOnly = true;
            this.multipliedBaseTrans.Size = new System.Drawing.Size(296, 176);
            this.multipliedBaseTrans.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(326, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 38);
            this.button2.TabIndex = 11;
            this.button2.Text = "Выполнить сингулярное разложение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DoSvd);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Сингулярный вектор матрицы";
            // 
            // singularVectorBox
            // 
            this.singularVectorBox.Location = new System.Drawing.Point(326, 99);
            this.singularVectorBox.Multiline = true;
            this.singularVectorBox.Name = "singularVectorBox";
            this.singularVectorBox.ReadOnly = true;
            this.singularVectorBox.Size = new System.Drawing.Size(190, 55);
            this.singularVectorBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "U матрица";
            // 
            // uMatrixBox
            // 
            this.uMatrixBox.Location = new System.Drawing.Point(326, 178);
            this.uMatrixBox.Multiline = true;
            this.uMatrixBox.Name = "uMatrixBox";
            this.uMatrixBox.ReadOnly = true;
            this.uMatrixBox.Size = new System.Drawing.Size(207, 96);
            this.uMatrixBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "VT матрица";
            // 
            // vtMatrixBox
            // 
            this.vtMatrixBox.Location = new System.Drawing.Point(326, 299);
            this.vtMatrixBox.Multiline = true;
            this.vtMatrixBox.Name = "vtMatrixBox";
            this.vtMatrixBox.ReadOnly = true;
            this.vtMatrixBox.Size = new System.Drawing.Size(207, 96);
            this.vtMatrixBox.TabIndex = 17;
            // 
            // wMatrixBox
            // 
            this.wMatrixBox.Location = new System.Drawing.Point(326, 417);
            this.wMatrixBox.Multiline = true;
            this.wMatrixBox.Name = "wMatrixBox";
            this.wMatrixBox.ReadOnly = true;
            this.wMatrixBox.Size = new System.Drawing.Size(207, 96);
            this.wMatrixBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "W матрица";
            // 
            // MatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 745);
            this.Controls.Add(this.wMatrixBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vtMatrixBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uMatrixBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.singularVectorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.multipliedBaseTrans);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPseudoInverse);
            this.Controls.Add(this.transposedMatrixBox);
            this.Controls.Add(this.transponovanaButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseMatrixBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MatrixForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SLAR ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseMatrixBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button transponovanaButton;
        private System.Windows.Forms.TextBox transposedMatrixBox;
        private System.Windows.Forms.Label lblPseudoInverse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox multipliedBaseTrans;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox singularVectorBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uMatrixBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vtMatrixBox;
        private System.Windows.Forms.TextBox wMatrixBox;
        private System.Windows.Forms.Label label5;
    }
}

