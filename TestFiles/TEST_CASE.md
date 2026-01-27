# ScriptPro Test Cases

**Config:** RestartCount=5, 9 drawings, ~45 seconds per test

---

## Scenario 1: CLI + Specific EXE
```powershell
ScriptUI.exe "D:\Projects\2025\ScriptProPlus\TestFiles\xyz.bpl" run exit
```
- Launches AutoCAD 2026 (specified in .bpl)
- Processes drawings 1-5 → **Restarts silently** → Processes 6-9 → Exits

---

## Scenario 2: UI + Specific EXE
```powershell
ScriptUI.exe  # Load xyz.bpl, click Run
```
- Same as Scenario 1 via GUI
- Confirms restart works in both modes

---

## Scenario 3: Pre-existing AutoCAD
```powershell
# 1. Launch AutoCAD 2026 manually
D:\ACAD\AutoCAD 2026\acad.exe

# 2. Run ScriptPro
ScriptUI.exe "xyz.bpl" run exit
```
- Shows warning dialog (first time only)
- Processes all 9 drawings in **same instance** (NO restart)
- AutoCAD stays open after exit
- **⚠️ Requires matching privileges** (both admin or both non-admin)

---

## Scenario 4: Generic Mode
```powershell
ScriptUI.exe "D:\Projects\2025\ScriptProPlus\TestFiles\xyz_noexe.bpl" run exit
```
- Uses latest registered AutoCAD (AutoCADPath empty)
- Creates via COM → Restarts after 5 drawings → Exits

---

## Summary

| Scenario | AutoCAD Launch | Restart? | Exit Behavior |
|----------|----------------|----------|---------------|
| 1, 2, 4 | ScriptPro launches | ✅ After 5 dwgs | Closes AutoCAD |
| 3 | User launches | ❌ No restart | Stays open |

**Key:** Let ScriptPro launch AutoCAD for automatic restarts and memory management.
