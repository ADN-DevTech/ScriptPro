namespace DrawingListUC
{
    partial class Wizard_Step1
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
            Viewbutton = new System.Windows.Forms.Button();
            ScriptBrowse = new System.Windows.Forms.Button();
            ScriptPath = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // Viewbutton
            // 
            Viewbutton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Viewbutton.BackColor = System.Drawing.SystemColors.Control;
            Viewbutton.Location = new System.Drawing.Point(1295, 22);
            Viewbutton.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            Viewbutton.Name = "Viewbutton";
            Viewbutton.Size = new System.Drawing.Size(190, 76);
            Viewbutton.TabIndex = 2;
            Viewbutton.Text = "Edit";
            Viewbutton.UseVisualStyleBackColor = false;
            Viewbutton.Click += Viewbutton_Click;
            // 
            // ScriptBrowse
            // 
            ScriptBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ScriptBrowse.BackColor = System.Drawing.SystemColors.Control;
            ScriptBrowse.Location = new System.Drawing.Point(1085, 22);
            ScriptBrowse.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            ScriptBrowse.Name = "ScriptBrowse";
            ScriptBrowse.Size = new System.Drawing.Size(190, 76);
            ScriptBrowse.TabIndex = 1;
            ScriptBrowse.Text = "Browse";
            ScriptBrowse.UseVisualStyleBackColor = false;
            ScriptBrowse.Click += ScriptBrowse_Click;
            // 
            // ScriptPath
            // 
            ScriptPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ScriptPath.Location = new System.Drawing.Point(16, 37);
            ScriptPath.Margin = new System.Windows.Forms.Padding(0);
            ScriptPath.Name = "ScriptPath";
            ScriptPath.Size = new System.Drawing.Size(1047, 47);
            ScriptPath.TabIndex = 0;
            // 
            // Wizard_Step1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(Viewbutton);
            Controls.Add(ScriptBrowse);
            Controls.Add(ScriptPath);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "Wizard_Step1";
            Size = new System.Drawing.Size(1496, 145);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Viewbutton;
        private System.Windows.Forms.Button ScriptBrowse;
        private System.Windows.Forms.TextBox ScriptPath;
    }
}
