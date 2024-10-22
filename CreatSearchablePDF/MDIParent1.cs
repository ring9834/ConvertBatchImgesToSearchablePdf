using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR2ImageOrSearchablePDF
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CreatePdfForm childForm = new CreatePdfForm();
            childForm.MdiParent = this;
            childForm.Text = "双层PDF制作系统";
            childForm.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            WhiteUpForm childForm = new WhiteUpForm();
            childForm.MdiParent = this;
            childForm.Text = "图片补白边系统";
            childForm.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CalculateImageNumber childForm = new CalculateImageNumber();
            childForm.MdiParent = this;
            childForm.Text = "纸张数量（A4）计算系统";
            childForm.Show();
        }
    }
}
