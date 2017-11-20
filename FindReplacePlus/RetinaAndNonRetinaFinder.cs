using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindReplacePlus
{
    public partial class RetinaAndNonRetinaFinder : Form
    {
        public RetinaAndNonRetinaFinder()
        {
            InitializeComponent();
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
            ChooseFolder();
        }

        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath)
        {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            while (pending.Count > 0)
            {
                rootFolderPath = pending.Dequeue();
                string[] tmp;
                try
                {
                    tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                foreach (string t in tmp)
                {
                    yield return t;
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                foreach (string t in tmp)
                {
                    pending.Enqueue(t);
                }
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            FindRetinaAndNonRetina();
        }

        private void retinaFinderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // if it's a child node, or if it has no children, don't update the srcset textbox.
            if (e.Node.Parent != null || e.Node.Nodes.Count < 1) return;

            srcsetTextBox.Text =
                $@"srcset=""{e.Node.Nodes[0]?.Text.Replace(baseFolderTextBox.Text, string.Empty).Replace(@"\", @"/")} 1x, {e.Node.Text
                    .Replace(baseFolderTextBox.Text, string.Empty).Replace(@"\", @"/")} 2x""";
        }

        private void showOnlyEntriesWithNonRetinaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FindRetinaAndNonRetina();
        }

        private void FindRetinaAndNonRetina()
        {
            try
            {
                retinaFinderTreeView.Nodes.Clear();
                IEnumerable<string> test = GetFileList("*@2x*", baseFolderTextBox.Text);

                foreach (string s in test)
                {
                    string[] extension = s.Split('.');
                    string nonRetina =
                        $"{s.Split(new[] { "@2x" }, StringSplitOptions.None)[0]}.{extension[extension.Length - 1]}";

                    TreeNode retinaRoot = new TreeNode(s);
                    if (File.Exists(nonRetina))
                    {
                        retinaRoot.Nodes.Add(new TreeNode(nonRetina));
                    }

                    if (!showOnlyEntriesWithNonRetinaCheckBox.Checked || showOnlyEntriesWithNonRetinaCheckBox.Checked && retinaRoot.Nodes.Count > 0)
                        retinaFinderTreeView.Nodes.Add(retinaRoot);

                    //matchingFilesCheckedListBox.Items.Add(s, CheckState.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
        }
    }
}
