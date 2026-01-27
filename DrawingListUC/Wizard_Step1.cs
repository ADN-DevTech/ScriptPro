using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DrawingListUC
{
    public partial class Wizard_Step1 : UserControl
    {
        public Wizard_Step1()
        {
            InitializeComponent();
        }

        private void ScriptBrowse_Click(object sender, EventArgs e)
        {
            try{
                OpenFileDialog BPFileOpenDlg = new OpenFileDialog();
                BPFileOpenDlg.Filter = "Script (*.scr) |*.scr;";

                if (BPFileOpenDlg.ShowDialog() == DialogResult.OK)
                {
                    ScriptPath.Text = BPFileOpenDlg.FileName;
                }
            }catch{}
        }

        private void Viewbutton_Click(object sender, EventArgs e)
        {
            try{
            Process notePad = new Process();
            notePad.StartInfo.FileName = "notepad.exe";

            // Find if the file present

            if (File.Exists(ScriptPath.Text))
                notePad.StartInfo.Arguments = ScriptPath.Text;
            notePad.Start();
            }
            catch { }
        }

        public string scriptFile()
        {
            return ScriptPath.Text;
        }
    }
}
