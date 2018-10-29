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
        private UserFriendManager m_UserFriendManager;

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
        public void PostStatus(Utils.USER_PROFILE i_User, string i_TextToPost, List<TagInfo> i_UserTags = null, Checkin i_CheckIn = null)//not finished: tags, checkin
        {
            validateInputString(i_TextToPost);
            try
            {
                switch(i_User)
                {
                    case Utils.USER_PROFILE.MY_PROFILE:
                        FacebookAuth.LoggedInUser.PostStatus(i_TextToPost);

                        break;
                    case Utils.USER_PROFILE.FRIEND_PROFILE:
                        m_UserFriendManager.PostOnFriendWall(i_TextToPost);
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Facebook Server Error");
            }
        }

        private void validateInputString(string i_TextToPost)
        {
            if (i_TextToPost == string.Empty)
            {
                throw new Exception("Invalid Input");
            }
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
        public string DerivePostTextFormat(Post i_Post)
        {
            string divider = "_________________________________________________";
            return string.Format(
@"FROM: {0}
POSTED AT:{1}

{2}{3}{4}{3}{3}", i_Post?.From?.Name, i_Post?.CreatedTime?.ToString(), i_Post?.Message, System.Environment.NewLine, divider);
        }

        public void verifyFriendSearchAndImportInfo(string i_FriendNameToSearch)
        {
            User desiredFriend = FacebookAuth.LoggedInUser.Friends.Find(x => x.Name == i_FriendNameToSearch);
            if(desiredFriend==null)
            {
                throw new Exception("We couldn't find your Friend\nPlease try again");
            }

            m_UserFriendManager = new UserFriendManager(desiredFriend);

        }
        public string getCurrentShowedFriendProfilePictureURL()
        {
            return m_UserFriendManager.GetProfilePictureURL();
        }
    }
}
