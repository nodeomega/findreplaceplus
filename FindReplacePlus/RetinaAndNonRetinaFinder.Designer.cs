namespace FindReplacePlus
{
    partial class RetinaAndNonRetinaFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.changeBaseFolderButton = new System.Windows.Forms.Button();
            this.baseFolderTextBox = new System.Windows.Forms.TextBox();
            this.baseFolderLabel = new System.Windows.Forms.Label();
            this.retinaFinderTreeView = new System.Windows.Forms.TreeView();
            this.findButton = new System.Windows.Forms.Button();
            this.srcsetTextBox = new System.Windows.Forms.TextBox();
            this.srcsetLabel = new System.Windows.Forms.Label();
            this.showOnlyEntriesWithNonRetinaCheckBox = new System.Windows.Forms.CheckBox();
            this.searchProcessLabel = new System.Windows.Forms.Label();
            this.consoleLogListBox = new System.Windows.Forms.ListBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Retina Images and associated Non-Retina Images";
            // 
            // changeBaseFolderButton
            // 
            this.changeBaseFolderButton.Location = new System.Drawing.Point(719, 50);
            this.changeBaseFolderButton.Name = "changeBaseFolderButton";
            this.changeBaseFolderButton.Size = new System.Drawing.Size(317, 23);
            this.changeBaseFolderButton.TabIndex = 9;
            this.changeBaseFolderButton.Text = "Change Base Folder";
            this.changeBaseFolderButton.UseVisualStyleBackColor = true;
            this.changeBaseFolderButton.Click += new System.EventHandler(this.changeBaseFolderButton_Click);
            // 
            // baseFolderTextBox
            // 
            this.baseFolderTextBox.Location = new System.Drawing.Point(719, 24);
            this.baseFolderTextBox.Name = "baseFolderTextBox";
            this.baseFolderTextBox.Size = new System.Drawing.Size(317, 20);
            this.baseFolderTextBox.TabIndex = 8;
            // 
            // baseFolderLabel
            // 
            this.baseFolderLabel.AutoSize = true;
            this.baseFolderLabel.Location = new System.Drawing.Point(716, 8);
            this.baseFolderLabel.Name = "baseFolderLabel";
            this.baseFolderLabel.Size = new System.Drawing.Size(63, 13);
            this.baseFolderLabel.TabIndex = 7;
            this.baseFolderLabel.Text = "Base Folder";
            // 
            // retinaFinderTreeView
            // 
            this.retinaFinderTreeView.Location = new System.Drawing.Point(12, 298);
            this.retinaFinderTreeView.Name = "retinaFinderTreeView";
            this.retinaFinderTreeView.Size = new System.Drawing.Size(1024, 432);
            this.retinaFinderTreeView.TabIndex = 10;
            this.retinaFinderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.retinaFinderTreeView_AfterSelect);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(719, 79);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(317, 23);
            this.findButton.TabIndex = 11;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // srcsetTextBox
            // 
            this.srcsetTextBox.Location = new System.Drawing.Point(12, 24);
            this.srcsetTextBox.Multiline = true;
            this.srcsetTextBox.Name = "srcsetTextBox";
            this.srcsetTextBox.Size = new System.Drawing.Size(701, 78);
            this.srcsetTextBox.TabIndex = 12;
            // 
            // srcsetLabel
            // 
            this.srcsetLabel.AutoSize = true;
            this.srcsetLabel.Location = new System.Drawing.Point(9, 8);
            this.srcsetLabel.Name = "srcsetLabel";
            this.srcsetLabel.Size = new System.Drawing.Size(172, 13);
            this.srcsetLabel.TabIndex = 13;
            this.srcsetLabel.Text = "srcset Attribute Based on Selection";
            // 
            // showOnlyEntriesWithNonRetinaCheckBox
            // 
            this.showOnlyEntriesWithNonRetinaCheckBox.AutoSize = true;
            this.showOnlyEntriesWithNonRetinaCheckBox.Location = new System.Drawing.Point(719, 109);
            this.showOnlyEntriesWithNonRetinaCheckBox.Name = "showOnlyEntriesWithNonRetinaCheckBox";
            this.showOnlyEntriesWithNonRetinaCheckBox.Size = new System.Drawing.Size(225, 17);
            this.showOnlyEntriesWithNonRetinaCheckBox.TabIndex = 14;
            this.showOnlyEntriesWithNonRetinaCheckBox.Text = "Show only images with non-retina versions";
            this.showOnlyEntriesWithNonRetinaCheckBox.UseVisualStyleBackColor = true;
            this.showOnlyEntriesWithNonRetinaCheckBox.CheckedChanged += new System.EventHandler(this.showOnlyEntriesWithNonRetinaCheckBox_CheckedChanged);
            // 
            // searchProcessLabel
            // 
            this.searchProcessLabel.AutoSize = true;
            this.searchProcessLabel.Location = new System.Drawing.Point(12, 152);
            this.searchProcessLabel.Name = "searchProcessLabel";
            this.searchProcessLabel.Size = new System.Drawing.Size(66, 13);
            this.searchProcessLabel.TabIndex = 16;
            this.searchProcessLabel.Text = "Console Log";
            // 
            // consoleLogListBox
            // 
            this.consoleLogListBox.FormattingEnabled = true;
            this.consoleLogListBox.Location = new System.Drawing.Point(12, 168);
            this.consoleLogListBox.Name = "consoleLogListBox";
            this.consoleLogListBox.Size = new System.Drawing.Size(1024, 108);
            this.consoleLogListBox.TabIndex = 17;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 113);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 13);
            this.statusLabel.TabIndex = 18;
            this.statusLabel.Text = "Waiting...";
            // 
            // RetinaAndNonRetinaFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 742);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.consoleLogListBox);
            this.Controls.Add(this.searchProcessLabel);
            this.Controls.Add(this.showOnlyEntriesWithNonRetinaCheckBox);
            this.Controls.Add(this.srcsetLabel);
            this.Controls.Add(this.srcsetTextBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.retinaFinderTreeView);
            this.Controls.Add(this.changeBaseFolderButton);
            this.Controls.Add(this.baseFolderTextBox);
            this.Controls.Add(this.baseFolderLabel);
            this.Controls.Add(this.label1);
            this.Name = "RetinaAndNonRetinaFinder";
            this.Text = "Retina And Non-Retina Finder";
            this.Load += new System.EventHandler(this.RetinaAndNonRetinaFinder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button changeBaseFolderButton;
        private System.Windows.Forms.TextBox baseFolderTextBox;
        private System.Windows.Forms.Label baseFolderLabel;
        private System.Windows.Forms.TreeView retinaFinderTreeView;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox srcsetTextBox;
        private System.Windows.Forms.Label srcsetLabel;
        private System.Windows.Forms.CheckBox showOnlyEntriesWithNonRetinaCheckBox;
        private System.Windows.Forms.Label searchProcessLabel;
        private System.Windows.Forms.ListBox consoleLogListBox;
        private System.Windows.Forms.Label statusLabel;
    }
}