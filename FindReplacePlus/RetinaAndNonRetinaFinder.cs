using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindReplacePlus.Classes;

namespace FindReplacePlus
{
    public partial class RetinaAndNonRetinaFinder : Form
    {
        private readonly RetinaTask _retina = new RetinaTask();

        private readonly Thread _thisThread = Thread.CurrentThread;

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

        private async void findButton_Click(object sender, EventArgs e)
        {
            await Task.Run(FindRetinaAndNonRetina);
        }

        private void retinaFinderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // if it's a child node, or if it has no children, don't update the srcset textbox.
            if (e.Node.Parent != null || e.Node.Nodes.Count < 1) return;

            srcsetTextBox.Text =
                $@"srcset=""{e.Node.Nodes[0]?.Text.Replace(baseFolderTextBox.Text, string.Empty).Replace(@"\", @"/")} 1x, {e.Node.Text
                    .Replace(baseFolderTextBox.Text, string.Empty).Replace(@"\", @"/")} 2x""";
        }

        private async Task FindRetinaAndNonRetina()
        {
            try
            {
                ClearNodes();

                _retina.Start();

                IEnumerable<string> test = await Task.Run(() => GetFileList("*@2x*", baseFolderTextBox.Text));

                ParallelOptions opt = new ParallelOptions {MaxDegreeOfParallelism = 4};

                //Task process = Task.Factory.StartNew(delegate
                await Task.Run(delegate
                {
                    // We need to keep the thread process alive until everything is processed.
                    //List<Task> taskList = new List<Task>();


                    ParallelLoopResult par = Parallel.ForEach(test, opt, s =>
                    {
                        string[] extension = s.Split('.');
                        string nonRetina =
                            $"{s.Split(new[] {"@2x"}, StringSplitOptions.None)[0]}.{extension[extension.Length - 1]}";

                        TreeNode retinaRoot = new TreeNode(s);

                        //taskList.Add(Task.Run(() =>
                        //{
                        _retina.ChangeData($"Checking non-retina for {s}...", null);
                        if (File.Exists(nonRetina))
                        {
                            TreeNode nonRetinaNode = new TreeNode(nonRetina);
                            List<string> fileListWhereFound =
                                GetFileList(fileSearchPatternTextBox.Text,
                                        baseFolderTextBox.Text,
                                        nonRetina.Replace(baseFolderTextBox.Text, string.Empty).Replace(@"\", @"/"))
                                    .ToList();

                            foreach (string fileName in fileListWhereFound)
                            {
                                nonRetinaNode.Nodes.Add(new TreeNode(fileName));
                            }
                            // filters if set to only show where non-retina images are referenced by any files in the base folder.
                            if (!showOnlyImageSetsFoundInFiles.Checked ||
                                showOnlyImageSetsFoundInFiles.Checked && nonRetinaNode.Nodes.Count > 0)
                                retinaRoot.Nodes.Add(nonRetinaNode);
                        }

                        // filters if set to only show retina images with corresponding images.
                        // filter for only showing non-retina in files if selected will already be applied.
                        if (!showOnlyEntriesWithNonRetinaCheckBox.Checked ||
                            showOnlyEntriesWithNonRetinaCheckBox.Checked && retinaRoot.Nodes.Count > 0)
                            _retina.ChangeData(string.Empty, retinaRoot);
                        //}));

                        string stillProcessing = "Matching images and finding usages in files.";
                        UpdateStatus($@"{stillProcessing} | {_retina.QueueCount} currently in queue.", Color.Blue);
                    });

                    //while (!Task.WhenAll(taskList).IsCompleted || _retina.QueueCount > 0)
                    while (!par.IsCompleted || _retina.QueueCount > 0)
                    {
                        //int tasksRemaining = (int) taskList?.Count(x => !x.IsCompleted);
                        //UpdateStatus($@"{tasksRemaining} entries remaining to be processed | {_retina.QueueCount} in queue.", Color.Blue

                        string stillProcessing = par.IsCompleted
                            ? "File matching completed"
                            : "Matching images and finding usages in files.";
                        UpdateStatus($@"{stillProcessing} | {_retina.QueueCount} currently in queue.", Color.Blue);
                    }
                    // stop the process once the parallel is finally done.
                    _retina.Stop();

                    UpdateStatus("All retina images examined!", Color.DarkGreen);
                });

                //process.Wait();
                //await process;
                //retina.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
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
                    if (!text.Contains(findPattern)) continue;
                    List<string> lines = text.Split('\n')
                        .Select((line, idx) => line.Contains(findPattern) ? $"{t}: Line {idx + 1}" : string.Empty)
                        .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                    // purge the string so it doesn't stay in memory.
                    text = null;

                    foreach (string line in lines)
                    {
                        yield return line;
                    }

                    //List<int> lineNum = findPattern.Select((line, idx) => line == '\n' ? idx : -1)
                    //    .Where(idx => idx > 0).ToList();

                    //for (int fileLine = 0; fileLine < lines.Length; fileLine++)
                    //{
                    //    if (lines[fileLine].Contains(findPattern))
                    //    {
                    //        yield return $"{t}: Line {fileLine + 1}";
                    //    }
                    //}
                    //string[] lines = File.ReadAllLines(t);
                }
                tmp = Directory.GetDirectories(rootFolderPath).ToList();
                foreach (string t in tmp)
                {
                    pending.Enqueue(t);
                }
            }
        }

        private void RetinaAndNonRetinaFinder_Load(object sender, EventArgs e)
        {
            fileSearchPatternTextBox.Text = @"*.aspx|*.html|*.htm|*.css|*.scss|*.less|*.ascx|*.cshtml|*.php";

            _retina.CallbackLog += CallbackChangeConsoleLog;
            _retina.CallbackTree += CallbackChangeTreeView;

            _retina.Start();
        }

        private void CallbackChangeConsoleLog(object sender, RetinaTaskResponse response)
        {
            if (consoleLogListBox.InvokeRequired)
            {
                consoleLogListBox.BeginInvoke(new Action(() =>
                {
                    consoleLogListBox.Items.Add(response.Message);
                    consoleLogListBox.TopIndex = consoleLogListBox.Items.Count - 1;
                }));
            }
            else
            {
                consoleLogListBox.Items.Add(response.Message);
                consoleLogListBox.TopIndex = consoleLogListBox.Items.Count - 1;
            }
        }

        private void CallbackChangeTreeView(object sender, RetinaTaskResponse response)
        {
            if (response.Node == null)
            {
                if (consoleLogListBox.InvokeRequired)
                {
                    consoleLogListBox.BeginInvoke(new Action(() =>
                    {
                        consoleLogListBox.Items.Add(response.Message + " and something was null");
                        consoleLogListBox.TopIndex = consoleLogListBox.Items.Count - 1;
                    }));
                }
                else
                {
                    consoleLogListBox.Items.Add(response.Message + " and something was null");
                    consoleLogListBox.TopIndex = consoleLogListBox.Items.Count - 1;
                }
                return;
            }
            if (retinaFinderTreeView.InvokeRequired)
            {
                retinaFinderTreeView.BeginInvoke(new Action(() =>
                {
                    retinaFinderTreeView.Nodes.Add((TreeNode)response.Node.Clone());
                }));
            }
            else
            {
                retinaFinderTreeView.Nodes.Add((TreeNode)response.Node.Clone());
            }
        }

        private void ClearNodes()
        {
            if (retinaFinderTreeView.InvokeRequired)
            {
                retinaFinderTreeView.BeginInvoke(new Action(() =>
                {
                    retinaFinderTreeView.Nodes.Clear();
                }));
            }
            else
            {
                retinaFinderTreeView.Nodes.Clear();
            }
        }

        private void UpdateStatus(string message, Color color)
        {
            if (statusLabel.InvokeRequired)
            {
                statusLabel.BeginInvoke(
                    new Action(
                        () =>
                        {
                            statusLabel.Text = message;
                            statusLabel.ForeColor = color;
                        }));
            }
            else
            {
                statusLabel.Text = message;
                statusLabel.ForeColor = color;
            }
        }
    }
}
