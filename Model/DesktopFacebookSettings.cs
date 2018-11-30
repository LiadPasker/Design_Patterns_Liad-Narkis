using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace Model
{
    public sealed class DesktopFacebookSettings
	{
        public static DesktopFacebookSettings Settings { get; private set; }

        private static readonly object rs_ThreadContext = new object();

        private DesktopFacebookSettings()
        {
        }

        public string LastAccessToken { get; set; } = string.Empty;

        public Point Location { get; set; } = new Point(100, 100);

        public bool KeepSignedIn { get; set; } = false;

        // export old settings
        public static DesktopFacebookSettings LoadAppSettings()
        {
            if (Settings == null)
            { // double check lock
                lock (rs_ThreadContext)
                {
                    if (Settings == null)
                    {
                        Settings = new DesktopFacebookSettings();
                        string currentLocation = Environment.CurrentDirectory;
                        currentLocation += "\\appSettings.xml";
                        if (File.Exists(currentLocation) && new FileInfo(currentLocation).Length > 0)
                        {
                            using (Stream stream = new FileStream(currentLocation, FileMode.Open))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(DesktopFacebookSettings));
                                Settings = serializer.Deserialize(stream) as DesktopFacebookSettings;
                            }
                        }
                    }
                }
            }

            return Settings;
        }

        // import new settings
        public void SaveAppSettings()
        {
            string currentLocation = Environment.CurrentDirectory;
            currentLocation += "\\appSettings.xml";
            FileMode fileMode = File.Exists(currentLocation) ? FileMode.Truncate : FileMode.Create;
            using (Stream stream = new FileStream(currentLocation, fileMode))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DesktopFacebookSettings));
                serializer.Serialize(stream, this);
            }
        }
	}
}
