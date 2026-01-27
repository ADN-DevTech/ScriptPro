namespace DrawingListUC
{
    partial class OptionsDlg
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
            this.label_timeout = new System.Windows.Forms.Label();
            this.textSeconds = new System.Windows.Forms.TextBox();
            this.IniViewbutton = new System.Windows.Forms.Button();
            this.intScriptGBox = new System.Windows.Forms.GroupBox();
            this.IniScriptBrowse = new System.Windows.Forms.Button();
            this.ScriptPath = new System.Windows.Forms.TextBox();
            this.OptionOK = new System.Windows.Forms.Button();
            this.OptionCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logPathBrowse = new System.Windows.Forms.Button();
            this.ProcessLogFilePath = new System.Windows.Forms.TextBox();
            this.restartAcad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchFolder = new System.Windows.Forms.CheckBox();
            this.groupBox_image = new System.Windows.Forms.GroupBox();
            this.radioButton_none = new System.Windows.Forms.RadioButton();
            this.radioButton_failed = new System.Windows.Forms.RadioButton();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.diagnosticMode = new System.Windows.Forms.CheckBox();
            this.groupBox_exepath = new System.Windows.Forms.GroupBox();
            this.button_exePath = new System.Windows.Forms.Button();
            this.textBox_exePath = new System.Windows.Forms.TextBox();
            this.groupBox_speed = new System.Windows.Forms.GroupBox();
            this.trackBar_speed = new System.Windows.Forms.TrackBar();
            this.OpenDWGFile = new System.Windows.Forms.CheckBox();
            this.UseExeCheckbox = new System.Windows.Forms.CheckBox();
            this.intScriptGBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_image.SuspendLayout();
            this.groupBox_exepath.SuspendLayout();
            this.groupBox_speed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // label_timeout
            // 
            this.label_timeout.AutoSize = true;
            this.label_timeout.Location = new System.Drawing.Point(20, 70);
            this.label_timeout.Name = "label_timeout";
            this.label_timeout.Size = new System.Drawing.Size(233, 13);
            this.label_timeout.TabIndex = 0;
            this.label_timeout.Text = "Process timeout per drawing in seconds ( >= 10)";
            // 
            // textSeconds
            // 
            this.textSeconds.Location = new System.Drawing.Point(267, 67);
            this.textSeconds.Name = "textSeconds";
            this.textSeconds.Size = new System.Drawing.Size(49, 20);
            this.textSeconds.TabIndex = 1;
            this.textSeconds.Text = "30";
            // 
            // IniViewbutton
            // 
            this.IniViewbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IniViewbutton.Location = new System.Drawing.Point(409, 17);
            this.IniViewbutton.Name = "IniViewbutton";
            this.IniViewbutton.Size = new System.Drawing.Size(61, 24);
            this.IniViewbutton.TabIndex = 2;
            this.IniViewbutton.Text = "Edit";
            this.IniViewbutton.UseVisualStyleBackColor = true;
            this.IniViewbutton.Click += new System.EventHandler(this.IniViewbutton_Click);
            // 
            // intScriptGBox
            // 
            this.intScriptGBox.Controls.Add(this.IniViewbutton);
            this.intScriptGBox.Controls.Add(this.IniScriptBrowse);
            this.intScriptGBox.Controls.Add(this.ScriptPath);
            this.intScriptGBox.Location = new System.Drawing.Point(25, 125);
            this.intScriptGBox.Name = "intScriptGBox";
            this.intScriptGBox.Size = new System.Drawing.Size(491, 51);
            this.intScriptGBox.TabIndex = 3;
            this.intScriptGBox.TabStop = false;
            this.intScriptGBox.Text = "AutoCAD startup script file";
            // 
            // IniScriptBrowse
            // 
            this.IniScriptBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IniScriptBrowse.Location = new System.Drawing.Point(349, 17);
            this.IniScriptBrowse.Name = "IniScriptBrowse";
            this.IniScriptBrowse.Size = new System.Drawing.Size(53, 25);
            this.IniScriptBrowse.TabIndex = 1;
            this.IniScriptBrowse.Text = "Browse";
            this.IniScriptBrowse.UseVisualStyleBackColor = true;
            this.IniScriptBrowse.Click += new System.EventHandler(this.IniScriptBrowse_Click);
            // 
            // ScriptPath
            // 
            this.ScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScriptPath.Location = new System.Drawing.Point(23, 20);
            this.ScriptPath.Name = "ScriptPath";
            this.ScriptPath.Size = new System.Drawing.Size(320, 20);
            this.ScriptPath.TabIndex = 0;
            // 
            // OptionOK
            // 
            this.OptionOK.Location = new System.Drawing.Point(302, 352);
            this.OptionOK.Name = "OptionOK";
            this.OptionOK.Size = new System.Drawing.Size(86, 25);
            this.OptionOK.TabIndex = 10;
            this.OptionOK.Text = "OK";
            this.OptionOK.UseVisualStyleBackColor = true;
            this.OptionOK.Click += new System.EventHandler(this.OptionOK_Click);
            // 
            // OptionCancel
            // 
            this.OptionCancel.Location = new System.Drawing.Point(411, 352);
            this.OptionCancel.Name = "OptionCancel";
            this.OptionCancel.Size = new System.Drawing.Size(86, 25);
            this.OptionCancel.TabIndex = 11;
            this.OptionCancel.Text = "Cancel";
            this.OptionCancel.UseVisualStyleBackColor = true;
            this.OptionCancel.Click += new System.EventHandler(this.OptionCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logPathBrowse);
            this.groupBox1.Controls.Add(this.ProcessLogFilePath);
            this.groupBox1.Location = new System.Drawing.Point(25, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 51);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process log folder";
            // 
            // logPathBrowse
            // 
            this.logPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logPathBrowse.Location = new System.Drawing.Point(403, 14);
            this.logPathBrowse.Name = "logPathBrowse";
            this.logPathBrowse.Size = new System.Drawing.Size(67, 25);
            this.logPathBrowse.TabIndex = 1;
            this.logPathBrowse.Text = "Browse";
            this.logPathBrowse.UseVisualStyleBackColor = true;
            this.logPathBrowse.Click += new System.EventHandler(this.logPathBrowse_Click);
            // 
            // ProcessLogFilePath
            // 
            this.ProcessLogFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessLogFilePath.Location = new System.Drawing.Point(23, 17);
            this.ProcessLogFilePath.Name = "ProcessLogFilePath";
            this.ProcessLogFilePath.Size = new System.Drawing.Size(374, 20);
            this.ProcessLogFilePath.TabIndex = 0;
            // 
            // restartAcad
            // 
            this.restartAcad.Location = new System.Drawing.Point(170, 93);
            this.restartAcad.Name = "restartAcad";
            this.restartAcad.Size = new System.Drawing.Size(49, 20);
            this.restartAcad.TabIndex = 2;
            this.restartAcad.Text = "30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Restart AutoCAD after every ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "drawings (>= 1)";
            // 
            // searchFolder
            // 
            this.searchFolder.AutoSize = true;
            this.searchFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchFolder.Location = new System.Drawing.Point(25, 308);
            this.searchFolder.Name = "searchFolder";
            this.searchFolder.Size = new System.Drawing.Size(218, 17);
            this.searchFolder.TabIndex = 7;
            this.searchFolder.Text = "Select DWG/DXF files in sub directories ";
            this.searchFolder.UseVisualStyleBackColor = true;
            // 
            // groupBox_image
            // 
            this.groupBox_image.Controls.Add(this.radioButton_none);
            this.groupBox_image.Controls.Add(this.radioButton_failed);
            this.groupBox_image.Controls.Add(this.radioButton_all);
            this.groupBox_image.Location = new System.Drawing.Point(24, 243);
            this.groupBox_image.Name = "groupBox_image";
            this.groupBox_image.Size = new System.Drawing.Size(257, 59);
            this.groupBox_image.TabIndex = 5;
            this.groupBox_image.TabStop = false;
            this.groupBox_image.Text = "Create image before closing the drawing file";
            // 
            // radioButton_none
            // 
            this.radioButton_none.AutoSize = true;
            this.radioButton_none.Checked = true;
            this.radioButton_none.Location = new System.Drawing.Point(176, 25);
            this.radioButton_none.Name = "radioButton_none";
            this.radioButton_none.Size = new System.Drawing.Size(51, 17);
            this.radioButton_none.TabIndex = 2;
            this.radioButton_none.TabStop = true;
            this.radioButton_none.Text = "None";
            this.radioButton_none.UseVisualStyleBackColor = true;
            // 
            // radioButton_failed
            // 
            this.radioButton_failed.AutoSize = true;
            this.radioButton_failed.Location = new System.Drawing.Point(77, 26);
            this.radioButton_failed.Name = "radioButton_failed";
            this.radioButton_failed.Size = new System.Drawing.Size(98, 17);
            this.radioButton_failed.TabIndex = 1;
            this.radioButton_failed.Text = "Only Failed files";
            this.radioButton_failed.UseVisualStyleBackColor = true;
            // 
            // radioButton_all
            // 
            this.radioButton_all.AutoSize = true;
            this.radioButton_all.Location = new System.Drawing.Point(17, 26);
            this.radioButton_all.Name = "radioButton_all";
            this.radioButton_all.Size = new System.Drawing.Size(57, 17);
            this.radioButton_all.TabIndex = 0;
            this.radioButton_all.Text = "All files";
            this.radioButton_all.UseVisualStyleBackColor = true;
            // 
            // diagnosticMode
            // 
            this.diagnosticMode.AutoSize = true;
            this.diagnosticMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diagnosticMode.Location = new System.Drawing.Point(289, 308);
            this.diagnosticMode.Name = "diagnosticMode";
            this.diagnosticMode.Size = new System.Drawing.Size(181, 17);
            this.diagnosticMode.TabIndex = 8;
            this.diagnosticMode.Text = "Run the tool in diagnostic  mode ";
            this.diagnosticMode.UseVisualStyleBackColor = true;
            // 
            // groupBox_exepath
            // 
            this.groupBox_exepath.Controls.Add(this.button_exePath);
            this.groupBox_exepath.Controls.Add(this.textBox_exePath);
            this.groupBox_exepath.Location = new System.Drawing.Point(25, 9);
            this.groupBox_exepath.Name = "groupBox_exepath";
            this.groupBox_exepath.Size = new System.Drawing.Size(491, 51);
            this.groupBox_exepath.TabIndex = 0;
            this.groupBox_exepath.TabStop = false;
            this.groupBox_exepath.Text = "AutoCAD application to use";
            // 
            // button_exePath
            // 
            this.button_exePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exePath.Location = new System.Drawing.Point(409, 15);
            this.button_exePath.Name = "button_exePath";
            this.button_exePath.Size = new System.Drawing.Size(63, 25);
            this.button_exePath.TabIndex = 1;
            this.button_exePath.Text = "Browse";
            this.button_exePath.UseVisualStyleBackColor = true;
            this.button_exePath.Click += new System.EventHandler(this.button_exePath_Click);
            // 
            // textBox_exePath
            // 
            this.textBox_exePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_exePath.Location = new System.Drawing.Point(23, 18);
            this.textBox_exePath.Name = "textBox_exePath";
            this.textBox_exePath.Size = new System.Drawing.Size(376, 20);
            this.textBox_exePath.TabIndex = 0;
            this.textBox_exePath.Leave += new System.EventHandler(this.textBox_exePath_Leave);
            // 
            // groupBox_speed
            // 
            this.groupBox_speed.Controls.Add(this.trackBar_speed);
            this.groupBox_speed.Location = new System.Drawing.Point(289, 243);
            this.groupBox_speed.Name = "groupBox_speed";
            this.groupBox_speed.Size = new System.Drawing.Size(227, 59);
            this.groupBox_speed.TabIndex = 6;
            this.groupBox_speed.TabStop = false;
            this.groupBox_speed.Text = "Delay during process (Seconds)";
            // 
            // trackBar_speed
            // 
            this.trackBar_speed.LargeChange = 1;
            this.trackBar_speed.Location = new System.Drawing.Point(13, 15);
            this.trackBar_speed.Name = "trackBar_speed";
            this.trackBar_speed.Size = new System.Drawing.Size(195, 42);
            this.trackBar_speed.TabIndex = 0;
            this.trackBar_speed.Scroll += new System.EventHandler(this.trackBar_speed_Scroll);
            // 
            // OpenDWGFile
            // 
            this.OpenDWGFile.AutoSize = true;
            this.OpenDWGFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenDWGFile.Location = new System.Drawing.Point(26, 331);
            this.OpenDWGFile.Name = "OpenDWGFile";
            this.OpenDWGFile.Size = new System.Drawing.Size(217, 17);
            this.OpenDWGFile.TabIndex = 9;
            this.OpenDWGFile.Text = "Run script without opening drawing file   ";
            this.OpenDWGFile.UseVisualStyleBackColor = true;
            // 
            // UseExeCheckbox
            // 
            this.UseExeCheckbox.AutoSize = true;
            this.UseExeCheckbox.Location = new System.Drawing.Point(23, 360);
            this.UseExeCheckbox.Name = "UseExeCheckbox";
            this.UseExeCheckbox.Size = new System.Drawing.Size(268, 17);
            this.UseExeCheckbox.TabIndex = 12;
            this.UseExeCheckbox.Text = "Use script as commandline argument for application";
            this.UseExeCheckbox.UseVisualStyleBackColor = true;
            this.UseExeCheckbox.Visible = false;
            this.UseExeCheckbox.CheckedChanged += new System.EventHandler(this.UseExeCheckbox_CheckedChanged);
            // 
            // OptionsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 392);
            this.Controls.Add(this.UseExeCheckbox);
            this.Controls.Add(this.OpenDWGFile);
            this.Controls.Add(this.groupBox_speed);
            this.Controls.Add(this.groupBox_exepath);
            this.Controls.Add(this.diagnosticMode);
            this.Controls.Add(this.groupBox_image);
            this.Controls.Add(this.searchFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restartAcad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OptionCancel);
            this.Controls.Add(this.OptionOK);
            this.Controls.Add(this.intScriptGBox);
            this.Controls.Add(this.textSeconds);
            this.Controls.Add(this.label_timeout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDlg_Load);
            this.intScriptGBox.ResumeLayout(false);
            this.intScriptGBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_image.ResumeLayout(false);
            this.groupBox_image.PerformLayout();
            this.groupBox_exepath.ResumeLayout(false);
            this.groupBox_exepath.PerformLayout();
            this.groupBox_speed.ResumeLayout(false);
            this.groupBox_speed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_timeout;
        private System.Windows.Forms.TextBox textSeconds;
        private System.Windows.Forms.Button IniViewbutton;
        private System.Windows.Forms.GroupBox intScriptGBox;
        private System.Windows.Forms.Button IniScriptBrowse;
        private System.Windows.Forms.TextBox ScriptPath;
        private System.Windows.Forms.Button OptionOK;
        private System.Windows.Forms.Button OptionCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button logPathBrowse;
        private System.Windows.Forms.TextBox ProcessLogFilePath;
        private System.Windows.Forms.TextBox restartAcad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox searchFolder;
        private System.Windows.Forms.GroupBox groupBox_image;
        private System.Windows.Forms.RadioButton radioButton_failed;
        private System.Windows.Forms.RadioButton radioButton_all;
        private System.Windows.Forms.RadioButton radioButton_none;
        private System.Windows.Forms.CheckBox diagnosticMode;
        private System.Windows.Forms.GroupBox groupBox_exepath;
        private System.Windows.Forms.Button button_exePath;
        private System.Windows.Forms.TextBox textBox_exePath;
        private System.Windows.Forms.GroupBox groupBox_speed;
        private System.Windows.Forms.TrackBar trackBar_speed;
        private System.Windows.Forms.CheckBox OpenDWGFile;
        private System.Windows.Forms.CheckBox UseExeCheckbox;
    }
}