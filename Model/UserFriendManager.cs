using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserFriendManager
    {
        private User m_UserFriend = null;

        public UserFriendManager(User i_UserFriend)
        {
            m_UserFriend = i_UserFriend;
        }

        public string GetProfilePictureURL()
        {
            return m_UserFriend.PictureNormalURL;
        }

        public void PostOnFriendWall(string i_TextToPost)
        {
            m_UserFriend.PostStatus(i_TextToPost);
        }
    }
}
