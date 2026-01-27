namespace DrawingListUC
{
    partial class WizardForm
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
            this.Step1_panel = new System.Windows.Forms.Panel();
            this.Step3_panel = new System.Windows.Forms.Panel();
            this.StartScriptPro = new System.Windows.Forms.Button();
            this.Finish_Button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.label1_step1 = new System.Windows.Forms.Label();
            this.Step2_panel = new System.Windows.Forms.Panel();
            this.label_step2 = new System.Windows.Forms.Label();
            this.label_step3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Step1_panel
            // 
            this.Step1_panel.Location = new System.Drawing.Point(16, 24);
            this.Step1_panel.Name = "Step1_panel";
            this.Step1_panel.Size = new System.Drawing.Size(533, 32);
            this.Step1_panel.TabIndex = 0;
            // 
            // Step3_panel
            // 
            this.Step3_panel.Location = new System.Drawing.Point(16, 394);
            this.Step3_panel.Margin = new System.Windows.Forms.Padding(0);
            this.Step3_panel.Name = "Step3_panel";
            this.Step3_panel.Size = new System.Drawing.Size(533, 134);
            this.Step3_panel.TabIndex = 0;
            // 
            // StartScriptPro
            // 
            this.StartScriptPro.Location = new System.Drawing.Point(403, 535);
            this.StartScriptPro.Name = "StartScriptPro";
            this.StartScriptPro.Size = new System.Drawing.Size(146, 24);
            this.StartScriptPro.TabIndex = 23;
            this.StartScriptPro.Text = "Finish && Start ScriptPro";
            this.StartScriptPro.UseVisualStyleBackColor = true;
            this.StartScriptPro.Click += new System.EventHandler(this.StartScriptPro_Click);
            // 
            // Finish_Button
            // 
            this.Finish_Button.Location = new System.Drawing.Point(323, 535);
            this.Finish_Button.Name = "Finish_Button";
            this.Finish_Button.Size = new System.Drawing.Size(70, 24);
            this.Finish_Button.TabIndex = 22;
            this.Finish_Button.Text = "Finish";
            this.Finish_Button.UseVisualStyleBackColor = true;
            this.Finish_Button.Click += new System.EventHandler(this.Finish_Button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(246, 535);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(69, 24);
            this.Cancel_button.TabIndex = 21;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // label1_step1
            // 
            this.label1_step1.AutoSize = true;
            this.label1_step1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_step1.ForeColor = System.Drawing.Color.Blue;
            this.label1_step1.Location = new System.Drawing.Point(16, 9);
            this.label1_step1.Name = "label1_step1";
            this.label1_step1.Size = new System.Drawing.Size(170, 13);
            this.label1_step1.TabIndex = 24;
            this.label1_step1.Text = "Step 1 : Select the script file";
            this.label1_step1.Click += new System.EventHandler(this.label1_step1_Click);
            // 
            // Step2_panel
            // 
            this.Step2_panel.Location = new System.Drawing.Point(16, 82);
            this.Step2_panel.Margin = new System.Windows.Forms.Padding(0);
            this.Step2_panel.Name = "Step2_panel";
            this.Step2_panel.Size = new System.Drawing.Size(533, 296);
            this.Step2_panel.TabIndex = 0;
            // 
            // label_step2
            // 
            this.label_step2.AutoSize = true;
            this.label_step2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_step2.ForeColor = System.Drawing.Color.Blue;
            this.label_step2.Location = new System.Drawing.Point(16, 61);
            this.label_step2.Name = "label_step2";
            this.label_step2.Size = new System.Drawing.Size(153, 13);
            this.label_step2.TabIndex = 25;
            this.label_step2.Text = "Step 2 : Add drawing files";
            // 
            // label_step3
            // 
            this.label_step3.AutoSize = true;
            this.label_step3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_step3.ForeColor = System.Drawing.Color.Blue;
            this.label_step3.Location = new System.Drawing.Point(16, 381);
            this.label_step3.Name = "label_step3";
            this.label_step3.Size = new System.Drawing.Size(226, 13);
            this.label_step3.TabIndex = 26;
            this.label_step3.Text = "Step 3 : Select the Application version";
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 567);
            this.Controls.Add(this.Step3_panel);
            this.Controls.Add(this.label_step3);
            this.Controls.Add(this.Step2_panel);
            this.Controls.Add(this.label_step2);
            this.Controls.Add(this.label1_step1);
            this.Controls.Add(this.Step1_panel);
            this.Controls.Add(this.StartScriptPro);
            this.Controls.Add(this.Finish_Button);
            this.Controls.Add(this.Cancel_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wizard : 3 simple steps";
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Step1_panel;
        private System.Windows.Forms.Panel Step3_panel;
        private System.Windows.Forms.Button StartScriptPro;
        private System.Windows.Forms.Button Finish_Button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Label label1_step1;
        private System.Windows.Forms.Panel Step2_panel;
        private System.Windows.Forms.Label label_step2;
        private System.Windows.Forms.Label label_step3;
    }
}