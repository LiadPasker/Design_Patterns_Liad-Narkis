﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public class AppFacade
    {
        private UserAlbumsManager m_UserAlbumManager;
        private UserManager m_UserManager;
        private OccasionHandler m_OccasionHandler = null;

        public OfficeManager OfficeManager { get; private set; } = null;

        public static bool IsValidPostEnteredValue(string i_TextToCheck)
        {
            return Regex.IsMatch(i_TextToCheck, @"^([1-9]|[1-2][0-9]|3[0-6])$");
        }

        public AppFacade()
        {
            m_UserAlbumManager = new UserAlbumsManager();
            m_UserManager = new UserManager();
            m_OccasionHandler = new OccasionHandler();
        }

        public void Login()
        {
            DesktopFacebookSettings appSettings = DesktopFacebookSettings.LoadAppSettings();
            FacebookAuthentication.FAuthInstance.Login();
        }

        public DesktopFacebookSettings GetApplicationSettings()
        {
            return DesktopFacebookSettings.Settings;
        }

        public string GetProfilePicForViewer(Utils.eAppComponent eUserType)
        {
            return m_UserManager.GetProfilePicForViewer(eUserType);
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
            m_UserAlbumManager.AlbumPropStrategy = album => album.Name;
            m_UserAlbumManager.AlbumStrategy = album => true;

            List<string> AlbumNames = new List<string>();
            foreach(string name in m_UserAlbumManager)
            {
                AlbumNames.Add(name);
            }

            return AlbumNames;
        }

        public void InitializeMyAlbums()
        {
            m_UserAlbumManager.ImportUserAlbumsList(FacebookAuthentication.FAuthInstance.LoggedInUser.Albums);
        }

        public Album GetAlbum(string i_AlbumName)
        {
            m_UserAlbumManager.AlbumPropStrategy = album => album;
            m_UserAlbumManager.AlbumStrategy = album => album.Name == i_AlbumName;
            IEnumerator<object> itr = m_UserAlbumManager.GetEnumerator();
            itr.MoveNext();
            return itr?.Current as Album;
        }

        public List<string> GetAlbumURLs(Album i_Album)
        {
            return m_UserAlbumManager.GetAlbumURLs(i_Album);
        }

        public void PostStatus(Utils.eAppComponent i_UserType, string i_TextToPost, List<TagInfo> i_UserTags = null, Checkin i_CheckIn = null) // not finished: tags, checkin
        {
            validateInputString(i_TextToPost);
            m_UserManager.PostStatus(i_UserType, i_TextToPost, i_UserTags, i_CheckIn);
        }

        public FacebookObjectCollection<Post> getFeed(Utils.eAppComponent i_UserType, int i_PostsMonthsOld)
        {
            return m_UserManager.getFeed(i_UserType, i_PostsMonthsOld);
        }

        public string DerivePostTextFormat(Post i_Post)
        {
            return m_UserManager.DerivePostTextFormat(i_Post);
        }

        public void VerifyFriendSearchAndImportInfo(string i_FriendNameToSearch)
        {
            m_UserManager.verifyFriendSearchAndImportInfo(i_FriendNameToSearch);
        }

        public string GetcurrentShowedUserInfo(Utils.eAppComponent i_UserType)
        {
            return m_UserManager.GetcurrentShowedUserInfo(i_UserType);
        }

        public FacebookObjectCollection<Event> GetUserUpcomingEvents(Utils.eAppComponent i_UserType)
        {
            return m_UserManager.GetUserUpcomingEvents(i_UserType);
        }

        public FacebookObjectCollection<Event> GetFriendUpcomingEventsByTime(FacebookObjectCollection<Event> i_RecentEvents, int i_EventsAgeInMonths = 100)
        {
            return m_UserManager.GetFriendUpcomingEventsByTime(i_RecentEvents, i_EventsAgeInMonths);
        }

        public List<User> GetFriendsByBirthday(bool i_ToSort)
        {
            return m_UserManager.GetConnectedUserFriendsSortedByBirthdays(i_ToSort);
        }

        public bool IsOccasionSoon(string i_Occasion, int i_HowFarInMonths, bool i_IsBirthday = false)
        {
            return OccasionHandler.IsOccasionSoon(i_Occasion, i_HowFarInMonths, i_IsBirthday);
        }

        public bool IsValidHour(string i_StrHourToCheck)
        {
            return m_OccasionHandler.IsValidHour(i_StrHourToCheck);
        }

        public bool IsValidMinute(string i_MinuteToCheck)
        {
            return m_OccasionHandler.IsValidMinute(i_MinuteToCheck);
        }

        public string GenerateRandomBirthdayWish(string i_Name)
        {
            return m_OccasionHandler.GenerateRandomBirthdayWish(i_Name);
        }

        public void ExportData(Utils.eFileType i_FileType, string i_FilePath = null) // at the moment, only excel export allowed
        {
            if (OfficeManager == null)
            {
                OfficeManager = new OfficeManager();
            }

            switch (i_FileType)
            {
                case Utils.eFileType.XLS:
                    try
                    {
                        string SheetName = ((Utils.eMonths)DateTime.Now.Month).ToString();
                        new Thread(() => { OfficeManager.ExportToExcel(SheetName, m_UserManager, i_FilePath); }).Start();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Excel Loading Failed!");
                    }

                    break;
            }
        }
    }
}
