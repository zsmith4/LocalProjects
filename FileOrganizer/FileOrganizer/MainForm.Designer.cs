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
            this.txtSourceDirectory.Text = "C:\\Users\\Zach\\Photos\\_Testing\\Input";
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
            this.txtOutputDirectory.Text = "C:\\Users\\Zach\\Photos\\_Testing\\Output";
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
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run...";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 160);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.outputBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.sourceOutput);
            this.Name = "MainForm";
            this.Text = "Form1";
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
    }
}

