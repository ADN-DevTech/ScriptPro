using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace DrawingListUC
{
    public partial class Wizard_step3 : UserControl
    {
        public Wizard_step3()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        }

        public string acadPath()
        {
            return textBox_exePath.Text;
        }


        internal static void GetAcadInstallPaths(List<string> productList, List<string> pathList)
        {
            string value = string.Empty;
            RegistryKey localMac = Registry.LocalMachine;
            RegistryKey registrySubKey = localMac.OpenSubKey(@"Software\Autodesk\AutoCAD\");

            if (registrySubKey != null)
            {
                string[] SubKeyNames = registrySubKey.GetSubKeyNames();

                foreach (string subKeyName in SubKeyNames)
                {
                    RegistryKey key = registrySubKey.OpenSubKey(subKeyName);
                    if (key != null)
                    {
                        string[] keyNames = key.GetSubKeyNames();

                        foreach (string keyName in keyNames)
                        {
                            RegistryKey location = key.OpenSubKey(keyName);
                            if (location != null)
                            {
                                object regKey = location.GetValue("AcadLocation");
                                if (regKey != null)
                                {
                                    string path = regKey.ToString();
                                    string acad = Path.Combine(path, "acad.exe");  


                                    if (File.Exists(acad))
                                    {
                                        pathList.Add(acad);

                                        string prodName = string.Empty;
                                        regKey = location.GetValue("ProductName");
                                        if (regKey != null)
                                        {
                                            prodName = regKey.ToString();
                                            productList.Add(prodName);
                                        }

                                        acad = Path.Combine(path, "accoreconsole.exe"); 

                                        if (File.Exists(acad))
                                        {
                                            pathList.Add(acad);
                                            productList.Add(prodName + " " + "Accoreconsole");
                                        }
                                    }
                                }
                            }
                            location.Close();

                        }
                        key.Close();
                    }
                }

                registrySubKey.Close();
            }
        }

        private void Wizard_step3_Load(object sender, EventArgs e)
        {
            //go through the system and find all acad.exe...
            List <string> pathList = new List<string>();
            List<string> ProductList = new List<string>();

            try
            {
                GetAcadInstallPaths(ProductList, pathList);

                //populate
                int nIndex = 0;
                foreach (string acad in ProductList)
                {
                    ListViewItem item = new ListViewItem(acad, 0);
                    item.SubItems.Add(pathList[nIndex]);
                    item.Tag = pathList[nIndex];
                    nIndex++;
                    
                    
                    listView_acadPaths.Items.Add(item);
                }

                if (listView_acadPaths.Items.Count != 0)
                {
                    listView_acadPaths.Items[0].Selected = true;
                    textBox_exePath.Text = listView_acadPaths.Items[0].Tag as string;
                }

                int width = listView_acadPaths.Width;
                listView_acadPaths.Columns[0].Width = (int)(width * 0.25);
                listView_acadPaths.Columns[1].Width = (int)(width * 0.72);
            }
            catch
            {
            }
        }

        


        private void button_exePath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog FileOpenDlg = new OpenFileDialog
                {
                    Filter = "AutoCAD application (*.exe) |*.exe;"
                };
                if (FileOpenDlg.ShowDialog() == DialogResult.OK)
                {
                    textBox_exePath.Text = FileOpenDlg.FileName;
                }
            }
            catch { }
        }

        private void listView_acadPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView_acadPaths.SelectedItems.Count != 0)
                textBox_exePath.Text = listView_acadPaths.SelectedItems[0].Tag as string;
        }

        private void textBox_exePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
