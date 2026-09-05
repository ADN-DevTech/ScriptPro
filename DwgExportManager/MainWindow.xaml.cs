using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DwgExportManager.Models;
using WinForms = System.Windows.Forms;

namespace DwgExportManager
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<DwgFileItem> _files = new ObservableCollection<DwgFileItem>();
        private readonly AcadSession _acadSession = new AcadSession();

        private BackgroundWorker _exportWorker;
        private readonly ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);
        private volatile bool _stopRequested;
        private volatile bool _isRunning;

        public MainWindow()
        {
            InitializeComponent();
            DwgGrid.ItemsSource = _files;

            // Cho phep COM tu dong retry khi AutoCAD bao "busy" thay vi nem loi
            // ("The message filter indicated that the application is busy").
            MessageFilter.Register();
            Closed += (s, e) => MessageFilter.Revoke();
        }

        // ===== Dong 1: chon thu muc chua ban ve =====

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning) return;

            using (var dlg = new WinForms.FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(FolderPathTextBox.Text) && Directory.Exists(FolderPathTextBox.Text))
                    dlg.SelectedPath = FolderPathTextBox.Text;

                if (dlg.ShowDialog() == WinForms.DialogResult.OK)
                {
                    FolderPathTextBox.Text = dlg.SelectedPath;
                    LoadFolder(dlg.SelectedPath);
                }
            }
        }

        private void LoadFolder(string folder)
        {
            _files.Clear();

            string[] dwgFiles;
            try
            {
                dwgFiles = Directory.GetFiles(folder, "*.dwg")
                    .Concat(Directory.GetFiles(folder, "*.dxf"))
                    .OrderBy(f => Path.GetFileName(f), StringComparer.OrdinalIgnoreCase)
                    .ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc thư mục:\n" + ex.Message, "DWG Export Manager",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dwgFiles.Length == 0)
            {
                StatusText.Text = "Không tìm thấy file .dwg/.dxf trong thư mục này.";
                return;
            }

            StatusText.Text = "Đang đọc danh sách layout...";

            // Doc Layout tung file (ACadSharp) tren luong nen de khong dong UI
            Task.Run(() =>
            {
                foreach (string file in dwgFiles)
                {
                    var item = new DwgFileItem
                    {
                        FileName = Path.GetFileName(file),
                        FullPath = file
                    };
                    item.AvailableTabs.Add("Model");
                    foreach (string layoutName in LayoutReader.ReadLayoutNames(file))
                        item.AvailableTabs.Add(layoutName);
                    item.SelectedTab = "Model";

                    var captured = item;
                    Dispatcher.Invoke(() => _files.Add(captured));
                }

                Dispatcher.Invoke(() => StatusText.Text = $"Đã tải {dwgFiles.Length} file.");
            });
        }

        // ===== Dong 2: nut "Xem" tren tung dong luoi =====

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.Tag as DwgFileItem;
            if (item == null) return;

            if (_isRunning)
            {
                MessageBox.Show("Đang trong quá trình xuất file, vui lòng chờ hoặc bấm Tạm dừng.",
                    "DWG Export Manager");
                return;
            }

            button.IsEnabled = false;
            StatusText.Text = "Đang mở " + item.FileName + " ...";
            try
            {
                object document = _acadSession.OpenDocument(item.FullPath);
                _acadSession.SetActiveTab(document, item.SelectedTab);
                StatusText.Text = $"Đã mở {item.FileName} ({item.SelectedTab}) trong AutoCAD.";
            }
            catch (Exception ex)
            {
                StatusText.Text = "";
                MessageBox.Show("Không thể mở AutoCAD để xem file:\n" + ex.Message,
                    "DWG Export Manager", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                button.IsEnabled = true;
            }
        }

        // ===== Dong 2: nut "Xóa" tren tung dong luoi =====

        private void DeleteRowButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.Tag as DwgFileItem;
            if (item == null) return;

            if (_isRunning)
            {
                MessageBox.Show("Đang trong quá trình xuất file, vui lòng chờ hoặc bấm Tạm dừng trước khi xóa.",
                    "DWG Export Manager");
                return;
            }

            _files.Remove(item);
        }

        // ===== Thanh cong cu tren luoi: xoa nhieu ban ghi cung luc =====

        private void DwgGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = DwgGrid.SelectedItems.Count;
            DeleteSelectedButton.IsEnabled = !_isRunning && count > 0;
            DeleteSelectedButton.Content = count > 0 ? $"Xóa mục đã chọn ({count})" : "Xóa mục đã chọn";
        }

        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("Đang trong quá trình xuất file, vui lòng chờ hoặc bấm Tạm dừng trước khi xóa.",
                    "DWG Export Manager");
                return;
            }

            List<DwgFileItem> selected = DwgGrid.SelectedItems.Cast<DwgFileItem>().ToList();
            if (selected.Count == 0) return;

            foreach (DwgFileItem item in selected)
                _files.Remove(item);

            DeleteSelectedButton.Content = "Xóa mục đã chọn";
            DeleteSelectedButton.IsEnabled = false;
        }

        // ===== Dong 2: nut "Xuất" tren tung dong luoi (xuat rieng 1 file) =====

        private void ExportRowButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.Tag as DwgFileItem;
            if (item == null) return;

            if (_isRunning)
            {
                MessageBox.Show("Đang trong quá trình xuất file khác, vui lòng chờ hoặc bấm Tạm dừng.",
                    "DWG Export Manager");
                return;
            }

            StartExport(new List<DwgFileItem> { item });
        }

        // ===== Dong 3: Xuat / Tam dung =====

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                // Dang chay -> nut nay dong vai tro "Dung"
                _stopRequested = true;
                _pauseEvent.Set(); // nha tam dung (neu co) de vong lap thoat ngay
                ExportButton.IsEnabled = false;
                StatusText.Text = "Đang dừng...";
                return;
            }

            if (_files.Count == 0)
            {
                MessageBox.Show("Chưa có file nào trong danh sách. Hãy chọn thư mục chứa bản vẽ trước.",
                    "DWG Export Manager");
                return;
            }

            StartExport(_files.ToList());
        }

        // Dung chung cho ca xuat hang loat (nut Xuat o dong 3) va xuat rieng 1 file (nut Xuat tren luoi)
        private void StartExport(List<DwgFileItem> items)
        {
            if (items.Count == 0) return;

            ExportFormat format =
                FormatPdfRadio.IsChecked == true ? ExportFormat.PdfOnly :
                FormatPngRadio.IsChecked == true ? ExportFormat.PngOnly :
                ExportFormat.PdfAndPng;

            _stopRequested = false;
            _pauseEvent.Set();

            _isRunning = true;
            ExportButton.Content = "Dừng";
            PauseButton.IsEnabled = true;
            PauseButton.Content = "Tạm dừng";
            BrowseButton.IsEnabled = false;
            DeleteSelectedButton.IsEnabled = false;
            ExportProgressBar.Value = 0;

            _exportWorker = new BackgroundWorker { WorkerReportsProgress = true };
            _exportWorker.DoWork += (s, args) => RunExport(items, format);
            _exportWorker.ProgressChanged += (s, args) =>
            {
                ExportProgressBar.Value = args.ProgressPercentage;
                StatusText.Text = args.UserState as string;
            };
            _exportWorker.RunWorkerCompleted += (s, args) =>
            {
                _isRunning = false;
                ExportButton.Content = "Xuất";
                ExportButton.IsEnabled = true;
                PauseButton.IsEnabled = false;
                PauseButton.Content = "Tạm dừng";
                BrowseButton.IsEnabled = true;
                DeleteSelectedButton.IsEnabled = DwgGrid.SelectedItems.Count > 0;
                StatusText.Text = _stopRequested ? "Đã dừng." : "Hoàn tất xuất file.";
            };
            _exportWorker.RunWorkerAsync();
        }

        private void RunExport(List<DwgFileItem> items, ExportFormat format)
        {
            var engine = new ExportEngine(_acadSession);
            int total = items.Count;

            for (int i = 0; i < total; i++)
            {
                if (_stopRequested) break;

                DwgFileItem item = items[i];
                Dispatcher.Invoke(() => item.Status = "Đang xuất...");
                _exportWorker.ReportProgress(
                    (int)(i * 100.0 / total),
                    $"Đang xuất: {item.FileName} ({item.SelectedTab})...");

                bool ok = engine.ExportFile(
                    item.FullPath, item.SelectedTab, format,
                    () => _stopRequested, _pauseEvent, out string error,
                    item.PngPaperSize);

                var capturedItem = item;
                var capturedOk = ok;
                var capturedError = error;
                Dispatcher.Invoke(() => capturedItem.Status = capturedOk ? "OK" : "Lỗi: " + capturedError);

                _exportWorker.ReportProgress(
                    (int)((i + 1) * 100.0 / total),
                    ok ? $"Xong: {item.FileName}" : $"Lỗi: {item.FileName} - {error}");
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isRunning) return;

            if (_pauseEvent.IsSet)
            {
                _pauseEvent.Reset();
                PauseButton.Content = "Tiếp tục";
                StatusText.Text = "Đã tạm dừng.";
            }
            else
            {
                _pauseEvent.Set();
                PauseButton.Content = "Tạm dừng";
            }
        }
    }
}
