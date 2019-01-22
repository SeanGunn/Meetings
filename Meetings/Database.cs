using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private List<string> UpdateMeetingDate = new List<string>();
        private string Public = "false";
        private List<string> UpdateMeetingName = new List<string>();
        string a = "";
        private string VaidateMeetingName;
        private string VaidateMeetingDate;
        public Database(string Name)
        {
            this.Name = Name;
        }
        public void SetPublic(string value)
        {
            this.Public = value;
        }

        public string GetPublic()
        {
            return this.Public;
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
        public string GetUpdateMeetingDate(int value)
        {
            return UpdateMeetingDate.ElementAt(value);
        }
        public void AddUpdateMeetingName(String value)
        {
            UpdateMeetingName.Add(value);
        }

        public void ClearUpdateMeetingName()
        {
            UpdateMeetingName.Clear();
        }
        public string GetUpdateMeetingName(int value)
        {
            return UpdateMeetingName.ElementAt(value);
        }

        public void SetVaidateMeetingName(string value)
        {
            this.VaidateMeetingName = value;
        }

        public string GetVaidateMeetingName()
        {
            return this.VaidateMeetingName;
        }
        public void SetVaidateMeetingDate(string value)
        {
            this.VaidateMeetingDate = value;
        }

        public string GetVaidateMeetingDate()
        {
            return this.VaidateMeetingDate;
        }
        //public string GetUPMN(int value)
        //{
        //     return this.a  = GetUpdateMeetingName(value).ToString();
        //}

    }
}
