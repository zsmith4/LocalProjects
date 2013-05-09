using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FileUtilities
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
			this.btnSourceBrowse = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.txtSourceDirectory = new TextBox();
			this.label1 = new Label();
			this.btnOutputBrowse = new Button();
			this.txtOutputDirectory = new TextBox();
			this.label2 = new Label();
			this.label6 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.txtPrefix = new TextBox();
			this.cboDigits = new ComboBox();
			this.grpCopy = new GroupBox();
			this.chkNumberFirst = new CheckBox();
			this.lblStart = new Label();
			this.txtStart = new TextBox();
			this.chkUseDir = new CheckBox();
			this.txtExample = new Label();
			this.cmdRun = new Button();
			this.statusStrip1 = new StatusStrip();
			this.statusProgress = new ToolStripProgressBar();
			this.statusLabel = new ToolStripStatusLabel();
			this.cmdCancel = new Button();
			this.Worker = new BackgroundWorker();
			this.grpConstraint = new GroupBox();
			this.label5 = new Label();
			this.txtLandscape = new TextBox();
			this.txtPortrait = new TextBox();
			this.radioRatio = new RadioButton();
			this.txtRatio = new TextBox();
			this.radioPortrait = new RadioButton();
			this.radioLandscape = new RadioButton();
			this.tabContainer = new TabControl();
			this.tabOrganize = new TabPage();
			this.groupBox2 = new GroupBox();
			this.chkUseYearMonthDir = new CheckBox();
			this.chkAddDashesToDates = new CheckBox();
			this.chkSkipExisting = new CheckBox();
			this.chkOverwrite = new CheckBox();
			this.tabSort = new TabPage();
			this.groupBox1 = new GroupBox();
			this.chkSortCopy = new CheckBox();
			this.textBox1 = new TextBox();
			this.tabRename = new TabPage();
			this.tabResize = new TabPage();
			this.grpCopy.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.grpConstraint.SuspendLayout();
			this.tabContainer.SuspendLayout();
			this.tabOrganize.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabSort.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabRename.SuspendLayout();
			this.tabResize.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSourceBrowse
			// 
			this.btnSourceBrowse.Location = new Point(579, 42);
			this.btnSourceBrowse.Name = "btnSourceBrowse";
			this.btnSourceBrowse.Size = new Size(75, 23);
			this.btnSourceBrowse.TabIndex = 1;
			this.btnSourceBrowse.Text = "Browse...";
			this.btnSourceBrowse.UseVisualStyleBackColor = true;
			this.btnSourceBrowse.Click += new EventHandler(this.btnSourceBrowse_Click);
			// 
			// txtSourceDirectory
			// 
			this.txtSourceDirectory.Location = new Point(142, 44);
			this.txtSourceDirectory.Name = "txtSourceDirectory";
			this.txtSourceDirectory.Size = new Size(419, 20);
			this.txtSourceDirectory.TabIndex = 0;
			this.txtSourceDirectory.TextChanged += new EventHandler(this.txtSourceDirectory_TextChanged);
			this.txtSourceDirectory.Leave += new EventHandler(this.txtSourceDirectory_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new Point(36, 44);
			this.label1.Name = "label1";
			this.label1.Size = new Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Source Directory:";
			// 
			// btnOutputBrowse
			// 
			this.btnOutputBrowse.Location = new Point(579, 71);
			this.btnOutputBrowse.Name = "btnOutputBrowse";
			this.btnOutputBrowse.Size = new Size(75, 23);
			this.btnOutputBrowse.TabIndex = 3;
			this.btnOutputBrowse.Text = "Browse...";
			this.btnOutputBrowse.UseVisualStyleBackColor = true;
			this.btnOutputBrowse.Click += new EventHandler(this.btnOutputBrowse_Click);
			// 
			// txtOutputDirectory
			// 
			this.txtOutputDirectory.Location = new Point(142, 70);
			this.txtOutputDirectory.Name = "txtOutputDirectory";
			this.txtOutputDirectory.Size = new Size(419, 20);
			this.txtOutputDirectory.TabIndex = 2;
			this.txtOutputDirectory.TextChanged += new EventHandler(this.txtOutputDirectory_TextChanged);
			this.txtOutputDirectory.Leave += new EventHandler(this.txtOutputDirectory_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new Point(39, 70);
			this.label2.Name = "label2";
			this.label2.Size = new Size(87, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output Directory:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Enabled = false;
			this.label6.Location = new Point(14, 111);
			this.label6.Name = "label6";
			this.label6.Size = new Size(50, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Example:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new Point(14, 30);
			this.label3.Name = "label3";
			this.label3.Size = new Size(36, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Prefix:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new Point(14, 57);
			this.label4.Name = "label4";
			this.label4.Size = new Size(36, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Digits:";
			// 
			// txtPrefix
			// 
			this.txtPrefix.Location = new Point(73, 26);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new Size(107, 20);
			this.txtPrefix.TabIndex = 0;
			this.txtPrefix.TextChanged += new EventHandler(this.txtPrefix_TextChanged);
			// 
			// cboDigits
			// 
			this.cboDigits.FormattingEnabled = true;
			this.cboDigits.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6"});
			this.cboDigits.Location = new Point(73, 54);
			this.cboDigits.Name = "cboDigits";
			this.cboDigits.Size = new Size(34, 21);
			this.cboDigits.TabIndex = 1;
			this.cboDigits.SelectedIndexChanged += new EventHandler(this.cboDigits_SelectedIndexChanged);
			// 
			// grpCopy
			// 
			this.grpCopy.Controls.Add(this.chkNumberFirst);
			this.grpCopy.Controls.Add(this.lblStart);
			this.grpCopy.Controls.Add(this.txtStart);
			this.grpCopy.Controls.Add(this.chkUseDir);
			this.grpCopy.Controls.Add(this.txtExample);
			this.grpCopy.Controls.Add(this.cboDigits);
			this.grpCopy.Controls.Add(this.txtPrefix);
			this.grpCopy.Controls.Add(this.label4);
			this.grpCopy.Controls.Add(this.label3);
			this.grpCopy.Controls.Add(this.label6);
			this.grpCopy.Location = new Point(1, 1);
			this.grpCopy.Name = "grpCopy";
			this.grpCopy.Size = new Size(405, 147);
			this.grpCopy.TabIndex = 14;
			this.grpCopy.TabStop = false;
			this.grpCopy.Text = "Rename";
			// 
			// chkNumberFirst
			// 
			this.chkNumberFirst.AutoSize = true;
			this.chkNumberFirst.Location = new Point(227, 54);
			this.chkNumberFirst.Name = "chkNumberFirst";
			this.chkNumberFirst.Size = new Size(114, 17);
			this.chkNumberFirst.TabIndex = 4;
			this.chkNumberFirst.Text = "&Serial Number First";
			this.chkNumberFirst.UseVisualStyleBackColor = true;
			this.chkNumberFirst.CheckedChanged += new EventHandler(this.chkNumberFirst_CheckedChanged);
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new Point(14, 84);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new Size(44, 13);
			this.lblStart.TabIndex = 17;
			this.lblStart.Text = "Start at:";
			// 
			// txtStart
			// 
			this.txtStart.Location = new Point(73, 83);
			this.txtStart.Name = "txtStart";
			this.txtStart.Size = new Size(107, 20);
			this.txtStart.TabIndex = 2;
			this.txtStart.TextChanged += new EventHandler(this.txtStart_TextChanged);
			// 
			// chkUseDir
			// 
			this.chkUseDir.AutoSize = true;
			this.chkUseDir.Location = new Point(227, 28);
			this.chkUseDir.Name = "chkUseDir";
			this.chkUseDir.Size = new Size(121, 17);
			this.chkUseDir.TabIndex = 3;
			this.chkUseDir.Text = "&Use Directory Name";
			this.chkUseDir.UseVisualStyleBackColor = true;
			this.chkUseDir.CheckedChanged += new EventHandler(this.chkUseDir_CheckedChanged);
			// 
			// txtExample
			// 
			this.txtExample.AutoSize = true;
			this.txtExample.Location = new Point(73, 111);
			this.txtExample.Name = "txtExample";
			this.txtExample.Size = new Size(47, 13);
			this.txtExample.TabIndex = 14;
			this.txtExample.Text = "Example";
			// 
			// cmdRun
			// 
			this.cmdRun.Location = new Point(142, 286);
			this.cmdRun.Name = "cmdRun";
			this.cmdRun.Size = new Size(75, 23);
			this.cmdRun.TabIndex = 4;
			this.cmdRun.Text = "&Run";
			this.cmdRun.UseVisualStyleBackColor = true;
			this.cmdRun.Click += new EventHandler(this.cmdRun_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new ToolStripItem[] {
            this.statusProgress,
            this.statusLabel});
			this.statusStrip1.Location = new Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(702, 22);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "Click \'Run\' to Start";
			// 
			// statusProgress
			// 
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new Size(475, 16);
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new Size(94, 17);
			this.statusLabel.Text = "Click \'Run\' to Start";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new Point(224, 286);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new Size(75, 23);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new EventHandler(this.cmdCancel_Click);
			this.cmdCancel.MouseLeave += new EventHandler(this.cmdCancel_MouseLeave);
			this.cmdCancel.MouseHover += new EventHandler(this.cmdCancel_MouseHover);
			// 
			// Worker
			// 
			this.Worker.WorkerReportsProgress = true;
			this.Worker.WorkerSupportsCancellation = true;
			this.Worker.DoWork += new DoWorkEventHandler(this.Worker_DoWork);
			this.Worker.ProgressChanged += new ProgressChangedEventHandler(this.Worker_ProgressChanged);
			this.Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
			// 
			// grpConstraint
			// 
			this.grpConstraint.BackColor = SystemColors.ButtonFace;
			this.grpConstraint.Controls.Add(this.label5);
			this.grpConstraint.Controls.Add(this.txtLandscape);
			this.grpConstraint.Controls.Add(this.txtPortrait);
			this.grpConstraint.Controls.Add(this.radioRatio);
			this.grpConstraint.Controls.Add(this.txtRatio);
			this.grpConstraint.Controls.Add(this.radioPortrait);
			this.grpConstraint.Controls.Add(this.radioLandscape);
			this.grpConstraint.Location = new Point(1, 1);
			this.grpConstraint.Name = "grpConstraint";
			this.grpConstraint.Size = new Size(405, 147);
			this.grpConstraint.TabIndex = 21;
			this.grpConstraint.TabStop = false;
			this.grpConstraint.Text = "Constraint";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new Point(153, 79);
			this.label5.Name = "label5";
			this.label5.Size = new Size(63, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "133% = 133";
			// 
			// txtLandscape
			// 
			this.txtLandscape.Location = new Point(102, 28);
			this.txtLandscape.Name = "txtLandscape";
			this.txtLandscape.Size = new Size(45, 20);
			this.txtLandscape.TabIndex = 0;
			this.txtLandscape.TextAlign = HorizontalAlignment.Center;
			this.txtLandscape.TextChanged += new EventHandler(this.txtLandscape_TextChanged);
			this.txtLandscape.Enter += new EventHandler(this.txtLandscape_Enter);
			// 
			// txtPortrait
			// 
			this.txtPortrait.Location = new Point(102, 51);
			this.txtPortrait.Name = "txtPortrait";
			this.txtPortrait.Size = new Size(45, 20);
			this.txtPortrait.TabIndex = 1;
			this.txtPortrait.TextAlign = HorizontalAlignment.Center;
			this.txtPortrait.TextChanged += new EventHandler(this.txtPortrait_TextChanged);
			this.txtPortrait.Enter += new EventHandler(this.txtPortrait_Enter);
			// 
			// radioRatio
			// 
			this.radioRatio.AutoSize = true;
			this.radioRatio.Location = new Point(18, 75);
			this.radioRatio.Name = "radioRatio";
			this.radioRatio.Size = new Size(62, 17);
			this.radioRatio.TabIndex = 22;
			this.radioRatio.TabStop = true;
			this.radioRatio.Text = "&Percent";
			this.radioRatio.UseVisualStyleBackColor = true;
			// 
			// txtRatio
			// 
			this.txtRatio.Location = new Point(102, 74);
			this.txtRatio.Name = "txtRatio";
			this.txtRatio.Size = new Size(45, 20);
			this.txtRatio.TabIndex = 2;
			this.txtRatio.TextAlign = HorizontalAlignment.Center;
			this.txtRatio.TextChanged += new EventHandler(this.txtRatio_TextChanged);
			this.txtRatio.Enter += new EventHandler(this.txtRatio_Enter);
			// 
			// radioPortrait
			// 
			this.radioPortrait.AutoSize = true;
			this.radioPortrait.Location = new Point(18, 52);
			this.radioPortrait.Name = "radioPortrait";
			this.radioPortrait.Size = new Size(58, 17);
			this.radioPortrait.TabIndex = 1;
			this.radioPortrait.TabStop = true;
			this.radioPortrait.Text = "&Portrait";
			this.radioPortrait.UseVisualStyleBackColor = true;
			// 
			// radioLandscape
			// 
			this.radioLandscape.AutoSize = true;
			this.radioLandscape.Checked = true;
			this.radioLandscape.Location = new Point(18, 29);
			this.radioLandscape.Name = "radioLandscape";
			this.radioLandscape.Size = new Size(78, 17);
			this.radioLandscape.TabIndex = 0;
			this.radioLandscape.TabStop = true;
			this.radioLandscape.Text = "&Landscape";
			this.radioLandscape.UseVisualStyleBackColor = true;
			// 
			// tabContainer
			// 
			this.tabContainer.Controls.Add(this.tabOrganize);
			this.tabContainer.Controls.Add(this.tabSort);
			this.tabContainer.Controls.Add(this.tabRename);
			this.tabContainer.Controls.Add(this.tabResize);
			this.tabContainer.Location = new Point(142, 100);
			this.tabContainer.Name = "tabContainer";
			this.tabContainer.SelectedIndex = 0;
			this.tabContainer.Size = new Size(419, 180);
			this.tabContainer.TabIndex = 4;
			this.tabContainer.SelectedIndexChanged += new EventHandler(this.tabContainer_SelectedIndexChanged);
			// 
			// tabOrganize
			// 
			this.tabOrganize.BackColor = SystemColors.Control;
			this.tabOrganize.BorderStyle = BorderStyle.Fixed3D;
			this.tabOrganize.CausesValidation = false;
			this.tabOrganize.Controls.Add(this.groupBox2);
			this.tabOrganize.Location = new Point(4, 22);
			this.tabOrganize.Name = "tabOrganize";
			this.tabOrganize.Size = new Size(411, 154);
			this.tabOrganize.TabIndex = 2;
			this.tabOrganize.Text = "Organize";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkUseYearMonthDir);
			this.groupBox2.Controls.Add(this.chkAddDashesToDates);
			this.groupBox2.Controls.Add(this.chkSkipExisting);
			this.groupBox2.Controls.Add(this.chkOverwrite);
			this.groupBox2.Location = new Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(405, 148);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Organize Files";
			// 
			// chkUseYearMonthDir
			// 
			this.chkUseYearMonthDir.AutoSize = true;
			this.chkUseYearMonthDir.Location = new Point(21, 100);
			this.chkUseYearMonthDir.Name = "chkUseYearMonthDir";
			this.chkUseYearMonthDir.Size = new Size(152, 17);
			this.chkUseYearMonthDir.TabIndex = 13;
			this.chkUseYearMonthDir.Text = "Use \'YYYY-MM\' Sub-folder";
			this.chkUseYearMonthDir.UseVisualStyleBackColor = true;
			this.chkUseYearMonthDir.CheckedChanged += new EventHandler(this.chkUseYearMonthDir_CheckedChanged);
			// 
			// chkAddDashesToDates
			// 
			this.chkAddDashesToDates.AutoSize = true;
			this.chkAddDashesToDates.Checked = true;
			this.chkAddDashesToDates.CheckState = CheckState.Checked;
			this.chkAddDashesToDates.Location = new Point(21, 77);
			this.chkAddDashesToDates.Name = "chkAddDashesToDates";
			this.chkAddDashesToDates.Size = new Size(253, 17);
			this.chkAddDashesToDates.TabIndex = 12;
			this.chkAddDashesToDates.Text = "Update \'yyyymmdd\' to \'yyyy-mm-dd\' in Source Dir";
			this.chkAddDashesToDates.UseVisualStyleBackColor = true;
			this.chkAddDashesToDates.CheckedChanged += new EventHandler(this.chkAddDashesToDates_CheckedChanged);
			// 
			// chkSkipExisting
			// 
			this.chkSkipExisting.AutoSize = true;
			this.chkSkipExisting.Checked = true;
			this.chkSkipExisting.CheckState = CheckState.Checked;
			this.chkSkipExisting.Location = new Point(21, 53);
			this.chkSkipExisting.Name = "chkSkipExisting";
			this.chkSkipExisting.Size = new Size(86, 17);
			this.chkSkipExisting.TabIndex = 11;
			this.chkSkipExisting.Text = "Skip Existing";
			this.chkSkipExisting.UseVisualStyleBackColor = true;
			this.chkSkipExisting.CheckedChanged += new EventHandler(this.chkSkipExisting_CheckedChanged);
			// 
			// chkOverwrite
			// 
			this.chkOverwrite.AutoSize = true;
			this.chkOverwrite.Location = new Point(21, 30);
			this.chkOverwrite.Name = "chkOverwrite";
			this.chkOverwrite.Size = new Size(127, 17);
			this.chkOverwrite.TabIndex = 10;
			this.chkOverwrite.Text = "Overwrite Destination";
			this.chkOverwrite.UseVisualStyleBackColor = true;
			this.chkOverwrite.CheckedChanged += new EventHandler(this.chkOverwrite_CheckedChanged);
			// 
			// tabSort
			// 
			this.tabSort.BackColor = SystemColors.Control;
			this.tabSort.BorderStyle = BorderStyle.Fixed3D;
			this.tabSort.CausesValidation = false;
			this.tabSort.Controls.Add(this.groupBox1);
			this.tabSort.Location = new Point(4, 22);
			this.tabSort.Name = "tabSort";
			this.tabSort.Size = new Size(411, 154);
			this.tabSort.TabIndex = 3;
			this.tabSort.Text = "Sort";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkSortCopy);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(405, 148);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sort Files Into Directories";
			// 
			// chkSortCopy
			// 
			this.chkSortCopy.AutoSize = true;
			this.chkSortCopy.Location = new Point(21, 30);
			this.chkSortCopy.Name = "chkSortCopy";
			this.chkSortCopy.Size = new Size(74, 17);
			this.chkSortCopy.TabIndex = 19;
			this.chkSortCopy.Text = "Copy Files";
			this.chkSortCopy.UseVisualStyleBackColor = true;
			this.chkSortCopy.CheckedChanged += new EventHandler(this.chkSortCopy_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = SystemColors.Control;
			this.textBox1.BorderStyle = BorderStyle.None;
			this.textBox1.Location = new Point(21, 77);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(366, 55);
			this.textBox1.TabIndex = 18;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "NOTE - Existing files are never overwritten.  Files are moved unless specified.  " +
    "May use \'YYYY-MM\' checkbox. Only processes top-level directory.";
			// 
			// tabRename
			// 
			this.tabRename.BackColor = SystemColors.Control;
			this.tabRename.BorderStyle = BorderStyle.Fixed3D;
			this.tabRename.Controls.Add(this.grpCopy);
			this.tabRename.Location = new Point(4, 22);
			this.tabRename.Name = "tabRename";
			this.tabRename.Padding = new Padding(3);
			this.tabRename.Size = new Size(411, 154);
			this.tabRename.TabIndex = 0;
			this.tabRename.Text = "Rename";
			// 
			// tabResize
			// 
			this.tabResize.BackColor = SystemColors.Control;
			this.tabResize.BorderStyle = BorderStyle.Fixed3D;
			this.tabResize.Controls.Add(this.grpConstraint);
			this.tabResize.Cursor = Cursors.Default;
			this.tabResize.Location = new Point(4, 22);
			this.tabResize.Name = "tabResize";
			this.tabResize.Padding = new Padding(3);
			this.tabResize.Size = new Size(411, 154);
			this.tabResize.TabIndex = 1;
			this.tabResize.Text = "Resize";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(702, 361);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdRun);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOutputDirectory);
			this.Controls.Add(this.btnOutputBrowse);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSourceDirectory);
			this.Controls.Add(this.btnSourceBrowse);
			this.Controls.Add(this.tabContainer);
			this.Name = "MainForm";
			this.Text = "File Utilities";
			this.Load += new EventHandler(this.MainForm_Load);
			this.grpCopy.ResumeLayout(false);
			this.grpCopy.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.grpConstraint.ResumeLayout(false);
			this.grpConstraint.PerformLayout();
			this.tabContainer.ResumeLayout(false);
			this.tabOrganize.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabSort.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabRename.ResumeLayout(false);
			this.tabResize.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Button btnSourceBrowse;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtSourceDirectory;
        private Label label1;
        private Button btnOutputBrowse;
        private TextBox txtOutputDirectory;
		private Label label2;
		private Label label6;
		private Label label3;
		private Label label4;
		private TextBox txtPrefix;
		private ComboBox cboDigits;
		private GroupBox grpCopy;
		private Label txtExample;
		private Button cmdRun;
		private CheckBox chkUseDir;
		private TextBox txtStart;
		private Label lblStart;
		public StatusStrip statusStrip1;
		public ToolStripProgressBar statusProgress;
		private Button cmdCancel;
		private ToolStripStatusLabel statusLabel;
		protected BackgroundWorker Worker;
		private CheckBox chkNumberFirst;
		private GroupBox grpConstraint;
		private TextBox txtRatio;
		private RadioButton radioPortrait;
		private RadioButton radioLandscape;
		private RadioButton radioRatio;
		protected internal TabControl tabContainer;
		private TabPage tabRename;
		private TabPage tabResize;
		private TextBox txtLandscape;
		private TextBox txtPortrait;
		private TabPage tabOrganize;
		private TabPage tabSort;
		private GroupBox groupBox1;
		private CheckBox chkSortCopy;
		private TextBox textBox1;
		private GroupBox groupBox2;
		private CheckBox chkUseYearMonthDir;
		private CheckBox chkAddDashesToDates;
		private CheckBox chkSkipExisting;
		private CheckBox chkOverwrite;
		private Label label5;
    }
}

