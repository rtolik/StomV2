using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MetroFramework.Properties;
using Resources = Stomatology.Properties.Resources;

namespace Stomatology.Utils
{
    public class SettingsSerializer
    {
        public static void SerializeSettings(Settings settings)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(Resources.InstallPath+@"Settings\Settings.xml", FileMode.Create))
            {
                xs.Serialize(fs, settings);
            }
        }

        public static Settings DeserializeSettings()
        {
            Settings settings = new Settings(0, 0, 1);
            XmlSerializer xs = new XmlSerializer(typeof(Settings));
            if (File.Exists(Resources.InstallPath + @"Settings\Settings.xml"))
            {
                using (FileStream fs = new FileStream(Resources.InstallPath + @"Settings\Settings.xml", FileMode.OpenOrCreate))
                {
                    settings = xs.Deserialize(fs) as Settings;
                }
            }

            return settings;
        }
    }
}
