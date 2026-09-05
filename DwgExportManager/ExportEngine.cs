using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DwgExportManager
{
    public enum ExportFormat
    {
        PdfOnly,
        PngOnly,
        PdfAndPng
    }

    // Nghiep vu xuat hang loat: voi moi file, mo trong AutoCAD, chuyen den tab
    // (Model/Layout) da chon tren luoi, plot ra PDF va/hoac PNG, roi dong lai
    // khong luu. Tham so plot (kho A1 / Extents+Fit+Center) giu nguyen theo 2 script
    // PlotAllLayoutsToPDF_A1.scr va PlotAllLayoutsToPNG.scr da tao truoc do, chi khac
    // la chi xuat DUY NHAT tab nguoi dung chon cho tung file. Rieng kho anh PNG co the
    // chon khac nhau cho tung dong (pngPaperSize), mac dinh DefaultPngPaperSize neu bo trong.
    // File xuat ra dat CUNG TEN voi file DWG goc, luu trong thu muc con "danxuat"
    // nam ngay trong thu muc goc (thu muc chua cac file DWG).
    public class ExportEngine
    {
        // Ten thu muc con (nam ngay trong thu muc goc chua cac file DWG) de chua ket qua xuat
        private const string OutputFolderName = "danxuat";

        private const string PdfDevice = "DWG To PDF.pc3";
        private const string PdfPaperSize = "ISO A1 (594.00 x 841.00 MM)";

        private const string PngDevice = "PublishToWeb PNG.pc3";
        private const string DefaultPngPaperSize = "1600 x 1280 Pixels";

        private readonly AcadSession _session;

        public ExportEngine(AcadSession session)
        {
            _session = session;
        }

        // Tra ve true neu xuat thanh cong, false neu co loi (se ghi vao out error)
        public bool ExportFile(
            string dwgPath, string tabName, ExportFormat format,
            Func<bool> isStopRequested, ManualResetEventSlim pauseEvent,
            out string error, string pngPaperSize = null)
        {
            error = null;
            object document = null;
            try
            {
                pauseEvent.Wait();
                if (isStopRequested()) return false;

                document = _session.OpenDocument(dwgPath);
                _session.SetActiveTab(document, tabName);

                _session.SetVariable(document, "FILEDIA", 0);
                _session.SetVariable(document, "BACKGROUNDPLOT", 0);

                // Bat log lenh cua AutoCAD de doc lai noi dung khi -PLOT that bai
                // (vd sai ten kho giay/thiet bi) - SendCommand khong nem loi .NET
                // khi AutoCAD tu choi lenh, nen phai doc log moi biet ly do that.
                _session.SetVariable(document, "LOGFILEMODE", 1);
                string logFile = _session.GetStringVariable(document, "LOGFILENAME", null);

                string rootFolder = Path.GetDirectoryName(dwgPath);
                string outputFolder = Path.Combine(rootFolder, OutputFolderName);
                Directory.CreateDirectory(outputFolder);

                string baseName = Path.GetFileNameWithoutExtension(dwgPath);
                bool isModel = string.Equals(tabName, "Model", StringComparison.OrdinalIgnoreCase);
                string layoutArg = isModel ? "Model" : tabName;

                var failures = new List<string>();

                if (format == ExportFormat.PdfOnly || format == ExportFormat.PdfAndPng)
                {
                    pauseEvent.Wait();
                    if (isStopRequested()) return false;

                    string pdfPath = Path.Combine(outputFolder, baseName + ".pdf");
                    long logPos = GetLogLength(logFile);
                    Plot(document, layoutArg, PdfDevice, PdfPaperSize, pdfPath);
                    WaitForIdle(document, 120_000);

                    if (!File.Exists(pdfPath))
                        failures.Add(BuildPlotFailureMessage("PDF", PdfDevice, PdfPaperSize, logFile, logPos));
                }

                if (format == ExportFormat.PngOnly || format == ExportFormat.PdfAndPng)
                {
                    pauseEvent.Wait();
                    if (isStopRequested()) return false;

                    string effectivePngPaperSize = string.IsNullOrWhiteSpace(pngPaperSize)
                        ? DefaultPngPaperSize : pngPaperSize;

                    string pngPath = Path.Combine(outputFolder, baseName + ".png");
                    long logPos = GetLogLength(logFile);
                    Plot(document, layoutArg, PngDevice, effectivePngPaperSize, pngPath);
                    WaitForIdle(document, 120_000);

                    if (!File.Exists(pngPath))
                        failures.Add(BuildPlotFailureMessage("PNG", PngDevice, effectivePngPaperSize, logFile, logPos));
                }

                _session.SetVariable(document, "FILEDIA", 1);

                if (failures.Count > 0)
                {
                    error = string.Join(" | ", failures);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {
                if (document != null)
                    _session.CloseDocument(document);
            }
        }

        private static long GetLogLength(string logFile)
        {
            try
            {
                if (string.IsNullOrEmpty(logFile) || !File.Exists(logFile))
                    return 0;
                return new FileInfo(logFile).Length;
            }
            catch
            {
                return 0;
            }
        }

        // Doc phan noi dung MOI duoc ghi vao log lenh cua AutoCAD (tinh tu logPos)
        // de biet AutoCAD tra loi gi cho lenh -PLOT vua gui (vd bao khong tim
        // thay kho giay/thiet bi).
        private static string ReadLogTail(string logFile, long logPos, int maxChars = 600)
        {
            try
            {
                if (string.IsNullOrEmpty(logFile) || !File.Exists(logFile))
                    return null;

                using (var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (logPos > fs.Length) logPos = 0;
                    fs.Seek(logPos, SeekOrigin.Begin);
                    using (var sr = new StreamReader(fs))
                    {
                        string text = sr.ReadToEnd().Trim();
                        if (text.Length > maxChars)
                            text = text.Substring(text.Length - maxChars);
                        return text;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private static string BuildPlotFailureMessage(
            string formatName, string device, string paperSize, string logFile, long logPos)
        {
            string msg = $"Không tạo được {formatName} (kiểm tra thiết bị '{device}' / khổ giấy '{paperSize}' có tồn tại trên máy này không)";
            string tail = ReadLogTail(logFile, logPos);
            if (!string.IsNullOrEmpty(tail))
                msg += $" — AutoCAD trả lời: {tail}";
            return msg;
        }

        private void Plot(object document, string layoutArg, string device, string paperSize, string outFile)
        {
            string cmd =
                "_.-PLOT\n" +
                "Yes\n" +           // Detailed plot configuration? Yes
                layoutArg + "\n" +  // Layout can plot
                device + "\n" +     // Output device
                paperSize + "\n" +  // Paper size
                "Millimeters\n" +   // Paper units
                "Landscape\n" +     // Orientation
                "No\n" +            // Plot upside down?
                "Extents\n" +       // Plot area
                "Fit\n" +           // Plot scale
                "Center\n" +        // Plot offset
                "Yes\n" +           // Plot with plot styles
                ".\n" +             // Giu nguyen bang plot style hien tai
                "Yes\n" +           // Plot with lineweights
                "\n" +              // Shade plot setting mac dinh
                outFile + "\n" +    // Ten file xuat ra
                "No\n" +            // Save changes to page setup? No
                "Yes\n";            // Proceed with plot

            _session.SendCommand(document, cmd);
            Thread.Sleep(1000);
        }

        // Cho AutoCAD xu ly xong lenh plot (CMDACTIVE == 0) truoc khi lam tiep,
        // toi da timeoutMs, tranh dong file khi PDF/PNG chua ghi xong.
        private void WaitForIdle(object document, int timeoutMs)
        {
            DateTime end = DateTime.UtcNow.AddMilliseconds(timeoutMs);
            while (DateTime.UtcNow < end)
            {
                int cmdActive = _session.GetIntVariable(document, "CMDACTIVE", 0);
                if (cmdActive == 0)
                    return;
                Thread.Sleep(300);
            }
        }
    }
}
