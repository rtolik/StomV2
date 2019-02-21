using System.IO;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;
using Stomatology.Forms;
using Stomatology.Properties;
using Stomatology.Utils;
using Settings = Stomatology.Utils.Settings;

namespace Stomatology
{
    public partial class Main : MetroForm
    {
        private Settings _settings;

        public Main()
        {
            InitializeComponent();
            
            InitBrowser();

            InitTheme();
        }

        private void InitTheme()
        {
            StyleManager = metroStyleManager1;

            if (File.Exists(Resources.InstallPath + @"Settings\Settings.xml"))
            {
                _settings = SettingsSerializer.DeserializeSettings();
            }
            else
            {
                _settings = new Settings(0, 0,-1);
                SettingsSerializer.SerializeSettings(_settings);
            }

            metroStyleManager1.Style = (MetroColorStyle) _settings.Style;
            metroStyleManager1.Theme = (MetroThemeStyle) _settings.Theme;
        }

        private void InitBrowser()
        {
            InitBrowserEngine();

            webBrowser1.Navigate("https://calendar.google.com/calendar/r?pli=1");
        }

        private static void InitBrowserEngine()
        {
            try
            {
                using (
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
                )
                {
                    dynamic value = rk.GetValue("Stomatology.exe");
                    if (value == null)
                        rk.SetValue("Stomatology.exe", (uint) 11001, RegistryValueKind.DWord);
                }
            }
            catch
            {
            }
        }

        private void CardFileBtn_Click(object sender, System.EventArgs e)
        {
            CardFile form = new CardFile();
            form.Show();
        }
    }
}