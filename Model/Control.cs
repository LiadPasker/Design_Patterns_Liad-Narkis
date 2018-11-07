using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    public class Control
    {
        private readonly int r_WishesNumber = 5;
        private DesktopFacebookSettings m_DFSetting;
        public FacebookAuthentication FacebookAuth { get; private set; }
        private UserAlbumsManager m_UserAlbumManager;
        private User m_CurrentUserFriend = null;
        private List<string> m_WishList;
        public OfficeManager OfficeManager { get; private set; } = null;

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
        public void PostStatus(Utils.eUserProfile i_UserType, string i_TextToPost, List<TagInfo> i_UserTags = null, Checkin i_CheckIn = null)//not finished: tags, checkin
        {
            validateInputString(i_TextToPost);
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
            m_UserAlbumManager.ImportUserAlbumsList(FacebookAuth.LoggedInUser.Albums);
        }
        public Album GetAlbum(string i_AlbumName)
        {
            return m_UserAlbumManager.GetAlbum(i_AlbumName);
        }
        public List<string> GetAlbumURLs(Album i_Album)
        {
            return m_UserAlbumManager.GetAlbumURLs(i_Album);
        }
        public FacebookObjectCollection<Post> getFeed(Utils.eUserProfile i_UserType, int i_PostsMonthsOld)
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
        private FacebookObjectCollection<Post> getAllUserPosts(Utils.eUserProfile i_UserType)
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
        public static bool IsValidPostEnteredValue(string i_TextToCheck)
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
            try
            {
                m_CurrentUserFriend = FacebookAuth.LoggedInUser.Friends.Find(x => x.Name == i_FriendNameToSearch);
                if(m_CurrentUserFriend==null)
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                throw new Exception("We couldn't find your Friend\nPlease try again");
            }
        }
        public string getCurrentShowedFriendProfilePictureURL()
        {
            try
            {
                return m_CurrentUserFriend.PictureLargeURL;
            }
            catch(Exception)
            {
                throw new Exception("Couldn't find Picture");
            }
            
        }
        public string GetcurrentShowedUserInfo(Utils.eUserProfile i_UserType)
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
currUser?.Name,currUser?.Gender,currUser?.Birthday,currUser?.Email,currUser?.Hometown?.Name,currUser?.Educations?[0].School?.Name,
currUser?.WorkExperiences?[0].Name,currUser?.RelationshipStatus,currUser?.About);
        }
        public FacebookObjectCollection<Event> GetUserUpcomingEvents(Utils.eUserProfile i_UserType)
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
                throw;
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
        public List<User> getConnectedUserFriendsSortedByBirthdays()
        {
            List<User> sortedFriendsList;
            try
            {
                FacebookObjectCollection<User> friends = FacebookAuth.LoggedInUser.Friends;
                sortedFriendsList = friends.OrderBy(x => DateTime.ParseExact(x.Birthday.Substring(0, 5), "MM/dd", null)).ToList();
                //sortedFriendsList = removeFriendsThatAlreadyHadBirthdays(sortedFriendsList);
            }
            catch (Exception)
            {
                throw new Exception("Import sorted Friends Failed");
            }

            return sortedFriendsList;
        }

        public List<User> RemoveFriendsThatAlreadyHadBirthdays(List<User> i_SortedByBirthdayFriendsList)
        {
            DateTime now = DateTime.Now;
            List<User> birthdaysList = new List<User>();
            foreach(User friend in i_SortedByBirthdayFriendsList)
            {
                DateTime userBirthday = DateTime.ParseExact(friend.Birthday, "MM/dd/yyyy", null);
                if(userBirthday>now)
                {
                    birthdaysList.Add(friend);
                }
            }

            return birthdaysList;
        }

        public bool isOccasionSoon(string i_Occasion, int i_HowFarInMonths, bool isBirthday=false)
        {
            bool isSoon = false;
            DateTime occasion = DateTime.ParseExact(i_Occasion,"MM/dd/yyyy",null);
            if(isBirthday)
            {
                occasion = occasion.AddYears(DateTime.Now.Year - occasion.Year + 1);
            }

            if (occasion <= DateTime.Now.AddMonths(Math.Abs(i_HowFarInMonths))&& occasion>=DateTime.Now)
            {
                isSoon = true;
            }

            return isSoon;
        }
        public string GenerateRandomBirthdayWish(string i_Name)
        {
            Random rand = new Random();
            if (m_WishList == null)
            {
                m_WishList = new List<string>();
                initializeWishList();
            }
            return m_WishList[rand.Next(r_WishesNumber)];
        }
        private void initializeWishList()
        {
            m_WishList.Add("Count your life by smiles, not tears. \nCount your age by friends, not years.\nHappy birthday!");
            m_WishList.Add("Happy birthday! I hope all your birthday wishes and dreams come true.");
            m_WishList.Add("A wish for you on your birthday, whatever you ask may you receive, whatever you seek may you find, whatever you wish may it be fulfilled on your birthday and always. \nHappy birthday!");
            m_WishList.Add("May the joy that you have spread in the past come back to you on this day. \nWishing you a very happy birthday!");
            m_WishList.Add("May you be gifted with life’s biggest joys and never-ending bliss. \nAfter all, you yourself are a gift to earth, so you deserve the best. \nHappy birthday");
        }
        public void ExportData(Utils.eFileType i_FileType, string i_FilePath=null)
        {
            if(OfficeManager==null)
            {
                OfficeManager = new OfficeManager();
            }

            switch (i_FileType)
            {
                case Utils.eFileType.XLS:
                    try
                    {
                        string SheetName = (((Utils.eMonths)DateTime.Now.Month)).ToString();
                        OfficeManager.ExportToExcel(initializeCalenderTable(SheetName), i_FilePath);
                    }
                    catch(Exception)
                    {
                        throw;
                    }   
                   
                    break;
            }
        }
        private DataTable initializeCalenderTable(string i_TableName)
        {
            DataTable userHighLights = new DataTable(i_TableName);
            DateTime monthDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // initializes to the first day of the current month
            DataRow dayRow = userHighLights.NewRow();
            DataRow occasionRow = userHighLights.NewRow();
            int numOfDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            string day = (monthDay.DayOfWeek).ToString();
            string[] birthdays = getBirthdaysCalendarically(numOfDaysInCurrentMonth);
            string[] events = getEventsCalendarically(numOfDaysInCurrentMonth);

            for (int days = (int)DayOfWeek.Sunday; days <= (int)DayOfWeek.Saturday; days++)
            {
                userHighLights.Columns.Add(((DayOfWeek)days).ToString());
            }

            for (int i = 1; i <= numOfDaysInCurrentMonth; i++)
            {
                dayRow[day] = i;
                if(birthdays[i-1]!=null || events[i-1]!=null)
                {
                    occasionRow[day] = string.Format("{0}\n{1}", birthdays[i - 1], events[i - 1]);
                }

                if (day == DayOfWeek.Saturday.ToString() || i== DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                {
                    userHighLights.Rows.Add(dayRow);
                    userHighLights.Rows.Add(occasionRow);
                    dayRow = userHighLights.NewRow();
                    occasionRow = userHighLights.NewRow();
                }
                monthDay=monthDay.AddDays(1);
                day = (monthDay.DayOfWeek).ToString();   
            }

            return userHighLights;
        }
        private string[] getBirthdaysCalendarically(int i_numOfDaysInCurrentMonth)
        {
            string[] birthdays=new string[i_numOfDaysInCurrentMonth];

            try
            {
                List<User> friends = getConnectedUserFriendsSortedByBirthdays();
                foreach (User friend in friends)
                {
                    DateTime birthdayDate = DateTime.ParseExact(friend.Birthday, "MM/dd/yyyy", null);
                    if (isOccasionSoon(friend.Birthday, 0,true))
                    {
                        birthdays[birthdayDate.Day-1] += string.Format("{0} have a Birthday\n", friend.Name);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

            return birthdays;
        }
        private string[] getEventsCalendarically(int i_numOfDaysInCurrentMonth)
        {
            string[] events = new string[i_numOfDaysInCurrentMonth];

            try
            {
                FacebookObjectCollection<Event> ConnectedUserEvents = FacebookAuth.LoggedInUser.Events;
                foreach (Event currentEvent in ConnectedUserEvents)
                {
                    DateTime? eventDate = currentEvent.StartTime;
                    if (isOccasionSoon(eventDate.ToString(), 0))
                    {
                        events[eventDate.Value.Day - 1] += string.Format("{0}\n", currentEvent.Name);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return events;
        }
        private User getUser(Utils.eUserProfile i_UserType)
        {
            User currUser = null;
            try
            {
                switch (i_UserType)
                {
                    case Utils.eUserProfile.MY_PROFILE:
                        currUser = FacebookAuth.LoggedInUser;
                        break;
                    case Utils.eUserProfile.FRIEND_PROFILE:
                        currUser = m_CurrentUserFriend;
                        if(currUser==null)
                        {
                            throw new Exception();
                        }
                        break;
                }
            }
            catch (Exception)
            {
                throw new Exception("Information Import Failed");
            }

            return currUser;

        } //throws exception if fails
    }
}
