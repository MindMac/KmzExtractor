using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace KmzExtractor
{
   
    public partial class MainForm : Form
    {
        
        public static String kmzDirPath = null;
        public static String csvDirPath = null;
        public static ArrayList kmzFilePathList = new ArrayList();
        public static ArrayList csvFilePathList = new ArrayList();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {

        }


        public void doConvert()
        {
            msgRichTextBox.Text = "";

            msgRichTextBox.AppendText(Util.HARD_WORKING_MSG + Environment.NewLine + Environment.NewLine);

            if (convertDirCheckBox.Checked && !mergeAllCheckBox.Checked)
            {
                foreach (String kmzFilePath in kmzFilePathList)
                {
                    msgRichTextBox.AppendText(Util.CONVERTING_MSG + " " + kmzFilePath + Environment.NewLine);
                    String csvFilePath = kmzFilePath.Replace(Path.VolumeSeparatorChar, '-');
                    csvFilePath = csvFilePath.Replace(Path.DirectorySeparatorChar, '-');
                    csvFilePath = String.Format("{0}\\{1}.csv", csvDirPath, csvFilePath);
                    msgRichTextBox.AppendText(csvFilePath + Environment.NewLine);
                    Util.startConvert(kmzFilePath, csvFilePath, FileMode.Create);
                }
                
            }else 
            {
                foreach (String kmzFilePath in kmzFilePathList)
                {
                    msgRichTextBox.AppendText(Util.CONVERTING_MSG + " " + kmzFilePath + Environment.NewLine);
                    Util.startConvert(kmzFilePath, (String)csvFilePathList[0], FileMode.Append);
                }
            }

            msgRichTextBox.AppendText(Environment.NewLine);
            msgRichTextBox.AppendText(Util.SUCCESS_MSG + Environment.NewLine);
            MessageBox.Show(Util.SUCCESS_MSG, "Kmz2Excel-By MindMac");

        }


        private void getFiles(DirectoryInfo rootDirectoryInfo, ArrayList fileList)
        {
            FileInfo[] fileInfos = null;
            DirectoryInfo[] subDirectoryInfos = null;

            try
            {
                fileInfos = rootDirectoryInfo.GetFiles("*.kmz");
            }
            catch (UnauthorizedAccessException e)
            {
                String msg = e.Message;
                Util.setRichTextBoxColor(msg, msgRichTextBox);

            }

            catch (DirectoryNotFoundException e)
            {
                String msg = e.Message;
                Util.setRichTextBoxColor(msg, msgRichTextBox);
            }

            if (fileInfos != null)
            {
                foreach (FileInfo fileInfo in fileInfos)
                    fileList.Add(fileInfo.FullName);
            }

            subDirectoryInfos = rootDirectoryInfo.GetDirectories();
            foreach(DirectoryInfo subDirectoryInfo in subDirectoryInfos)
            {
                getFiles(subDirectoryInfo, fileList);
            }

        }

        private void openFile()
        {
            DialogResult fileOpenDiaglogResult = fileOpenDialog.ShowDialog();
            if (fileOpenDiaglogResult == DialogResult.OK)
            {
                String kmzFilePath = fileOpenDialog.FileName;
                if (kmzFilePath != null)
                {
                    String fileExtension = Path.GetExtension(kmzFilePath);
                    if (fileExtension != null)
                    {
                        fileExtension = fileExtension.ToLower();
                        if (fileExtension.Equals(Util.KMZ_EXTENSION, StringComparison.InvariantCultureIgnoreCase))
                        {
                            fileOpenTextBox.Text = kmzFilePath;
                            kmzFilePathList.Clear();
                            kmzFilePathList.Add(kmzFilePath);
                        }
                        else
                        {
                            MessageBox.Show(Util.INVALID_KMZ_FILE_ERROR, Util.KMZ_FILE_TITLE);
                        }
                    }

                }
            }  
        }

        private void openDirectory()
        {
            DialogResult dirOpenDiaglogResult = folderOpenDialog.ShowDialog();
            if (dirOpenDiaglogResult == DialogResult.OK)
            {
                String dirPath = folderOpenDialog.SelectedPath;
                if (dirPath != null && dirPath != String.Empty)
                {
                    kmzDirPath = dirPath;
                    fileOpenTextBox.Text = kmzDirPath;
                    DirectoryInfo rootDirectoryInfo = new DirectoryInfo(dirPath);
                    kmzFilePathList.Clear();
                    getFiles(rootDirectoryInfo, kmzFilePathList);
                }
                   
            }
        }


        private void saveFile()
        {
            DialogResult fileSaveDiaglogResult = fileSaveDialog.ShowDialog();
            if (fileSaveDiaglogResult == DialogResult.OK)
            {
                String csvFilePath = fileSaveDialog.FileName;
                if (csvFilePath != null)
                {
                    String fileExtension = Path.GetExtension(csvFilePath);
                    if (csvFilePath != null)
                    {
                        fileExtension = fileExtension.ToLower();
                        if (fileExtension.Equals(Util.CSV_EXTENSION, StringComparison.InvariantCultureIgnoreCase))
                        {
                            fileSaveTextBox.Text = csvFilePath;
                            csvFilePathList.Clear();
                            csvFilePathList.Add(csvFilePath);
                        }
                        else
                        {
                            MessageBox.Show(Util.INVALID_EXCEL_FILE_ERROR, Util.EXCEL_FILE_TITLE);
                        }
                    }
                }

            }
        }

        private void saveDirectory()
        {
            DialogResult dirSaveDiaglogResult = folderSaveDialog.ShowDialog();
            if (dirSaveDiaglogResult == DialogResult.OK)
            {
                String dirPath = folderSaveDialog.SelectedPath;
                if (dirPath != null && dirPath != String.Empty)
                {
                    fileSaveTextBox.Text = dirPath;
                    csvDirPath = dirPath;
                }
                    
            }
        }

        private void fileOpenBtn_Click(object sender, EventArgs e)
        {
            if (convertDirCheckBox.Checked)
                openDirectory();
            else
                openFile();
        }

        private void fileSaveBtn_Click(object sender, EventArgs e)
        {
            if (convertDirCheckBox.Checked && !mergeAllCheckBox.Checked)
                saveDirectory();
            else
                saveFile();
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            convertBtn.Enabled = false;

            bool hasWrong = false;

            if (convertDirCheckBox.Checked)
            {
                if (kmzDirPath == null)
                {
                    hasWrong = true;
                    MessageBox.Show(Util.KMZ_NOT_SELECTED, Util.KMZ_FILE_TITLE);
                }

            }
            else
            {
                if (kmzFilePathList.Count == 0)
                {
                    MessageBox.Show(Util.KMZ_NOT_SELECTED, Util.KMZ_FILE_TITLE);
                    hasWrong = true;
                }
                   
            }
      
            if (csvFilePathList.Count == 0)
            {
                MessageBox.Show(Util.EXCEL_NOT_SELECTED, Util.EXCEL_FILE_TITLE);
                hasWrong = true;
            } 
            

            if (!hasWrong)
                doConvert();

            convertBtn.Enabled = true;
        }

        private void mergeAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void convertDirCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
