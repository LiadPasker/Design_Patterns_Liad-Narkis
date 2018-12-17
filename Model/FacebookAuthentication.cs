using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public sealed class FacebookAuthentication
    {
        private static readonly object rs_ThreadContext = new object();
        private static FacebookAuthentication m_FAuthInstance = null;

        public static FacebookAuthentication FAuthInstance
        {
            get
            {
                if (m_FAuthInstance == null)
                {
                    m_FAuthInstance = new FacebookAuthentication();
                }

                return m_FAuthInstance;
            }

            set => FAuthInstance = value;
        }

        public User LoggedInUser { get; set; } = null;

        private FacebookAuthentication()
        {
        }

        private string FacebookLogin()
        {
            lock (rs_ThreadContext)
            {
                LoginResult result = FacebookService.Login("295427534630566", "public_profile", "email", "user_friends", "user_photos", "user_birthday", "user_likes", "manage_pages", "user_events", "user_hometown", "user_posts", "user_tagged_places", "user_location");
                LoggedInUser = result.LoggedInUser;
                return result.AccessToken;
            }
        }

        private void AutoLogin(string i_LastAccessToken)
        {
            lock (rs_ThreadContext)
            {
                LoginResult loginResult = FacebookService.Connect(i_LastAccessToken);
                LoggedInUser = loginResult.LoggedInUser;
            }
        }

        public void Login()
        {
            if (DesktopFacebookSettings.Settings.KeepSignedIn == false)
            {
                DesktopFacebookSettings.Settings.LastAccessToken = FacebookLogin();
            }
            else
            {
                AutoLogin(DesktopFacebookSettings.Settings.LastAccessToken);
            }
        }
    }
}
