using System;
using System.Collections.Generic;
using System.IO;
using ACadSharp;
using ACadSharp.IO;

namespace DwgExportManager
{
    // Doc nhanh danh sach Layout (khong tinh Model) tu file DWG/DXF bang ACadSharp,
    // KHONG can mo AutoCAD - dung de do vao ComboBox "Model/Layout" tren luoi.
    public static class LayoutReader
    {
        public static List<string> ReadLayoutNames(string filePath)
        {
            var names = new List<string>();
            try
            {
                string ext = Path.GetExtension(filePath).ToLowerInvariant();

                CadDocument doc = ext == ".dxf"
                    ? DxfReader.Read(filePath)
                    : DwgReader.Read(filePath);

                if (doc?.Layouts != null)
                {
                    foreach (var layout in doc.Layouts)
                    {
                        string name = layout?.Name;
                        if (!string.IsNullOrEmpty(name) &&
                            !string.Equals(name, "Model", StringComparison.OrdinalIgnoreCase))
                        {
                            names.Add(name);
                        }
                    }
                }
            }
            catch
            {
                // File loi, ma hoa, hoac phien ban chua ho tro: bo qua,
                // luoi se chi con lua chon "Model".
            }
            return names;
        }
    }
}
