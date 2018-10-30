using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserFriendManager
    {
        public User UserFriend { get; } = null;
        private readonly int r_CheckInAgeInMonths = 100;

        public UserFriendManager(User i_UserFriend)
        {
            UserFriend = i_UserFriend;
        }

        public FacebookObjectCollection<Event> getFriendUpcomingEvents()
        {
            FacebookObjectCollection<Event> recentEvents = new FacebookObjectCollection<Event>();

            foreach (Event userEvent in UserFriend.Events)
            {
                if (userEvent.StartTime >= DateTime.Now.AddMonths(Math.Abs(r_CheckInAgeInMonths)))
                {
                    recentEvents.Add(userEvent);
                }
            }

            return recentEvents;
        }



    }
}
