
namespace bighm.UserControl
{
    partial class RegisterForm
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
            this.UserIdText = new System.Windows.Forms.TextBox();
            this.UserPwText = new System.Windows.Forms.TextBox();
            this.EnsurePwText = new System.Windows.Forms.TextBox();
            this.Registerbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Checkcode = new System.Windows.Forms.Label();
            this.TextCheck = new System.Windows.Forms.TextBox();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Admincheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserIdText
            // 
            this.UserIdText.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIdText.Location = new System.Drawing.Point(122, 52);
            this.UserIdText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserIdText.Name = "UserIdText";
            this.UserIdText.Size = new System.Drawing.Size(150, 26);
            this.UserIdText.TabIndex = 0;
            this.UserIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserIdText_KeyPress);
            // 
            // UserPwText
            // 
            this.UserPwText.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPwText.Location = new System.Drawing.Point(122, 103);
            this.UserPwText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserPwText.Name = "UserPwText";
            this.UserPwText.PasswordChar = '*';
            this.UserPwText.Size = new System.Drawing.Size(150, 26);
            this.UserPwText.TabIndex = 1;
            // 
            // EnsurePwText
            // 
            this.EnsurePwText.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnsurePwText.Location = new System.Drawing.Point(122, 154);
            this.EnsurePwText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnsurePwText.Name = "EnsurePwText";
            this.EnsurePwText.PasswordChar = '*';
            this.EnsurePwText.Size = new System.Drawing.Size(150, 26);
            this.EnsurePwText.TabIndex = 2;
            // 
            // Registerbtn
            // 
            this.Registerbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Registerbtn.FlatAppearance.BorderSize = 0;
            this.Registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registerbtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Registerbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Registerbtn.Location = new System.Drawing.Point(30, 312);
            this.Registerbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registerbtn.Name = "Registerbtn";
            this.Registerbtn.Size = new System.Drawing.Size(90, 40);
            this.Registerbtn.TabIndex = 3;
            this.Registerbtn.Text = "注  册";
            this.Registerbtn.UseVisualStyleBackColor = false;
            this.Registerbtn.Click += new System.EventHandler(this.Registerbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::bighm.Properties.Resources.验证码;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Checkcode
            // 
            this.Checkcode.AutoSize = true;
            this.Checkcode.BackColor = System.Drawing.Color.Transparent;
            this.Checkcode.Font = new System.Drawing.Font("Ravie", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Checkcode.ForeColor = System.Drawing.Color.Purple;
            this.Checkcode.Location = new System.Drawing.Point(30, 47);
            this.Checkcode.Name = "Checkcode";
            this.Checkcode.Size = new System.Drawing.Size(116, 36);
            this.Checkcode.TabIndex = 5;
            this.Checkcode.Text = "12989";
            this.Checkcode.Click += new System.EventHandler(this.Checkcode_Click);
            // 
            // TextCheck
            // 
            this.TextCheck.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCheck.Location = new System.Drawing.Point(122, 205);
            this.TextCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextCheck.Name = "TextCheck";
            this.TextCheck.Size = new System.Drawing.Size(150, 26);
            this.TextCheck.TabIndex = 6;
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Exitbtn.FlatAppearance.BorderSize = 0;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Exitbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exitbtn.Location = new System.Drawing.Point(140, 312);
            this.Exitbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(89, 40);
            this.Exitbtn.TabIndex = 7;
            this.Exitbtn.Text = "退  出";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(16, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.MintCream;
            this.label3.Location = new System.Drawing.Point(16, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(16, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "验证码";
            // 
            // Admincheckbox
            // 
            this.Admincheckbox.AutoSize = true;
            this.Admincheckbox.BackColor = System.Drawing.Color.Transparent;
            this.Admincheckbox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Admincheckbox.ForeColor = System.Drawing.Color.MintCream;
            this.Admincheckbox.Location = new System.Drawing.Point(16, 256);
            this.Admincheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Admincheckbox.Name = "Admincheckbox";
            this.Admincheckbox.Size = new System.Drawing.Size(140, 28);
            this.Admincheckbox.TabIndex = 12;
            this.Admincheckbox.Text = "是否为管理员";
            this.Admincheckbox.UseVisualStyleBackColor = false;
            this.Admincheckbox.CheckedChanged += new System.EventHandler(this.Admincheckbox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(276, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "*不支持汉字 区分大小写";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Location = new System.Drawing.Point(276, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "*需大于6位数 区分大小写";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Checkcode);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(464, 199);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(201, 112);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查看验证码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Location = new System.Drawing.Point(487, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "点击图片更换验证码";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::bighm.Properties.Resources.图片1;
            this.ClientSize = new System.Drawing.Size(711, 375);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Admincheckbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.TextCheck);
            this.Controls.Add(this.Registerbtn);
            this.Controls.Add(this.EnsurePwText);
            this.Controls.Add(this.UserPwText);
            this.Controls.Add(this.UserIdText);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserIdText;
        private System.Windows.Forms.TextBox UserPwText;
        private System.Windows.Forms.TextBox EnsurePwText;
        private System.Windows.Forms.Button Registerbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Checkcode;
        private System.Windows.Forms.TextBox TextCheck;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Admincheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}