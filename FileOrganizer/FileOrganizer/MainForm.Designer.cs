namespace FileOrganizer
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
			this.sourceOutput = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtSourceDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.outputBrowse = new System.Windows.Forms.Button();
			this.txtOutputDirectory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRun = new System.Windows.Forms.Button();
			this.chkDestination = new System.Windows.Forms.CheckBox();
			this.chkSkipExisting = new System.Windows.Forms.CheckBox();
			this.chkAddDashesToDates = new System.Windows.Forms.CheckBox();
			this.chkUseYearMonthDir = new System.Windows.Forms.CheckBox();
			this.btnSortIndividual = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkSortCopy = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sourceOutput
			// 
			this.sourceOutput.Location = new System.Drawing.Point(579, 42);
			this.sourceOutput.Name = "sourceOutput";
			this.sourceOutput.Size = new System.Drawing.Size(75, 23);
			this.sourceOutput.TabIndex = 0;
			this.sourceOutput.Text = "Browse...";
			this.sourceOutput.UseVisualStyleBackColor = true;
			this.sourceOutput.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtSourceDirectory
			// 
			this.txtSourceDirectory.Location = new System.Drawing.Point(142, 44);
			this.txtSourceDirectory.Name = "txtSourceDirectory";
			this.txtSourceDirectory.Size = new System.Drawing.Size(419, 20);
			this.txtSourceDirectory.TabIndex = 1;
			this.txtSourceDirectory.Text = "C:\\Users\\Zach\\Documents\\Temp\\_Testing\\Input";
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
			// outputBrowse
			// 
			this.outputBrowse.Location = new System.Drawing.Point(579, 71);
			this.outputBrowse.Name = "outputBrowse";
			this.outputBrowse.Size = new System.Drawing.Size(75, 23);
			this.outputBrowse.TabIndex = 3;
			this.outputBrowse.Text = "Browse...";
			this.outputBrowse.UseVisualStyleBackColor = true;
			this.outputBrowse.Click += new System.EventHandler(this.outputBrowse_Click);
			// 
			// txtOutputDirectory
			// 
			this.txtOutputDirectory.Location = new System.Drawing.Point(142, 70);
			this.txtOutputDirectory.Name = "txtOutputDirectory";
			this.txtOutputDirectory.Size = new System.Drawing.Size(419, 20);
			this.txtOutputDirectory.TabIndex = 4;
			this.txtOutputDirectory.Text = "C:\\Users\\Zach\\Documents\\Temp\\_Testing\\Output";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output Directory";
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(142, 105);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(69, 23);
			this.btnRun.TabIndex = 6;
			this.btnRun.Text = "Go";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// chkDestination
			// 
			this.chkDestination.AutoSize = true;
			this.chkDestination.Location = new System.Drawing.Point(434, 111);
			this.chkDestination.Name = "chkDestination";
			this.chkDestination.Size = new System.Drawing.Size(127, 17);
			this.chkDestination.TabIndex = 7;
			this.chkDestination.Text = "Overwrite Destination";
			this.chkDestination.UseVisualStyleBackColor = true;
			// 
			// chkSkipExisting
			// 
			this.chkSkipExisting.AutoSize = true;
			this.chkSkipExisting.Checked = true;
			this.chkSkipExisting.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSkipExisting.Location = new System.Drawing.Point(434, 134);
			this.chkSkipExisting.Name = "chkSkipExisting";
			this.chkSkipExisting.Size = new System.Drawing.Size(86, 17);
			this.chkSkipExisting.TabIndex = 9;
			this.chkSkipExisting.Text = "Skip Existing";
			this.chkSkipExisting.UseVisualStyleBackColor = true;
			// 
			// chkAddDashesToDates
			// 
			this.chkAddDashesToDates.AutoSize = true;
			this.chkAddDashesToDates.Checked = true;
			this.chkAddDashesToDates.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAddDashesToDates.Location = new System.Drawing.Point(434, 158);
			this.chkAddDashesToDates.Name = "chkAddDashesToDates";
			this.chkAddDashesToDates.Size = new System.Drawing.Size(253, 17);
			this.chkAddDashesToDates.TabIndex = 10;
			this.chkAddDashesToDates.Text = "Update \'yyyymmdd\' to \'yyyy-mm-dd\' in Source Dir";
			this.chkAddDashesToDates.UseVisualStyleBackColor = true;
			// 
			// chkUseYearMonthDir
			// 
			this.chkUseYearMonthDir.AutoSize = true;
			this.chkUseYearMonthDir.Checked = true;
			this.chkUseYearMonthDir.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUseYearMonthDir.Location = new System.Drawing.Point(434, 181);
			this.chkUseYearMonthDir.Name = "chkUseYearMonthDir";
			this.chkUseYearMonthDir.Size = new System.Drawing.Size(152, 17);
			this.chkUseYearMonthDir.TabIndex = 11;
			this.chkUseYearMonthDir.Text = "Use \'YYYY-MM\' Sub-folder";
			this.chkUseYearMonthDir.UseVisualStyleBackColor = true;
			// 
			// btnSortIndividual
			// 
			this.btnSortIndividual.Location = new System.Drawing.Point(12, 31);
			this.btnSortIndividual.Name = "btnSortIndividual";
			this.btnSortIndividual.Size = new System.Drawing.Size(88, 23);
			this.btnSortIndividual.TabIndex = 13;
			this.btnSortIndividual.Text = "Sort Individual";
			this.btnSortIndividual.UseVisualStyleBackColor = true;
			this.btnSortIndividual.Click += new System.EventHandler(this.btnSortIndividual_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkSortCopy);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.btnSortIndividual);
			this.groupBox1.Location = new System.Drawing.Point(135, 214);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(473, 112);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Individual File Sorting by Date";
			// 
			// chkSortCopy
			// 
			this.chkSortCopy.AutoSize = true;
			this.chkSortCopy.Location = new System.Drawing.Point(116, 37);
			this.chkSortCopy.Name = "chkSortCopy";
			this.chkSortCopy.Size = new System.Drawing.Size(74, 17);
			this.chkSortCopy.TabIndex = 15;
			this.chkSortCopy.Text = "Copy Files";
			this.chkSortCopy.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.Location = new System.Drawing.Point(12, 68);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(455, 38);
			this.textBox1.TabIndex = 14;
			this.textBox1.Text = "NOTE - Existing files are never overwritten.  Files are moved.  May use \'YYYY-MM\'" +
				" checkbox. Only processes top-level directory.";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 338);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkUseYearMonthDir);
			this.Controls.Add(this.chkAddDashesToDates);
			this.Controls.Add(this.chkSkipExisting);
			this.Controls.Add(this.chkDestination);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtOutputDirectory);
			this.Controls.Add(this.outputBrowse);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtSourceDirectory);
			this.Controls.Add(this.sourceOutput);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sourceOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button outputBrowse;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.CheckBox chkDestination;
		private System.Windows.Forms.CheckBox chkSkipExisting;
		private System.Windows.Forms.CheckBox chkAddDashesToDates;
		private System.Windows.Forms.CheckBox chkUseYearMonthDir;
		private System.Windows.Forms.Button btnSortIndividual;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox chkSortCopy;
    }
}

