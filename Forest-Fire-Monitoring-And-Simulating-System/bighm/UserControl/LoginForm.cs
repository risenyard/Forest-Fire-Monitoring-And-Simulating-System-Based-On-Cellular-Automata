using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.UserControl
{
    public partial class LoginForm : Form
    {
        #region 需要用到的变量定义
        public static bool IsOk = false;
        private int errorTime = 3;
        int Usersnum;//获取用户数量
        List<string[]> Usersdata;//导入用户数据
        string username;//获取用户名文件
        #endregion

        #region 程序初始化与数据库连接
        public LoginForm()
        {
            InitializeComponent();
            RegisterForm registerForm = new RegisterForm();
            Usersdata = registerForm.Read("./UserData.txt").Item1;
            Usersnum = registerForm.Read("./UserData.txt").Item2 - 1;
            username = registerForm.Getdata().Item1;
        }
        #endregion

        #region 退出系统
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();//退出系统
        }
        #endregion

        #region 用户登录
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (AdminNameTextbox.Text != "" & PasswordTextbox.Text != "")
            {
                if (!username.Contains(AdminNameTextbox.Text))
                {
                    MessageBox.Show("用户名不存在");
                    AdminNameTextbox.Text = "";   //清空账号
                    AdminNameTextbox.Focus();     //光标设置在账号上
                }
                else
                {
                    for (int i = 1; i <= Usersnum; i++)
                    {
                        if (Usersdata[i][0] == AdminNameTextbox.Text)
                        {
                            if (Usersdata[i][1] == PasswordTextbox.Text)
                            {
                                IsOk = true;//判断用户名和密码是否匹配
                            }
                            else
                            {
                                IsOk = false;
                                errorTime = errorTime - 1;
                            }
                        }
                    }
                    if (errorTime <= 3 && errorTime > 0)
                    {
                        if (IsOk)
                        {
                            MessageBox.Show("欢迎使用！"); //登录成功
                            MainForm mainForm = new MainForm();
                            this.Hide();
                            mainForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("用户名与密码不匹配！您还有" + errorTime.ToString() + "次机会");
                            AdminNameTextbox.Text = ""; //清空账号
                            PasswordTextbox.Text = ""; //清空密码
                            AdminNameTextbox.Focus(); //光标设置在账号上
                        }
                    }
                    else
                    {
                        MessageBox.Show("您输错的用户名或密码已达三次，将退出程序");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入完整信息");
            }

        }
        #endregion

        #region 用户注册
        private void Registerbtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            Usersdata = registerForm.Read("./UserData.txt").Item1;
            Usersnum = registerForm.Read("./UserData.txt").Item2 - 1;
            username = registerForm.Getdata().Item1;
        }
        #endregion

        #region 忘记或重设密码
        private void Findpassword_Click(object sender, EventArgs e)
        {
            Resetpassword resetpassword = new Resetpassword();
            resetpassword.ShowDialog();
            RegisterForm registerForm = new RegisterForm();
            Usersdata = registerForm.Read("./UserData.txt").Item1;
            Usersnum = registerForm.Read("./UserData.txt").Item2 - 1;
            username = registerForm.Getdata().Item1;
        }
        #endregion
    }
}
