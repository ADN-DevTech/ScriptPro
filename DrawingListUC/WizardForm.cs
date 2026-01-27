using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DrawingListUC
{
    public partial class WizardForm : Form
    {
        public WizardForm()
        {
            InitializeComponent();
        }

        Wizard_Step1 step1;
        Wizard_Step2 step2;
        Wizard_step3 step3;

        public List<string> dwgList;
        public string acadPath;
        public string scriptPath;
        public bool startScriptPro = false;


        private void WizardForm_Load(object sender, EventArgs e)
        {
            step1 = new Wizard_Step1();
            step2 = new Wizard_Step2();
            step3 = new Wizard_step3();

            Step1_panel.Controls.Add(step1);
            step1.Dock = DockStyle.Fill;
            Step2_panel.Controls.Add(step2);
            step2.Dock = DockStyle.Fill;
            Step3_panel.Controls.Add(step3);
            step3.Dock = DockStyle.Fill;
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Finish_Button_Click(object sender, EventArgs e)
        {
            scriptPath = step1.scriptFile();
            acadPath = step3.acadPath();

            if (scriptPath.Length == 0)
            {
                MessageBox.Show("Please specify a valid script file.");
                return;
            }

            if (acadPath.Length != 0)
            {
                if (!File.Exists(acadPath))
                {
                    MessageBox.Show("AutoCAD application does not exits");
                    return;
                }
            }

            dwgList = new List<string>();
            step2.populateDWGlist(dwgList);

            startScriptPro = false;
            //now add all the files to main dialog...
            this.DialogResult = DialogResult.OK;
        }

        private void StartScriptPro_Click(object sender, EventArgs e)
        {
            scriptPath = step1.scriptFile();
            acadPath = step3.acadPath();

            if (scriptPath.Length == 0)
            {
                MessageBox.Show("Please specify a valid script file.");
                return;
            }

            if (acadPath.Length != 0)
            {
                if (!File.Exists(acadPath))
                {
                    MessageBox.Show("AutoCAD application does not exits");
                    return;
                }
            }


            dwgList = new List<string>();
            step2.populateDWGlist(dwgList);

            if (dwgList.Count == 0)
            {
                MessageBox.Show("No drawing is selected");
                return;
            }

            startScriptPro = true;
            this.DialogResult = DialogResult.OK;

        }

        private void label1_step1_Click(object sender, EventArgs e)
        {

        }
    }
}
