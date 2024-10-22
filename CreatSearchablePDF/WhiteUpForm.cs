using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR2ImageOrSearchablePDF
{
    public partial class WhiteUpForm : Form
    {
        private bool IsGenerating { get; set; }
        public WhiteUpForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.IsGenerating)
            {
                MessageBox.Show("正在图片补边中...请稍后！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("请选择要补边的图片源路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                MessageBox.Show("请选择要存放补边图片的目标路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WhiteUpTaskDelegate task = new WhiteUpTaskDelegate(WhiteUpImage);
            task.BeginInvoke(textEdit1.Text, textEdit1.Text, textEdit2.Text, int.Parse(spinEdit1.Text), new AsyncCallback(WhiteUpCallBack), null);
            //WhiteUpImage(textEdit1.Text, textEdit2.Text, int.Parse(spinEdit1.Text));
            //ShowDynamicTextInRichText("图片补边任务完成！\r\n");
            //this.IsGenerating = false;
        }

        private delegate void WhiteUpTaskDelegate(string sourceRootPath, string sourcePath, string destinationPath, int outerSize);
        
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="result"></param>
        void WhiteUpCallBack(IAsyncResult result)
        {
            WhiteUpTaskDelegate gdk = (WhiteUpTaskDelegate)((AsyncResult)result).AsyncDelegate;
            gdk.EndInvoke(result);
            this.IsGenerating = false;
            ShowDynamicTextInRichText("补边任务完成！"+ DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") +"\r\n");
        }

        private void WhiteUpImage(string sourceRootPath, string sourcePath, string destinationPath, int outerSize)
        {
            this.IsGenerating = true;//标识正在执行状态
            DirectoryInfo di = new DirectoryInfo(sourcePath);
            DirectoryInfo[] diA = di.GetDirectories();
            for (int i = 0; i < diA.Length; i++)
            {
                WhiteUpImage(sourceRootPath, diA[i].FullName, destinationPath, outerSize);
            }

            FileInfo[] files = GetFileInfoArrayByDirectory(di);//获得文件信息列表
            string outPath = "";
            if (files.Length > 0)
            {
                for (int j = 0; j < files.Length; j++)
                {
                    FileInfo fi = files[j];
                    string strSourceImg = fi.FullName;
                    string directory = fi.DirectoryName;
                    outPath = CreateSavingDirectoryFolder(directory, sourceRootPath, destinationPath);//创建盛放PDF的目录

                    ShowDynamicTextInRichText("正在补边：" + strSourceImg + "图片...\r\n");

                    try
                    {
                        Bitmap b = new Bitmap(strSourceImg);
                        Bitmap btm = WhiteUpLogic.WhiteUp(b, outerSize);

                        if (!Directory.Exists(outPath))
                            Directory.CreateDirectory(outPath);

                        string fileName = outPath + "\\" + fi.Name;
                        btm.Save(fileName);
                    }
                    catch {
                        ShowDynamicTextInRichText("图片：" + strSourceImg + "有异常，此图片补边失败...\r\n");
                    }
                }
            }
        }

        private void ShowDynamicTextInRichText(string content)
        {
            Action act = delegate()//线程操作UI中的控件
            {
                richTextBox1.Text += content;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            };
            this.Invoke(act);
        }

        /// <summary>
        /// 取所选路径中的倒数第二层文件夹，与保存路径进行拼接，形成新的保存路径
        /// </summary>
        /// <param name="imageDirectoryName"></param>
        /// <param name="sourceRootPath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        private string CreateSavingDirectoryFolder(string imageDirectoryName, string sourceRootPath, string destinationPath)
        {
            string outPath = string.Empty;
            string[] strs = sourceRootPath.Split('\\');
            int length = strs.Length - 2;
            int len = 0;
            for (int i = 0; i <= length; i++)
            {
                len += strs[i].Length + 1;
            }

            outPath = imageDirectoryName.Substring(len - 1);
            outPath = destinationPath + outPath;
            return outPath;
        }

        /// <summary>
        /// 取得某路径下所有的图片信息
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        private FileInfo[] GetFileInfoArrayByDirectory(DirectoryInfo di)
        {
            List<string> list = GetImageFormats();
            List<FileInfo> fileInfoList = new List<FileInfo>();
            for (int u = 0; u < list.Count; u++)
            {
                FileInfo[] fin = di.GetFiles(list[u], SearchOption.TopDirectoryOnly);
                fileInfoList.AddRange(fin);
            }
            FileInfo[] files = fileInfoList.ToArray();
            return files;
        }

        /// <summary>
        /// 取得所有图片格式
        /// </summary>
        /// <returns></returns>
        private List<string> GetImageFormats()
        {
            List<string> list = new List<string>();
            list.Add("*.jpg");
            list.Add("*.tif");
            list.Add("*.tiff");
            list.Add("*.bmp");
            list.Add("*.png");
            return list;
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textEdit1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textEdit2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textEdit2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void WhiteUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsGenerating)
            {
                e.Cancel = true;
                MessageBox.Show("图片补边正在进行中，不能关闭窗口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WhiteUpForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
        }
    }
}
