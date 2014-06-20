namespace KmzExtractor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.convertBtn = new System.Windows.Forms.Button();
            this.fileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileOpenTextBox = new System.Windows.Forms.TextBox();
            this.fileOpenBtn = new System.Windows.Forms.Button();
            this.fileSaveTextBox = new System.Windows.Forms.TextBox();
            this.fileSaveBtn = new System.Windows.Forms.Button();
            this.msgRichTextBox = new System.Windows.Forms.RichTextBox();
            this.fileSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.convertDirCheckBox = new System.Windows.Forms.CheckBox();
            this.mergeAllCheckBox = new System.Windows.Forms.CheckBox();
            this.folderOpenDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.folderSaveDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // convertBtn
            // 
            this.convertBtn.Location = new System.Drawing.Point(237, 279);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 0;
            this.convertBtn.Text = "开始转换";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // fileOpenDialog
            // 
            this.fileOpenDialog.Filter = "KMZ文件|*.kmz|所有文件|*.*";
            this.fileOpenDialog.SupportMultiDottedExtensions = true;
            // 
            // fileOpenTextBox
            // 
            this.fileOpenTextBox.Location = new System.Drawing.Point(12, 56);
            this.fileOpenTextBox.Name = "fileOpenTextBox";
            this.fileOpenTextBox.Size = new System.Drawing.Size(396, 21);
            this.fileOpenTextBox.TabIndex = 1;
            // 
            // fileOpenBtn
            // 
            this.fileOpenBtn.Location = new System.Drawing.Point(432, 54);
            this.fileOpenBtn.Name = "fileOpenBtn";
            this.fileOpenBtn.Size = new System.Drawing.Size(105, 23);
            this.fileOpenBtn.TabIndex = 2;
            this.fileOpenBtn.Text = "选择文件";
            this.fileOpenBtn.UseVisualStyleBackColor = true;
            this.fileOpenBtn.Click += new System.EventHandler(this.fileOpenBtn_Click);
            // 
            // fileSaveTextBox
            // 
            this.fileSaveTextBox.Location = new System.Drawing.Point(12, 104);
            this.fileSaveTextBox.Name = "fileSaveTextBox";
            this.fileSaveTextBox.Size = new System.Drawing.Size(396, 21);
            this.fileSaveTextBox.TabIndex = 1;
            // 
            // fileSaveBtn
            // 
            this.fileSaveBtn.Location = new System.Drawing.Point(432, 102);
            this.fileSaveBtn.Name = "fileSaveBtn";
            this.fileSaveBtn.Size = new System.Drawing.Size(105, 23);
            this.fileSaveBtn.TabIndex = 2;
            this.fileSaveBtn.Text = "保存文件";
            this.fileSaveBtn.UseVisualStyleBackColor = true;
            this.fileSaveBtn.Click += new System.EventHandler(this.fileSaveBtn_Click);
            // 
            // msgRichTextBox
            // 
            this.msgRichTextBox.Location = new System.Drawing.Point(12, 151);
            this.msgRichTextBox.Name = "msgRichTextBox";
            this.msgRichTextBox.ReadOnly = true;
            this.msgRichTextBox.Size = new System.Drawing.Size(525, 106);
            this.msgRichTextBox.TabIndex = 3;
            this.msgRichTextBox.Text = "";
            // 
            // fileSaveDialog
            // 
            this.fileSaveDialog.Filter = "csv|*.csv";
            // 
            // convertDirCheckBox
            // 
            this.convertDirCheckBox.AutoSize = true;
            this.convertDirCheckBox.Location = new System.Drawing.Point(13, 27);
            this.convertDirCheckBox.Name = "convertDirCheckBox";
            this.convertDirCheckBox.Size = new System.Drawing.Size(132, 16);
            this.convertDirCheckBox.TabIndex = 4;
            this.convertDirCheckBox.Text = "转换目录下所有文件";
            this.convertDirCheckBox.UseVisualStyleBackColor = true;
            this.convertDirCheckBox.CheckedChanged += new System.EventHandler(this.convertDirCheckBox_CheckedChanged_1);
            // 
            // mergeAllCheckBox
            // 
            this.mergeAllCheckBox.AutoSize = true;
            this.mergeAllCheckBox.Checked = true;
            this.mergeAllCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mergeAllCheckBox.Location = new System.Drawing.Point(156, 27);
            this.mergeAllCheckBox.Name = "mergeAllCheckBox";
            this.mergeAllCheckBox.Size = new System.Drawing.Size(120, 16);
            this.mergeAllCheckBox.TabIndex = 5;
            this.mergeAllCheckBox.Text = "合并所有输出文件";
            this.mergeAllCheckBox.UseVisualStyleBackColor = true;
            this.mergeAllCheckBox.CheckedChanged += new System.EventHandler(this.mergeAllCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(549, 314);
            this.Controls.Add(this.mergeAllCheckBox);
            this.Controls.Add(this.convertDirCheckBox);
            this.Controls.Add(this.msgRichTextBox);
            this.Controls.Add(this.fileSaveBtn);
            this.Controls.Add(this.fileOpenBtn);
            this.Controls.Add(this.fileSaveTextBox);
            this.Controls.Add(this.fileOpenTextBox);
            this.Controls.Add(this.convertBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "KmzExtractor-By MindMac";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.OpenFileDialog fileOpenDialog;
        private System.Windows.Forms.TextBox fileOpenTextBox;
        private System.Windows.Forms.Button fileOpenBtn;
        private System.Windows.Forms.TextBox fileSaveTextBox;
        private System.Windows.Forms.Button fileSaveBtn;
        private System.Windows.Forms.RichTextBox msgRichTextBox;
        private System.Windows.Forms.SaveFileDialog fileSaveDialog;
        private System.Windows.Forms.CheckBox convertDirCheckBox;
        private System.Windows.Forms.CheckBox mergeAllCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog folderSaveDialog;
    }
}

