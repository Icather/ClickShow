<div align="center">

# ClickShow

**Ultra-lightweight Windows mouse click indicator**

A single **~400KB** exe, portable, tray-resident. Click ripple + cursor dot, DPI aware, i18n (zh/en).

[English](README.md) · [中文](README.zh-CN.md)

[![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows&logoColor=white)](https://github.com/Icather/ClickShow)
[![Language](https://img.shields.io/badge/C%23-WPF-512BD4?logo=csharp&logoColor=white)](https://github.com/Icather/ClickShow)
[![Size](https://img.shields.io/badge/Size-%7E400KB-06b6d4)](https://github.com/Icather/ClickShow)
[![License](https://img.shields.io/badge/License-MIT%20(fork%20code)-22c55e)](LICENSE)
[![Release](https://img.shields.io/github/v/release/Icather/ClickShow?color=blue)](https://github.com/Icather/ClickShow/releases/latest)

### 📥 Download

[![GitHub Release](https://img.shields.io/badge/GitHub%20Release-%E4%B8%8B%E8%BD%BD-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Icather/ClickShow/releases/latest)
[![Lanzou](https://img.shields.io/badge/Lanzou-%E4%B8%8B%E8%BD%BD-2E7CF6?style=for-the-badge)](https://wwawp.lanzouu.com/iOP7140pa8ud)
[![123Pan](https://img.shields.io/badge/123Pan-%E4%B8%8B%E8%BD%BD-FF4A1E?style=for-the-badge)](https://1821431120.share.123pan.cn/123pan/aGWpjv-JXapd)

> Unzip and run `ClickShow.exe`, no install needed.
> Chinese users: prefer the Lanzou / 123Pan mirrors; GitHub users can grab the Release.

</div>

> **Maintenance note (2026-08)**
>
> This is a maintenance fork. Upstream [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow) is archived and no longer maintained. This fork fixes the settings-window freeze on Windows 11 24H2/25H2. If upstream ever un-archives and accepts a PR, this fork will update the README to add a link pointing back to the upstream repo.

---

## Branches

| Branch | Purpose |
|:--|:--|
| `main` | **Maintenance line (recommended)** — fix + i18n + v1.4.2.0, used for daily use and releases. |
| `fix-settings-freeze` | **Upstream PR candidate** — single-commit fix (Option B software rendering) kept clean for a potential PR if upstream ever un-archives. |

## Fix for Windows 11 24H2/25H2

**Problem**: Opening the Settings window ("更多设置") hangs the app (window appears but unresponsive).

**Root cause**: It is a WPF render-thread failure (`UCEERR_RENDERTHREADFAILURE`). The upstream 1.4.1 release was built with `ReleaseElevated` (`uiAccess="true"`, added for showing effects above elevated windows, see upstream [#43](https://github.com/cuiliang/ClickShow/issues/43)), which triggers the Microsoft-confirmed WPF render-thread hang on Win11 24H2/25H2 (after KB5072033). See [WPF Render Thread Failures – .NET Framework](https://learn.microsoft.com/troubleshoot/developer/dotnet/framework/general/wpf-render-thread-failures).

**Fix**:
- Manifest `uiAccess="false"` (quick workaround, Option A).
- Software rendering forced for the settings window only (Option B, the workaround Microsoft recommends; animation windows keep hardware rendering).

## Features

| Feature | Description |
|:--|:--|
| **Ultra-lightweight** | Single ~400KB exe, portable, tray-resident |
| **Click ripple** | Ripple on mouse click, distinct color per button |
| **Cursor dot** | Indicator dot that follows the mouse |
| **DPI aware** | Multi-monitor DPI aware |
| **Auto-start** | Optional auto-start with Windows |
| **i18n** | UI follows system language (zh-CN / English) |

## Usage

- Requirements: Windows 7 SP1+, .NET Framework 4.7.2 (built into Win10+).
- To show effects above elevated windows (Task Manager, Start menu, admin apps), place the exe in `C:\Windows` or `C:\Program Files` — it will auto-elevate (1.3.1+).
- Minimizes to the system tray on start.
- Clicking X hides to tray.
- Left-click tray icon opens the main window, right-click opens the menu.

![test](https://user-images.githubusercontent.com/1972649/122925974-f17ead00-d399-11eb-9c57-9b2f14dd5973.gif)

![image](https://user-images.githubusercontent.com/1972649/129450207-45174d8b-89ad-489c-876b-a2bc657e5417.png)

## Changelog

### 1.4.2 (2026-08, this fork)
- i18n: UI follows system language (zh-CN / English).
- Version bumped to 1.4.2.0.

### 1.4.1-fix1 (2026-08, this fork)
- Fix settings-window freeze on Windows 11 24H2/25H2.
- Software rendering for settings window + manifest `uiAccess="false"`.

### 1.4.1
- Fix mouse-passthrough issue.
- Check for updates on start.

### 1.4.0
- Added settings and auto-save. Thanks @BigDevil82.

### 1.3.3
- Ripple avoids the exact center on press.

### 1.3.2
- Shows a small ripple on release after long press or long move.

### 1.3.1
- Avoid rendering below other windows in some cases.

### 1.3
- Fix not working on Win7.
- Multi-monitor DPI awareness.
- Auto-start with Windows.
- New blue icon.

## Troubleshooting

- Effects missing: the mouse hook was lost, restart the app.
- Auto-start blocked by third-party managers, enable it there.

## Credits

- Original (archived) upstream [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow), thanks to the author.
- Icon source: https://www.iconfont.cn/collections/detail?spm=a313x.7781069.1998910419.dc64b3430&cid=13315
