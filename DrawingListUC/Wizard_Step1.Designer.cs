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

            ScriptPath = new System.Windows.Forms.TextBox();
            Viewbutton = new System.Windows.Forms.Button();
            ScriptBrowse = new System.Windows.Forms.Button();
            SuspendLayout();

            // 
            // ScriptPath
            // 
            ScriptPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ScriptPath.Location = new System.Drawing.Point(3, 3);
            ScriptPath.Name = "ScriptPath";
            ScriptPath.Size = new System.Drawing.Size(387, 23);
            ScriptPath.TabIndex = 0;
            // 
            // Viewbutton
            // 
            Viewbutton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Viewbutton.Location = new System.Drawing.Point(396, 2);
            Viewbutton.Name = "Viewbutton";
            Viewbutton.Size = new System.Drawing.Size(75, 25);
            Viewbutton.TabIndex = 1;
            Viewbutton.Text = "Edit";
            Viewbutton.UseVisualStyleBackColor = true;
            Viewbutton.Click += Viewbutton_Click;
            // 
            // ScriptBrowse
            // 
            ScriptBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ScriptBrowse.Location = new System.Drawing.Point(477, 2);
            ScriptBrowse.Name = "ScriptBrowse";
            ScriptBrowse.Size = new System.Drawing.Size(75, 25);
            ScriptBrowse.TabIndex = 2;
            ScriptBrowse.Text = "Browse";
            ScriptBrowse.UseVisualStyleBackColor = true;
            ScriptBrowse.Click += ScriptBrowse_Click;
            // 
            // Wizard_Step1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ScriptBrowse);
            Controls.Add(Viewbutton);
            Controls.Add(ScriptPath);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "Wizard_Step1";
            Size = new System.Drawing.Size(555, 30);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Viewbutton;
        private System.Windows.Forms.Button ScriptBrowse;
        private System.Windows.Forms.TextBox ScriptPath;
    }
}
