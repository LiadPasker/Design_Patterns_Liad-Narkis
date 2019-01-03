using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Model
{
    public class UpcomingBithdayHandler : BirthdayManager
    {
        protected override bool isBirthdayComing(DateTime i_Birthday)
        {
            return i_Birthday.AddYears(DateTime.Now.Year - i_Birthday.Year) > DateTime.Now;
        }
    }
}
