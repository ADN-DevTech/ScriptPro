namespace DwgExportManager
{
    using System;
    using System.Runtime.InteropServices;

    // Dang ky IOleMessageFilter tren luong UI (STA) de COM tu dong retry khi AutoCAD
    // bao "busy" (dang hien dialog, dang xu ly lenh khac) thay vi nem loi ngay.
    // Sao chep dung nghiep vu da hoat dong on dinh trong ScriptUI/MessageFilter.cs.
    public class MessageFilter : IOleMessageFilter
    {
        public static void Register()
        {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            int test = CoRegisterMessageFilter(newFilter, out oldFilter);

            if (test != 0)
            {
                Console.WriteLine(string.Format("CoRegisterMessageFilter failed with error : {0}", test));
            }
        }

        public static void Revoke()
        {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, out oldFilter);
        }

        int IOleMessageFilter.HandleInComingCall(int dwCallType,
          System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr
          lpInterfaceInfo)
        {
            // SERVERCALL_ISHANDLED
            return 0;
        }

        int IOleMessageFilter.RetryRejectedCall(System.IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
        {
            if (dwRejectType == 2)
            // SERVERCALL_RETRYLATER
            {
                // Retry ngay lap tuc (0-99 = retry)
                return 99;
            }
            // Qua ban, huy cuoc goi
            return -1;
        }

        int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
        {
            // PENDINGMSG_WAITDEFPROCESS
            return 2;
        }

        [DllImport("Ole32.dll")]
        private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
    }

    [ComImport(), Guid("00000016-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    interface IOleMessageFilter
    {
        [PreserveSig]
        int HandleInComingCall(
            int dwCallType,
            IntPtr hTaskCaller,
            int dwTickCount,
            IntPtr lpInterfaceInfo);

        [PreserveSig]
        int RetryRejectedCall(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwRejectType);

        [PreserveSig]
        int MessagePending(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwPendingType);
    }
}
