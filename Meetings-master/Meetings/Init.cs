using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meetings
{
    class Init : Users
    {
        public Init(string username, string Fname, string Lname, string password, string email) : base(username, Fname, Lname, password, email)
        {
        }
        public void SetTimeAndDateOfMeetingsAndUsersForMeetings(string meetingsName, string datesAndTimesOfMeetings, string users)
        {

        }
        public void ExtendMeetings(string originalMeetingsName, string newDatesAndTimes)
        {
            
        }
        public void CancelMeetings(string meetingsWantCanceled)
        {
            
        }
    }
}
