using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Common;
using System.Configuration;

namespace OCR2ImageOrSearchablePDF
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            PageControlLocation.MakeControlVerticalCenter(panelControl1.Parent, panelControl1);
            PageControlLocation.MakeControlHoritionalCenter(panelControl2.Parent, panelControl2);
            //PageControlLocation.MakeControlHoritionalCenterNextToAnotherControl_Downward(panelControl1, panelControl3);
            simpleButton1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (!TestConnection())
            //{
            //    MessageBox.Show("数据库连接有误，请联系系统管理员进行正确配置！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (string.IsNullOrEmpty(UserNameTxt.Text))
            {
                MessageBox.Show("用户名不能为空！", "敬告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(PasswordTxt.Text))
            {
                MessageBox.Show("密码不能为空！", "敬告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!UserNameTxt.Text.Equals("gdsj") || !PasswordTxt.Text.Equals("gdsj@123"))
            {
                MessageBox.Show("用户名或密码有误，请重试！", "敬告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;//关键:设置登陆成功状态   
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UserNameTxt.ResetText();
            PasswordTxt.ResetText();
        }
    }
}