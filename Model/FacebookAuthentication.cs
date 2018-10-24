using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class FacebookAuthentication
    {
        private User LoggedInUser { get; set; }

        public string Login()
        {
            LoginResult result = FacebookService.Login("295427534630566", "public_profile", "email", "user_friends", "user_photos", "user_birthday", "user_likes", "manage_pages", "user_events", "user_hometown", "user_posts", "user_tagged_places", "user_location");
            LoggedInUser = result.LoggedInUser;
            return result.AccessToken;
        }

        public void AutoLogin(string i_LastAccessToken)
        {
            LoginResult loginResult = FacebookService.Connect(i_LastAccessToken);
            LoggedInUser = loginResult.LoggedInUser;
        }
    }
}
