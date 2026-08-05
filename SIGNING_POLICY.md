# ClickShow Code Signing Policy

> 代码签名策略 / Code signing policy

**Status**: Applying to [SignPath Foundation](https://signpath.org) for the free open-source code signing program. Until the application is approved and the signing workflow is configured, existing release files are unsigned.
**状态**：正在向 SignPath Foundation 申请免费开源项目代码签名。申请批准并配置签名流程前，现有 release 未签名。

---

## 1. Project / 项目信息

| Item | Value |
|---|---|
| Repository | https://github.com/Icather/ClickShow |
| Download page | https://github.com/Icather/ClickShow/releases |
| Description | Ultra-lightweight Windows mouse click indicator: ~400KB single exe, tray resident, click ripple + cursor dot, DPI aware, i18n (zh/en). |
| Planned signing provider | Free code signing by [SignPath.io](https://signpath.io), certificate issued by **SignPath Foundation** |
| License | This fork's **new code** (Localization.cs, the rendering fix in SettingsWindow.xaml.cs, i18n changes) is licensed under **MIT** (see `LICENSE`). Upstream code remains the copyright of its original author. No proprietary components. |

**License disclosure / 许可声明**: This repository is a maintenance fork of `cuiliang/ClickShow` (archived upstream). The upstream project is publicly distributed on GitHub but declares **no explicit license**; all upstream code is publicly available and the original author distributes it freely via GitHub Releases. This fork's own additions are MIT-licensed. No component in this project is proprietary or closed-source, and no maintainer-affiliated proprietary code is included.

**Privacy / 隐私**: ClickShow stores only a local settings file (`Documents\ClickShow.setting`). Network activity is limited to: an optional update check (`https://helperservice.getquicker.cn/clickshow/version`) and the homepage/feedback link opened only on user action. **No user data is collected, transmitted, or telemetried.**

**Uninstall / 卸载**: Portable application, no installer. Removal = delete the files. No registry entries, no system services, no startup entries except the optional user-controlled auto-start registry value.

## 2. Release Controls / 发布控制

- Windows binaries are built from this public repository by **GitHub-hosted GitHub Actions runners** (planned).
- The workflow uploads the unsigned artifact, then submits it to SignPath for signing.
- **Every production signing request is manually approved** by a signing approver before SignPath processes it.
- A tagged GitHub Release is published **only after** the returned artifact passes Windows **Authenticode verification** (`Signer = SignPath Foundation`).
- **SHA-256 checksums are calculated after signing** and published alongside the release assets.
- The release workflow does not publish unsigned artifacts as GitHub Release assets.

## 3. Team Roles / 团队角色

Sole-maintainer project (single-person team, consistent with other SignPath-approved single-maintainer projects).

| Role | Person | Responsibility |
|---|---|---|
| **Author** | Icather | Maintains source code; trusted to modify the repository without additional review |
| **Reviewer** | Icather | Reviews all proposed changes before they land on release branches |
| **Approver** | Icather | Approves every signing request; denies any request that cannot be traced to an approved repository build |

## 4. Security Practices / 安全实践

- **MFA**: All maintainer accounts require multi-factor authentication for both **GitHub** and **SignPath** access.
- **Key protection**: Private signing keys are generated and stored on **SignPath's Hardware Security Module (HSM)**; no private key material ever reaches the build machine or the repository.
- **Origin verification**: Signed binaries are verified by SignPath to originate from this official repository only (trusted build system + origin verification).
- **No malware / no hacking tools**: The project contains no malware, no potentially unwanted programs, and no vulnerability-scanning or security-circumvention features.
- **System changes**: The application does not modify system configuration without user action (auto-start is user-enabled via a checkbox).

## 5. Verifying a Release / 校验方法

```powershell
# Check the Authenticode signature (expect "SignPath Foundation" as signer)
Get-AuthenticodeSignature .\ClickShow.exe

# Verify the SHA-256 checksum matches the published value
Get-FileHash .\ClickShow.exe -Algorithm SHA256
```

For a signed production release, `Get-AuthenticodeSignature` must report **Valid**, and the hash must match the checksum published in the same GitHub Release.

## 6. Reporting Issues / 问题报告

If you encounter a signed binary that appears malicious or tampered with: do not run it; report the file hash and download source via a GitHub issue in this repository.

---

*Free code signing provided by [SignPath.io](https://signpath.io), certificate by [SignPath Foundation](https://signpath.org).*
