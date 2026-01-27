using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Application = System.Windows.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ScriptUI
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DWGControl.HostApplication = this;
            try
            {
                RegistryKey key = Registry.ClassesRoot.CreateSubKey(".bpl");
                key.SetValue(
                  "", "BPL", RegistryValueKind.String
                );
                key.Close();

                key = Registry.ClassesRoot.CreateSubKey(
                  "BPL\\shell\\open\\command"
                );
                key.SetValue(
                  "", "\"" +
                  System.Reflection.Assembly.GetExecutingAssembly().Location
                  + "\"" + "\"\"%l\"\"",
                  Microsoft.Win32.RegistryValueKind.String
                );
                key.Close();

                key = Registry.ClassesRoot.CreateSubKey("BPL\\DefaultIcon");
                key.SetValue(
                  "",
                  System.Reflection.Assembly.GetExecutingAssembly().Location
                  + ",-32512"
                );
                key.Close();
            }
            catch { }
        }

        /// <summary>
        /// Defines the _IsProcessRunning.
        /// </summary>
        private bool _IsProcessRunning = false;

        /// <summary>
        /// Defines the _toolTitle.
        /// </summary>
        private const string _toolTitle = "ScriptPro";

        /// <summary>
        /// The RibbonWindow_Loaded.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MessageFilter.Register();
            try
            {
                if (!String.IsNullOrEmpty(DWGControl.ProjectName))
                    this.Title =
                      _toolTitle + "  -  " + DWGControl.ProjectName;

                // Disable the stop button...

                StopProcess.IsEnabled = false;


                DWGControl.DoInitialize();
            }
            catch { }
        }

        /// <summary>
        /// The RibbonWindow_Closing.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.ComponentModel.CancelEventArgs"/>.</param>
        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MessageBoxResult result = SaveDrawingList();
                if (result == MessageBoxResult.Cancel)
                    e.Cancel = true;
            }
            catch
            {
            }
            MessageFilter.Revoke();
        }

        /// <summary>
        /// The NewList_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void NewList_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (_IsProcessRunning)
                    return;

                MessageBoxResult result = SaveDrawingList();
                if (result == MessageBoxResult.Cancel)
                    return;

                DWGControl.newDWGList();
                this.Title = _toolTitle;
            }
            catch
            {
            }
        }

        /// <summary>
        /// The WizardList_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void WizardList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;
                MessageBoxResult result = SaveDrawingList();
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                DWGControl.wizardDWGList();
            }
            catch
            {

            }
        }

        /// <summary>
        /// The LoadList_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void LoadList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;

                MessageBoxResult result = SaveDrawingList();
                if (result == MessageBoxResult.Cancel)
                    return;

                DWGControl.loadDWGList();

                if (!String.IsNullOrEmpty(DWGControl.ProjectName))
                    this.Title =
                      _toolTitle + "  -  " + DWGControl.ProjectName;
            }
            catch { }
        }

        /// <summary>
        /// The SaveList_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void SaveList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;

                DWGControl.saveDWGList(false);

                if (!String.IsNullOrEmpty(DWGControl.ProjectName))
                    Title =
                      _toolTitle + "  -  " + DWGControl.ProjectName;
            }
            catch { }
        }

        /// <summary>
        /// The SaveAsList_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void SaveAsList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;

                DWGControl.saveDWGList(true);

                if (DWGControl.ProjectName.Length != 0)
                    this.Title =
                      _toolTitle + "  -  " + DWGControl.ProjectName;
            }
            catch { }
        }

        /// <summary>
        /// The LoadSCP_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void LoadSCP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }
                MessageBoxResult result = SaveDrawingList();
                if (result == MessageBoxResult.Cancel) { return; }
                DWGControl.loadFromSCPfile();
            }
            catch { }
        }

        /// <summary>
        /// The AddDWGFile_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void AddDWGFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;

                this.DWGControl.AddDWGFiles();
            }
            catch { }
        }

        /// <summary>
        /// The AddDWGFolder_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void AddDWGFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                this.DWGControl.AddDWGFilesFromFolder();
            }
            catch { }
        }

        /// <summary>
        /// The RemoveDWG_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RemoveDWG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                DWGControl.RemoveSelectedDWG();
            }
            catch { }
        }

        /// <summary>
        /// The SkipDWG_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void SkipDWG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                    return;

                DWGControl.SkipSelectedDWG();
            }
            catch { }
        }

        /// <summary>
        /// The RunChecked_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RunChecked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                DWGControl.runCheckedFiles();
            }
            catch { }
        }

        /// <summary>
        /// The RunSelected_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RunSelected_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                DWGControl.runSelectedFiles();
            }
            catch { }
        }

        /// <summary>
        /// The RunFailed_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void RunFailed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                DWGControl.runFailedFiles();
            }
            catch { }
        }

        /// <summary>
        /// The StopProcess_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void StopProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DWGControl.stopProcess();
            }
            catch { }
        }

        /// <summary>
        /// The ProcessOptions_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void ProcessOptions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_IsProcessRunning)
                {
                    return;
                }

                DWGControl.setOptions();
            }
            catch { }
        }

        /// <summary>
        /// The ProcessHelp_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/>.</param>
        private void ProcessHelp_Click(object sender, RoutedEventArgs e)
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            bool helpFileFound = false;
            string exeFolder = System.IO.Path.GetDirectoryName(exePath);
            _ = System.IO.Directory.GetDirectoryRoot(exePath);
            string helpFile = "";

            try
            {
                // Try Modern.Help.html first, then fall back to ScriptPro2.htm
                helpFile = exeFolder + "\\" + "Modern.Help.html";
                if (System.IO.File.Exists(helpFile))
                {
                    helpFileFound = true;
                }
                else
                {
                    // Try ScriptPro2.htm as fallback
                    helpFile = exeFolder + "\\" + "ScriptPro2.htm";
                    if (System.IO.File.Exists(helpFile))
                    {
                        helpFileFound = true;
                    }
                    else
                    {
                        // Go one directory above and try again
                        exeFolder = System.IO.Directory.GetParent(exeFolder).FullName;
                        helpFile = exeFolder + "\\" + "Modern.Help.html";
                        if (System.IO.File.Exists(helpFile))
                        {
                            helpFileFound = true;
                        }
                        else
                        {
                            helpFile = exeFolder + "\\" + "ScriptPro2.htm";
                            if (System.IO.File.Exists(helpFile))
                            {
                                helpFileFound = true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            if (helpFileFound)
            {
                try
                {
                    // .NET 8.0 requires ProcessStartInfo with UseShellExecute = true
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = helpFile,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to open help file: {ex.Message}\n\nFile: {helpFile}",
                        _toolTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                string strFolder =
                  System.IO.Path.GetDirectoryName(exePath);
                _ = MessageBox.Show(
                  "ReadMe.txt file not found at location " + strFolder,
                  _toolTitle
                );
            }
        }

        /// <summary>
        /// The SaveDrawingList.
        /// </summary>
        /// <returns>The <see cref="MessageBoxResult"/>.</returns>
        private MessageBoxResult SaveDrawingList()
        {
            MessageBoxResult result = MessageBoxResult.None;
            try
            {
                if (DWGControl.Modified)
                {
                    result =
                      (MessageBoxResult)MessageBox.Show(
                        "Drawing list is modified. Do you want to save?",
                        _toolTitle, (MessageBoxButtons)MessageBoxButton.YesNoCancel
                      );

                    if (result == MessageBoxResult.Cancel)
                    {
                        return result;
                    }

                    if (result == MessageBoxResult.Yes)
                    {
                        DWGControl.saveDWGList(false);
                    }
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// The UpdateUI.
        /// </summary>
        /// <param name="enabled">The enabled<see cref="bool"/>.</param>
        private void UpdateUI(bool enabled)
        {
            try
            {
                NewList.IsEnabled = enabled;
                WizardList.IsEnabled = enabled;
                LoadList.IsEnabled = enabled;
                SaveList.IsEnabled = enabled;
                SaveAsList.IsEnabled = enabled;
                LoadSCP.IsEnabled = enabled;

                AddDWGFile.IsEnabled = enabled;
                AddDWGFolder.IsEnabled = enabled;
                RemoveDWG.IsEnabled = enabled;
                SkipDWG.IsEnabled = enabled;

                RunChecked.IsEnabled = enabled;
                RunSelected.IsEnabled = enabled;
                RunFailed.IsEnabled = enabled;

                // Opposite....

                StopProcess.IsEnabled = !enabled;

                ProcessOptions.IsEnabled = enabled;
            }
            catch { }
        }

        //This is to end the ScriptPro application
        //used in Silent exit
        /// <summary>
        /// The ExitApplication.
        /// </summary>
        public void ExitApplication()
        {
            MessageFilter.Revoke();
            Application.Current.Shutdown();
        }

        //This is done to set the focus back to script pro
        //application. some times, script pro is not able to kill
        //AutoCAD, when AutoCAD is topmost application
        /// <summary>
        /// The SetFocusToApplication.
        /// </summary>
        public void SetFocusToApplication()
        {
            try
            {
                WindowState state = this.WindowState;
                this.WindowState = WindowState.Minimized;
                this.WindowState = WindowState.Maximized;
                this.Activate();
                this.WindowState = state;
            }
            catch
            {
            }
        }

        /// <summary>
        /// The ProcessStatus.
        /// </summary>
        /// <param name="started">The started<see cref="bool"/>.</param>
        public void ProcessStatus(bool started)
        {
            try
            {
                _IsProcessRunning = started;
                UpdateUI(!_IsProcessRunning);
            }
            catch { }
        }       


    }
}
