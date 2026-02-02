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
            Step1_panel = new System.Windows.Forms.Panel();
            Step3_panel = new System.Windows.Forms.Panel();
            StartScriptPro = new System.Windows.Forms.Button();
            Finish_Button = new System.Windows.Forms.Button();
            Cancel_button = new System.Windows.Forms.Button();
            label1_step1 = new System.Windows.Forms.Label();
            Step2_panel = new System.Windows.Forms.Panel();
            label_step2 = new System.Windows.Forms.Label();
            label_step3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // Step1_panel
            // 
            Step1_panel.Location = new System.Drawing.Point(19, 28);
            Step1_panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Step1_panel.Name = "Step1_panel";
            Step1_panel.Size = new System.Drawing.Size(622, 37);
            Step1_panel.TabIndex = 0;
            // 
            // Step3_panel
            // 
            Step3_panel.Location = new System.Drawing.Point(19, 455);
            Step3_panel.Margin = new System.Windows.Forms.Padding(0);
            Step3_panel.Name = "Step3_panel";
            Step3_panel.Size = new System.Drawing.Size(622, 155);
            Step3_panel.TabIndex = 0;
            // 
            // StartScriptPro
            // 
            StartScriptPro.Location = new System.Drawing.Point(470, 617);
            StartScriptPro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            StartScriptPro.Name = "StartScriptPro";
            StartScriptPro.Size = new System.Drawing.Size(170, 28);
            StartScriptPro.TabIndex = 23;
            StartScriptPro.Text = "Finish && Start ScriptPro";
            StartScriptPro.UseVisualStyleBackColor = true;
            StartScriptPro.Click += StartScriptPro_Click;
            // 
            // Finish_Button
            // 
            Finish_Button.Location = new System.Drawing.Point(377, 617);
            Finish_Button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Finish_Button.Name = "Finish_Button";
            Finish_Button.Size = new System.Drawing.Size(82, 28);
            Finish_Button.TabIndex = 22;
            Finish_Button.Text = "Finish";
            Finish_Button.UseVisualStyleBackColor = true;
            Finish_Button.Click += Finish_Button_Click;
            // 
            // Cancel_button
            // 
            Cancel_button.Location = new System.Drawing.Point(287, 617);
            Cancel_button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Cancel_button.Name = "Cancel_button";
            Cancel_button.Size = new System.Drawing.Size(80, 28);
            Cancel_button.TabIndex = 21;
            Cancel_button.Text = "Cancel";
            Cancel_button.UseVisualStyleBackColor = true;
            Cancel_button.Click += Cancel_button_Click;
            // 
            // label1_step1
            // 
            label1_step1.AutoSize = true;
            label1_step1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1_step1.ForeColor = System.Drawing.Color.Blue;
            label1_step1.Location = new System.Drawing.Point(19, 10);
            label1_step1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1_step1.Name = "label1_step1";
            label1_step1.Size = new System.Drawing.Size(170, 13);
            label1_step1.TabIndex = 24;
            label1_step1.Text = "Step 1 : Select the script file";
            label1_step1.Click += label1_step1_Click;
            // 
            // Step2_panel
            // 
            Step2_panel.Location = new System.Drawing.Point(19, 95);
            Step2_panel.Margin = new System.Windows.Forms.Padding(0);
            Step2_panel.Name = "Step2_panel";
            Step2_panel.Size = new System.Drawing.Size(622, 342);
            Step2_panel.TabIndex = 0;
            // 
            // label_step2
            // 
            label_step2.AutoSize = true;
            label_step2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_step2.ForeColor = System.Drawing.Color.Blue;
            label_step2.Location = new System.Drawing.Point(19, 70);
            label_step2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_step2.Name = "label_step2";
            label_step2.Size = new System.Drawing.Size(153, 13);
            label_step2.TabIndex = 25;
            label_step2.Text = "Step 2 : Add drawing files";
            // 
            // label_step3
            // 
            label_step3.AutoSize = true;
            label_step3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label_step3.ForeColor = System.Drawing.Color.Blue;
            label_step3.Location = new System.Drawing.Point(19, 440);
            label_step3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_step3.Name = "label_step3";
            label_step3.Size = new System.Drawing.Size(226, 13);
            label_step3.TabIndex = 26;
            label_step3.Text = "Step 3 : Select the Application version";
            // 
            // WizardForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(670, 654);
            Controls.Add(Step3_panel);
            Controls.Add(label_step3);
            Controls.Add(Step2_panel);
            Controls.Add(label_step2);
            Controls.Add(label1_step1);
            Controls.Add(Step1_panel);
            Controls.Add(StartScriptPro);
            Controls.Add(Finish_Button);
            Controls.Add(Cancel_button);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WizardForm";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Wizard : 3 simple steps";
            Load += WizardForm_Load;
            ResumeLayout(false);
            PerformLayout();

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