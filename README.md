> **维护说明 / Maintenance note (2026-08)**
>
> 本仓库是修复维护 fork。上游仓库 [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow) 已归档（archived），不再维护。本 fork 修复了 Windows 11 24H2/25H2 上打开「更多设置」导致程序卡死的问题。若上游解除归档并接受 PR，本 fork 将更新 README 添加原项目跳转链接。
>
> This is a maintenance fork. Upstream [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow) is archived and no longer maintained. This fork fixes the settings-window freeze on Windows 11 24H2/25H2. If upstream ever un-archives and accepts a PR, this fork will update the README to add a link pointing back to the upstream repo.

---

# ClickShow

**极轻量**的 Windows 鼠标点击提示器：单个 exe 约 **400KB**，绿色免安装，托盘常驻。 / **Ultra-lightweight** Windows mouse click indicator: a single **~400KB** exe, portable, tray-resident.

用于提示鼠标点击、鼠标位置。 / Shows a visual indicator for mouse clicks and cursor position.

## 分支说明 / Branches

- `main` — **维护线（推荐使用）**：包含修复 + i18n + 版本 1.4.2.0，日常使用和 release 发布都从这里出。 / **Maintenance line (recommended)**: fix + i18n + v1.4.2.0, used for daily use and releases.
- `fix-settings-freeze` — **上游 PR 候选**：基于上游 main 的单个修复 commit（方案 B 软件渲染），若上游解除归档将直接以此分支向原仓库提交 PR。 / **Upstream PR candidate**: single-commit fix (Option B software rendering) based on upstream main, kept clean for a potential PR if upstream ever un-archives.

## 下载 / Download

**推荐下载修复版 / Recommended (fixed build):** [v1.4.1-fix1](https://github.com/Icather/ClickShow/releases/tag/v1.4.1-fix1)

> 解压后运行 `ClickShow.exe` 即可，无需安装。 / Unzip and run `ClickShow.exe`, no install needed.

## Windows 11 24H2/25H2 修复说明 / Fix for Windows 11 24H2/25H2

**问题 / Problem**: 打开「更多设置」（Settings）后程序卡死（窗口出现但无响应）。

**根因 / Root cause**: WPF 渲染线程故障（`UCEERR_RENDERTHREADFAILURE`）。官方 1.4.1 发布版使用 `ReleaseElevated` 配置构建（`uiAccess="true"`，用于在管理员窗口之上显示特效，见上游 [#43](https://github.com/cuiliang/ClickShow/issues/43)），该路径在 Windows 11 24H2/25H2（KB5072033 后）触发微软已确认的 WPF 渲染线程挂起。参见 [WPF Render Thread Failures – .NET Framework](https://learn.microsoft.com/troubleshoot/developer/dotnet/framework/general/wpf-render-thread-failures)。

**修复 / Fix (v1.4.1-fix1)**:
- manifest `uiAccess="false"`（快速方案 A）
- 设置窗口强制软件渲染（方案 B，防御渲染线程故障，微软官方推荐的 workaround）

It is a WPF render-thread failure (`UCEERR_RENDERTHREADFAILURE`). The upstream 1.4.1 release was built with `ReleaseElevated` (`uiAccess="true"`, added for showing effects above elevated windows, see upstream [#43](https://github.com/cuiliang/ClickShow/issues/43)), which triggers the Microsoft-confirmed WPF render-thread hang on Win11 24H2/25H2 (after KB5072033). See [WPF Render Thread Failures – .NET Framework](https://learn.microsoft.com/troubleshoot/developer/dotnet/framework/general/wpf-render-thread-failures). The fix: manifest `uiAccess="false"` plus software rendering for the settings window only (the workaround Microsoft recommends).

## 特色功能 / Features

- **极轻量**：单个 exe 约 400KB，绿色免安装，托盘常驻；/ **Ultra-lightweight**: single ~400KB exe, portable, tray-resident;
- 鼠标点击时显示波纹特效，每个按键对应不同的颜色；/ Shows a ripple effect on mouse click, with a distinct color per button;
- 支持跟随鼠标的位置指示圆标；/ Cursor-position indicator dot that follows the mouse;
- 支持多屏 DPI 感知；/ Multi-monitor DPI aware;
- 支持开机自启动；/ Auto-start with Windows;

## 使用 / Usage

- 系统需求：Windows 7 SP1+，.NET Framework 4.7.2（Win10+ 自带）。/ Requirements: Windows 7 SP1+, .NET Framework 4.7.2 (built into Win10+).
- 如需在任务管理器、开始菜单、管理员权限窗口上生效，请将程序放到 `C:\Windows` 或 `C:\Program Files` 目录下使用（1.3.1+ 版本会自动提升权限）。/ To show effects above elevated windows (Task Manager, Start menu, admin apps), place the exe in `C:\Windows` or `C:\Program Files` — it will auto-elevate (1.3.1+).
- 启动后自动缩到系统托盘。 / Minimizes to the system tray on start.
- 点 X 最小化到托盘。 / Clicking X hides to tray.
- 左键点托盘图标打开主窗口，右键打开菜单。 / Left-click tray icon opens the main window, right-click opens the menu.

![test](https://user-images.githubusercontent.com/1972649/122925974-f17ead00-d399-11eb-9c57-9b2f14dd5973.gif)

![image](https://user-images.githubusercontent.com/1972649/129450207-45174d8b-89ad-489c-876b-a2bc657e5417.png)

## 更新历史 / Changelog

### 1.4.1-fix1 (2026-08, this fork)
- 修复 Windows 11 24H2/25H2 设置窗口卡死。 / Fix settings-window freeze on Windows 11 24H2/25H2.
- 设置窗口强制软件渲染 + manifest `uiAccess="false"`。 / Software rendering for settings window + manifest `uiAccess="false"`.

### 1.4.1
- 修复鼠标穿透问题。 / Fix mouse-passthrough issue.
- 启动后检查版本更新。 / Check for updates on start.

### 1.4.0
- 增加参数设置与自动保存。感谢 @BigDevil82 贡献代码。 / Added settings and auto-save. Thanks @BigDevil82.

### 1.3.3
- 按下时的波纹效果避开中心一点。 / Ripple avoids the exact center on press.

### 1.3.2
- 长按鼠标抬起时，或鼠标移动了较远距离抬起时，显示小波纹提示抬起事件。 / Shows a small ripple on release after long press or long move.

### 1.3.1
- 避免某些情况下显示到别的窗口下面的问题。 / Avoid rendering below other windows in some cases.

### 1.3
- 解决 Win7 下不生效的问题。 / Fix not working on Win7.
- 支持多屏 Dpi 感知。 / Multi-monitor DPI awareness.
- 支持随 Windows 自动启动。 / Auto-start with Windows.
- 换了一个蓝色的图标。 / New blue icon.

## 可能会遇到的问题 / Troubleshooting

- 特效丢失：鼠标挂钩丢失了，需要重启程序。 / Effects missing: the mouse hook was lost, restart the app.
- 自启动不生效：被各类管家或启动软件拦截，请在这些软件里设置。 / Auto-start blocked by third-party managers, enable it there.

## 致谢 / Credits

- 上游原仓库（已归档）：[cuiliang/ClickShow](https://github.com/cuiliang/ClickShow)，感谢原作者 cuiliang 的作品。 / Original (archived) upstream [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow), thanks to the author.
- 图标来源 / Icon source: https://www.iconfont.cn/collections/detail?spm=a313x.7781069.1998910419.dc64b3430&cid=13315
