namespace DrawingListUC
{
    partial class DrawingListControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DwgList = new System.Windows.Forms.ListView();
            dwgName = new System.Windows.Forms.ColumnHeader();
            DwgPath = new System.Windows.Forms.ColumnHeader();
            Status = new System.Windows.Forms.ColumnHeader();
            DwgContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            AddDWG = new System.Windows.Forms.ToolStripMenuItem();
            ContextDWGAddFile = new System.Windows.Forms.ToolStripMenuItem();
            ContextDWGAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            RemoveDWG = new System.Windows.Forms.ToolStripMenuItem();
            SkipDWG = new System.Windows.Forms.ToolStripMenuItem();
            chToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            loadDWGListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveDWGListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            failToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            BPbar = new System.Windows.Forms.ProgressBar();
            scriptGBox = new System.Windows.Forms.GroupBox();
            Viewbutton = new System.Windows.Forms.Button();
            ScriptBrowse = new System.Windows.Forms.Button();
            ScriptPath = new System.Windows.Forms.TextBox();
            label_filename = new System.Windows.Forms.Label();
            DwgContextMenu.SuspendLayout();
            scriptGBox.SuspendLayout();
            SuspendLayout();
            // 
            // DwgList
            // 
            DwgList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DwgList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DwgList.CheckBoxes = true;
            DwgList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { dwgName, DwgPath, Status });
            DwgList.ContextMenuStrip = DwgContextMenu;
            DwgList.FullRowSelect = true;
            DwgList.GridLines = true;
            DwgList.Location = new System.Drawing.Point(49, 125);
            DwgList.Name = "DwgList";
            DwgList.Size = new System.Drawing.Size(544, 305);
            DwgList.TabIndex = 3;
            DwgList.UseCompatibleStateImageBehavior = false;
            DwgList.View = System.Windows.Forms.View.Details;
            DwgList.ItemChecked += DwgList_ItemChecked;
            DwgList.SizeChanged += DwgList_SizeChanged;
            // 
            // dwgName
            // 
            dwgName.Text = "Name";
            dwgName.Width = 149;
            // 
            // DwgPath
            // 
            DwgPath.Text = "Path";
            DwgPath.Width = 311;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 61;
            // 
            // DwgContextMenu
            // 
            DwgContextMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            DwgContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { AddDWG, RemoveDWG, SkipDWG, chToolStripMenuItem, toolStripSeparator2, loadDWGListToolStripMenuItem, saveDWGListToolStripMenuItem, toolStripSeparator3, toolStripMenuItem1 });
            DwgContextMenu.Name = "DwgContextMenu";
            DwgContextMenu.Size = new System.Drawing.Size(174, 170);
            DwgContextMenu.Opening += DwgContextMenu_Opening;
            // 
            // AddDWG
            // 
            AddDWG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ContextDWGAddFile, ContextDWGAddFolder });
            AddDWG.Name = "AddDWG";
            AddDWG.Size = new System.Drawing.Size(173, 22);
            AddDWG.Text = "Add";
            // 
            // ContextDWGAddFile
            // 
            ContextDWGAddFile.Name = "ContextDWGAddFile";
            ContextDWGAddFile.Size = new System.Drawing.Size(107, 22);
            ContextDWGAddFile.Text = "Files";
            ContextDWGAddFile.Click += ContextDWGAddFile_Click;
            // 
            // ContextDWGAddFolder
            // 
            ContextDWGAddFolder.Name = "ContextDWGAddFolder";
            ContextDWGAddFolder.Size = new System.Drawing.Size(107, 22);
            ContextDWGAddFolder.Text = "Folder";
            ContextDWGAddFolder.Click += ContextDWGAddFolder_Click;
            // 
            // RemoveDWG
            // 
            RemoveDWG.Name = "RemoveDWG";
            RemoveDWG.Size = new System.Drawing.Size(173, 22);
            RemoveDWG.Text = "Remove";
            RemoveDWG.Click += RemoveDWG_Click;
            // 
            // SkipDWG
            // 
            SkipDWG.Name = "SkipDWG";
            SkipDWG.Size = new System.Drawing.Size(173, 22);
            SkipDWG.Text = "Skip";
            SkipDWG.Click += SkipDWG_Click;
            // 
            // chToolStripMenuItem
            // 
            chToolStripMenuItem.Name = "chToolStripMenuItem";
            chToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            chToolStripMenuItem.Text = "Check\\Uncheck all";
            chToolStripMenuItem.Click += chToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // loadDWGListToolStripMenuItem
            // 
            loadDWGListToolStripMenuItem.Name = "loadDWGListToolStripMenuItem";
            loadDWGListToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            loadDWGListToolStripMenuItem.Text = "&Load DWG list";
            loadDWGListToolStripMenuItem.Click += loadDWGListToolStripMenuItem_Click;
            // 
            // saveDWGListToolStripMenuItem
            // 
            saveDWGListToolStripMenuItem.Name = "saveDWGListToolStripMenuItem";
            saveDWGListToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            saveDWGListToolStripMenuItem.Text = "&Save DWG list";
            saveDWGListToolStripMenuItem.Click += saveDWGListToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, failToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            toolStripMenuItem1.Text = "&Run";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            toolStripMenuItem2.Text = "&Checked";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(120, 22);
            toolStripMenuItem3.Text = "&Selected";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // failToolStripMenuItem
            // 
            failToolStripMenuItem.Name = "failToolStripMenuItem";
            failToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            failToolStripMenuItem.Text = "Failed";
            failToolStripMenuItem.Click += failToolStripMenuItem_Click;
            // 
            // BPbar
            // 
            BPbar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BPbar.ForeColor = System.Drawing.SystemColors.HotTrack;
            BPbar.Location = new System.Drawing.Point(125, 531);
            BPbar.Name = "BPbar";
            BPbar.Size = new System.Drawing.Size(468, 25);
            BPbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            BPbar.TabIndex = 4;
            // 
            // scriptGBox
            // 
            scriptGBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            scriptGBox.Controls.Add(Viewbutton);
            scriptGBox.Controls.Add(ScriptBrowse);
            scriptGBox.Location = new System.Drawing.Point(49, 32);
            scriptGBox.Name = "scriptGBox";
            scriptGBox.Size = new System.Drawing.Size(544, 55);
            scriptGBox.MinimumSize = new System.Drawing.Size(0, 55);
            scriptGBox.TabIndex = 9;
            scriptGBox.TabStop = false;
            scriptGBox.Text = "Script file";
            // 
            // Viewbutton
            // 
            Viewbutton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Viewbutton.BackColor = System.Drawing.SystemColors.Control;
            Viewbutton.Location = new System.Drawing.Point(460, 18);
            Viewbutton.Name = "Viewbutton";
            Viewbutton.Size = new System.Drawing.Size(84, 28);
            Viewbutton.TabIndex = 2;
            Viewbutton.Text = "Edit";
            Viewbutton.UseVisualStyleBackColor = false;
            Viewbutton.Click += Viewbutton_Click;
            // 
            // ScriptBrowse
            // 
            ScriptBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ScriptBrowse.BackColor = System.Drawing.SystemColors.Control;
            ScriptBrowse.Location = new System.Drawing.Point(362, 18);
            ScriptBrowse.Name = "ScriptBrowse";
            ScriptBrowse.Size = new System.Drawing.Size(74, 28);
            ScriptBrowse.TabIndex = 1;
            ScriptBrowse.Text = "Browse";
            ScriptBrowse.UseVisualStyleBackColor = false;
            ScriptBrowse.Click += ScriptBrowse_Click;
            // 
            // ScriptPath
            // 
            ScriptPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ScriptPath.Location = new System.Drawing.Point(49, 93);
            ScriptPath.Name = "ScriptPath";
            ScriptPath.Size = new System.Drawing.Size(544, 23);
            ScriptPath.TabIndex = 0;
            // 
            // label_filename
            // 
            label_filename.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_filename.ForeColor = System.Drawing.Color.DarkRed;
            label_filename.Location = new System.Drawing.Point(49, 531);
            label_filename.Name = "label_filename";
            label_filename.Size = new System.Drawing.Size(70, 25);
            label_filename.TabIndex = 10;
            label_filename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrawingListControl
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label_filename);
            Controls.Add(scriptGBox);
            Controls.Add(ScriptPath);           
            Controls.Add(DwgList);
            Controls.Add(BPbar);
            Name = "DrawingListControl";
            Size = new System.Drawing.Size(701, 696);
            Load += DrawingListControl_Load;
            DwgContextMenu.ResumeLayout(false);
            scriptGBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DwgList;
        private System.Windows.Forms.ColumnHeader dwgName;
        private System.Windows.Forms.ColumnHeader DwgPath;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ProgressBar BPbar;
        private System.Windows.Forms.ContextMenuStrip DwgContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddDWG;
        private System.Windows.Forms.ToolStripMenuItem ContextDWGAddFile;
        private System.Windows.Forms.ToolStripMenuItem ContextDWGAddFolder;
        private System.Windows.Forms.ToolStripMenuItem RemoveDWG;
        private System.Windows.Forms.ToolStripMenuItem SkipDWG;
        private System.Windows.Forms.ToolStripMenuItem chToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem loadDWGListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDWGListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem failToolStripMenuItem;
        private System.Windows.Forms.GroupBox scriptGBox;
        private System.Windows.Forms.Button Viewbutton;
        private System.Windows.Forms.Button ScriptBrowse;
        private System.Windows.Forms.TextBox ScriptPath;
        private System.Windows.Forms.Label label_filename;
    }
}
