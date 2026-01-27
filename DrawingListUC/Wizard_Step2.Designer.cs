namespace DrawingListUC
{
    partial class Wizard_Step2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wizard_Step2));
            Step2_toolStrip1 = new System.Windows.Forms.ToolStrip();
            AddButton = new System.Windows.Forms.ToolStripButton();
            AddFolder = new System.Windows.Forms.ToolStripButton();
            RemoveButton = new System.Windows.Forms.ToolStripButton();
            Panel_DWGList = new System.Windows.Forms.Panel();
            Step2_toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Step2_toolStrip1
            // 
            Step2_toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            Step2_toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { AddButton, AddFolder, RemoveButton });
            Step2_toolStrip1.Location = new System.Drawing.Point(0, 0);
            Step2_toolStrip1.Name = "Step2_toolStrip1";
            Step2_toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            Step2_toolStrip1.Size = new System.Drawing.Size(1655, 84);
            Step2_toolStrip1.TabIndex = 0;
            Step2_toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            AddButton.Image = (System.Drawing.Image)resources.GetObject("AddButton.Image");
            AddButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            AddButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(77, 77);
            AddButton.Text = "Add";
            AddButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            AddButton.ToolTipText = "Add DWG files";
            AddButton.Click += AddButton_Click;
            // 
            // AddFolder
            // 
            AddFolder.Image = (System.Drawing.Image)resources.GetObject("AddFolder.Image");
            AddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            AddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            AddFolder.Name = "AddFolder";
            AddFolder.Size = new System.Drawing.Size(234, 77);
            AddFolder.Text = "Add from folder";
            AddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            AddFolder.ToolTipText = "Add from folder";
            AddFolder.Click += AddFolder_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Image = (System.Drawing.Image)resources.GetObject("RemoveButton.Image");
            RemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            RemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new System.Drawing.Size(129, 77);
            RemoveButton.Text = "Remove";
            RemoveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // Panel_DWGList
            // 
            Panel_DWGList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Panel_DWGList.Location = new System.Drawing.Point(8, 90);
            Panel_DWGList.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            Panel_DWGList.Name = "Panel_DWGList";
            Panel_DWGList.Size = new System.Drawing.Size(1638, 777);
            Panel_DWGList.TabIndex = 1;
            // 
            // Wizard_Step2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(Panel_DWGList);
            Controls.Add(Step2_toolStrip1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "Wizard_Step2";
            Size = new System.Drawing.Size(1655, 877);
            Load += Wizard_Step2_Load;
            Step2_toolStrip1.ResumeLayout(false);
            Step2_toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Step2_toolStrip1;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton AddFolder;
        private System.Windows.Forms.ToolStripButton RemoveButton;
        private System.Windows.Forms.Panel Panel_DWGList;
    }
}
