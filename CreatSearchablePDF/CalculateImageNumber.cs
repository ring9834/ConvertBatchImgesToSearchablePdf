using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR2ImageOrSearchablePDF
{
    public partial class CalculateImageNumber : Form
    {
        public CalculateImageNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(this, "请选择要检测的路径！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.button2.Enabled = false;
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            //textBox7.Text = "0";
            GetPDFFilesDirectory(textBox1.Text);
            this.button2.Enabled = true;
        }

        private void GetPDFFilesDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diA = di.GetDirectories();

            FileInfo[] fiA0 = di.GetFiles("*.JPG");
            FileInfo[] fiA1 = di.GetFiles("*.JPEG");
            FileInfo[] fiA2 = di.GetFiles("*.TIFF");
            FileInfo[] fiA3 = di.GetFiles("*.BMP");
            FileInfo[] fiA = fiA0.Concat(fiA1).Concat(fiA2).Concat(fiA3).ToArray();

            string deta = ConfigurationManager.AppSettings["DETA"];//误差率
            float banlanceDeta = float.Parse(deta);
            for (int j = 0; j < fiA.Length; j++)
            {
                string name1 = fiA[j].FullName;
                try
                {
                    Stream s = File.Open(name1, FileMode.Open);
                    Image bmp = Image.FromStream(s);

                    string pageType = WhiteUpLogic.VerifyIfUseA4orA3orA2orA1orA0(bmp.Width, bmp.Height, bmp.HorizontalResolution, bmp.VerticalResolution, banlanceDeta);
                    bmp.Dispose();
                    s.Close();

                    if (pageType.Equals("A4"))
                    {
                        int number = int.Parse(textBox2.Text);
                        number = number + 1;
                        textBox2.Text = number.ToString();
                    }
                    if (pageType.Equals("A3"))
                    {
                        int number = int.Parse(textBox3.Text);
                        number = number + 1;
                        textBox3.Text = number.ToString();
                    }
                    if (pageType.Equals("A2"))
                    {
                        int number = int.Parse(textBox4.Text);
                        number = number + 1;
                        textBox4.Text = number.ToString();
                    }
                    if (pageType.Equals("A1"))
                    {
                        int number = int.Parse(textBox5.Text);
                        number = number + 1;
                        textBox5.Text = number.ToString();
                    }
                    if (pageType.Equals("A0"))
                    {
                        int number = int.Parse(textBox6.Text);
                        number = number + 1;
                        textBox6.Text = number.ToString();
                    }
                    //if (pageType.Equals("AMAX"))
                    //{
                    //    int number = int.Parse(textBox7.Text);
                    //    number = number + 1;
                    //    textBox7.Text = number.ToString();
                    //    textBox8.Text += name1 + "\r\n";
                    //}
                    textBox8.Text = (int.Parse(textBox2.Text) + int.Parse(textBox3.Text) * 2 + int.Parse(textBox4.Text) * 4 + int.Parse(textBox5.Text) * 8 + int.Parse(textBox6.Text) * 16).ToString();
                    textBox7.Text = (int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)).ToString();
                    Application.DoEvents();
                }
                catch
                {
                }
            }

            for (int i = 0; i < diA.Length; i++)
            {
                if (!diA[i].Name.Contains("扫描"))
                {
                    GetPDFFilesDirectory(diA[i].FullName);
                }
            }
        }
    }
}
