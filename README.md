# ScriptProPlus – .NET 8 Migration

ScriptProPlus has been migrated from **.NET Framework 4.8** to **.NET 8.0**.  
The application now supports **AutoCAD 2025 and later** with no changes required to existing scripts or workflows.

## Summary

*   Target framework updated to .NET 8.0    
*   Projects converted to SDK-style format    
*   Compatible with AutoCAD 2025+ (64-bit)    
*   Existing functionality and COM automation preserved
    

## Projects

*   **DrawingListUC** – Windows Forms control library (.NET 8)    
*   **ScriptUI** – WPF application (.NET 8)    
*   **DwgExportManager** – WPF application (.NET 8): browse a folder, pick Model/Layout per drawing, preview in AutoCAD, batch export to PDF/PNG    
*   **ScriptProSetup** – WiX-based installer (updated), framework-dependent: requires .NET 8 Desktop Runtime on the target machine    
*   **DwgExportManagerSetup** – WiX-based installer for DwgExportManager, **self-contained**: bundles the .NET 8 runtime, so it runs on machines without .NET 8 installed
    

## Build

`dotnet build ScriptProPlus.sln -c Release -p:Platform=x64`

You can also build the solution using **Visual Studio 2022 or later**.

## Requirements

### Development

*   Windows 10 or 11    
*   Visual Studio 2022+    
*   .NET 8 SDK    
*   WiX Toolset 3.11 or later
    

### Runtime

*   Windows 10 or 11 (64-bit)    
*   .NET 8 Desktop Runtime (not required for self-contained builds)    
*   AutoCAD 2025 or later
    

## Compatibility Notes

*   COM automation behavior remains the same    
*   Existing scripts, project files, and settings continue to work    
*   x64 builds are recommended due to AutoCAD requirements
  
## License
This project is licensed under the **MIT License**.

## Maintenance
Maintained by **Madhukar**.

## Community
Open to the community. Contributions, issues, and suggestions are welcome.

## Contributing
Please follow [CONTRIBUTING.md](CONTRIBUTING.md), including required PR test evidence from `TestFiles\TEST_CASE.md`.

