using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meetings
{
    class Database
    {
        private string Name;
        private string RemoveMeetingName;
        private List<string> UpdateMeetingDate;
        private List<string> UpdateMeetingName;
        public Database(string Name)
        {
            this.Name = Name;
        }

        public void SetName(String value)
        {
            this.Name = value;
            MessageBox.Show(value);
        }
        public string GetName()
        {
            return this.Name;
        }
        public void SetRemoveMeetingName(String value)
        {
            this.RemoveMeetingName = value;
            MessageBox.Show(value);
        }
        public string GetRemoveMeetingName()
        {
            return this.RemoveMeetingName;
        }
        public void AddUpdateMeetingDate(String value)
        {
            UpdateMeetingDate.Add(value);
        }

        public void ClearUpdateMeetingDate()
        {
            UpdateMeetingDate.Clear();
        }
        public List<string> GetUpdateMeetingDate()
        {
            return this.UpdateMeetingDate;
        }
        public void AddUpdateMeetingName(String value)
        {
            UpdateMeetingName.Add(value);
        }

        public void ClearUpdateMeetingName()
        {
            UpdateMeetingName.Clear();
        }
        public List<string> GetUpdateMeetingName()
        {
            return this.UpdateMeetingName;
        }
    }
}
