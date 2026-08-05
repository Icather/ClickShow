using System;
using System.Collections.Generic;
using System.Globalization;

namespace ClickShow
{
    /// <summary>
    /// Simple localization: UI strings for zh-CN and en (default).
    /// Language follows the system UI culture at startup (no runtime switching).
    /// </summary>
    public static class Strings
    {
        private static readonly Dictionary<string, string> En = new Dictionary<string, string>
        {
            // SettingsWindow
            { nameof(SettingsTitle), "Settings" },
            { nameof(RippleAppearance), "Ripple appearance" },
            { nameof(RippleSize), "Ripple size:" },
            { nameof(RippleColors), "Ripple color per button:" },
            { nameof(Left), "Left:" },
            { nameof(Middle), "Middle:" },
            { nameof(Right), "Right:" },
            { nameof(XButton1), "Side button (back):" },
            { nameof(XButton2), "Side button (forward):" },
            { nameof(Enabled), "Enable" },
            { nameof(HoverDotAppearance), "Cursor indicator" },
            { nameof(HoverDotSize), "Indicator size:" },
            { nameof(HoverDotColor), "Indicator color:" },
            { nameof(RestoreDefaults), "Defaults" },
            { nameof(Close), "Close(_C)" },

            // MainWindow
            { nameof(AutoStart), "Start with Windows(_S)" },
            { nameof(EnableClickCircle), "Show click effect(_C)" },
            { nameof(EnableHoverDot), "Show cursor indicator(_F)" },
            { nameof(FeedbackLink), "Feedback & Updates / Homepage" },
            { nameof(NewVersionAvailable), "New version available!" },
            { nameof(MoreSettings), "More Settings(_S)..." },
            { nameof(Exit), "Exit(_X)" },
            { nameof(AutoStartToolTip), "Start automatically with Windows" },
            { nameof(ClickCircleToolTip), "Show a ripple effect on click" },
            { nameof(HoverDotToolTip), "Show a dot that follows the cursor" },

            // Code strings
            { nameof(TrayBalloonTip), "ClickShow\nMouse click indicator\nClick to open" },
            { nameof(TrayExit), "Exit" },
            { nameof(NewVersionPrompt), "ClickShow has a new version ({0}). Open the page now?" },
            { nameof(CannotOpenUrl), "Cannot open URL: {0}" },
            { nameof(AutoStartLoadError), "Failed to load auto-start status." },
            { nameof(AutoStartSaveError), "Failed to save auto-start status." },
            { nameof(CorruptSettings), "Settings file is corrupt; defaults restored." },
            { nameof(ApplySettingsError), "Failed to apply settings; reset to defaults. Error: " },
            { nameof(SaveSettingsError), "Failed to save settings: " },
        };

        private static readonly Dictionary<string, string> Zh = new Dictionary<string, string>
        {
            // SettingsWindow
            { nameof(SettingsTitle), "设置" },
            { nameof(RippleAppearance), "点击波纹外观设置" },
            { nameof(RippleSize), "波纹大小:" },
            { nameof(RippleColors), "各按键波纹颜色:" },
            { nameof(Left), "左：" },
            { nameof(Middle), "中：" },
            { nameof(Right), "右：" },
            { nameof(XButton1), "侧键(后退)：" },
            { nameof(XButton2), "侧键(前进)：" },
            { nameof(Enabled), "启用" },
            { nameof(HoverDotAppearance), "位置浮标外观" },
            { nameof(HoverDotSize), "悬浮标大小:" },
            { nameof(HoverDotColor), "悬浮标颜色:" },
            { nameof(RestoreDefaults), "默认值" },
            { nameof(Close), "关闭(_C)" },

            // MainWindow
            { nameof(AutoStart), "开机自动启动(_S)" },
            { nameof(EnableClickCircle), "显示点击特效(_C)" },
            { nameof(EnableHoverDot), "显示位置提示浮标(_F)" },
            { nameof(FeedbackLink), "反馈与更新 / Homepage" },
            { nameof(NewVersionAvailable), "已有新版本!" },
            { nameof(MoreSettings), "更多设置(_S)..." },
            { nameof(Exit), "退出(_X)" },
            { nameof(AutoStartToolTip), "是否开机自动启动" },
            { nameof(ClickCircleToolTip), "点击时显示波纹特效" },
            { nameof(HoverDotToolTip), "在鼠标指针周围显示原点，跟随鼠标移动" },

            // Code strings
            { nameof(TrayBalloonTip), "ClickShow\n鼠标点击提示器\n点击打开" },
            { nameof(TrayExit), "退出(Exit)" },
            { nameof(NewVersionPrompt), "ClickShow有新版本（{0}），是否立即打开网页？" },
            { nameof(CannotOpenUrl), "无法打开网址：{0}" },
            { nameof(AutoStartLoadError), "无法加载开机自动启动状态。" },
            { nameof(AutoStartSaveError), "无法保存开机自动启动状态。" },
            { nameof(CorruptSettings), "配置文件损坏了，设置已恢复为默认值。" },
            { nameof(ApplySettingsError), "应用设置出错，已重置设置。错误：" },
            { nameof(SaveSettingsError), "设置保存出错：" },
        };

        private static bool IsChinese
        {
            get
            {
                var name = CultureInfo.CurrentUICulture.Name;
                return name.StartsWith("zh", StringComparison.OrdinalIgnoreCase);
            }
        }

        private static string Get(string key)
        {
            var table = IsChinese ? Zh : En;
            return table.TryGetValue(key, out var value) ? value : key;
        }

        // SettingsWindow
        public static string SettingsTitle => Get(nameof(SettingsTitle));
        public static string RippleAppearance => Get(nameof(RippleAppearance));
        public static string RippleSize => Get(nameof(RippleSize));
        public static string RippleColors => Get(nameof(RippleColors));
        public static string Left => Get(nameof(Left));
        public static string Middle => Get(nameof(Middle));
        public static string Right => Get(nameof(Right));
        public static string XButton1 => Get(nameof(XButton1));
        public static string XButton2 => Get(nameof(XButton2));
        public static string Enabled => Get(nameof(Enabled));
        public static string HoverDotAppearance => Get(nameof(HoverDotAppearance));
        public static string HoverDotSize => Get(nameof(HoverDotSize));
        public static string HoverDotColor => Get(nameof(HoverDotColor));
        public static string RestoreDefaults => Get(nameof(RestoreDefaults));
        public static string Close => Get(nameof(Close));

        // MainWindow
        public static string AutoStart => Get(nameof(AutoStart));
        public static string EnableClickCircle => Get(nameof(EnableClickCircle));
        public static string EnableHoverDot => Get(nameof(EnableHoverDot));
        public static string FeedbackLink => Get(nameof(FeedbackLink));
        public static string NewVersionAvailable => Get(nameof(NewVersionAvailable));
        public static string MoreSettings => Get(nameof(MoreSettings));
        public static string Exit => Get(nameof(Exit));
        public static string AutoStartToolTip => Get(nameof(AutoStartToolTip));
        public static string ClickCircleToolTip => Get(nameof(ClickCircleToolTip));
        public static string HoverDotToolTip => Get(nameof(HoverDotToolTip));

        // Code strings
        public static string TrayBalloonTip => Get(nameof(TrayBalloonTip));
        public static string TrayExit => Get(nameof(TrayExit));
        public static string NewVersionPrompt => Get(nameof(NewVersionPrompt));
        public static string CannotOpenUrl => Get(nameof(CannotOpenUrl));
        public static string AutoStartLoadError => Get(nameof(AutoStartLoadError));
        public static string AutoStartSaveError => Get(nameof(AutoStartSaveError));
        public static string CorruptSettings => Get(nameof(CorruptSettings));
        public static string ApplySettingsError => Get(nameof(ApplySettingsError));
        public static string SaveSettingsError => Get(nameof(SaveSettingsError));
    }
}
