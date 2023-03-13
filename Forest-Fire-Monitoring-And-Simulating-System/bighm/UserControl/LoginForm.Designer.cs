
namespace bighm.UserControl
{
    partial class LoginForm
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
            this.AdminNameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.Registerbtn = new System.Windows.Forms.Button();
            this.Findpassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AdminNameTextbox
            // 
            this.AdminNameTextbox.Location = new System.Drawing.Point(276, 182);
            this.AdminNameTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AdminNameTextbox.Name = "AdminNameTextbox";
            this.AdminNameTextbox.Size = new System.Drawing.Size(272, 25);
            this.AdminNameTextbox.TabIndex = 0;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(276, 225);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(272, 25);
            this.PasswordTextbox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLabel.ForeColor = System.Drawing.Color.MintCream;
            this.NameLabel.Location = new System.Drawing.Point(194, 179);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(72, 27);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "用户名";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.MintCream;
            this.PasswordLabel.Location = new System.Drawing.Point(215, 222);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(52, 27);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "密码";
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Loginbtn.FlatAppearance.BorderSize = 0;
            this.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loginbtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Loginbtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Loginbtn.Location = new System.Drawing.Point(276, 273);
            this.Loginbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(86, 33);
            this.Loginbtn.TabIndex = 4;
            this.Loginbtn.Text = "登  陆";
            this.Loginbtn.UseVisualStyleBackColor = false;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Exitbtn.FlatAppearance.BorderSize = 0;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Exitbtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Exitbtn.Location = new System.Drawing.Point(367, 273);
            this.Exitbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(84, 33);
            this.Exitbtn.TabIndex = 5;
            this.Exitbtn.Text = "退  出";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // Registerbtn
            // 
            this.Registerbtn.BackColor = System.Drawing.Color.AliceBlue;
            this.Registerbtn.FlatAppearance.BorderSize = 0;
            this.Registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registerbtn.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Registerbtn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Registerbtn.Location = new System.Drawing.Point(456, 273);
            this.Registerbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registerbtn.Name = "Registerbtn";
            this.Registerbtn.Size = new System.Drawing.Size(92, 33);
            this.Registerbtn.TabIndex = 6;
            this.Registerbtn.Text = "注  册";
            this.Registerbtn.UseVisualStyleBackColor = false;
            this.Registerbtn.Click += new System.EventHandler(this.Registerbtn_Click);
            // 
            // Findpassword
            // 
            this.Findpassword.AutoSize = true;
            this.Findpassword.BackColor = System.Drawing.Color.Transparent;
            this.Findpassword.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Findpassword.ForeColor = System.Drawing.Color.HotPink;
            this.Findpassword.Location = new System.Drawing.Point(565, 228);
            this.Findpassword.Name = "Findpassword";
            this.Findpassword.Size = new System.Drawing.Size(114, 20);
            this.Findpassword.TabIndex = 7;
            this.Findpassword.Text = "忘记或重设密码";
            this.Findpassword.Click += new System.EventHandler(this.Findpassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::bighm.Properties.Resources.登录;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(766, 339);
            this.Controls.Add(this.Findpassword);
            this.Controls.Add(this.Registerbtn);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.AdminNameTextbox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AdminNameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Button Registerbtn;
        private System.Windows.Forms.Label Findpassword;
    }
}