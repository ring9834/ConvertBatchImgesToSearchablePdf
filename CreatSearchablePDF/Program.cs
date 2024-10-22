using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR2ImageOrSearchablePDF
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login2 = new LoginForm();
            login2.ShowDialog();
            if (login2.DialogResult == DialogResult.OK)
            {
                Application.Run(new MDIParent1());//判断登陆成功时主进程显示主窗口;把登录成功的用户传递到主窗体
                login2.Close();
                login2.Dispose();
            }
            else return;
        }
    }
}
