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
        }

        public void SetPrefenceForMeeting()
        {
        }

        public void WithdrawFromTheMeeting(string meetingName, string user)
        { 
        }
    }
}
