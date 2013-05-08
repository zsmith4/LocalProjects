namespace FileUtilities
{
    partial class MainForm
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
			this.btnSourceBrowse = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtSourceDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOutputBrowse = new System.Windows.Forms.Button();
			this.txtOutputDirectory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.cboDigits = new System.Windows.Forms.ComboBox();
			this.grpCopy = new System.Windows.Forms.GroupBox();
			this.chkNumberFirst = new System.Windows.Forms.CheckBox();
			this.lblStart = new System.Windows.Forms.Label();
			this.txtStart = new System.Windows.Forms.TextBox();
			this.chkUseDir = new System.Windows.Forms.CheckBox();
			this.txtExample = new System.Windows.Forms.Label();
			this.cmdRun = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.Worker = new System.ComponentModel.BackgroundWorker();
			this.grpConstraint = new System.Windows.Forms.GroupBox();
			this.txtLandscape = new System.Windows.Forms.TextBox();
			this.txtPortrait = new System.Windows.Forms.TextBox();
			this.radioRatio = new System.Windows.Forms.RadioButton();
			this.txtRatio = new System.Windows.Forms.TextBox();
			this.radioPortrait = new System.Windows.Forms.RadioButton();
			this.radioLandscape = new System.Windows.Forms.RadioButton();
			this.tabContainer = new System.Windows.Forms.TabControl();
			this.tabRename = new System.Windows.Forms.TabPage();
			this.tabOrganize = new System.Windows.Forms.TabPage();
			this.tabSort = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkUseYearMonthDir = new System.Windows.Forms.CheckBox();
			this.chkSortCopy = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabResize = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.chkAddDashesToDates = new System.Windows.Forms.CheckBox();
			this.chkSkipExisting = new System.Windows.Forms.CheckBox();
			this.chkDestination = new System.Windows.Forms.CheckBox();
			this.grpCopy.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.grpConstraint.SuspendLayout();
			this.tabContainer.SuspendLayout();
			this.tabRename.SuspendLayout();
			this.tabOrganize.SuspendLayout();
			this.tabSort.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabResize.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSourceBrowse
			// 
			this.btnSourceBrowse.Location = new System.Drawing.Point(579, 42);
			this.btnSourceBrowse.Name = "btnSourceBrowse";
			this.btnSourceBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnSourceBrowse.TabIndex = 1;
			this.btnSourceBrowse.Text = "Browse...";
			this.btnSourceBrowse.UseVisualStyleBackColor = true;
			this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
			// 
			// txtSourceDirectory
			// 
			this.txtSourceDirectory.Location = new System.Drawing.Point(142, 44);
			this.txtSourceDirectory.Name = "txtSourceDirectory";
			this.txtSourceDirectory.Size = new System.Drawing.Size(419, 20);
			this.txtSourceDirectory.TabIndex = 0;
			this.txtSourceDirectory.TextChanged += new System.EventHandler(this.txtSourceDirectory_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Source Directory:";
			// 
			// btnOutputBrowse
			// 
			this.btnOutputBrowse.Location = new System.Drawing.Point(579, 71);
			this.btnOutputBrowse.Name = "btnOutputBrowse";
			this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnOutputBrowse.TabIndex = 3;
			this.btnOutputBrowse.Text = "Browse...";
			this.btnOutputBrowse.UseVisualStyleBackColor = true;
			this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
			// 
			// txtOutputDirectory
			// 
			this.txtOutputDirectory.Location = new System.Drawing.Point(142, 70);
			this.txtOutputDirectory.Name = "txtOutputDirectory";
			this.txtOutputDirectory.Size = new System.Drawing.Size(419, 20);
			this.txtOutputDirectory.TabIndex = 2;
			this.txtOutputDirectory.TextChanged += new System.EventHandler(this.txtOutputDirectory_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(39, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output Directory:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Enabled = false;
			this.label6.Location = new System.Drawing.Point(14, 111);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Example:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Prefix:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Digits:";
			// 
			// txtPrefix
			// 
			this.txtPrefix.Location = new System.Drawing.Point(73, 26);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(107, 20);
			this.txtPrefix.TabIndex = 0;
			this.txtPrefix.TextChanged += new System.EventHandler(this.txtPrefix_TextChanged);
			// 
			// cboDigits
			// 
			this.cboDigits.FormattingEnabled = true;
			this.cboDigits.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6"});
			this.cboDigits.Location = new System.Drawing.Point(73, 54);
			this.cboDigits.Name = "cboDigits";
			this.cboDigits.Size = new System.Drawing.Size(34, 21);
			this.cboDigits.TabIndex = 1;
			this.cboDigits.SelectedIndexChanged += new System.EventHandler(this.cboDigits_SelectedIndexChanged);
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
			this.grpCopy.Location = new System.Drawing.Point(6, 6);
			this.grpCopy.Name = "grpCopy";
			this.grpCopy.Size = new System.Drawing.Size(399, 142);
			this.grpCopy.TabIndex = 14;
			this.grpCopy.TabStop = false;
			this.grpCopy.Text = "Recursive Copy and Rename";
			// 
			// chkNumberFirst
			// 
			this.chkNumberFirst.AutoSize = true;
			this.chkNumberFirst.Location = new System.Drawing.Point(227, 54);
			this.chkNumberFirst.Name = "chkNumberFirst";
			this.chkNumberFirst.Size = new System.Drawing.Size(114, 17);
			this.chkNumberFirst.TabIndex = 4;
			this.chkNumberFirst.Text = "&Serial Number First";
			this.chkNumberFirst.UseVisualStyleBackColor = true;
			this.chkNumberFirst.CheckedChanged += new System.EventHandler(this.chkNumberFirst_CheckedChanged);
			// 
			// lblStart
			// 
			this.lblStart.AutoSize = true;
			this.lblStart.Location = new System.Drawing.Point(14, 84);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(44, 13);
			this.lblStart.TabIndex = 17;
			this.lblStart.Text = "Start at:";
			// 
			// txtStart
			// 
			this.txtStart.Location = new System.Drawing.Point(73, 83);
			this.txtStart.Name = "txtStart";
			this.txtStart.Size = new System.Drawing.Size(107, 20);
			this.txtStart.TabIndex = 2;
			this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
			// 
			// chkUseDir
			// 
			this.chkUseDir.AutoSize = true;
			this.chkUseDir.Location = new System.Drawing.Point(227, 28);
			this.chkUseDir.Name = "chkUseDir";
			this.chkUseDir.Size = new System.Drawing.Size(121, 17);
			this.chkUseDir.TabIndex = 3;
			this.chkUseDir.Text = "&Use Directory Name";
			this.chkUseDir.UseVisualStyleBackColor = true;
			this.chkUseDir.CheckedChanged += new System.EventHandler(this.chkUseDir_CheckedChanged);
			// 
			// txtExample
			// 
			this.txtExample.AutoSize = true;
			this.txtExample.Location = new System.Drawing.Point(73, 111);
			this.txtExample.Name = "txtExample";
			this.txtExample.Size = new System.Drawing.Size(47, 13);
			this.txtExample.TabIndex = 14;
			this.txtExample.Text = "Example";
			// 
			// cmdRun
			// 
			this.cmdRun.Location = new System.Drawing.Point(142, 286);
			this.cmdRun.Name = "cmdRun";
			this.cmdRun.Size = new System.Drawing.Size(75, 23);
			this.cmdRun.TabIndex = 4;
			this.cmdRun.Text = "&Run";
			this.cmdRun.UseVisualStyleBackColor = true;
			this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusProgress,
            this.statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(702, 22);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "Click \'Run\' to Start";
			// 
			// statusProgress
			// 
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new System.Drawing.Size(475, 16);
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(104, 17);
			this.statusLabel.Text = "Click \'Run\' to Start";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(224, 286);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.cmdCancel.MouseLeave += new System.EventHandler(this.cmdCancel_MouseLeave);
			this.cmdCancel.MouseHover += new System.EventHandler(this.cmdCancel_MouseHover);
			// 
			// Worker
			// 
			this.Worker.WorkerReportsProgress = true;
			this.Worker.WorkerSupportsCancellation = true;
			this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
			this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
			this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
			// 
			// grpConstraint
			// 
			this.grpConstraint.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.grpConstraint.Controls.Add(this.txtLandscape);
			this.grpConstraint.Controls.Add(this.txtPortrait);
			this.grpConstraint.Controls.Add(this.radioRatio);
			this.grpConstraint.Controls.Add(this.txtRatio);
			this.grpConstraint.Controls.Add(this.radioPortrait);
			this.grpConstraint.Controls.Add(this.radioLandscape);
			this.grpConstraint.Location = new System.Drawing.Point(6, 6);
			this.grpConstraint.Name = "grpConstraint";
			this.grpConstraint.Size = new System.Drawing.Size(399, 142);
			this.grpConstraint.TabIndex = 21;
			this.grpConstraint.TabStop = false;
			this.grpConstraint.Text = "Constraint";
			// 
			// txtLandscape
			// 
			this.txtLandscape.Location = new System.Drawing.Point(102, 28);
			this.txtLandscape.Name = "txtLandscape";
			this.txtLandscape.Size = new System.Drawing.Size(45, 20);
			this.txtLandscape.TabIndex = 0;
			this.txtLandscape.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtLandscape.TextChanged += new System.EventHandler(this.txtLandscape_TextChanged);
			this.txtLandscape.Enter += new System.EventHandler(this.txtLandscape_Enter);
			// 
			// txtPortrait
			// 
			this.txtPortrait.Location = new System.Drawing.Point(102, 51);
			this.txtPortrait.Name = "txtPortrait";
			this.txtPortrait.Size = new System.Drawing.Size(45, 20);
			this.txtPortrait.TabIndex = 1;
			this.txtPortrait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPortrait.TextChanged += new System.EventHandler(this.txtPortrait_TextChanged);
			this.txtPortrait.Enter += new System.EventHandler(this.txtPortrait_Enter);
			// 
			// radioRatio
			// 
			this.radioRatio.AutoSize = true;
			this.radioRatio.Location = new System.Drawing.Point(18, 75);
			this.radioRatio.Name = "radioRatio";
			this.radioRatio.Size = new System.Drawing.Size(62, 17);
			this.radioRatio.TabIndex = 22;
			this.radioRatio.TabStop = true;
			this.radioRatio.Text = "&Percent";
			this.radioRatio.UseVisualStyleBackColor = true;
			// 
			// txtRatio
			// 
			this.txtRatio.Location = new System.Drawing.Point(102, 74);
			this.txtRatio.Name = "txtRatio";
			this.txtRatio.Size = new System.Drawing.Size(45, 20);
			this.txtRatio.TabIndex = 2;
			this.txtRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtRatio.TextChanged += new System.EventHandler(this.txtRatio_TextChanged);
			this.txtRatio.Enter += new System.EventHandler(this.txtRatio_Enter);
			// 
			// radioPortrait
			// 
			this.radioPortrait.AutoSize = true;
			this.radioPortrait.Location = new System.Drawing.Point(18, 52);
			this.radioPortrait.Name = "radioPortrait";
			this.radioPortrait.Size = new System.Drawing.Size(58, 17);
			this.radioPortrait.TabIndex = 1;
			this.radioPortrait.TabStop = true;
			this.radioPortrait.Text = "&Portrait";
			this.radioPortrait.UseVisualStyleBackColor = true;
			// 
			// radioLandscape
			// 
			this.radioLandscape.AutoSize = true;
			this.radioLandscape.Checked = true;
			this.radioLandscape.Location = new System.Drawing.Point(18, 29);
			this.radioLandscape.Name = "radioLandscape";
			this.radioLandscape.Size = new System.Drawing.Size(78, 17);
			this.radioLandscape.TabIndex = 0;
			this.radioLandscape.TabStop = true;
			this.radioLandscape.Text = "&Landscape";
			this.radioLandscape.UseVisualStyleBackColor = true;
			// 
			// tabContainer
			// 
			this.tabContainer.Controls.Add(this.tabRename);
			this.tabContainer.Controls.Add(this.tabOrganize);
			this.tabContainer.Controls.Add(this.tabSort);
			this.tabContainer.Controls.Add(this.tabResize);
			this.tabContainer.Location = new System.Drawing.Point(142, 100);
			this.tabContainer.Name = "tabContainer";
			this.tabContainer.SelectedIndex = 0;
			this.tabContainer.Size = new System.Drawing.Size(419, 180);
			this.tabContainer.TabIndex = 4;
			this.tabContainer.SelectedIndexChanged += new System.EventHandler(this.tabContainer_SelectedIndexChanged);
			// 
			// tabRename
			// 
			this.tabRename.BackColor = System.Drawing.SystemColors.Control;
			this.tabRename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabRename.Controls.Add(this.grpCopy);
			this.tabRename.Location = new System.Drawing.Point(4, 22);
			this.tabRename.Name = "tabRename";
			this.tabRename.Padding = new System.Windows.Forms.Padding(3);
			this.tabRename.Size = new System.Drawing.Size(411, 154);
			this.tabRename.TabIndex = 0;
			this.tabRename.Text = "Rename";
			// 
			// tabOrganize
			// 
			this.tabOrganize.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tabOrganize.CausesValidation = false;
			this.tabOrganize.Controls.Add(this.groupBox2);
			this.tabOrganize.Location = new System.Drawing.Point(4, 22);
			this.tabOrganize.Name = "tabOrganize";
			this.tabOrganize.Size = new System.Drawing.Size(411, 154);
			this.tabOrganize.TabIndex = 2;
			this.tabOrganize.Text = "Organize";
			// 
			// tabSort
			// 
			this.tabSort.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tabSort.Controls.Add(this.groupBox1);
			this.tabSort.Location = new System.Drawing.Point(4, 22);
			this.tabSort.Name = "tabSort";
			this.tabSort.Size = new System.Drawing.Size(411, 154);
			this.tabSort.TabIndex = 3;
			this.tabSort.Text = "Sort";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkUseYearMonthDir);
			this.groupBox1.Controls.Add(this.chkSortCopy);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(3, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 137);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sort Files Into Directories";
			// 
			// chkUseYearMonthDir
			// 
			this.chkUseYearMonthDir.AutoSize = true;
			this.chkUseYearMonthDir.Location = new System.Drawing.Point(4, -15);
			this.chkUseYearMonthDir.Name = "chkUseYearMonthDir";
			this.chkUseYearMonthDir.Size = new System.Drawing.Size(152, 17);
			this.chkUseYearMonthDir.TabIndex = 20;
			this.chkUseYearMonthDir.Text = "Use \'YYYY-MM\' Sub-folder";
			this.chkUseYearMonthDir.UseVisualStyleBackColor = true;
			// 
			// chkSortCopy
			// 
			this.chkSortCopy.AutoSize = true;
			this.chkSortCopy.Location = new System.Drawing.Point(19, 31);
			this.chkSortCopy.Name = "chkSortCopy";
			this.chkSortCopy.Size = new System.Drawing.Size(74, 17);
			this.chkSortCopy.TabIndex = 19;
			this.chkSortCopy.Text = "Copy Files";
			this.chkSortCopy.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.textBox1.Location = new System.Drawing.Point(19, 65);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(366, 69);
			this.textBox1.TabIndex = 18;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "NOTE - Existing files are never overwritten.  Files are moved unless specified.  " +
				"May use \'YYYY-MM\' checkbox. Only processes top-level directory.";
			// 
			// tabResize
			// 
			this.tabResize.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tabResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.tabResize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabResize.Controls.Add(this.grpConstraint);
			this.tabResize.Location = new System.Drawing.Point(4, 22);
			this.tabResize.Name = "tabResize";
			this.tabResize.Padding = new System.Windows.Forms.Padding(3);
			this.tabResize.Size = new System.Drawing.Size(411, 154);
			this.tabResize.TabIndex = 1;
			this.tabResize.Text = "Resize";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.chkAddDashesToDates);
			this.groupBox2.Controls.Add(this.chkSkipExisting);
			this.groupBox2.Controls.Add(this.chkDestination);
			this.groupBox2.Location = new System.Drawing.Point(3, 14);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(405, 137);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Organize Files";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(23, 98);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(152, 17);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Text = "Use \'YYYY-MM\' Sub-folder";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// chkAddDashesToDates
			// 
			this.chkAddDashesToDates.AutoSize = true;
			this.chkAddDashesToDates.Checked = true;
			this.chkAddDashesToDates.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAddDashesToDates.Location = new System.Drawing.Point(23, 75);
			this.chkAddDashesToDates.Name = "chkAddDashesToDates";
			this.chkAddDashesToDates.Size = new System.Drawing.Size(253, 17);
			this.chkAddDashesToDates.TabIndex = 12;
			this.chkAddDashesToDates.Text = "Update \'yyyymmdd\' to \'yyyy-mm-dd\' in Source Dir";
			this.chkAddDashesToDates.UseVisualStyleBackColor = true;
			// 
			// chkSkipExisting
			// 
			this.chkSkipExisting.AutoSize = true;
			this.chkSkipExisting.Checked = true;
			this.chkSkipExisting.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSkipExisting.Location = new System.Drawing.Point(23, 51);
			this.chkSkipExisting.Name = "chkSkipExisting";
			this.chkSkipExisting.Size = new System.Drawing.Size(86, 17);
			this.chkSkipExisting.TabIndex = 11;
			this.chkSkipExisting.Text = "Skip Existing";
			this.chkSkipExisting.UseVisualStyleBackColor = true;
			// 
			// chkDestination
			// 
			this.chkDestination.AutoSize = true;
			this.chkDestination.Location = new System.Drawing.Point(23, 28);
			this.chkDestination.Name = "chkDestination";
			this.chkDestination.Size = new System.Drawing.Size(127, 17);
			this.chkDestination.TabIndex = 10;
			this.chkDestination.Text = "Overwrite Destination";
			this.chkDestination.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 361);
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
			this.Text = "Recursive Copy and Rename";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.grpCopy.ResumeLayout(false);
			this.grpCopy.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.grpConstraint.ResumeLayout(false);
			this.grpConstraint.PerformLayout();
			this.tabContainer.ResumeLayout(false);
			this.tabRename.ResumeLayout(false);
			this.tabOrganize.ResumeLayout(false);
			this.tabSort.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabResize.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.TextBox txtOutputDirectory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.ComboBox cboDigits;
		private System.Windows.Forms.GroupBox grpCopy;
		private System.Windows.Forms.Label txtExample;
		private System.Windows.Forms.Button cmdRun;
		private System.Windows.Forms.CheckBox chkUseDir;
		private System.Windows.Forms.TextBox txtStart;
		private System.Windows.Forms.Label lblStart;
		public System.Windows.Forms.StatusStrip statusStrip1;
		public System.Windows.Forms.ToolStripProgressBar statusProgress;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		protected System.ComponentModel.BackgroundWorker Worker;
		private System.Windows.Forms.CheckBox chkNumberFirst;
		private System.Windows.Forms.GroupBox grpConstraint;
		private System.Windows.Forms.TextBox txtRatio;
		private System.Windows.Forms.RadioButton radioPortrait;
		private System.Windows.Forms.RadioButton radioLandscape;
		private System.Windows.Forms.RadioButton radioRatio;
		protected internal System.Windows.Forms.TabControl tabContainer;
		private System.Windows.Forms.TabPage tabRename;
		private System.Windows.Forms.TabPage tabResize;
		private System.Windows.Forms.TextBox txtLandscape;
		private System.Windows.Forms.TextBox txtPortrait;
		private System.Windows.Forms.TabPage tabOrganize;
		private System.Windows.Forms.TabPage tabSort;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkUseYearMonthDir;
		private System.Windows.Forms.CheckBox chkSortCopy;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox chkAddDashesToDates;
		private System.Windows.Forms.CheckBox chkSkipExisting;
		private System.Windows.Forms.CheckBox chkDestination;
    }
}

