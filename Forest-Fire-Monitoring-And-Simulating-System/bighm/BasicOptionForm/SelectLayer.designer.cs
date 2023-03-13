
namespace bighm.BasicOptionForm
{
    partial class SelectLayer
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelLayer = new System.Windows.Forms.Label();
            this.listBoxLayer = new System.Windows.Forms.ListBox();
            this.ConfirmValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(307, 368);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 48);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelLayer
            // 
            this.labelLayer.AutoSize = true;
            this.labelLayer.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.labelLayer.Location = new System.Drawing.Point(35, 30);
            this.labelLayer.Name = "labelLayer";
            this.labelLayer.Size = new System.Drawing.Size(46, 21);
            this.labelLayer.TabIndex = 25;
            this.labelLayer.Text = "图层";
            // 
            // listBoxLayer
            // 
            this.listBoxLayer.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxLayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.listBoxLayer.FormattingEnabled = true;
            this.listBoxLayer.ItemHeight = 21;
            this.listBoxLayer.Location = new System.Drawing.Point(124, 30);
            this.listBoxLayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxLayer.Name = "listBoxLayer";
            this.listBoxLayer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLayer.Size = new System.Drawing.Size(334, 298);
            this.listBoxLayer.TabIndex = 26;
            // 
            // ConfirmValue
            // 
            this.ConfirmValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.ConfirmValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmValue.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmValue.ForeColor = System.Drawing.Color.White;
            this.ConfirmValue.Location = new System.Drawing.Point(124, 368);
            this.ConfirmValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmValue.Name = "ConfirmValue";
            this.ConfirmValue.Size = new System.Drawing.Size(151, 49);
            this.ConfirmValue.TabIndex = 17;
            this.ConfirmValue.Text = "确认";
            this.ConfirmValue.UseVisualStyleBackColor = false;
            this.ConfirmValue.Click += new System.EventHandler(this.ConfirmValue_Click);
            // 
            // SelectLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(488, 431);
            this.Controls.Add(this.listBoxLayer);
            this.Controls.Add(this.labelLayer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ConfirmValue);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SelectLayer";
            this.Text = "选择图层";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelLayer;
        private System.Windows.Forms.ListBox listBoxLayer;
        private System.Windows.Forms.Button ConfirmValue;
    }
}