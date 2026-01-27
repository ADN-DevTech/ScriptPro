namespace DrawingListUC
{
    partial class Wizard_step3
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
            this.button_exePath = new System.Windows.Forms.Button();
            this.textBox_exePath = new System.Windows.Forms.TextBox();
            this.listView_acadPaths = new System.Windows.Forms.ListView();
            this.Productcolumn = new System.Windows.Forms.ColumnHeader();
            this.ExePath = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // button_exePath
            // 
            this.button_exePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exePath.Location = new System.Drawing.Point(458, 7);
            this.button_exePath.Name = "button_exePath";
            this.button_exePath.Size = new System.Drawing.Size(67, 24);
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
            this.textBox_exePath.Location = new System.Drawing.Point(3, 10);
            this.textBox_exePath.Name = "textBox_exePath";
            this.textBox_exePath.Size = new System.Drawing.Size(449, 20);
            this.textBox_exePath.TabIndex = 0;
            this.textBox_exePath.TextChanged += new System.EventHandler(this.textBox_exePath_TextChanged);
            // 
            // listView_acadPaths
            // 
            this.listView_acadPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_acadPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Productcolumn,
            this.ExePath});
            this.listView_acadPaths.FullRowSelect = true;
            this.listView_acadPaths.GridLines = true;
            this.listView_acadPaths.HideSelection = false;
            this.listView_acadPaths.Location = new System.Drawing.Point(3, 40);
            this.listView_acadPaths.MultiSelect = false;
            this.listView_acadPaths.Name = "listView_acadPaths";
            this.listView_acadPaths.Size = new System.Drawing.Size(522, 118);
            this.listView_acadPaths.TabIndex = 2;
            this.listView_acadPaths.UseCompatibleStateImageBehavior = false;
            this.listView_acadPaths.View = System.Windows.Forms.View.Details;
            this.listView_acadPaths.SelectedIndexChanged += new System.EventHandler(this.listView_acadPaths_SelectedIndexChanged);
            // 
            // Productcolumn
            // 
            this.Productcolumn.Text = "Product";
            this.Productcolumn.Width = 77;
            // 
            // ExePath
            // 
            this.ExePath.Text = "Path";
            this.ExePath.Width = 378;
            // 
            // Wizard_step3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_acadPaths);
            this.Controls.Add(this.button_exePath);
            this.Controls.Add(this.textBox_exePath);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Wizard_step3";
            this.Size = new System.Drawing.Size(528, 161);
            this.Load += new System.EventHandler(this.Wizard_step3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_exePath;
        private System.Windows.Forms.TextBox textBox_exePath;
        private System.Windows.Forms.ListView listView_acadPaths;
        private System.Windows.Forms.ColumnHeader Productcolumn;
        private System.Windows.Forms.ColumnHeader ExePath;
    }
}
