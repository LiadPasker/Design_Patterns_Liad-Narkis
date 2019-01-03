using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public abstract class BirthdayManager
    {
        public List<User> GetConnectedUserFriendsSortedByBirthdays()
        {
            List<User> sortedFriendsList;
            DateTime now = DateTime.Now;

            try
            {
                FacebookObjectCollection<User> friends = FacebookAuthentication.FAuthInstance.LoggedInUser.Friends;
                sortedFriendsList = friends.OrderBy(x => DateTime.ParseExact(x.Birthday.Substring(0, 5), "MM/dd", null)).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Import sorted Friends Failed");
            }

            return RemoveFriendsThatAlreadyHadBirthdays(sortedFriendsList);
        }

        private List<User> RemoveFriendsThatAlreadyHadBirthdays(List<User> i_SortedByBirthdayFriendsList)
        {
            DateTime now = DateTime.Now;
            List<User> birthdaysList = new List<User>();
            foreach (User friend in i_SortedByBirthdayFriendsList)
            {
                try
                {
                    DateTime userBirthday = DateTime.ParseExact(friend?.Birthday, "MM/dd/yyyy", null);
                    if (isBirthdayComing(userBirthday)) 
                    { // checks only by month & day
                        birthdaysList.Add(friend);
                    }
                }
                catch (Exception)
                {
                }
            }

            return birthdaysList;
        }

        protected abstract bool isBirthdayComing(DateTime i_Birthday);
    }
}
