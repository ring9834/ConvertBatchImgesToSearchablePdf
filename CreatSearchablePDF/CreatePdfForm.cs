using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace OCR2ImageOrSearchablePDF
{
    public partial class CreatePdfForm : Form
    {
        private bool IsGenerating { get; set; }
        public CreatePdfForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 2;//默认：生成PDF时原始图片按照名称升序排列
            radioGroup2.SelectedIndex = 2;//默认：把档号的各个组成部分，从前往后顺序拼接创建（存放原始图片的最后一层文件夹名是档号）
            radioGroup4.SelectedIndex = 1;
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

        /// <summary>
        /// 取得所有图片格式
        /// </summary>
        /// <returns></returns>
        private List<string> GetImageFormats()
        {
            List<string> list = new List<string>();
            if (checkEdit1.Checked)
            {
                list.Add("*.jpg");
                list.Add("*.jpeg");
            }
            if (checkEdit2.Checked)
            {
                list.Add("*.tif");
                list.Add("*.tiff");
            }
            if (checkEdit3.Checked)
            {
                list.Add("*.bmp");
            }
            if (checkEdit4.Checked)
            {
                list.Add("*.png");
            }
            return list;
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
        /// 按文件名的升序排序文件信息数组
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private FileInfo[] SortFilesByFileNameAsc(FileInfo[] files)
        {
            Array.Sort(files, new FileNameSort());
            return files;
        }

        /// <summary>
        /// 按文件时间的升序排序文件信息数组
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private FileInfo[] SortFilesByFileLastTimeAsc(FileInfo[] files)
        {
            Array.Sort(files, new FileLastTimeComparerAsc());
            return files;
        }

        /// <summary>
        /// 按文件时间的降序排序文件信息数组
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private FileInfo[] SortFilesByFileLastTimeDesc(FileInfo[] files)
        {
            Array.Sort(files, new FileLastTimeComparerDesc());
            return files;
        }

        /// <summary>
        /// 根据文件名称或时间排序文件信息数组
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private FileInfo[] GetFileInfoArrayByFileNameOrTime(FileInfo[] files)
        {
            FileInfo[] fs = null;
            if (radioGroup1.SelectedIndex == 0)
            {
                fs = SortFilesByFileLastTimeAsc(files);
            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                fs = SortFilesByFileLastTimeDesc(files);
            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                fs = SortFilesByFileNameAsc(files);
            }
            return fs;
        }

        /// <summary>
        /// 按档号的各个组成部分（从前往后）顺序单独创建 输出路径中的文件夹
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="outPath"></param>
        private string CreateDirectoryFolderByEachOfArchiveNoPartsFromFontToEnd(FileInfo fi, string destinationPath)
        {
            string outPath = destinationPath;
            string directory = fi.DirectoryName;
            string dh = directory.Substring(directory.LastIndexOf("\\") + 1);
            string[] fs = dh.Split('-');
            for (int s = 0; s < fs.Length; s++)
                outPath += "\\" + fs[s];
            if (!Directory.Exists(outPath))
                Directory.CreateDirectory(outPath);
            return outPath;
        }

        /// <summary>
        /// 把档号的各个组成部分（从前往后）顺序,每层增加一个档号组成部分，拼接创建输出路径中的文件夹
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="outPath"></param>
        private string CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEnd(FileInfo fi, string destinationPath)
        {
            string outPath = "";
            string str = "";
            string directory = fi.DirectoryName;
            string dh = directory.Substring(directory.LastIndexOf("\\") + 1);
            string[] fs = dh.Split('-');
            for (int s = 0; s < fs.Length; s++)
            {
                if (s == 0)
                {
                    str += fs[s];
                }
                else
                {
                    str += "-" + fs[s];
                }
                outPath += "\\" + str;
            }
            outPath = destinationPath + outPath;
            if (!Directory.Exists(outPath))
                Directory.CreateDirectory(outPath);
            return outPath;
        }

        /// <summary>
        /// 件号那层文件夹不创建 其余按档号组成从前往后拼接创建（存放原始图片的最后一层文件夹名是档号）
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="outPath"></param>
        private string CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEndWithTheLastPartIgnored(FileInfo fi, string destinationPath)
        {
            string outPath = "";
            string str = "";
            string directory = fi.DirectoryName;
            string dh = directory.Substring(directory.LastIndexOf("\\") + 1);
            string[] fs = dh.Split('-');
            for (int s = 0; s < fs.Length - 1; s++)
            {
                if (s == 0)
                {
                    str += fs[s];
                }
                else
                {
                    str += "-" + fs[s];
                }
                outPath += "\\" + str;
            }
            outPath = destinationPath + outPath;
            if (!Directory.Exists(outPath))
                Directory.CreateDirectory(outPath);
            return outPath;
        }

        /// <summary>
        /// 件号那层文件夹用“PDF”代替 其余按档号组成从前往后拼接创建（存放原始图片的最后一层文件夹名件号，倒数第二层文件夹名称是档案号除去件号）
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="outPath"></param>
        private string CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEndWithTheLastPartSubstitutedByPDF(FileInfo fi, string destinationPath)
        {
            string outPath = "";
            //string str = "";
            string parentDirectory = fi.Directory.Parent.FullName;
            //string directory = fi.DirectoryName;
            string dh = parentDirectory.Substring(parentDirectory.LastIndexOf("\\") + 1);
            //string jh = directory.Substring(directory.LastIndexOf("\\") + 1);
            //string[] fs = dh.Split('-');
            //for (int s = 0; s < fs.Length - 1; s++)
            //{
            //    if (s == 0)
            //    {
            //        str += fs[s];
            //    }
            //    else
            //    {
            //        str += "-" + fs[s];
            //    }
            //    outPath += "\\" + str;
            //}
            outPath = destinationPath + dh;
            if (!Directory.Exists(outPath))
                Directory.CreateDirectory(outPath);
            return outPath;
        }

        /// <summary>
        /// 创建盛放PDF的路径
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        private string CreateDirectorySavingPdf(FileInfo fi, string destinationPath)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                return CreateDirectoryFolderByEachOfArchiveNoPartsFromFontToEnd(fi, destinationPath);
            }
            else if (radioGroup2.SelectedIndex == 1)
            {
                return CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEnd(fi, destinationPath);
            }
            else if (radioGroup2.SelectedIndex == 2)
            {
                return CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEndWithTheLastPartIgnored(fi, destinationPath);
            }
            else if (radioGroup2.SelectedIndex == 3)
            {
                return destinationPath;
            }
            else if (radioGroup2.SelectedIndex == 4)
            {
                return CreateDirectoryFolderThroughContactingArchiveNoPartByAddingOnePartEachTimeFromFontToEndWithTheLastPartSubstitutedByPDF(fi, destinationPath);
            }
            return string.Empty;
        }

        private string GetMergedPdfFileName(FileInfo fi)
        {
            string dh = "";
            if (radioGroup3.SelectedIndex == 0)
            {
                string directory = fi.DirectoryName;
                dh = directory.Substring(directory.LastIndexOf("\\") + 1);
            }
            else if (radioGroup3.SelectedIndex == 1)
            {
                dh = fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension));
            }
            return dh;
        }

        /// <summary>
        /// 生成双层PDF
        /// </summary>
        /// <param name="strTesseractPath">引擎</param>
        /// <param name="language">语言</param>
        /// <param name="sourcePath">图片文件夹</param>
        /// <param name="destanationPath">目标文件夹</param>
        private void GeneratePDFFileFromImage(string strTesseractPath, string language, string sourcePath, string destinationPath)
        {
            this.IsGenerating = true;//标识正在执行状态
            DirectoryInfo di = new DirectoryInfo(sourcePath);
            DirectoryInfo[] diA = di.GetDirectories();
            for (int i = 0; i < diA.Length; i++)
            {
                GeneratePDFFileFromImage(strTesseractPath, language, diA[i].FullName, destinationPath);
            }

            FileInfo[] filesFromDirectory = GetFileInfoArrayByDirectory(di);//获得文件信息列表
            FileInfo[] files = GetFileInfoArrayByFileNameOrTime(filesFromDirectory);//对文件列表进行指定规则的排序

            string outPath = "";
            string dh = "";
            string tempOutPath = "";//当radioGroup2.SelectedIndex == 3时临时使用
            //生成的PDF使用原始图片自己的名称时
            if (radioGroup3.SelectedIndex == 0)
            {
                if (files.Length > 0)
                {
                    for (int j = 0; j < files.Length; j++)
                    {
                        FileInfo fi = files[j];
                        string strSourceImg = fi.FullName;
                        string extention = fi.Extension;
                        string directory = fi.DirectoryName;
                        dh = directory.Substring(directory.LastIndexOf("\\") + 1);
                        outPath = CreateDirectorySavingPdf(fi, destinationPath);//创建盛放PDF的目录

                        ShowDynamicTextInRichText("正在生成：" + fi.FullName + " 对应的PDF文件...\r\n");

                        string fileNameWithoutExtention = fi.Name.Substring(0, fi.Name.IndexOf(extention));
                        string strOutputPath = outPath + "\\" + fileNameWithoutExtention;
                        if (radioGroup2.SelectedIndex == 2 || radioGroup2.SelectedIndex == 3 || radioGroup2.SelectedIndex == 4)
                        {
                            if (string.IsNullOrEmpty(tempOutPath))//在同一个文件夹下（同一件）的原始图片生成的PDF，使用同一个临时文件
                                tempOutPath = outPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");//创建保存合成前的众多PDF的临时文件夹，合成后再删除
                            if (!Directory.Exists(tempOutPath))
                                Directory.CreateDirectory(tempOutPath);
                            strOutputPath = tempOutPath + "\\" + fileNameWithoutExtention;
                        }

                        try
                        {
                            if (singleOrSearchableRdioGroup.SelectedIndex == 0)
                                PdfHelper.fnOCR(strTesseractPath, strSourceImg, strOutputPath, language);//OCR识别并生成双层PDF
                            else
                                PdfHelper.ImageToSingleTierPDF(strSourceImg, strOutputPath + ".pdf");//生成单层PDF
                        }
                        catch
                        {
                            ShowExptionTextInRichText(strSourceImg + " 生成PDF时有错误...\r\n");//图片读取有异常时
                        }
                        //Application.DoEvents();
                    }

                    //合并多个图片对应的PDF为一个PDF文件
                    DirectoryInfo pdfDirectory = new DirectoryInfo(outPath);
                    if (radioGroup2.SelectedIndex == 2 || radioGroup2.SelectedIndex == 3 || radioGroup2.SelectedIndex == 4)
                        pdfDirectory = new DirectoryInfo(tempOutPath);

                    FileInfo[] pdfs = pdfDirectory.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
                    if (pdfs.Length > 0)
                    {
                        string pdfName = outPath + "\\" + dh + ".pdf";
                        if (File.Exists(pdfName))//如果已经存在同名的PDF文件，则先删除,否则会有占用异常
                        {
                            List<FileInfo> flist = pdfs.ToList();
                            FileInfo file = flist.SingleOrDefault(f => f.Name.Contains(dh));
                            if (file != null)
                            {
                                flist.Remove(file);
                                pdfs = flist.ToArray();
                            }
                            File.Delete(pdfName);
                        }

                        if (radioGroup4.SelectedIndex == 1)//每件档案生成一个PDF时
                        {
                            string exception = string.Empty;
                            PdfHelper.MergePdfFiles(pdfs, pdfName, out exception);//执行合并
                            if (string.IsNullOrEmpty(exception))
                            {
                                ShowDynamicTextInRichText("已合并为：" + pdfName + "\r\n");
                            }
                            else
                            {
                                ShowExptionTextInRichText(dh + " 生成PDF时有错误...\r\n");//图片读取有异常时
                                exception = string.Empty;
                                return;//发生异常，就跳出本次PDF合并，继续之后的PDF合并
                            }

                            //删除单独图片对应的PDF文件
                            for (int de = 0; de < pdfs.Length; de++)
                                File.Delete(pdfs[de].FullName);
                            if (radioGroup2.SelectedIndex == 2 || radioGroup2.SelectedIndex == 3 || radioGroup2.SelectedIndex == 4)//合成后删除之前临时创建的文件夹
                            {
                                if (Directory.Exists(tempOutPath))
                                {
                                    try
                                    {
                                        Directory.Delete(tempOutPath);
                                    }
                                    catch { }
                                }
                                tempOutPath = "";//别的档案件内的原始图片生成的PDF，不能使用别的件创建的临时文件夹
                            }
                        }
                    }
                }
            }
            else if (radioGroup3.SelectedIndex == 0)
            {

            }
        }

        private void ShowDynamicTextInRichText(string content)
        {
            Action act = delegate ()
            {
                richTextBox1.Text += content;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            };
            this.Invoke(act);
        }

        private void ShowExptionTextInRichText(string content)
        {
            Action act = delegate ()
            {
                richTextBox2.Text += content;
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
            };
            this.Invoke(act);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string strTesseractPath =@"Tesseract-OCR\tesseract.exe";
            //string strSourceImgPath = @"D:\SOFTHAVESETUP\WorkSpace\CreatFilesInGroup\SorceImages\aa.jpg";
            //string strOutputPath = @"D:\SOFTHAVESETUP\WorkSpace\CreatFilesInGroup\OutFiles\2";
            ////string strOutputPath = "abc";
            //string lang = "chi_sim pdf";
            //fnOCR(strTesseractPath, strSourceImgPath, strOutputPath, lang);
            //MessageBox.Show("成功！");
            if (this.IsGenerating)
            {
                MessageBox.Show("正在生成PDF中...请稍后！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("请选择要生成PDF文件的图片源路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                MessageBox.Show("请选择要存放PDF文件的目标路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkEdit1.Checked && !checkEdit2.Checked && !checkEdit3.Checked && !checkEdit4.Checked)
            {
                MessageBox.Show("请至少选取一种图片的格式！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioGroup3.SelectedIndex == 1 && radioGroup2.SelectedIndex != 3)
            {
                MessageBox.Show("“PDF文件命名的参考来源”选第2项时，\r\n “输出路径中需要动态创建的文件夹的创建规则”中请选第4项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strTesseractPath = @"Tesseract-OCR\tesseract.exe";
            string lang = "chi_sim pdf";
            //GeneratePDFFileFromImage(strTesseractPath, lang, textEdit1.Text, textEdit2.Text);
            //异步调用 交给一个线程去处理PDF生成任务
            PdfCreateTaskDelegate pdfTask = new PdfCreateTaskDelegate(GeneratePDFFileFromImage);
            pdfTask.BeginInvoke(strTesseractPath, lang, textEdit1.Text, textEdit2.Text, new AsyncCallback(PdfCreateCallBack), null);

            //richTextBox1.Text += "任务完成！\r\n";
            //this.IsGenerating = false;
        }

        private delegate void PdfCreateTaskDelegate(string strTesseractPath, string lang, string imgeFolder, string pdfFolder);

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="result"></param>
        void PdfCreateCallBack(IAsyncResult result)
        {
            PdfCreateTaskDelegate gdk = (PdfCreateTaskDelegate)((AsyncResult)result).AsyncDelegate;
            gdk.EndInvoke(result);
            this.IsGenerating = false;
            ShowDynamicTextInRichText("PDF生成任务完成！" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "\r\n");
        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup4.SelectedIndex == 0)
            {
                groupControl3.Enabled = false;
                groupControl5.Enabled = false;
            }
            else
            {
                groupControl3.Enabled = true;
                groupControl5.Enabled = true;
            }
        }

        private void CreatePdfForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsGenerating)
            {
                e.Cancel = true;
                MessageBox.Show("PDF正在生成中，不能关闭窗口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox2.Text);
            MessageBox.Show(this, "已将数据拷贝到粘贴板，请粘贴到文本文件、word或excel文件中！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class FileNameSort : IComparer
    {
        //调用DLL
        [System.Runtime.InteropServices.DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string param1, string param2);

        //前后文件名进行比较。
        public int Compare(object name1, object name2)
        {
            if (null == name1 && null == name2)
            {
                return 0;
            }
            if (null == name1)
            {
                return -1;
            }
            if (null == name2)
            {
                return 1;
            }
            return StrCmpLogicalW(name1.ToString(), name2.ToString());
        }
    }

    public class FileLastTimeComparerAsc : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.LastWriteTime.CompareTo(x.LastWriteTime);//递减
            //return x.LastWriteTime.CompareTo(y.LastWriteTime);//递增
        }
    }

    public class FileLastTimeComparerDesc : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            //return y.LastWriteTime.CompareTo(x.LastWriteTime);//递减
            return x.LastWriteTime.CompareTo(y.LastWriteTime);//递增
        }
    }
}
