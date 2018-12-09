using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetings
{
    class Init : Users
    {

        public void SetTimeAndDateOfMeetingsAndUsersForMeetings(string meetingsName, string datesAndTimesOfMeetingsAndUsers)
        {
            Pairs.AddMeeting(meetingsName, datesAndTimesOfMeetingsAndUsers);
        }

        public void ExtendMeetings(string originalMeetingsName, string newDatesAndTimes)
        {
            Pairs.ExtendMeetings(originalMeetingsName, newDatesAndTimes);
        }

        public void CancelMeetings(string meetingsWantCanceled)
        {
            Pairs.CancelMeetings(meetingsWantCanceled);
        }
    }
}
