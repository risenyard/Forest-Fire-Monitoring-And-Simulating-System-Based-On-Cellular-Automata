
namespace bighm.BasicOptionForm
{
    partial class RasterCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterCalculator));
            this.listBoxBand = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.ConfirmValue = new System.Windows.Forms.Button();
            this.ClearEquation = new System.Windows.Forms.Button();
            this.ConfirmEquation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Parentheses = new System.Windows.Forms.Button();
            this.labelVariable = new System.Windows.Forms.Label();
            this.listBoxLayer = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxBand
            // 
            this.listBoxBand.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxBand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.listBoxBand.FormattingEnabled = true;
            this.listBoxBand.ItemHeight = 18;
            this.listBoxBand.Location = new System.Drawing.Point(314, 259);
            this.listBoxBand.Name = "listBoxBand";
            this.listBoxBand.Size = new System.Drawing.Size(184, 76);
            this.listBoxBand.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(32, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(466, 132);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(32, 159);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Multiply
            // 
            this.Multiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.Multiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Multiply.ForeColor = System.Drawing.Color.White;
            this.Multiply.Location = new System.Drawing.Point(31, 203);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(64, 40);
            this.Multiply.TabIndex = 4;
            this.Multiply.Text = "*";
            this.Multiply.UseVisualStyleBackColor = false;
            this.Multiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // Minus
            // 
            this.Minus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Minus.ForeColor = System.Drawing.Color.White;
            this.Minus.Location = new System.Drawing.Point(101, 159);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(65, 38);
            this.Minus.TabIndex = 7;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = false;
            this.Minus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // divide
            // 
            this.divide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.divide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.divide.ForeColor = System.Drawing.Color.White;
            this.divide.Location = new System.Drawing.Point(101, 203);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(65, 40);
            this.divide.TabIndex = 8;
            this.divide.Text = "/";
            this.divide.UseVisualStyleBackColor = false;
            this.divide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // ConfirmValue
            // 
            this.ConfirmValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.ConfirmValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmValue.ForeColor = System.Drawing.Color.White;
            this.ConfirmValue.Location = new System.Drawing.Point(155, 429);
            this.ConfirmValue.Name = "ConfirmValue";
            this.ConfirmValue.Size = new System.Drawing.Size(158, 49);
            this.ConfirmValue.TabIndex = 17;
            this.ConfirmValue.Text = "确认";
            this.ConfirmValue.UseVisualStyleBackColor = false;
            this.ConfirmValue.Click += new System.EventHandler(this.ConfirmValue_Click);
            // 
            // ClearEquation
            // 
            this.ClearEquation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.ClearEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClearEquation.ForeColor = System.Drawing.Color.White;
            this.ClearEquation.Location = new System.Drawing.Point(332, 203);
            this.ClearEquation.Name = "ClearEquation";
            this.ClearEquation.Size = new System.Drawing.Size(166, 40);
            this.ClearEquation.TabIndex = 18;
            this.ClearEquation.Text = "清除表达式";
            this.ClearEquation.UseVisualStyleBackColor = false;
            this.ClearEquation.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ConfirmEquation
            // 
            this.ConfirmEquation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.ConfirmEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmEquation.ForeColor = System.Drawing.Color.White;
            this.ConfirmEquation.Location = new System.Drawing.Point(332, 155);
            this.ConfirmEquation.Name = "ConfirmEquation";
            this.ConfirmEquation.Size = new System.Drawing.Size(166, 42);
            this.ConfirmEquation.TabIndex = 20;
            this.ConfirmEquation.Text = "确定表达式";
            this.ConfirmEquation.UseVisualStyleBackColor = false;
            this.ConfirmEquation.Click += new System.EventHandler(this.ConfirmEquation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(332, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(166, 48);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Parentheses
            // 
            this.Parentheses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.Parentheses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Parentheses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Parentheses.ForeColor = System.Drawing.Color.White;
            this.Parentheses.Location = new System.Drawing.Point(172, 159);
            this.Parentheses.Name = "Parentheses";
            this.Parentheses.Size = new System.Drawing.Size(65, 38);
            this.Parentheses.TabIndex = 22;
            this.Parentheses.Text = "()";
            this.Parentheses.UseVisualStyleBackColor = false;
            this.Parentheses.Click += new System.EventHandler(this.btnParentheses_Click);
            // 
            // labelVariable
            // 
            this.labelVariable.AutoSize = true;
            this.labelVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelVariable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.labelVariable.Location = new System.Drawing.Point(32, 259);
            this.labelVariable.Name = "labelVariable";
            this.labelVariable.Size = new System.Drawing.Size(46, 18);
            this.labelVariable.TabIndex = 25;
            this.labelVariable.Text = "label1";
            // 
            // listBoxLayer
            // 
            this.listBoxLayer.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxLayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.listBoxLayer.FormattingEnabled = true;
            this.listBoxLayer.ItemHeight = 18;
            this.listBoxLayer.Location = new System.Drawing.Point(123, 259);
            this.listBoxLayer.Name = "listBoxLayer";
            this.listBoxLayer.Size = new System.Drawing.Size(166, 76);
            this.listBoxLayer.TabIndex = 26;
            this.listBoxLayer.SelectedIndexChanged += new System.EventHandler(this.listBoxLayer_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(155, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(343, 46);
            this.button1.TabIndex = 27;
            this.button1.Text = "确认选择，并显示下一个变量";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(12, 401);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 28;
            // 
            // RasterCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(510, 513);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxLayer);
            this.Controls.Add(this.labelVariable);
            this.Controls.Add(this.Parentheses);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ConfirmEquation);
            this.Controls.Add(this.ClearEquation);
            this.Controls.Add(this.ConfirmValue);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.Multiply);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBoxBand);
            this.MaximizeBox = false;
            this.Name = "RasterCalculator";
            this.Text = "栅格计算器";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBand;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button ConfirmValue;
        private System.Windows.Forms.Button ClearEquation;
        private System.Windows.Forms.Button ConfirmEquation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button Parentheses;
        private System.Windows.Forms.Label labelVariable;
        private System.Windows.Forms.ListBox listBoxLayer;
        private System.Windows.Forms.Button button1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
    }
}