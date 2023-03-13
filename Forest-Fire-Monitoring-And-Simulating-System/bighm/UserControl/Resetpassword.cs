using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.UserControl
{
    public partial class Resetpassword : Form
    {
        #region 需要用到的变量定义
        int Usersnum;//获取用户数量
        List<string[]> Usersdata;//导入用户数据
        string username;//获取用户名文件
        #endregion

        #region 程序初始化与数据库导入
        public Resetpassword()
        {
            InitializeComponent();
            //设置验证码的位置
            checkedcode.Parent = pictureBox1;
            checkedcode.Location = new Point(10, 12);
            //先生成随机验证码
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            checkedcode.Text = random.Next(minV, maxV).ToString();

            RegisterForm registerForm = new RegisterForm();
            Usersdata = registerForm.Read("./UserData.txt").Item1;
            Usersnum = registerForm.Read("./UserData.txt").Item2 - 1;
            username = registerForm.Getdata().Item1;
        }
        #endregion

        #region 重设密码
        private void UserIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            //首先禁止用户名输入中文
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("禁止输入中文");
            }
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {

            if (UserIdText.Text != "" & checkcode.Text != ""
               & Renamepasstext.Text != "" & ensurepasstext.Text != "")
            {
                if (!username.Contains(UserIdText.Text))
                {
                    MessageBox.Show("用户名不存在");
                    UserIdText.Text = "";   //清空账号
                    UserIdText.Focus();     //光标设置在账号上
                }
                else
                {
                    //确认两次密码输入相同
                    if (ensurepasstext.Text != Renamepasstext.Text)
                    {
                        ensurepasstext.Text = "";
                        MessageBox.Show("两次密码输入需相同");
                    }
                    else
                    {
                        //确认验证码输入正确
                        if (checkcode.Text != checkedcode.Text)
                        {
                            checkcode.Text = "";
                            MessageBox.Show("验证码输入有误");
                        }
                        else
                        {
                            if (Renamepasstext.TextLength < 6)
                            {
                                MessageBox.Show("密码需至少为6位数");
                            }
                            else
                            {
                                //修改密码并存储
                                for (int i = 1; i <= Usersnum; i++)
                                {
                                    if (Usersdata[i][0] == UserIdText.Text)
                                    {
                                        Usersdata[i][1] = Renamepasstext.Text;
                                    }
                                }
                                Storage("./UserData.txt", Usersdata);
                                MessageBox.Show("密码已更新！");
                                this.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请将信息填完整");
            }
        }

        #endregion

        #region 数据库更新
        public void Storage(string fpath, List<string[]> data)
        {
            using (var sw = new StreamWriter(new FileStream(fpath, FileMode.Create, FileAccess.Write), Encoding.UTF8))
            {
                foreach (var row in data)
                    for (var j = 0; j < 3; ++j)
                        sw.Write(row[j] + (j == 2 ? "\r\n" : ";"));
                sw.Flush();
            }
        }
        #endregion

        #region 关闭程序
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 生成验证码
        private void checkedcode_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            checkedcode.Text = random.Next(minV, maxV).ToString();
        }
        #endregion

    }
}
