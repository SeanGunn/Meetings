using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meetings
{
    class HashMap
    {
        Dictionary<String, String> Pairs = new Dictionary<String, String>();
        public HashMap()
        {

        }


        public void Add(String key, String info)
        {
            if(Pairs.ContainsKey(key))
                MessageBox.Show(key+" is in use create a diffent one");
            else
                Pairs.Add(key, info);
        }

        public void AddMeeting(string key, string datesAndTimes)
        {
            if (Pairs.ContainsKey(key))
                MessageBox.Show(key + " is already a meeting");
            else
                Pairs.Add(key, datesAndTimes);
        }

        public void CancelMeetings(string key)
        {
            if (Pairs.ContainsKey(key))
            {
                Pairs.Remove(key);
                if (Pairs.ContainsKey(key))
                {
                    MessageBox.Show(key + " has been removed");
                    // key removed
                }
                else
                {
                    MessageBox.Show(key + " hasn't been removed");
                    CancelMeetings(key);
                    // dictionary doesn't contain the key
                }
            }
            else
                MessageBox.Show(key + " doesn't exist");
        }

        public void ExtendMeetings(string key, string newDatesAndTimes)
        {
            if (Pairs.ContainsKey(key))
            {
                Pairs.Remove(key);
                Pairs.Add(key, newDatesAndTimes);
            }
            else
            {
                MessageBox.Show("The meeting doesnt exist");
            }
        }
        //TODO: here is the say to check users in meetings
        public void OtherUsersInMeetings(string key, string user,string dateTime)
        {
            string a = "";
            if (Pairs.ContainsKey(key))
            {
                if (Pairs.TryGetValue(key, out a))
                {
                    MessageBox.Show(a);
                    if (a.Contains(user))
                    {
                        Pairs.Add("pref " + key + " " + user, " ");
                    }
                }
                else
                    MessageBox.Show("The meeting doesnt exist");
            }
            else
                MessageBox.Show("The meeting doesnt exist");
        }

        public void RemoveUserFromMeeting(string key, string user)
        {
            string a = "";
            if (Pairs.ContainsKey(key))
            {
                if(Pairs.TryGetValue(key, out a))
                {
                    MessageBox.Show(a);
                    if (a.Contains(user))
                    {
                        int b = user.Length;
                        a.Remove(a.IndexOf(user), b);
                    }
                }
                else
                    MessageBox.Show("The meeting doesnt exist");
            }
            else
                MessageBox.Show("The meeting doesnt exist");
        }

       
        public void RemoveHashMapAstextfile()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                using (StreamWriter finished = new StreamWriter(@"C: \Users\sean\source\repos\Meetings\DataMeetings.txt", false))
                {
                    int i = Pairs.Count;
                    for (int a = 0; a < i; a++)
                    {
                        String c = i.ToString();
                        if (Pairs[c].Contains("pref") || Pairs[c].Contains("exc"))
                        {
                            //TODO: Finish this part/adds to new textfile
                        }
                        else
                        {
                            finished.WriteLine(Pairs[c]);
                        }
                    }
                    finished.Close();
                }
            }
            catch (Exception C)
            {
                MessageBox.Show("Exception: " + C.Message);
            }
        }

        public void UserIsInTheHash(string user, string password)
        {
            string a = "";
            if (Pairs.ContainsKey(user))
            {
                if (Pairs.TryGetValue(user, out a))
                {
                    if (a.Contains(password))
                    {
                        SplittingStringsUsers(a, user);
                    }
                    else
                        MessageBox.Show("Mate your password is incorrect.");
                }
            }
            else
                MessageBox.Show("WHAT YOU THINK YOU DOING?!!?!?!");
        }

        private void SplittingStringsUsers(string userinfo, string user)
        {
            string[] splitString = userinfo.Split(':');
            string Fname = splitString[0];
            string Lname = splitString[1];
            string password = splitString[2];
            string email = splitString[3];
            if (Fname == "Mehmet")
            {
                MessageBox.Show("ITS MEMEhet");
                ItsMehmet(user, Fname, Lname, password, email);
            }

            else
                ItsNotMehmet(user, Fname, Lname, password, email);
        }

        private void ItsNotMehmet(string user, string Fname, string Lname, string password, string email)
        {
            Recip recip1 = new Recip(user, Fname, Lname, password, email);
            MessageBox.Show(recip1.ToString());
        }

        private void ItsMehmet(string user, string Fname, string Lname, string password, string email)
        {
            Init init1 = new Init(user, Fname, Lname, password, email);
            MessageBox.Show(init1.ToString()); 
        }
    }
}
