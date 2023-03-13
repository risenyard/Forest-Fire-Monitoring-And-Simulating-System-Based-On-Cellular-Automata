using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.UserControl
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            Checkcode.Parent = pictureBox1;
            Checkcode.Location = new Point(15,15);
            //先生成随机验证码
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            Checkcode.Text = random.Next(minV, maxV).ToString();
        }

        #region 需要用到的变量定义
        string Flag_admin = "No";
        private string UserID = "";
        private string Password = "";
        private string Admin = "";
        #endregion

        #region 检查注册数据内容并录入数据库

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

        public Tuple<List<string[]>, int> Read(string FileName)
        {
            var rawdata = new List<string[]>();
            using (var sr = new StreamReader(FileName, Encoding.UTF8))
            {
                string[] colName = sr.ReadLine().ToString().Split(';');
                rawdata.Add(colName);
                //读到文件末尾
                int row = 1;
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().TrimEnd((char[])"\n\r".ToCharArray()).Split(';');
                    rawdata.Add(line);
                    ++row;
                }
                Tuple<List<string[]>, int> result = new Tuple<List<string[]>, int>(rawdata, row);
                return result;
            }
        }

        public Tuple<string, string, string> Getdata()
        {
            List<string[]> Usersdata = Read("./UserData.txt").Item1;
            int Usersnum = Read("./UserData.txt").Item2 - 1;
            for (int i = 1; i <= Usersnum; i++)
            {
                UserID = UserID + Usersdata[i][0].ToString() + ";";
                Password = Password + Usersdata[i][1].ToString() + ";";
                Admin = Admin + Usersdata[i][2].ToString() + ";";
            }
            Tuple<string, string, string> result = new Tuple<string, string, string>(
               UserID, Password, Admin);
            return result;
        }

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

        private void Registerbtn_Click(object sender, EventArgs e)
        {
            //导入账户数据库
            List<string[]> Usersdata = Read("./UserData.txt").Item1;
            int Usersnum = Read("./UserData.txt").Item2 - 1;
            for (int i = 1; i <= Usersnum; i++)
            {
                UserID = UserID + Usersdata[i][0].ToString() + ";";
                Password = Password + Usersdata[i][1].ToString() + ";";
                Admin = Admin + Usersdata[i][2].ToString() + ";";
            }
            //检查信息是否填写完整
            if (UserIdText.Text == "" || EnsurePwText.Text == ""
                || TextCheck.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
            }
            else
            {
                //接下来这部分是多重判断数据输入是否符合要求
                //检查该注册账户是否已经存在
                string userID = UserIdText.Text.Trim();  //取出账号
                if (UserID.Contains(userID))
                {
                    MessageBox.Show("用户名存在");
                    UserIdText.Text = "";
                    UserPwText.Text = "";
                    EnsurePwText.Text = "";
                }
                else
                {
                    //确认两次密码输入相同
                    if (EnsurePwText.Text != UserPwText.Text)
                    {
                        MessageBox.Show("两次输入的密码需一致");
                        EnsurePwText.Text = "";
                        UserPwText.Text = "";
                    }
                    else
                    {
                        //验证码
                        if (TextCheck.Text != Checkcode.Text)
                        {
                            MessageBox.Show("输入验证码有误！");
                            TextCheck.Text = "";
                        }
                        else
                        {
                            if (UserPwText.TextLength < 6)
                            {
                                MessageBox.Show("密码需至少为6位数");
                            }
                            else
                            {
                                MessageBox.Show("注册成功");
                                string[] newuser = { UserIdText.Text.Trim(), UserPwText.Text.Trim(), Flag_admin };
                                Usersdata.Add(newuser);
                                Storage("./UserData.txt", Usersdata);
                                this.Close();
                            }
                        }
                    }
                }

            }
        }

        private void Admincheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Admincheckbox.Checked == true)
            {
                Flag_admin = "Yes";
            }
            else
            {
                Flag_admin = "No";
            }
        }
        #endregion

        #region 生成验证码
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            Checkcode.Text = random.Next(minV, maxV).ToString();
        }
        private void Checkcode_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int minV = 12345, maxV = 98765;
            Checkcode.Text = random.Next(minV, maxV).ToString();
        }
        #endregion

        #region 退出程序
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
