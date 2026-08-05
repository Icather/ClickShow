using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClickShow.Settings;
using Button = System.Windows.Controls.Button;

namespace ClickShow.UI
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly AppSetting _settings;

        public SettingsWindow(AppSetting appSetting)
        {
            _settings = appSetting;
            InitializeComponent();

            this.DataContext = appSetting;

            // Force software rendering once the window handle is created to avoid
            // WPF render-thread failures on Windows 11 24H2/25H2.
            SourceInitialized += (s, e) => ForceSoftwareRendering();
        }

        /// <summary>
        /// Force software rendering for this window only.
        /// Workaround for WPF render-thread failures (UCEERR_RENDERTHREADFAILURE)
        /// seen on Windows 11 24H2/25H2 with hardware-accelerated rendering.
        /// https://learn.microsoft.com/troubleshoot/developer/dotnet/framework/general/wpf-render-thread-failures
        /// </summary>
        private void ForceSoftwareRendering()
        {
            try
            {
                var hwnd = new WindowInteropHelper(this).Handle;
                var source = HwndSource.FromHwnd(hwnd);
                if (source != null)
                {
                    source.CompositionTarget.RenderMode = RenderMode.SoftwareOnly;
                }
            }
            catch
            {
                // Best-effort workaround; ignore failures.
            }
        }

        

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnRestoreDefault_OnClick(object sender, RoutedEventArgs e)
        {
            var defaultSetting = new AppSetting();

            _settings.IndicatorSize = defaultSetting.IndicatorSize;
            foreach (var key in _settings.MouseButtonSettings.Keys.ToList())
            {
                _settings.MouseButtonSettings[key].IsEnabled = defaultSetting.MouseButtonSettings[key].IsEnabled;
                _settings.MouseButtonSettings[key].Color = defaultSetting.MouseButtonSettings[key].Color;
            }

            _settings.HoverDotSize = defaultSetting.HoverDotSize;
            _settings.HoverDotFill = defaultSetting.HoverDotFill;
        }
    }
}
