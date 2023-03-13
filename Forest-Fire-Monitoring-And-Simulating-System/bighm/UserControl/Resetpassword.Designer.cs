
namespace bighm.UserControl
{
    partial class Resetpassword
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
            this.Resetbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.UserIdText = new System.Windows.Forms.TextBox();
            this.Renamepasstext = new System.Windows.Forms.TextBox();
            this.ensurepasstext = new System.Windows.Forms.TextBox();
            this.checkcode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Resetbtn
            // 
            this.Resetbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Resetbtn.FlatAppearance.BorderSize = 0;
            this.Resetbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Resetbtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Resetbtn.ForeColor = System.Drawing.Color.Black;
            this.Resetbtn.Location = new System.Drawing.Point(68, 305);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(102, 37);
            this.Resetbtn.TabIndex = 0;
            this.Resetbtn.Text = "重设密码";
            this.Resetbtn.UseVisualStyleBackColor = false;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Exitbtn.FlatAppearance.BorderSize = 0;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Exitbtn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Exitbtn.Location = new System.Drawing.Point(215, 305);
            this.Exitbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(103, 37);
            this.Exitbtn.TabIndex = 1;
            this.Exitbtn.Text = "退  出";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // UserIdText
            // 
            this.UserIdText.Location = new System.Drawing.Point(152, 44);
            this.UserIdText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserIdText.Name = "UserIdText";
            this.UserIdText.Size = new System.Drawing.Size(167, 25);
            this.UserIdText.TabIndex = 3;
            this.UserIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserIdText_KeyPress);
            // 
            // Renamepasstext
            // 
            this.Renamepasstext.Location = new System.Drawing.Point(152, 112);
            this.Renamepasstext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Renamepasstext.Name = "Renamepasstext";
            this.Renamepasstext.Size = new System.Drawing.Size(167, 25);
            this.Renamepasstext.TabIndex = 4;
            // 
            // ensurepasstext
            // 
            this.ensurepasstext.Location = new System.Drawing.Point(152, 181);
            this.ensurepasstext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ensurepasstext.Name = "ensurepasstext";
            this.ensurepasstext.Size = new System.Drawing.Size(167, 25);
            this.ensurepasstext.TabIndex = 5;
            // 
            // checkcode
            // 
            this.checkcode.Location = new System.Drawing.Point(152, 249);
            this.checkcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkcode.Name = "checkcode";
            this.checkcode.Size = new System.Drawing.Size(167, 25);
            this.checkcode.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::bighm.Properties.Resources.验证码;
            this.pictureBox1.Location = new System.Drawing.Point(25, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkedcode);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(443, 175);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(201, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看验证码";
            // 
            // checkedcode
            // 
            this.checkedcode.AutoSize = true;
            this.checkedcode.BackColor = System.Drawing.Color.Transparent;
            this.checkedcode.Font = new System.Drawing.Font("Ravie", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.checkedcode.ForeColor = System.Drawing.Color.Purple;
            this.checkedcode.Location = new System.Drawing.Point(35, 36);
            this.checkedcode.Name = "checkedcode";
            this.checkedcode.Size = new System.Drawing.Size(121, 36);
            this.checkedcode.TabIndex = 8;
            this.checkedcode.Text = "label1";
            this.checkedcode.Click += new System.EventHandler(this.checkedcode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.Location = new System.Drawing.Point(43, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "确认新密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.label4.Location = new System.Drawing.Point(43, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "输入验证码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(464, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "点击图片更换验证码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Location = new System.Drawing.Point(324, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "*密码不小于6位数";
            // 
            // Resetpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::bighm.Properties.Resources.图片1;
            this.ClientSize = new System.Drawing.Size(711, 375);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkcode);
            this.Controls.Add(this.ensurepasstext);
            this.Controls.Add(this.Renamepasstext);
            this.Controls.Add(this.UserIdText);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Resetbtn);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Resetpassword";
            this.Text = "Resetpassword";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.TextBox UserIdText;
        private System.Windows.Forms.TextBox Renamepasstext;
        private System.Windows.Forms.TextBox ensurepasstext;
        private System.Windows.Forms.TextBox checkcode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label checkedcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}