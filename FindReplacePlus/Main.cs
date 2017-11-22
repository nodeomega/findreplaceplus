using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FindReplacePlus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            fileSearchPatternTextBox.Text = @"*.aspx|*.html|*.htm|*.css|*.scss|*.less|*.ascx|*.cshtml|*.php";
        }

        public void ChooseFolder()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                baseFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void changeBaseFolderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(baseFolderTextBox.Text))
            {
                matchingFilesCheckedListBox.Items.Clear();
                return;
            }
            ChooseFolder();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            matchingFilesCheckedListBox.Items.Clear();
            IEnumerable<string> test = GetFileList(fileSearchPatternTextBox.Text, baseFolderTextBox.Text, findTextBox.Text);
            
            foreach (string s in test)
            {
                matchingFilesCheckedListBox.Items.Add(s, CheckState.Checked);
            }
        }

        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath, string findPattern)
        {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            while (pending.Count > 0 && !string.IsNullOrWhiteSpace(rootFolderPath))
            {
                rootFolderPath = pending.Dequeue();
                List<string> tmp = new List<string>();
                try
                {
                    string[] patterns = fileSearchPattern.Split('|');
                    foreach (string pattern in patterns)
                    {
                        tmp.AddRange(Directory.GetFiles(rootFolderPath, pattern));
                    }
                    //tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                foreach (string t in tmp)
                {
                    string text = File.ReadAllText(t);
                    if (text.Contains(findPattern))
                    {
                        yield return t;
                    }
                }
                tmp = Directory.GetDirectories(rootFolderPath).ToList();
                foreach (string t in tmp)
                {
                    pending.Enqueue(t);
                }
            }
        }

        public int ReplaceAllInFiles(List<string> fileList, string find, string replace)
        {
            int filesChanged = 0;
            foreach (string s in fileList)
            {
                if (!File.Exists(s)) continue;
                try
                {
                    string text = File.ReadAllText(s);
                    text = text.Replace(find, replace);
                    File.WriteAllText(s, text);
                    filesChanged++;
                }
                catch
                {
                    //ignore for now
                }
            }
            return filesChanged;
        }


        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            List<string> filesToChange = (from object o in matchingFilesCheckedListBox.CheckedItems select o.ToString()).ToList();
            resultLabel.Text = $@"{ReplaceAllInFiles(filesToChange, findTextBox.Text, replaceTextBox.Text)} file(s) changed.";
        }

        private void findRetinaAndAssociatedNonretinaImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            RetinaAndNonRetinaFinder form = new RetinaAndNonRetinaFinder();
            form.Show();
        }
    }
}
