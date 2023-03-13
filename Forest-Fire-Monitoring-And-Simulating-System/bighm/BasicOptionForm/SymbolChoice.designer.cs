
namespace bighm.BasicOptionForm
{ 
    partial class SymbolChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolChoice));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.NumericUpDown();
            this.lblAngle = new System.Windows.Forms.NumericUpDown();
            this.Text = new System.Windows.Forms.Label();
            this.Angle = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptbPreview = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyControl1.Location = new System.Drawing.Point(0, 0);
            this.axSymbologyControl1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(405, 510);
            this.axSymbologyControl1.TabIndex = 0;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(0, 478);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lblSize);
            this.groupBox2.Controls.Add(this.lblAngle);
            this.groupBox2.Controls.Add(this.Text);
            this.groupBox2.Controls.Add(this.Angle);
            this.groupBox2.Controls.Add(this.Size);
            this.groupBox2.Controls.Add(this.btnColor);
            this.groupBox2.Controls.Add(this.Color);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.groupBox2.Location = new System.Drawing.Point(14, 206);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(319, 291);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.textBox1.Location = new System.Drawing.Point(99, 170);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 24);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(166, 238);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 45);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(27, 238);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSize
            // 
            this.lblSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.lblSize.Location = new System.Drawing.Point(99, 90);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(132, 24);
            this.lblSize.TabIndex = 6;
            this.lblSize.ValueChanged += new System.EventHandler(this.lblSize_ValueChanged);
            // 
            // lblAngle
            // 
            this.lblAngle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.lblAngle.Location = new System.Drawing.Point(99, 128);
            this.lblAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(132, 24);
            this.lblAngle.TabIndex = 5;
            this.lblAngle.ValueChanged += new System.EventHandler(this.lblAngle_ValueChanged);
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text.Location = new System.Drawing.Point(23, 170);
            this.Text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(52, 25);
            this.Text.TabIndex = 4;
            this.Text.Text = "文本";
            // 
            // Angle
            // 
            this.Angle.AutoSize = true;
            this.Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Angle.Location = new System.Drawing.Point(23, 128);
            this.Angle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(52, 25);
            this.Angle.TabIndex = 3;
            this.Angle.Text = "角度";
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Size.Location = new System.Drawing.Point(23, 90);
            this.Size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(52, 25);
            this.Size.TabIndex = 2;
            this.Size.Text = "大小";
            // 
            // btnColor
            // 
            this.btnColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.btnColor.Location = new System.Drawing.Point(99, 49);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(132, 29);
            this.btnColor.TabIndex = 1;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Color
            // 
            this.Color.AutoSize = true;
            this.Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Color.Location = new System.Drawing.Point(23, 50);
            this.Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(52, 25);
            this.Color.TabIndex = 0;
            this.Color.Text = "颜色";
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.ptbPreview);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(327, 173);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // ptbPreview
            // 
            this.ptbPreview.BackColor = System.Drawing.SystemColors.Info;
            this.ptbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbPreview.Location = new System.Drawing.Point(4, 21);
            this.ptbPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbPreview.Name = "ptbPreview";
            this.ptbPreview.Size = new System.Drawing.Size(319, 148);
            this.ptbPreview.TabIndex = 0;
            this.ptbPreview.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axSymbologyControl1);
            this.splitContainer1.Panel1.Controls.Add(this.axLicenseControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(786, 510);
            this.splitContainer1.SplitterDistance = 405;
            this.splitContainer1.TabIndex = 7;
            // 
            // SymbolChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(786, 510);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SymbolChoice";
            this.Load += new System.EventHandler(this.SymbolChoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown lblSize;
        private System.Windows.Forms.NumericUpDown lblAngle;
        private System.Windows.Forms.Label Text;
        private System.Windows.Forms.Label Angle;
        private System.Windows.Forms.Label Size;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label Color;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ptbPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}