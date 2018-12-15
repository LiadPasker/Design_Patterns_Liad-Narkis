using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Model
{
    public class OccasionHandler
    {
        private readonly int r_WishesNumber = 5;
        private List<string> m_WishList;

        public static bool IsOccasionSoon(string i_Occasion, int i_HowFarInMonths, bool isBirthday = false)
        {
            DateTime occasion;
            bool isSoon = false;
            try
            {
                occasion = DateTime.ParseExact(i_Occasion, "MM/dd/yyyy", null);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't Find The Exact Date");
            }

            if (isBirthday)
            {
                occasion = occasion.AddYears(DateTime.Now.Year - occasion.Year);
                if (occasion < DateTime.Now)
                {
                    occasion = occasion.AddYears(1);
                }
            }

            if (occasion <= DateTime.Now.AddMonths(Math.Abs(i_HowFarInMonths)) && occasion >= DateTime.Now)
            {
                isSoon = true;
            }

            return isSoon;
        }

        public bool IsValidHour(string i_StrHourToCheck)
        {
            return Regex.IsMatch(i_StrHourToCheck, @"^([0-1][0-9]|[2][0-3])$");
        }

        public bool IsValidMinute(string i_MinuteToCheck)
        {
            return Regex.IsMatch(i_MinuteToCheck, @"^([0-5][0-9])$");
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
    }
}
