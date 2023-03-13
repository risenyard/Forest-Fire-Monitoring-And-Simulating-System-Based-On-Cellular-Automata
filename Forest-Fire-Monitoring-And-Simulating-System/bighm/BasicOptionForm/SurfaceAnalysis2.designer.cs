
namespace bighm.BasicOptionForm
{
    partial class SurfaceAnalysis2
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AspectCountbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rasinputcbb
            // 
            this.Rasinputcbb.FormattingEnabled = true;
            this.Rasinputcbb.Location = new System.Drawing.Point(139, 30);
            this.Rasinputcbb.Margin = new System.Windows.Forms.Padding(4);
            this.Rasinputcbb.Name = "Rasinputcbb";
            this.Rasinputcbb.Size = new System.Drawing.Size(257, 32);
            this.Rasinputcbb.TabIndex = 0;
            this.Rasinputcbb.SelectedIndexChanged += new System.EventHandler(this.Rasinputcbb_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AspectCountbtn);
            this.groupBox2.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.groupBox2.Location = new System.Drawing.Point(28, 77);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(389, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坡向计算";
            // 
            // AspectCountbtn
            // 
            this.AspectCountbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.AspectCountbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AspectCountbtn.ForeColor = System.Drawing.Color.White;
            this.AspectCountbtn.Location = new System.Drawing.Point(24, 47);
            this.AspectCountbtn.Margin = new System.Windows.Forms.Padding(4);
            this.AspectCountbtn.Name = "AspectCountbtn";
            this.AspectCountbtn.Size = new System.Drawing.Size(344, 44);
            this.AspectCountbtn.TabIndex = 0;
            this.AspectCountbtn.Text = "计  算";
            this.AspectCountbtn.UseVisualStyleBackColor = false;
            this.AspectCountbtn.Click += new System.EventHandler(this.AspectCountbtn_Click);
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
            // SurfaceAnalysis2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(448, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Rasinputcbb);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SurfaceAnalysis2";
            this.Text = "计算坡向";
            this.Load += new System.EventHandler(this.SurfaceAnalysis_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Rasinputcbb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AspectCountbtn;
        private System.Windows.Forms.Label label1;
    }
}