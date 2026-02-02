// AcadComUtils.cs
// .NET 8 / x64
// Utility class for AutoCAD COM operations
// Used exclusively by DrawingListControl.cs

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace DrawingListUC
{
    internal static class AcadComUtils
    {
        // -------------------- PUBLIC API --------------------

        /// <summary>
        /// Start AutoCAD executable and return its process ID
        /// </summary>
        public static int StartAcadExe(string exePath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = exePath,
                UseShellExecute = true,
                Arguments = ""
            };

            var p = Process.Start(psi);
            if (p == null)
                throw new InvalidOperationException("Failed to start AutoCAD process.");

            return p.Id;
        }

        /// <summary>
        /// Wait for AutoCAD process to create main window
        /// </summary>
        public static void WaitForMainWindow(int pid, int timeoutMs)
        {
            var end = DateTime.UtcNow.AddMilliseconds(timeoutMs);

            while (DateTime.UtcNow < end)
            {
                var p = Process.GetProcessById(pid);
                if (p.HasExited)
                    throw new InvalidOperationException("AutoCAD exited before it created a main window.");

                p.Refresh();
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    return;
                }
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Create latest installed AutoCAD instance via COM
        /// </summary>
        public static object CreateLatestAutoCADInstance()
        {
            string latestProgId = FindLatestVersionedProgId();

            Type? t = Type.GetTypeFromProgID(latestProgId, throwOnError: false);
            if (t == null)
                throw new InvalidOperationException($"Type.GetTypeFromProgID failed for {latestProgId}");

            int tries = 3;
            while (true)
            {
                try
                {
                    var obj = Activator.CreateInstance(t)!;
                    return obj;
                }
                catch (Exception)
                {
                    tries--;
                    if (tries <= 0) throw;
                    Thread.Sleep(10_000);
                }
            }
        }

        /// <summary>
        /// Set AutoCAD application visibility
        /// </summary>
        public static void SetVisible(object acadObj, bool visible)
        {
            acadObj.GetType().InvokeMember(
                "Visible",
                BindingFlags.SetProperty,
                null, acadObj,
                new object[] { visible }
            );
        }

        /// <summary>
        /// Get snapshot of all running AutoCAD processes (PID and EXE path)
        /// </summary>
        public static HashSet<(int, string)> SnapshotAcadPids()
        {
           
            var IdNameSet = Process.GetProcessesByName("acad").SelectMany(p =>
            {
                string exePath = "";
                try
                {
                    exePath = p.MainModule?.FileName ?? "";
                }
                catch { }
                return exePath != "" ? new[] { (p.Id, exePath) } : Array.Empty<(int, string)>();
            });
            return [.. IdNameSet];

        }

        /// <summary>
        /// Try to get any running AutoCAD instance via GetActiveObject
        /// </summary>
        public static object? TryGetAnyRunningAcad()
        {
            // Generic first
            var obj = TryGetActiveObject("AutoCAD.Application");
            if (obj != null) return obj;

            // Versioned
            foreach (var progId in GetAcadProgIdsForAttach().Where(p => p.StartsWith("AutoCAD.Application.", StringComparison.OrdinalIgnoreCase)))
            {
                obj = TryGetActiveObject(progId);
                if (obj != null) return obj;
            }

            return null;
        }

        /// <summary>
        /// Try to get COM object for specific ProgID
        /// </summary>
        public static object? TryGetActiveObject(string progId)
        {
            try
            {
                return MarshalUtils.GetActiveObject(progId);
            }
            catch (COMException ex)
            {
                System.Diagnostics.Debug.WriteLine($"TryGetActiveObject failed for {progId}: {ex.Message}");
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get AutoCAD ProgIDs for attach operations (generic + versioned, sorted newest first)
        /// </summary>
        public static List<string> GetAcadProgIdsForAttach()
        {
            var ids = new List<string>();
            using var hkcr = Registry.ClassesRoot;

            if (hkcr.OpenSubKey("AutoCAD.Application") != null)
                ids.Add("AutoCAD.Application");

            var versioned = hkcr.GetSubKeyNames()
                .Where(n => n.StartsWith("AutoCAD.Application.", StringComparison.OrdinalIgnoreCase))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            versioned.Sort((a, b) => ParseVer(b).CompareTo(ParseVer(a)));
            ids.AddRange(versioned);

            if (ids.Count == 0) ids.Add("AutoCAD.Application");

            return ids;

            static Version ParseVer(string progId)
            {
                try
                {
                    var suffix = progId.Substring("AutoCAD.Application.".Length);
                    return Version.TryParse(suffix, out var v) ? v : new Version(0, 0);
                }
                catch { return new Version(0, 0); }
            }
        }


        /// <summary>
        /// Get AutoCAD version from exe file (e.g., "25.1" from AutoCAD 2026)
        /// Uses FileVersion string which contains "R25.1.xxx.x.x" format
        /// </summary>
        public static Version? GetAutoCADVersionFromExe(string exePath)
        {
            try
            {
                if (!System.IO.File.Exists(exePath))
                {
                    System.Diagnostics.Debug.WriteLine($"GetAutoCADVersionFromExe: File does not exist: {exePath}");
                    return null;
                }

                var versionInfo = FileVersionInfo.GetVersionInfo(exePath);               

                // FileVersion is a string like "R25.1.164.0.0"
                if (!string.IsNullOrWhiteSpace(versionInfo.FileVersion))
                {
                    string versionString = versionInfo.FileVersion;

                    // Remove "R" prefix if present (AutoCAD format: R25.1.164.0.0)
                    if (versionString.StartsWith("R", StringComparison.OrdinalIgnoreCase))
                    {
                        versionString = versionString.Substring(1);
                    }

                    System.Diagnostics.Debug.WriteLine($"  Parsing version string: '{versionString}'");

                    // AutoCAD has 5 components (25.1.164.0.0), but Version only supports 4
                    // Split and take only first 2 components (Major.Minor)
                    string[] parts = versionString.Split('.');
                    if (parts.Length >= 2)
                    {
                        if (int.TryParse(parts[0], out int major) && int.TryParse(parts[1], out int minor))
                        {
                            var result = new Version(major, minor);
                            System.Diagnostics.Debug.WriteLine($"  SUCCESS: Parsed version: {result}");
                            return result;
                        }
                    }

                    System.Diagnostics.Debug.WriteLine($"  FAILED: Could not parse major.minor from '{versionString}'");
                }

                // Fallback to integer properties if string parsing fails
                var fallback = new Version(versionInfo.FileMajorPart, versionInfo.FileMinorPart);
                System.Diagnostics.Debug.WriteLine($"  FALLBACK: Using FileMajorPart.FileMinorPart: {fallback}");
                return fallback;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAutoCADVersionFromExe EXCEPTION: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get ProgIDs matching a specific AutoCAD version, ordered by preference
        /// Returns versioned ProgIDs (e.g., AutoCAD.Application.25.1, AutoCAD.Application.25)
        /// </summary>
        public static List<string> GetProgIdsForVersion(Version acadVersion)
        {
            var progIds = new List<string>();

            // Build the specific ProgID from the version
            // AutoCAD 2026 → "AutoCAD.Application.25.1"
            // AutoCAD 2025 → "AutoCAD.Application.25.0"
            // AutoCAD 2024 → "AutoCAD.Application.24.3"
            // AutoCAD 2023 → "AutoCAD.Application.24.2"
            // AutoCAD 2022 → "AutoCAD.Application.24.1"
            // AutoCAD 2021 → "AutoCAD.Application.24.0"
           
            string versionedProgId = $"AutoCAD.Application.{acadVersion.Major}.{acadVersion.Minor}";
            progIds.Add(versionedProgId);

            // Fallback: try major version only (e.g., "AutoCAD.Application.25")
            string majorProgId = $"AutoCAD.Application.{acadVersion.Major}";
            progIds.Add(majorProgId);

            // Last fallback: generic ProgID (points to latest AutoCAD)
            progIds.Add("AutoCAD.Application");

            return progIds;
        }

        /// <summary>
        /// Try to get COM object for AutoCAD at specific exe path
        /// Uses intelligent version-to-ProgID mapping
        /// </summary>
        public static object? TryGetActiveObjectForExePath(string acadExePath)
        {
            // Get AutoCAD version from the exe
            var version = GetAutoCADVersionFromExe(acadExePath);
            if (version == null)
            {
                // Fallback: try all ProgIDs
                return TryGetAnyRunningAcad();
            }

            // Get ProgIDs matching this version
            var progIds = GetProgIdsForVersion(version);

            // Try each ProgID in order of preference
            foreach (var progId in progIds)
            {
                var obj = TryGetActiveObject(progId);
                if (obj != null)
                {
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Get process ID from AutoCAD COM object by reading its HWND property
        /// </summary>
        public static int GetProcessIdFromComObject(object acadObject)
        {
            try
            {
                // Get the HWND from the AutoCAD COM Object
                var hwndProperty = acadObject.GetType().InvokeMember(
                    "HWND",
                    BindingFlags.GetProperty,
                    null, acadObject, null);

                IntPtr hWnd = new IntPtr(Convert.ToInt64(hwndProperty));

                if (hWnd == IntPtr.Zero) return -1;

                // Get the Process ID from that Window Handle
                GetWindowThreadProcessId(hWnd, out int pid);

                return pid;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Get the product name for a specific AutoCAD exe path
        /// Example: "D:\ACAD\AutoCAD 2026\acad.exe" → "AutoCAD Plant 3D 2026 - English"
        /// </summary>
        public static string GetProductNameFromExePath(string exePath)
        {
            var productList = new List<string>();
            var pathList = new List<string>();
            GetAcadInstallPaths(productList, pathList);

            for (int i = 0; i < pathList.Count; i++)
            {
                if (string.Equals(pathList[i], exePath, StringComparison.OrdinalIgnoreCase))
                {
                    return productList[i];
                }
            }

            // Fallback: extract from folder name if not found in registry
            string folderName = Path.GetFileName(Path.GetDirectoryName(exePath));
            return string.IsNullOrWhiteSpace(folderName) ? Path.GetFileName(exePath) : folderName;
        }

        /// <summary>
        /// Get all installed AutoCAD paths from registry
        /// Returns both acad.exe and accoreconsole.exe paths
        /// </summary>
        public static void GetAcadInstallPaths(List<string> productList, List<string> pathList)
        {
            RegistryKey localMac = Registry.LocalMachine;
            RegistryKey? registrySubKey = localMac.OpenSubKey(@"Software\Autodesk\AutoCAD\");

            if (registrySubKey != null)
            {
                string[] subKeyNames = registrySubKey.GetSubKeyNames();

                foreach (string subKeyName in subKeyNames)
                {
                    RegistryKey? key = registrySubKey.OpenSubKey(subKeyName);
                    if (key != null)
                    {
                        string[] keyNames = key.GetSubKeyNames();

                        foreach (string keyName in keyNames)
                        {
                            RegistryKey? location = key.OpenSubKey(keyName);
                            if (location != null)
                            {
                                object? regKey = location.GetValue("AcadLocation");
                                if (regKey != null)
                                {
                                    string path = regKey.ToString()!;
                                    string acad = Path.Combine(path, "acad.exe");  // ✅ Fixed double backslash

                                    if (System.IO.File.Exists(acad))
                                    {
                                        pathList.Add(acad);

                                        string prodName = string.Empty;
                                        regKey = location.GetValue("ProductName");
                                        if (regKey != null)
                                        {
                                            prodName = regKey.ToString()!;
                                            productList.Add(prodName);
                                        }

                                        string accore = Path.Combine(path, "accoreconsole.exe");  // ✅ Fixed

                                        if (System.IO.File.Exists(accore))
                                        {
                                            pathList.Add(accore);
                                            productList.Add(prodName + " Accoreconsole");
                                        }
                                    }
                                }
                                location.Close();
                            }
                        }
                        key.Close();
                    }
                }
                registrySubKey.Close();
            }
        }

        // -------------------- PRIVATE HELPERS --------------------

        /// <summary>
        /// Find the latest versioned AutoCAD ProgID (e.g., AutoCAD.Application.25.1)
        /// </summary>
        private static string FindLatestVersionedProgId()
        {
            using var hkcr = Registry.ClassesRoot;

            var best = hkcr.GetSubKeyNames()
                .Where(n => n.StartsWith("AutoCAD.Application.", StringComparison.OrdinalIgnoreCase))
                .Select(n => new { Name = n, Ver = ParseVer(n) })
                .Where(x => x.Ver != null)
                .OrderByDescending(x => x.Ver)
                .FirstOrDefault();

            if (best == null)
                throw new InvalidOperationException("No versioned AutoCAD ProgID found (AutoCAD.Application.*).");

            return best.Name;

            static Version? ParseVer(string progId)
            {
                var suffix = progId.Substring("AutoCAD.Application.".Length);
                return Version.TryParse(suffix, out var v) ? v : null;
            }
        }

        // -------------------- P/INVOKE --------------------

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        // -------------------- .NET 8 GetActiveObject (P/Invoke) --------------------

        public static class MarshalUtils
        {
            internal const string OLEAUT32 = "oleaut32.dll";
            internal const string OLE32 = "ole32.dll";

            [DllImport(OLE32, PreserveSig = false)]
            [SuppressUnmanagedCodeSecurity]
            [SecurityCritical]
            private static extern void CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

            [DllImport(OLE32, PreserveSig = false)]
            [SuppressUnmanagedCodeSecurity]
            [SecurityCritical]
            private static extern void CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string progId, out Guid clsid);

            [DllImport(OLEAUT32, PreserveSig = false)]
            [SuppressUnmanagedCodeSecurity]
            [SecurityCritical]
            private static extern void GetActiveObject(ref Guid rclsid, IntPtr reserved,
                [MarshalAs(UnmanagedType.Interface)] out object ppunk);

            [SecurityCritical]
            public static object GetActiveObject(string progID)
            {
                Guid clsid;
                try { CLSIDFromProgIDEx(progID, out clsid); }
                catch { CLSIDFromProgID(progID, out clsid); }

                GetActiveObject(ref clsid, IntPtr.Zero, out object obj);
                return obj;
            }
        }
    }
}
