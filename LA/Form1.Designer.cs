namespace LA
{
    partial class Form1
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
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMultiply = new System.Windows.Forms.Label();
            this.txtSolution = new System.Windows.Forms.TextBox();
            this.lblEqual = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnClick = new System.Windows.Forms.Button();
            this.txtPInv = new System.Windows.Forms.TextBox();
            this.lblPseudoInverse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMatrix
            // 
            this.txtMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMatrix.Location = new System.Drawing.Point(12, 43);
            this.txtMatrix.Multiline = true;
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.Size = new System.Drawing.Size(305, 247);
            this.txtMatrix.TabIndex = 0;
            this.txtMatrix.Text = " 1 -1   2  0\r\n-1  2  -3  1\r\n 0  1  -1  1";
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
            // lblMultiply
            // 
            this.lblMultiply.AutoSize = true;
            this.lblMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMultiply.Location = new System.Drawing.Point(323, 153);
            this.lblMultiply.Name = "lblMultiply";
            this.lblMultiply.Size = new System.Drawing.Size(25, 31);
            this.lblMultiply.TabIndex = 2;
            this.lblMultiply.Text = "*";
            // 
            // txtSolution
            // 
            this.txtSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSolution.Location = new System.Drawing.Point(354, 43);
            this.txtSolution.Multiline = true;
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.Size = new System.Drawing.Size(80, 247);
            this.txtSolution.TabIndex = 3;
            // 
            // lblEqual
            // 
            this.lblEqual.AutoSize = true;
            this.lblEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEqual.Location = new System.Drawing.Point(446, 153);
            this.lblEqual.Name = "lblEqual";
            this.lblEqual.Size = new System.Drawing.Size(30, 31);
            this.lblEqual.TabIndex = 4;
            this.lblEqual.Text = "=";
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB.Location = new System.Drawing.Point(493, 43);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(80, 247);
            this.txtB.TabIndex = 5;
            this.txtB.Text = "3\r\n6\r\n0";
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(12, 311);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(301, 23);
            this.btnClick.TabIndex = 6;
            this.btnClick.Text = "Обчислити псевдообернену матрицю";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPInv
            // 
            this.txtPInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPInv.Location = new System.Drawing.Point(12, 371);
            this.txtPInv.Multiline = true;
            this.txtPInv.Name = "txtPInv";
            this.txtPInv.Size = new System.Drawing.Size(299, 176);
            this.txtPInv.TabIndex = 7;
            // 
            // lblPseudoInverse
            // 
            this.lblPseudoInverse.AutoSize = true;
            this.lblPseudoInverse.Location = new System.Drawing.Point(13, 346);
            this.lblPseudoInverse.Name = "lblPseudoInverse";
            this.lblPseudoInverse.Size = new System.Drawing.Size(139, 13);
            this.lblPseudoInverse.TabIndex = 8;
            this.lblPseudoInverse.Text = "Псевдообернена матриця";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Невідомі";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Права частина";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 569);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPseudoInverse);
            this.Controls.Add(this.txtPInv);
            this.Controls.Add(this.btnClick);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblEqual);
            this.Controls.Add(this.txtSolution);
            this.Controls.Add(this.lblMultiply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatrix);
            this.Name = "Form1";
            this.Text = "SLAR ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMultiply;
        private System.Windows.Forms.TextBox txtSolution;
        private System.Windows.Forms.Label lblEqual;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.TextBox txtPInv;
        private System.Windows.Forms.Label lblPseudoInverse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

