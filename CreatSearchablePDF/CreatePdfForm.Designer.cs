namespace OCR2ImageOrSearchablePDF
{
    partial class CreatePdfForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePdfForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup2 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup3 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup4 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.singleOrSearchableGroup = new DevExpress.XtraEditors.GroupControl();
            this.singleOrSearchableRdioGroup = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleOrSearchableGroup)).BeginInit();
            this.singleOrSearchableGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleOrSearchableRdioGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(602, 32);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(677, 298);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(14, 37);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(2);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.NullValuePrompt = "请选择要生成PDF文件的图片文件所在路径...";
            this.textEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit1.Size = new System.Drawing.Size(564, 20);
            this.textEdit1.TabIndex = 2;
            this.textEdit1.Click += new System.EventHandler(this.textEdit1_Click);
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(14, 64);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(2);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.NullValuePrompt = "请指定PDF文件存放的目标文件夹...";
            this.textEdit2.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit2.Size = new System.Drawing.Size(564, 20);
            this.textEdit2.TabIndex = 3;
            this.textEdit2.Click += new System.EventHandler(this.textEdit2_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.textEdit2);
            this.groupControl1.Location = new System.Drawing.Point(12, 88);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(583, 100);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "位置选择";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.checkEdit4);
            this.groupControl2.Controls.Add(this.checkEdit3);
            this.groupControl2.Controls.Add(this.checkEdit2);
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Location = new System.Drawing.Point(12, 194);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(583, 66);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "图片种类选择";
            // 
            // checkEdit4
            // 
            this.checkEdit4.Location = new System.Drawing.Point(166, 33);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Caption = "PNG";
            this.checkEdit4.Size = new System.Drawing.Size(56, 19);
            this.checkEdit4.TabIndex = 3;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(114, 33);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Caption = "BMP";
            this.checkEdit3.Size = new System.Drawing.Size(56, 19);
            this.checkEdit3.TabIndex = 2;
            // 
            // checkEdit2
            // 
            this.checkEdit2.EditValue = true;
            this.checkEdit2.Location = new System.Drawing.Point(63, 33);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "TIFF";
            this.checkEdit2.Size = new System.Drawing.Size(56, 19);
            this.checkEdit2.TabIndex = 1;
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(14, 33);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "JPG";
            this.checkEdit1.Size = new System.Drawing.Size(56, 19);
            this.checkEdit1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.radioGroup1);
            this.groupControl3.Location = new System.Drawing.Point(12, 338);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(583, 109);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "生成PDF内页的排序规则";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(14, 28);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "按照原始图片文件的日期升序"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "按照原始图片文件的日期降序"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "按照原始图片文件名称的升序")});
            this.radioGroup1.Size = new System.Drawing.Size(564, 71);
            this.radioGroup1.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.radioGroup2);
            this.groupControl4.Location = new System.Drawing.Point(12, 454);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(583, 159);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "输出路径中需要动态创建的文件夹的创建规则";
            // 
            // radioGroup2
            // 
            this.radioGroup2.Location = new System.Drawing.Point(14, 28);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "按档号的各个组成部分，从前往后顺序单独创建（存放原始图片的最后一层文件夹名是档号）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "把档号的各个组成部分，从前往后顺序拼接创建（存放原始图片的最后一层文件夹名是档号）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "件号那层文件夹不创建 其余按档号组成从前往后拼接创建（存放原始图片的最后一层文件夹名是档号）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定的路径下直接生成所有的PDF，而无需创建其它文件夹（存放原始图片的最后一层文件夹名是档号）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "盛放PDF的文件夹名称由原始图片路径的第二层至倒数第二层文件夹名称组成")});
            this.radioGroup2.Size = new System.Drawing.Size(564, 121);
            this.radioGroup2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(602, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "生成状态：";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.radioGroup3);
            this.groupControl5.Location = new System.Drawing.Point(12, 622);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(583, 100);
            this.groupControl5.TabIndex = 9;
            this.groupControl5.Text = "PDF文件命名的参考来源";
            // 
            // radioGroup3
            // 
            this.radioGroup3.Location = new System.Drawing.Point(14, 26);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "存放原始图片的最后一层文件夹名（此文件夹名是档号时选此项）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "图片文件自己的名称（不包含文件扩展名；此图片文件名对应一个唯一档号时选此项）"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "存放原始图片的最后一层文件夹名（此文件夹名是档号时选此项）")});
            this.radioGroup3.Size = new System.Drawing.Size(564, 69);
            this.radioGroup3.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(226, 736);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(107, 23);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "执行PDF生成";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.radioGroup4);
            this.groupControl7.Location = new System.Drawing.Point(12, 266);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(583, 66);
            this.groupControl7.TabIndex = 12;
            this.groupControl7.Text = "PDF在档案件中的生成方式";
            // 
            // radioGroup4
            // 
            this.radioGroup4.Location = new System.Drawing.Point(15, 24);
            this.radioGroup4.Name = "radioGroup4";
            this.radioGroup4.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "每件档案中每张图片单独生成PDF"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "每件档案生成一个PDF文件")});
            this.radioGroup4.Size = new System.Drawing.Size(563, 36);
            this.radioGroup4.TabIndex = 0;
            this.radioGroup4.SelectedIndexChanged += new System.EventHandler(this.radioGroup4_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(602, 359);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "生成PDF的错误信息：";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(602, 378);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(677, 344);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(869, 350);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(107, 23);
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "导出错误信息";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // singleOrSearchableGroup
            // 
            this.singleOrSearchableGroup.Controls.Add(this.singleOrSearchableRdioGroup);
            this.singleOrSearchableGroup.Location = new System.Drawing.Point(13, 12);
            this.singleOrSearchableGroup.Name = "singleOrSearchableGroup";
            this.singleOrSearchableGroup.Size = new System.Drawing.Size(583, 66);
            this.singleOrSearchableGroup.TabIndex = 13;
            this.singleOrSearchableGroup.Text = "单层还是双层PDF";
            // 
            // singleOrSearchableRdioGroup
            // 
            this.singleOrSearchableRdioGroup.Location = new System.Drawing.Point(14, 24);
            this.singleOrSearchableRdioGroup.Name = "singleOrSearchableRdioGroup";
            this.singleOrSearchableRdioGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "双层PDF"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "单层PDF")});
            this.singleOrSearchableRdioGroup.Size = new System.Drawing.Size(563, 36);
            this.singleOrSearchableRdioGroup.TabIndex = 0;
            // 
            // CreatePdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 771);
            this.Controls.Add(this.singleOrSearchableGroup);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreatePdfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "山东高第数据-双层PDF文件生成系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreatePdfForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleOrSearchableGroup)).EndInit();
            this.singleOrSearchableGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.singleOrSearchableRdioGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.RadioGroup radioGroup2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.RadioGroup radioGroup3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraEditors.RadioGroup radioGroup4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.GroupControl singleOrSearchableGroup;
        private DevExpress.XtraEditors.RadioGroup singleOrSearchableRdioGroup;
    }
}

