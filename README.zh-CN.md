<div align="center">

# ClickShow

**极轻量的 Windows 鼠标点击提示器**

单个 exe 约 **400KB**，绿色免安装，托盘常驻。点击波纹特效 + 光标位置浮标，DPI 感知，中英双语。

[English](README.md) · [中文](README.zh-CN.md)

[![平台](https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows&logoColor=white)](https://github.com/Icather/ClickShow)
[![语言](https://img.shields.io/badge/C%23-WPF-512BD4?logo=csharp&logoColor=white)](https://github.com/Icather/ClickShow)
[![体积](https://img.shields.io/badge/Size-%7E400KB-06b6d4)](https://github.com/Icather/ClickShow)
[![许可证](https://img.shields.io/badge/License-MIT%20(fork%20code)-22c55e)](LICENSE)
[![版本](https://img.shields.io/github/v/release/Icather/ClickShow?color=blue)](https://github.com/Icather/ClickShow/releases/latest)

### 📥 下载

[![GitHub Release](https://img.shields.io/badge/GitHub%20Release-%E4%B8%8B%E8%BD%BD-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Icather/ClickShow/releases/latest)
[![蓝奏云](https://img.shields.io/badge/%E8%93%9D%E5%A5%8F%E4%BA%91-%E4%B8%8B%E8%BD%BD-2E7CF6?style=for-the-badge)](https://wwawp.lanzouu.com/iOP7140pa8ud)
[![123云盘](https://img.shields.io/badge/123%E4%BA%91%E7%9B%98-%E4%B8%8B%E8%BD%BD-FF4A1E?style=for-the-badge)](https://1821431120.share.123pan.cn/123pan/aGWpjv-JXapd)

> 解压后运行 `ClickShow.exe` 即可，无需安装。
> 国内用户优先使用蓝奏云 / 123云盘镜像，GitHub 用户直接走 Release。

</div>

> **维护说明 (2026-08)**
>
> 本仓库是修复维护 fork。上游仓库 [cuiliang/ClickShow](https://github.com/cuiliang/ClickShow) 已归档（archived），不再维护。本 fork 修复了 Windows 11 24H2/25H2 上打开「更多设置」导致程序卡死的问题。若上游解除归档并接受 PR，本 fork 将更新 README 添加原项目跳转链接。

---

## 分支说明

| 分支 | 用途 |
|:--|:--|
| `main` | **维护线（推荐使用）** — 包含修复 + i18n + 版本 1.4.2.0，日常使用和 release 发布都从这里出。 |
| `fix-settings-freeze` | **上游 PR 候选** — 基于上游 main 的单个修复 commit（方案 B 软件渲染），若上游解除归档将直接以此分支向原仓库提交 PR。 |

## Windows 11 24H2/25H2 修复说明

**问题**: 打开「更多设置」（Settings）后程序卡死（窗口出现但无响应）。

**根因**: WPF 渲染线程故障（`UCEERR_RENDERTHREADFAILURE`）。官方 1.4.1 发布版使用 `ReleaseElevated` 配置构建（`uiAccess="true"`，用于在管理员窗口之上显示特效，见上游 [#43](https://github.com/cuiliang/ClickShow/issues/43)），该路径在 Windows 11 24H2/25H2（KB5072033 后）触发微软已确认的 WPF 渲染线程挂起。参见 [WPF Render Thread Failures – .NET Framework](https://learn.microsoft.com/troubleshoot/developer/dotnet/framework/general/wpf-render-thread-failures)。

**修复**:
- manifest `uiAccess="false"`（快速方案 A）。
- 设置窗口强制软件渲染（方案 B，微软官方推荐的 workaround；特效窗口保持硬件渲染）。

## 特色功能

| 功能 | 说明 |
|:--|:--|
| **极轻量** | 单个 exe 约 400KB，绿色免安装，托盘常驻 |
| **点击波纹** | 鼠标点击时显示波纹特效，每个按键对应不同的颜色 |
| **位置浮标** | 支持跟随鼠标的位置指示圆标 |
| **DPI 感知** | 支持多屏 DPI 感知 |
| **开机自启** | 支持开机自启动 |
| **中英双语** | 界面跟随系统语言（中/英） |

## 使用

- 系统需求：Windows 7 SP1+，.NET Framework 4.7.2（Win10+ 自带）。
- 如需在任务管理器、开始菜单、管理员权限窗口上生效，请将程序放到 `C:\Windows` 或 `C:\Program Files` 目录下使用（1.3.1+ 版本会自动提升权限）。
- 启动后自动缩到系统托盘。
- 点 X 最小化到托盘。
- 左键点托盘图标打开主窗口，右键打开菜单。

![test](https://user-images.githubusercontent.com/1972649/122925974-f17ead00-d399-11eb-9c57-9b2f14dd5973.gif)

![image](https://user-images.githubusercontent.com/1972649/129450207-45174d8b-89ad-489c-876b-a2bc657e5417.png)

## 更新历史

### 1.4.2 (2026-08, 本 fork)
- 界面国际化，跟随系统语言（中/英）。
- 版本号升至 1.4.2.0。

### 1.4.1-fix1 (2026-08, 本 fork)
- 修复 Windows 11 24H2/25H2 设置窗口卡死。
- 设置窗口强制软件渲染 + manifest `uiAccess="false"`。

### 1.4.1
- 修复鼠标穿透问题。
- 启动后检查版本更新。

### 1.4.0
- 增加参数设置与自动保存。感谢 @BigDevil82 贡献代码。

### 1.3.3
- 按下时的波纹效果避开中心一点。

### 1.3.2
- 长按鼠标抬起时，或鼠标移动了较远距离抬起时，显示小波纹提示抬起事件。

### 1.3.1
- 避免某些情况下显示到别的窗口下面的问题。

### 1.3
- 解决 Win7 下不生效的问题。
- 支持多屏 Dpi 感知。
- 支持随 Windows 自动启动。
- 换了一个蓝色的图标。

## 可能会遇到的问题

- 特效丢失：鼠标挂钩丢失了，需要重启程序。
- 自启动不生效：被各类管家或启动软件拦截，请在这些软件里设置。

## 致谢

- 上游原仓库（已归档）：[cuiliang/ClickShow](https://github.com/cuiliang/ClickShow)，感谢原作者 cuiliang 的作品。
- 图标来源: https://www.iconfont.cn/collections/detail?spm=a313x.7781069.1998910419.dc64b3430&cid=13315
