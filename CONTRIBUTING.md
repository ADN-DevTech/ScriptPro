# Contributing to ScriptProPlus

Thanks for contributing.

## Pull Request Expectations

All PRs should include:

1. A short summary of what changed and why.
2. Scope statement (what is included and what is intentionally not included).
3. Test evidence for the touched behavior.

## Required Test Evidence

Use `TestFiles\TEST_CASE.md` as the baseline and attach a test report in the PR description or comments.

For every relevant scenario, include:

1. **Environment**
   - Windows version
   - AutoCAD version
   - Visual Studio version
   - Build config/platform
2. **Results**
   - Scenario name/ID
   - Pass/Fail
   - Notes (actual behavior, errors, or deviation)
3. **Artifacts**
   - Screenshots and/or logs when behavior changes or a test fails.

If you change UI/UX only, test evidence is still required (at minimum: launch + workflow sanity on affected screens).

## Suggested Report Template

```md
## Test Run Report

### Environment
- OS:
- AutoCAD:
- Visual Studio:
- Build: Release|x64 (or other)

### Results
| Scenario | Status | Notes |
|---|---|---|
| Scenario 1 (CLI + Specific EXE) | Pass | |
| Scenario 2 (UI + Specific EXE) | Pass | |
| Scenario 3 (Pre-existing AutoCAD) | Pass | |
| Scenario 4 (Generic Mode) | Pass | |

### Artifacts
- Screenshot/log links:
```

## Quality Notes

- Keep changes focused and avoid unrelated refactors.
- Update docs when behavior, setup, or user-visible UI is changed.
- Confirm build success before opening or updating the PR.
