using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Control
    {
        private DesktopFacebookSettings m_DFSetting;
        private FacebookAuthentication m_FacebookAuth;

        public Control()
        {
            m_DFSetting = new DesktopFacebookSettings();
            m_FacebookAuth = new FacebookAuthentication();
        }

        public void LogIn()
        {
            if(CheckIfLoggedIn())
            {
                m_FacebookAuth.AutoLogin(m_DFSetting.LastAccessToken);
            }
            else
            {
                m_DFSetting.LastAccessToken=m_FacebookAuth.Login();
                if(m_DFSetting.KeepSignedIn)
                {
                    m_DFSetting.SaveAppSettings();
                }
            }
        }

        public bool CheckIfLoggedIn()
        {
            return m_DFSetting.LoadAppSettings() != null && m_DFSetting.LoadAppSettings().LastAccessToken != string.Empty;
        }
    }
}
