# ScriptPro Agentic Test Skill

This file is the execution contract for maintainers, contributors, and agents running ScriptPro validation.

Run from repository root (`ScriptProPlus`).

## Objective

Validate ScriptPro run behavior and produce concrete, reviewable evidence:
1. scenario outcome (Pass/Fail),
2. ScriptPro logs,
3. output artifacts (PDFs),
4. environment details.

## Inputs

- Built app: `Binaries\x64\Release\net8.0-windows\ScriptUI.exe`
- Project files: `TestFiles\xyz.bpl`, `TestFiles\xyz_noexe.bpl`
- Script/data files under `TestFiles\`

## Preflight (must pass)

```powershell
$RepoRoot = (Get-Location).Path
$Exe = Join-Path $RepoRoot "Binaries\x64\Release\net8.0-windows\ScriptUI.exe"
if (-not (Test-Path $Exe)) { throw "Missing ScriptUI.exe. Build Release|x64 first." }

# Optional: set explicit AutoCAD path for Scenario 3 launcher convenience
# $AcadExe = "D:\ACAD\AutoCAD 2026\acad.exe"
```

## Execution policy

- Use a timeout long enough for 9 DWGs (recommended: 10+ minutes).
- Do not claim success without logs.
- If a scenario times out, mark it `Fail/Timeout` and still collect partial evidence.
- `RestartCount=5` is expected in sample BPLs.

## Scenarios

### S1 - CLI with generic AutoCAD resolution
```powershell
& $Exe (Join-Path $RepoRoot "TestFiles\xyz.bpl") run exit
```
Expected: ScriptPro resolves AutoCAD from registration, runs batch, applies restart policy.

### S2 - UI flow with generic AutoCAD resolution
```powershell
& $Exe
# In UI: Load TestFiles\xyz.bpl, click Run
```
Expected: same behavior as S1 through UI path.

### S3 - Attach to pre-existing AutoCAD instance
```powershell
# Launch AutoCAD manually first (path depends on machine)
# & $AcadExe

& $Exe (Join-Path $RepoRoot "TestFiles\xyz.bpl") run exit
```
Expected: existing instance reused; no forced restart behavior.
Important: ScriptPro and AutoCAD must run with matching privilege level.

### S4 - CLI with explicit AutoCAD path from BPL
```powershell
& $Exe (Join-Path $RepoRoot "TestFiles\xyz_noexe.bpl") run exit
```
Expected: run uses `AutoCADPath*...` value from BPL, with restart policy.

## Evidence collection (required)

Log folder comes from `LogFileName*` in BPL (sample uses `%LOCALAPPDATA%\Temp`).

```powershell
$LogRoot = "$env:LOCALAPPDATA\Temp"
Get-ChildItem $LogRoot -Filter "xyz*.log" |
  Where-Object { -not $_.PSIsContainer } |
  Sort-Object LastWriteTime -Descending |
  Select-Object -First 20 Name, LastWriteTime, FullName
```

PDF artifacts (for PlotToPDF sample):
```powershell
Get-ChildItem (Join-Path $RepoRoot "TestFiles") -Filter "*.pdf" |
  Select-Object Name, Length, LastWriteTime
```

Required attachments in PR:
1. environment (OS, AutoCAD version, VS version, build config),
2. per-scenario command + Pass/Fail,
3. summary log (`xyz_*.log`) and detail log (`xyz_Detail_*.log`),
4. artifact list (generated PDFs),
5. notes for any failure/timeout.

## PR report template

```md
## Test Run Report

### Environment
- OS:
- AutoCAD:
- Visual Studio:
- Build:

### Scenario Results
| Scenario | Command/Flow | Status | Notes |
|---|---|---|---|
| S1 | CLI + xyz.bpl | Pass/Fail | |
| S2 | UI + xyz.bpl | Pass/Fail | |
| S3 | Pre-opened AutoCAD + xyz.bpl | Pass/Fail | |
| S4 | CLI + xyz_noexe.bpl | Pass/Fail | |

### Evidence
- Summary log:
- Detail log:
- Generated PDFs:
- Screenshots (if UI issue):
```
