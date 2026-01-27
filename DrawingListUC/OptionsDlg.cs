using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DrawingListUC
{
  public partial class OptionsDlg : Form
  {
    public OptionsDlg()
    {
      InitializeComponent();
    }

    private string _iniScript = "";
    private string _logFilePath = "";
    private string _acadExePath = "";
    private int _timeout = 30;
    private int _restartCount = 30;
    private bool _searchAllDirectories = false;
    private int _createImage = 2; // Failed 
    private bool _diagnosticMode;
    private int _toolSpeed = 0;
    private bool _runWithoutOpen = false;
    private bool _useCmdLine = false;

    public string IniScript
    {
      get
      {
        return _iniScript;
      }
      set
      {
        try
        {
          _iniScript = value;
          ScriptPath.Text =
            _iniScript;
        }
        catch { }
      }
    }
    //


    public string acadExePath
    {
      get
      {
          return _acadExePath;
      }
      set
      {
        try
        {
            _acadExePath = value;
            textBox_exePath.Text =
            _acadExePath;
        }
        catch { }
      }
    }

    public string logFilePath
    {
        get
        {
            return _logFilePath;
        }
        set
        {
            try
            {
                _logFilePath = value;
                ProcessLogFilePath.Text =
                  _logFilePath;
            }
            catch { }
        }
    }

    public int timeout
    {
      get
      {
        return _timeout;
      }
    }

    public int reStartCount
    {
      get
      {
        return _restartCount;
      }
    }

    public int nCreateImage
    {
      get
      {
        return _createImage;
      }
    }
    public int toolSpeed
    {
        get
        {
            return _toolSpeed;
        }
        set
        {
            try
            {
                _toolSpeed = value;
                trackBar_speed.Value = _toolSpeed;
            }
            catch { }
        }
    }


    public bool SearchAllDirectories
    {
      get
      {
        return _searchAllDirectories;
      }
      set
      {
        _searchAllDirectories = value;
      }
    }

    public bool RunWithoutOpen
    {
        get
        {
            return _runWithoutOpen;
        }
        set
        {
            try
            {
                _runWithoutOpen = value;
                OpenDWGFile.Checked =
                  value;
            }
            catch { }
           
        }
    }

      //Not used for now..
    public bool UseScriptAsCmdLine
    {
        get
        {
            return _useCmdLine;
        }
        set
        {
            try
            {
                _useCmdLine = value;
                UseExeCheckbox.Checked =
                  value;
            }
            catch { }

        }
    }

    public bool DiagnosticMode
    {
      get
      {
        return _diagnosticMode;
      }
      set
      {
        _diagnosticMode = value;

        try
        {
          diagnosticMode.Checked = _diagnosticMode;
        }
        catch { }
      }
    }



    private void OptionOK_Click(object sender, EventArgs e)
    {
      try
      {
        if (Convert.ToInt32(this.textSeconds.Text) < 10)
        {
          MessageBox.Show("Timeout should be at least 10 seconds");
          return;
        }
      }
      catch
      {
        MessageBox.Show(
          "Specific valid publish timeout in seconds"
        );
        textSeconds.Focus();
        return;
      }
      //
      try
      {
        if (Convert.ToInt32(this.restartAcad.Text) <= 0)
        {
          MessageBox.Show(
            "Restart AutoCAD value should be more then 0"
          );
          return;
        }
      }
      catch
      {
        MessageBox.Show(
          "Specific valid AutoCAD restart value"
        );
        restartAcad.Focus();
        return;
      }

      if (ScriptPath.Text.Length != 0)
      {
        if (!System.IO.File.Exists(ScriptPath.Text))
        {
          MessageBox.Show(
            "Specific valid Start up script file"
          );

          IniScriptBrowse.Focus();
          return;
        }
      }

      if (ProcessLogFilePath.Text.Length != 0)
      {
        try
        {
          string str = ProcessLogFilePath.Text + "\\" + "test.log";
          StreamWriter SW = File.CreateText(str);
          SW.Close();

          File.Delete(str);
        }
        catch
        {
          MessageBox.Show("Specific valid log file folder value");
          ProcessLogFilePath.Focus();
          ProcessLogFilePath.Text = Path.GetTempPath();
          return;
        }
      }

      if (textBox_exePath.Text.Length != 0)
      {
          if (!System.IO.File.Exists(textBox_exePath.Text))
          {
              MessageBox.Show(
                "Specific valid AutoCAD application"
              );

              textBox_exePath.Focus();
              return;
          }
      }

      _iniScript = ScriptPath.Text;
      _timeout = Convert.ToInt32(this.textSeconds.Text);
      _restartCount = Convert.ToInt32(this.restartAcad.Text);
      _logFilePath = ProcessLogFilePath.Text;
      _searchAllDirectories = searchFolder.Checked;
      _acadExePath = textBox_exePath.Text;
      _diagnosticMode = diagnosticMode.Checked;
      _toolSpeed = trackBar_speed.Value;
      _runWithoutOpen = OpenDWGFile.Checked;

        //not used for now
      //_useCmdLine = UseExeCheckbox.Checked;

        //check for exe
      if (_useCmdLine)
      {
            //
          bool showError = true;
          if (textBox_exePath.Text.Length != 0)
          {
              if (System.IO.File.Exists(textBox_exePath.Text))
              {
                  showError = false;
                  
              }
          }

          if (showError)
          {
              MessageBox.Show(
                    "Specific valid AutoCAD/Console application"
                  );

              textBox_exePath.Focus();
              return;
          }
      }

      try
      {
        if (searchFolder.Checked)
        {
          Properties.Settings.Default.SearchAllDirectories = "true";
        }
        else
        {
          Properties.Settings.Default.SearchAllDirectories = "false";
        }

        if (radioButton_none.Checked)
        {
          Properties.Settings.Default.CreateImage = "2";
          _createImage = 2;
        }
        else if (radioButton_failed.Checked)
        {
          Properties.Settings.Default.CreateImage = "1";
          _createImage = 1;
        }
        else
        {
          Properties.Settings.Default.CreateImage = "0";
          _createImage = 0;
        }
        Properties.Settings.Default.Save();
      }
      catch
      {
      }

      SaveSettings();
      DialogResult = DialogResult.OK;
    }

    private void OptionCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void IniScriptBrowse_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog FileOpenDlg = new OpenFileDialog();

        if (File.Exists(_iniScript))
          FileOpenDlg.InitialDirectory =
            Path.GetDirectoryName(_iniScript);

        FileOpenDlg.Filter = "Script (*.scr) |*.scr;";
        if (FileOpenDlg.ShowDialog() == DialogResult.OK)
          IniScript = FileOpenDlg.FileName;
      }
      catch { }
    }

    private void IniViewbutton_Click(object sender, EventArgs e)
    {
      Process notePad = new Process();
      notePad.StartInfo.FileName = "notepad.exe";

      // Find if the file is present

      if (File.Exists(ScriptPath.Text))
      {
        notePad.StartInfo.Arguments = ScriptPath.Text;
      }
      notePad.Start();
    }

    private void OptionsDlg_Load(object sender, EventArgs e)
    {
      ApplySettings();

      //
      if (ProcessLogFilePath.Text.Length == 0)
        logFilePath = Path.GetTempPath();


        if (_useCmdLine)
        {
            UpdateUI_seExeCheckbox(true);
        }
    }
    public void SaveSettings()
    {
     
    }

    public void ApplySettings()
    {
      
    }

    public void setProjectSetting(
      string startUpScript, string timeout,
      string logFile, string _restartDWGCount
    )
    {
      textSeconds.Text = timeout;
      restartAcad.Text = _restartDWGCount;
      ScriptPath.Text = startUpScript;
      logFilePath = logFile;

      // Read from the settings
      
      string str = Properties.Settings.Default.SearchAllDirectories;

      if (str.Contains("false"))
        searchFolder.Checked = false;
      else
        searchFolder.Checked = true;

      str = Properties.Settings.Default.CreateImage;

      if (str.Contains("1"))
        this.radioButton_failed.Checked = true;
      else if (str.Contains("0"))
      {
        this.radioButton_all.Checked = true;
      }
      else
      {
        this.radioButton_none.Checked = true;
      }
    }

    private void logPathBrowse_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog LogDia = new FolderBrowserDialog();
      LogDia.ShowNewFolderButton = true;
      LogDia.SelectedPath = _logFilePath;

      if (LogDia.ShowDialog() == DialogResult.OK)
      {
        ProcessLogFilePath.Text = LogDia.SelectedPath;

        try
        {
          string str = ProcessLogFilePath.Text + "\\" + "test.log";
          StreamWriter SW = File.CreateText(str);
          SW.Close();

          File.Delete(str);
          _logFilePath = ProcessLogFilePath.Text;
        }
        catch
        {
          MessageBox.Show("Unable to create the log file");
          ProcessLogFilePath.Text = "";
        }
      }
    }

    private void button_exePath_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog FileOpenDlg = new OpenFileDialog();

            if (File.Exists(_acadExePath))
                FileOpenDlg.InitialDirectory =
                  Path.GetDirectoryName(_acadExePath);
            
            FileOpenDlg.Filter = "AutoCAD application (*.exe) |*.exe;";
            if (FileOpenDlg.ShowDialog() == DialogResult.OK)
            {
                acadExePath = FileOpenDlg.FileName;

                if (DrawingListControl.isHeadlessAcad(acadExePath))
                    UpdateUI_seExeCheckbox(true);
                else
                    UpdateUI_seExeCheckbox(false);
            }
        }
        catch { }
    }

    private void trackBar_speed_Scroll(object sender, EventArgs e)
    {
        
    }



    private void UpdateUI_seExeCheckbox(bool useExe)
    {
        try
        {
            restartAcad.Enabled = !useExe;
            radioButton_all.Enabled = !useExe;
            radioButton_none.Enabled = !useExe;
            this.radioButton_failed.Enabled = !useExe;
            this.trackBar_speed.Enabled = !useExe;
            this.diagnosticMode.Enabled = !useExe;
            this.OpenDWGFile.Enabled = !useExe;
            this.ScriptPath.Enabled = !useExe;
            this.intScriptGBox.Enabled = !useExe;
            this.IniViewbutton.Enabled = !useExe;

            UseScriptAsCmdLine = useExe;
        }
        catch
        {
        }

    }

      //Not used for now
    private void UseExeCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        //not used
        //UpdateUI_seExeCheckbox(UseExeCheckbox.Checked);
    }

    private void textBox_exePath_Leave(object sender, EventArgs e)
    {
        if (File.Exists(textBox_exePath.Text))
        {
            if (DrawingListControl.isHeadlessAcad(textBox_exePath.Text))
                UpdateUI_seExeCheckbox(true);
            else
                UpdateUI_seExeCheckbox(false);
        }
    }
  }
}
