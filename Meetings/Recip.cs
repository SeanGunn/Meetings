using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetings
{
    class Recip : Users 
    {
        public Recip(string username, string Fname, string Lname, string password, string email) : base (username, Fname,Lname, password, email)
        {
        }
        public void SetExclusionsForMeeting()
        {
            //TODO: asks the user to set exclusion days/times
            //TODO: needs to have a bool that checks if their is a exclusion
        }

        public void SetPrefenceForMeeting()
        {
            //TODO: asks the user to set prefence days/times
            //TODO: needs to have a bool that checks if their is a prefence
        }

        public void WithdrawFromTheMeeting(string meetingName, string user)
        {
            Pairs.RemoveUserFromMeeting(meetingName, user);
        }
    }
}
