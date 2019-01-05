using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public class UserManager
    {
        private static readonly object rs_ThreadContext = new object();
        private User m_CurrentUserFriend = null;

        public void PostStatus(Utils.eAppComponent i_UserType, string i_TextToPost, List<TagInfo> i_UserTags = null, Checkin i_CheckIn = null) // not finished: tags, checkin
        {
            User user = null;
            try
            {
                user = getUser(i_UserType);
                user.PostStatus(i_TextToPost);
            }
            catch (Exception)
            {
                throw new Exception("Facebook Server Error");
            }
        }

        public FacebookObjectCollection<Post> getFeed(Utils.eAppComponent i_UserType, int i_PostsMonthsOld)
        {
            FacebookObjectCollection<Post> recentWallPosts = new FacebookObjectCollection<Post>();
            FacebookObjectCollection<Post> allUserPosts = getAllUserPosts(i_UserType);
            foreach (Post post in allUserPosts)
            {
                if (post.CreatedTime >= DateTime.Now.AddMonths(-Math.Abs(i_PostsMonthsOld)))
                {
                    recentWallPosts.Add(post);
                }
            }

            return recentWallPosts;
        }

        private FacebookObjectCollection<Post> getAllUserPosts(Utils.eAppComponent i_UserType)
        {
            User user = null;
            try
            {
                user = getUser(i_UserType);
            }
            catch (Exception)
            {
                throw;
            }

            return user.NewsFeed;
        }

        private User getUser(Utils.eAppComponent i_UserType)
        {
            User currUser = null;
            try
            {
                lock (rs_ThreadContext)
                {
                    switch (i_UserType)
                    {
                        case Utils.eAppComponent.UserProfileViewer:
                            currUser = FacebookAuthentication.FAuthInstance.LoggedInUser;
                            break;

                        case Utils.eAppComponent.FriendProfileViewer:
                            currUser = m_CurrentUserFriend;
                            if (currUser == null)
                            {
                                throw new Exception();
                            }

                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Information Import Failed");
            }

            return currUser;
        } // throws exception if fails

        public string DerivePostTextFormat(Post i_Post)
        {
            string divider = "_________________________________________________";
            return string.Format(
@"FROM: {0}
POSTED AT:{1}

{2}{3}{4}{3}{3}",
i_Post?.From?.Name,
i_Post?.CreatedTime?.ToString(),
i_Post?.Message,
System.Environment.NewLine,
divider);
        }

        public void verifyFriendSearchAndImportInfo(string i_FriendNameToSearch)
        {
            try
            {
                m_CurrentUserFriend = FacebookAuthentication.FAuthInstance.LoggedInUser.Friends.Find(x => x.Name == i_FriendNameToSearch);
                if (m_CurrentUserFriend == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception("We couldn't find your Friend\nPlease try again");
            }
        }

        private string getCurrentShowedFriendProfilePictureURL()
        {
            try
            {
                return m_CurrentUserFriend.PictureLargeURL;
            }
            catch (Exception)
            {
                throw new Exception("Couldn't find Picture");
            }
        }

        public string GetcurrentShowedUserInfo(Utils.eAppComponent i_UserType)
        {
            User currUser = null;
            try
            {
                currUser = getUser(i_UserType);
            }
            catch (Exception)
            {
                throw;
            }

            return string.Format(
@"Name: {0}
Gender: {1}
Birthday: {2}
Email: {3}
City: {4}
Education: {5}
Work: {6}
Status: {7}
About:
{8}",
currUser?.Name,
currUser?.Gender,
currUser?.Birthday,
currUser?.Email,
currUser?.Hometown?.Name,
currUser?.Educations?[0].School?.Name,
currUser?.WorkExperiences?[0].Name,
currUser?.RelationshipStatus,
currUser?.About);
        }

        public FacebookObjectCollection<Event> GetUserUpcomingEvents(Utils.eAppComponent i_UserType)
        {
            User user = null;
            FacebookObjectCollection<Event> userEvents = null;

            try
            {
                user = getUser(i_UserType);
                userEvents = GetFriendUpcomingEventsByTime(user.Events);
            }
            catch (Exception)
            {
                throw new Exception("Facebook Error: Couldn't fetch events");
            }

            return userEvents;
        }

        public FacebookObjectCollection<Event> GetFriendUpcomingEventsByTime(FacebookObjectCollection<Event> i_RecentEvents, int i_EventsAgeInMonths = 100)
        {
            FacebookObjectCollection<Event> recentUserEvents = null;
            foreach (Event userEvent in i_RecentEvents)
            {
                if (userEvent.StartTime >= DateTime.Now.AddMonths(Math.Abs(i_EventsAgeInMonths)))
                {
                    recentUserEvents.Add(userEvent);
                }
            }

            return recentUserEvents;
        }

        public List<User> GetConnectedUserFriendsSortedByBirthdays(bool i_ToSort)
        {
            BirthdayManager birthdays;
            if(i_ToSort)
            {
                birthdays = new UpcomingBithdayHandler();
            }
            else
            {
                birthdays = new AllBirthdayHandler();
            }

            return birthdays.PickCustomedFriends();
        }

        public string GetProfilePicForViewer(Utils.eAppComponent eUserType)
        {
            string picURL = null;
            if (eUserType == Model.Utils.eAppComponent.FriendProfileViewer)
            {
                picURL = getCurrentShowedFriendProfilePictureURL();
            }
            else
            {
                picURL = FacebookAuthentication.FAuthInstance.LoggedInUser.PictureLargeURL;
            }

            return picURL;
        }
    }
}
