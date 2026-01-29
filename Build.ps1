# ScriptProPlus Build Script
# Usage:
#   .\Build.ps1                    # Build Debug x64 (default)
#   .\Build.ps1 -Release           # Build Release x64
#   .\Build.ps1 -Setup             # Build + Create MSI Installer
#   .\Build.ps1 -Standalone        # Create portable standalone package

param(
    [switch]$Release,
    [switch]$Setup,
    [switch]$Standalone
)

$ErrorActionPreference = "Stop"
$SolutionPath = "ScriptProPlus.sln"

# Determine configuration
$Config = if ($Release -or $Setup -or $Standalone) { "Release" } else { "Debug" }
$Platform = "x64"

Write-Host "========================================" -ForegroundColor Cyan
Write-Host " ScriptProPlus Build Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Configuration: $Config"
Write-Host "Platform: $Platform"
Write-Host ""

# Build the solution
Write-Host "Building solution..." -ForegroundColor Yellow
msbuild $SolutionPath /p:Configuration=$Config /p:Platform=$Platform /t:Rebuild /m /v:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}

Write-Host "Build successful!" -ForegroundColor Green
Write-Host ""

$OutputPath = "Binaries\$Platform\$Config\net8.0-windows"
Write-Host "Output: $OutputPath" -ForegroundColor Green

# Create MSI Installer
if ($Setup) {
    Write-Host ""
    Write-Host "Building installer..." -ForegroundColor Yellow
    
    # Build WiX installer
    msbuild ScriptProSetup\ScriptProSetup.wixproj /p:Configuration=$Config /p:Platform=x64 /v:minimal
    
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Installer build failed!" -ForegroundColor Red
        exit 1
    }
    
    $MsiPath = "ScriptProSetup\bin\$Config\ScriptProSetup.msi"
    if (Test-Path $MsiPath) {
        Write-Host "Installer created: $MsiPath" -ForegroundColor Green
        
        # Copy to Release folder
        if (!(Test-Path "Release")) { New-Item -ItemType Directory -Path "Release" | Out-Null }
        Copy-Item $MsiPath "Release\ScriptProSetup.msi" -Force
        Write-Host "Copied to: Release\ScriptProSetup.msi" -ForegroundColor Green
    }
}

# Create Standalone Package
if ($Standalone) {
    Write-Host ""
    Write-Host "Creating standalone package..." -ForegroundColor Yellow
    
    $StandaloneDir = "Standalone\ScriptPro-Portable"
    if (Test-Path $StandaloneDir) {
        Remove-Item $StandaloneDir -Recurse -Force
    }
    
    New-Item -ItemType Directory -Path $StandaloneDir | Out-Null
    
    # Copy binaries
    Copy-Item "$OutputPath\*" $StandaloneDir -Recurse -Force
    
    # Copy README.md from root
    if (Test-Path "README.md") {
        Copy-Item "README.md" $StandaloneDir -Force
    }
    
    Write-Host "Standalone package created: $StandaloneDir" -ForegroundColor Green
    
    # Create ZIP
    $ZipPath = "Release\ScriptPro-Portable.zip"
    if (Test-Path $ZipPath) { Remove-Item $ZipPath -Force }
    
    # Create Release folder if needed
    if (!(Test-Path "Release")) { New-Item -ItemType Directory -Path "Release" | Out-Null }
    
    Compress-Archive -Path "$StandaloneDir\*" -DestinationPath $ZipPath
    
    Write-Host "ZIP created: $ZipPath" -ForegroundColor Green
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host " Build Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan

