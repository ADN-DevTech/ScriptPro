using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DrawingListUC
{
    public partial class Wizard_Step2 : UserControl
    {
        public Wizard_Step2()
        {
            InitializeComponent();

            dwgList = new DrawingListControl();

            try
            {
                dwgList.ApplySettings();
            }
            catch
            {
            }
        }

        DrawingListControl dwgList = null;
        
 

        private void Wizard_Step2_Load(object sender, EventArgs e)
        {
            dwgList.Dock = DockStyle.Fill;
            Panel_DWGList.Controls.Add(dwgList);

            dwgList.hideControlsForWizard();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                dwgList.AddDWGFiles();
            }
            catch { }
        }

        private void AddFolder_Click(object sender, EventArgs e)
        {
            try
            {
                dwgList.AddDWGFilesFromFolder();
            }
            catch { }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                dwgList.RemoveSelectedDWG();
            }
            catch { }
        }

        public void populateDWGlist(List<string> list)
        {
            try
            {
                dwgList.populateDWGlist(list);
            }
            catch { }
        }

       
    }
}
