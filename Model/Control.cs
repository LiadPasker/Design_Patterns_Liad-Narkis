using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    public class Control
    {
        private DesktopFacebookSettings m_DFSetting;
        public FacebookAuthentication FacebookAuth { get; private set; }
        private UserAlbumsManager m_UserAlbumManager;

        public Control()
        {
            m_DFSetting = new DesktopFacebookSettings();
            FacebookAuth = new FacebookAuthentication();
            m_UserAlbumManager = new UserAlbumsManager();
        }
        public void Login()
        {
            if (CheckIfLoggedIn())
            {
                FacebookAuth.AutoLogin(m_DFSetting.LastAccessToken);
            }
            else
            {
                m_DFSetting.LastAccessToken = FacebookAuth.Login();
                if (m_DFSetting.KeepSignedIn)
                {
                    m_DFSetting.SaveAppSettings();
                }
            }
        }
        public bool CheckIfLoggedIn()
        {
            return m_DFSetting.LoadAppSettings() != null && m_DFSetting.LoadAppSettings().LastAccessToken != string.Empty;
        }
        public string PostStatus(string i_TextToPost, List<TagInfo> i_UserTags = null, Checkin i_CheckIn = null)//not finished: tags, checkin
        {
            string postSuccess = null;
            List<string> tagsIDs = new List<string>();

            //if (i_UserTags != null)
            //{
            //    foreach (TagInfo taggedFriend in i_UserTags)
            //    {
            //        tagsIDs.Add(taggedFriend.User.Id);
            //    }
            //}

            try
            {
                FacebookAuth.LoggedInUser.PostStatus(i_TextToPost);
            }
            catch (Exception i_exception)
            {
                postSuccess = i_exception.Message;
            }

            return postSuccess;
        }
        public List<string> GetAlbumsNames()
        {
            return m_UserAlbumManager.getNames();
        }
        public void InitializeMyAlbums()
        {
            m_UserAlbumManager.importUserAlbumsList(FacebookAuth.LoggedInUser.Albums);
        }
        public Album GetAlbum(string i_AlbumName)
        {
            return m_UserAlbumManager.GetAlbum(i_AlbumName);
        }
        public List<string> getAlbumURLs(Album i_Album)
        {
            return m_UserAlbumManager.GetAlbumURLs(i_Album);
        }
        public FacebookObjectCollection<Post> getFeed(int i_PostsMonthsOld)
        {
            FacebookObjectCollection<Post> recentWallPosts = new FacebookObjectCollection<Post>();

            foreach (Post post in FacebookAuth.LoggedInUser.WallPosts)
            {
                if (post.CreatedTime >= DateTime.Now.AddMonths(-Math.Abs(i_PostsMonthsOld)))
                {
                    recentWallPosts.Add(post);
                }
            }

            return recentWallPosts;
        }
        public bool isValidPostEnteredValue(string i_TextToCheck)
        {
            return Regex.IsMatch(i_TextToCheck, @"^([1-9]|[1-2][0-9]|3[0-6])$");
        }
    }
}
