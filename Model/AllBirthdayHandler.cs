using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AllBirthdayHandler : BirthdayManager
    {
        protected override bool isBirthdayComing(DateTime i_Birthday)
        {
            return true;
        }
    }
}
