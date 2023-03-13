
namespace bighm.BasicOptionForm
{
    partial class SurfaceAnalysis
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
            this.Rasinputcbb = new System.Windows.Forms.ComboBox();
            this.Slopeunitcbb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SlopeCountbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rasinputcbb
            // 
            this.Rasinputcbb.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rasinputcbb.FormattingEnabled = true;
            this.Rasinputcbb.Location = new System.Drawing.Point(139, 30);
            this.Rasinputcbb.Margin = new System.Windows.Forms.Padding(4);
            this.Rasinputcbb.Name = "Rasinputcbb";
            this.Rasinputcbb.Size = new System.Drawing.Size(257, 29);
            this.Rasinputcbb.TabIndex = 0;
            this.Rasinputcbb.SelectedIndexChanged += new System.EventHandler(this.Rasinputcbb_SelectedIndexChanged);
            // 
            // Slopeunitcbb
            // 
            this.Slopeunitcbb.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Slopeunitcbb.FormattingEnabled = true;
            this.Slopeunitcbb.Location = new System.Drawing.Point(180, 35);
            this.Slopeunitcbb.Margin = new System.Windows.Forms.Padding(4);
            this.Slopeunitcbb.Name = "Slopeunitcbb";
            this.Slopeunitcbb.Size = new System.Drawing.Size(179, 29);
            this.Slopeunitcbb.TabIndex = 1;
            this.Slopeunitcbb.SelectedIndexChanged += new System.EventHandler(this.Slopeunitcbb_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SlopeCountbtn);
            this.groupBox1.Controls.Add(this.Slopeunitcbb);
            this.groupBox1.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.groupBox1.Location = new System.Drawing.Point(27, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(390, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坡度计算";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出测量单位";
            // 
            // SlopeCountbtn
            // 
            this.SlopeCountbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.SlopeCountbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SlopeCountbtn.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SlopeCountbtn.ForeColor = System.Drawing.Color.White;
            this.SlopeCountbtn.Location = new System.Drawing.Point(13, 93);
            this.SlopeCountbtn.Margin = new System.Windows.Forms.Padding(4);
            this.SlopeCountbtn.Name = "SlopeCountbtn";
            this.SlopeCountbtn.Size = new System.Drawing.Size(356, 47);
            this.SlopeCountbtn.TabIndex = 2;
            this.SlopeCountbtn.Text = "计  算";
            this.SlopeCountbtn.UseVisualStyleBackColor = false;
            this.SlopeCountbtn.Click += new System.EventHandler(this.SlopeCountbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "输入栅格";
            // 
            // SurfaceAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(448, 251);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rasinputcbb);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SurfaceAnalysis";
            this.Text = "计算坡度";
            this.Load += new System.EventHandler(this.SurfaceAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Rasinputcbb;
        private System.Windows.Forms.ComboBox Slopeunitcbb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SlopeCountbtn;
        private System.Windows.Forms.Label label1;
    }
}