using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using DrawingListUC;

namespace DwgExportManager
{
    // Dieu khien AutoCAD qua COM (attach vao instance dang chay hoac tao moi),
    // mo/kich hoat ban ve va chuyen tab Model/Layout.
    // Tai su dung AcadComUtils - nghiep vu ket noi AutoCAD da co san trong ScriptPro (DrawingListUC).
    public class AcadSession
    {
        // HRESULT AutoCAD/COM tra ve khi ung dung dang ban (dang hien dialog, dang ve lai man hinh...)
        // ScriptUI/DrawingListUC khong gap loi nay vi no chay tren luong UI (STA) co dang ky
        // IOleMessageFilter (xem MessageFilter.cs) de COM tu dong retry. DwgExportManager goi COM
        // ca tu luong nen (BackgroundWorker, MTA) - IOleMessageFilter KHONG co tac dung voi MTA,
        // nen phai tu bat loi va retry thu cong o day.
        private const int RPC_E_CALL_REJECTED = unchecked((int)0x80010001);
        private const int RPC_E_SERVERCALL_RETRYLATER = unchecked((int)0x8001010A);
        private const int MaxRetries = 60;      // toi da ~15s (60 x 250ms)
        private const int RetryDelayMs = 250;

        private object _acadApp;

        // Goi InvokeMember co tu dong retry khi AutoCAD bao "busy"
        private static object Invoke(object target, string name, BindingFlags flags, object[] args)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    return target.GetType().InvokeMember(name, flags, null, target, args);
                }
                catch (COMException ex) when (
                    (ex.HResult == RPC_E_CALL_REJECTED || ex.HResult == RPC_E_SERVERCALL_RETRYLATER) &&
                    attempt < MaxRetries)
                {
                    attempt++;
                    Thread.Sleep(RetryDelayMs);
                }
            }
        }

        public object EnsureAcadRunning()
        {
            if (_acadApp != null)
            {
                try
                {
                    // Kiem tra COM object con song khong (AutoCAD co the da bi dong tay)
                    Invoke(_acadApp, "Visible", BindingFlags.GetProperty, null);
                    return _acadApp;
                }
                catch
                {
                    _acadApp = null;
                }
            }

            _acadApp = AcadComUtils.TryGetAnyRunningAcad();
            if (_acadApp == null)
                _acadApp = AcadComUtils.CreateLatestAutoCADInstance();

            AcadComUtils.SetVisible(_acadApp, true);
            return _acadApp;
        }

        // Mo file (hoac kich hoat lai neu da mo san) va tra ve AcadDocument (COM object)
        public object OpenDocument(string dwgPath)
        {
            object acadApp = EnsureAcadRunning();

            object documents = Invoke(acadApp, "Documents", BindingFlags.GetProperty, null);

            int count = (int)Invoke(documents, "Count", BindingFlags.GetProperty, null);

            for (int i = 0; i < count; i++)
            {
                object existing = Invoke(documents, "Item", BindingFlags.InvokeMethod, new object[] { i });

                string fullName = (string)Invoke(existing, "FullName", BindingFlags.GetProperty, null);

                if (string.Equals(fullName, dwgPath, StringComparison.OrdinalIgnoreCase))
                {
                    ActivateDocument(existing);
                    return existing;
                }
            }

            object opened = Invoke(documents, "Open", BindingFlags.InvokeMethod,
                new object[] { dwgPath, false, " " });

            // Cho AutoCAD ve xong ban ve vua mo truoc khi goi tiep lenh COM khac,
            // giam kha nang gap "application is busy" ngay sau khi Open.
            Thread.Sleep(800);

            ActivateDocument(opened);
            return opened;
        }

        public void ActivateDocument(object document)
        {
            try
            {
                Invoke(document, "Activate", BindingFlags.InvokeMethod, null);
            }
            catch { }

            try
            {
                AcadComUtils.SetVisible(_acadApp, true);
            }
            catch { }
        }

        // Chuyen sang tab Model hoac Layout co ten tuong ung
        public void SetActiveTab(object document, string tabName)
        {
            if (string.IsNullOrEmpty(tabName) ||
                string.Equals(tabName, "Model", StringComparison.OrdinalIgnoreCase))
                return;

            try
            {
                object layouts = Invoke(document, "Layouts", BindingFlags.GetProperty, null);

                object layout = Invoke(layouts, "Item", BindingFlags.InvokeMethod, new object[] { tabName });

                Invoke(document, "ActiveLayout", BindingFlags.SetProperty, new object[] { layout });

                // Cho AutoCAD chuyen tab xong truoc khi goi tiep lenh COM khac
                Thread.Sleep(300);
            }
            catch
            {
                // Khong tim thay layout (co the da bi doi ten) - giu nguyen tab hien tai
            }
        }

        public void SetVariable(object document, string varName, object value)
        {
            try
            {
                Invoke(document, "SetVariable", BindingFlags.InvokeMethod, new object[] { varName, value });
            }
            catch { }
        }

        public int GetIntVariable(object document, string varName, int defaultValue)
        {
            try
            {
                object result = Invoke(document, "GetVariable", BindingFlags.InvokeMethod, new object[] { varName });
                return Convert.ToInt32(result);
            }
            catch
            {
                return defaultValue;
            }
        }

        public string GetStringVariable(object document, string varName, string defaultValue)
        {
            try
            {
                object result = Invoke(document, "GetVariable", BindingFlags.InvokeMethod, new object[] { varName });
                return result?.ToString() ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public void SendCommand(object document, string commandText)
        {
            Invoke(document, "SendCommand", BindingFlags.InvokeMethod, new object[] { commandText });
        }

        public void CloseDocument(object document)
        {
            try
            {
                Invoke(document, "Close", BindingFlags.InvokeMethod, new object[] { false, "" });
            }
            catch { }
        }
    }
}
