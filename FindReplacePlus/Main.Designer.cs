namespace FindReplacePlus
{
    partial class Main
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
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.findLabel = new System.Windows.Forms.Label();
            this.replaceLabel = new System.Windows.Forms.Label();
            this.baseFolderLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.baseFolderTextBox = new System.Windows.Forms.TextBox();
            this.changeBaseFolderButton = new System.Windows.Forms.Button();
            this.matchingFilesLabel = new System.Windows.Forms.Label();
            this.matchingFilesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.findButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.otherFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSearchPatternTextBox = new System.Windows.Forms.TextBox();
            this.fileSearchPatternLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findTextBox
            // 
            this.findTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findTextBox.Location = new System.Drawing.Point(12, 48);
            this.findTextBox.Multiline = true;
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(705, 154);
            this.findTextBox.TabIndex = 0;
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaceTextBox.Location = new System.Drawing.Point(12, 221);
            this.replaceTextBox.Multiline = true;
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(705, 146);
            this.replaceTextBox.TabIndex = 1;
            // 
            // findLabel
            // 
            this.findLabel.AutoSize = true;
            this.findLabel.Location = new System.Drawing.Point(12, 32);
            this.findLabel.Name = "findLabel";
            this.findLabel.Size = new System.Drawing.Size(27, 13);
            this.findLabel.TabIndex = 2;
            this.findLabel.Text = "Find";
            // 
            // replaceLabel
            // 
            this.replaceLabel.AutoSize = true;
            this.replaceLabel.Location = new System.Drawing.Point(12, 205);
            this.replaceLabel.Name = "replaceLabel";
            this.replaceLabel.Size = new System.Drawing.Size(47, 13);
            this.replaceLabel.TabIndex = 3;
            this.replaceLabel.Text = "Replace";
            // 
            // baseFolderLabel
            // 
            this.baseFolderLabel.AutoSize = true;
            this.baseFolderLabel.Location = new System.Drawing.Point(720, 32);
            this.baseFolderLabel.Name = "baseFolderLabel";
            this.baseFolderLabel.Size = new System.Drawing.Size(63, 13);
            this.baseFolderLabel.TabIndex = 4;
            this.baseFolderLabel.Text = "Base Folder";
            // 
            // baseFolderTextBox
            // 
            this.baseFolderTextBox.Location = new System.Drawing.Point(723, 48);
            this.baseFolderTextBox.Name = "baseFolderTextBox";
            this.baseFolderTextBox.Size = new System.Drawing.Size(317, 20);
            this.baseFolderTextBox.TabIndex = 5;
            // 
            // changeBaseFolderButton
            // 
            this.changeBaseFolderButton.Location = new System.Drawing.Point(723, 74);
            this.changeBaseFolderButton.Name = "changeBaseFolderButton";
            this.changeBaseFolderButton.Size = new System.Drawing.Size(317, 23);
            this.changeBaseFolderButton.TabIndex = 6;
            this.changeBaseFolderButton.Text = "Change Base Folder";
            this.changeBaseFolderButton.UseVisualStyleBackColor = true;
            this.changeBaseFolderButton.Click += new System.EventHandler(this.changeBaseFolderButton_Click);
            // 
            // matchingFilesLabel
            // 
            this.matchingFilesLabel.AutoSize = true;
            this.matchingFilesLabel.Location = new System.Drawing.Point(12, 370);
            this.matchingFilesLabel.Name = "matchingFilesLabel";
            this.matchingFilesLabel.Size = new System.Drawing.Size(75, 13);
            this.matchingFilesLabel.TabIndex = 7;
            this.matchingFilesLabel.Text = "Matching Files";
            // 
            // matchingFilesCheckedListBox
            // 
            this.matchingFilesCheckedListBox.FormattingEnabled = true;
            this.matchingFilesCheckedListBox.HorizontalScrollbar = true;
            this.matchingFilesCheckedListBox.Location = new System.Drawing.Point(12, 386);
            this.matchingFilesCheckedListBox.Name = "matchingFilesCheckedListBox";
            this.matchingFilesCheckedListBox.Size = new System.Drawing.Size(1028, 289);
            this.matchingFilesCheckedListBox.TabIndex = 8;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(12, 685);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(317, 23);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(400, 685);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(317, 23);
            this.replaceAllButton.TabIndex = 10;
            this.replaceAllButton.Text = "Replace All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 735);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otherFunctionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // otherFunctionsToolStripMenuItem
            // 
            this.otherFunctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem});
            this.otherFunctionsToolStripMenuItem.Name = "otherFunctionsToolStripMenuItem";
            this.otherFunctionsToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.otherFunctionsToolStripMenuItem.Text = "Other Functions";
            // 
            // findRetinaAndAssociatedNonretinaImagesToolStripMenuItem
            // 
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem.Name = "findRetinaAndAssociatedNonretinaImagesToolStripMenuItem";
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem.Size = new System.Drawing.Size(314, 22);
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem.Text = "Find Retina and associated non-retina images";
            this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem.Click += new System.EventHandler(this.findRetinaAndAssociatedNonretinaImagesToolStripMenuItem_Click);
            // 
            // fileSearchPatternTextBox
            // 
            this.fileSearchPatternTextBox.Location = new System.Drawing.Point(723, 116);
            this.fileSearchPatternTextBox.Name = "fileSearchPatternTextBox";
            this.fileSearchPatternTextBox.Size = new System.Drawing.Size(317, 20);
            this.fileSearchPatternTextBox.TabIndex = 14;
            // 
            // fileSearchPatternLabel
            // 
            this.fileSearchPatternLabel.AutoSize = true;
            this.fileSearchPatternLabel.Location = new System.Drawing.Point(723, 100);
            this.fileSearchPatternLabel.Name = "fileSearchPatternLabel";
            this.fileSearchPatternLabel.Size = new System.Drawing.Size(300, 13);
            this.fileSearchPatternLabel.TabIndex = 13;
            this.fileSearchPatternLabel.Text = "File Search Pattern (* and ? wildcards allowed, | (pipe) delimits)";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 762);
            this.Controls.Add(this.fileSearchPatternTextBox);
            this.Controls.Add(this.fileSearchPatternLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.matchingFilesCheckedListBox);
            this.Controls.Add(this.matchingFilesLabel);
            this.Controls.Add(this.changeBaseFolderButton);
            this.Controls.Add(this.baseFolderTextBox);
            this.Controls.Add(this.baseFolderLabel);
            this.Controls.Add(this.replaceLabel);
            this.Controls.Add(this.findLabel);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Find/Replace Plus";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Label findLabel;
        private System.Windows.Forms.Label replaceLabel;
        private System.Windows.Forms.Label baseFolderLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox baseFolderTextBox;
        private System.Windows.Forms.Button changeBaseFolderButton;
        private System.Windows.Forms.Label matchingFilesLabel;
        private System.Windows.Forms.CheckedListBox matchingFilesCheckedListBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem otherFunctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findRetinaAndAssociatedNonretinaImagesToolStripMenuItem;
        private System.Windows.Forms.TextBox fileSearchPatternTextBox;
        private System.Windows.Forms.Label fileSearchPatternLabel;
    }
}

