
namespace bighm.BasicOptionForm
{
    partial class NDVI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NDVI));
            this.listBoxBandR = new System.Windows.Forms.ListBox();
            this.ConfirmValue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelLayer = new System.Windows.Forms.Label();
            this.listBoxLayer = new System.Windows.Forms.ListBox();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.listBoxBandNIR = new System.Windows.Forms.ListBox();
            this.labelNIR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxBandR
            // 
            this.listBoxBandR.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxBandR.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxBandR.ForeColor = System.Drawing.Color.DarkCyan;
            this.listBoxBandR.FormattingEnabled = true;
            this.listBoxBandR.ItemHeight = 21;
            this.listBoxBandR.Location = new System.Drawing.Point(264, 264);
            this.listBoxBandR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxBandR.Name = "listBoxBandR";
            this.listBoxBandR.Size = new System.Drawing.Size(193, 109);
            this.listBoxBandR.TabIndex = 0;
            // 
            // ConfirmValue
            // 
            this.ConfirmValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.ConfirmValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmValue.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmValue.ForeColor = System.Drawing.Color.White;
            this.ConfirmValue.Location = new System.Drawing.Point(265, 415);
            this.ConfirmValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmValue.Name = "ConfirmValue";
            this.ConfirmValue.Size = new System.Drawing.Size(192, 48);
            this.ConfirmValue.TabIndex = 17;
            this.ConfirmValue.Text = "确认";
            this.ConfirmValue.UseVisualStyleBackColor = false;
            this.ConfirmValue.Click += new System.EventHandler(this.ConfirmValue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(36, 415);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(193, 48);
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
            this.labelLayer.Location = new System.Drawing.Point(32, 48);
            this.labelLayer.Name = "labelLayer";
            this.labelLayer.Size = new System.Drawing.Size(46, 21);
            this.labelLayer.TabIndex = 25;
            this.labelLayer.Text = "图层";
            // 
            // listBoxLayer
            // 
            this.listBoxLayer.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxLayer.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxLayer.ForeColor = System.Drawing.Color.DarkCyan;
            this.listBoxLayer.FormattingEnabled = true;
            this.listBoxLayer.ItemHeight = 21;
            this.listBoxLayer.Location = new System.Drawing.Point(124, 48);
            this.listBoxLayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxLayer.Name = "listBoxLayer";
            this.listBoxLayer.Size = new System.Drawing.Size(334, 130);
            this.listBoxLayer.TabIndex = 26;
            this.listBoxLayer.SelectedIndexChanged += new System.EventHandler(this.listBoxLayer_SelectedIndexChanged);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(12, 354);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 28;
            // 
            // listBoxBandNIR
            // 
            this.listBoxBandNIR.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxBandNIR.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxBandNIR.ForeColor = System.Drawing.Color.DarkCyan;
            this.listBoxBandNIR.FormattingEnabled = true;
            this.listBoxBandNIR.ItemHeight = 21;
            this.listBoxBandNIR.Location = new System.Drawing.Point(35, 264);
            this.listBoxBandNIR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxBandNIR.Name = "listBoxBandNIR";
            this.listBoxBandNIR.Size = new System.Drawing.Size(194, 109);
            this.listBoxBandNIR.TabIndex = 29;
            // 
            // labelNIR
            // 
            this.labelNIR.AutoSize = true;
            this.labelNIR.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNIR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.labelNIR.Location = new System.Drawing.Point(32, 229);
            this.labelNIR.Name = "labelNIR";
            this.labelNIR.Size = new System.Drawing.Size(100, 21);
            this.labelNIR.TabIndex = 30;
            this.labelNIR.Text = "近红外波段";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华光大标宋_CNKI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(80)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(261, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "红光波段";
            // 
            // NDVI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(488, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNIR);
            this.Controls.Add(this.listBoxBandNIR);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.listBoxLayer);
            this.Controls.Add(this.labelLayer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ConfirmValue);
            this.Controls.Add(this.listBoxBandR);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "NDVI";
            this.Text = "计算NDVI";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBandR;
        private System.Windows.Forms.Button ConfirmValue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelLayer;
        private System.Windows.Forms.ListBox listBoxLayer;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ListBox listBoxBandNIR;
        private System.Windows.Forms.Label labelNIR;
        private System.Windows.Forms.Label label1;
    }
}