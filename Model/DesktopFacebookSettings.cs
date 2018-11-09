using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace Model
{
    public class DesktopFacebookSettings
	{
        public static DesktopFacebookSettings Settings { get; private set; }

        public string LastAccessToken { get; set; } = string.Empty;

        public Point Location { get; set; } = new Point(10, 10);

        public bool KeepSignedIn { get; set; } = true;

        // export old settings
        public DesktopFacebookSettings LoadAppSettings()
        {
            DesktopFacebookSettings formSettings;
            string currentLocation = Environment.CurrentDirectory;
            currentLocation += "\\appSettings.xml";
            if (File.Exists(currentLocation) && new FileInfo(currentLocation).Length > 0)
            {
                using (Stream stream = new FileStream(currentLocation, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DesktopFacebookSettings));
                    formSettings = serializer.Deserialize(stream) as DesktopFacebookSettings;
                }
            }
            else
            {
                formSettings = null;
            }

            return formSettings;
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
