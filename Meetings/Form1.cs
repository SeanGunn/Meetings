using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Meetings
{
    //TODO: Recip may withdraw and exclude some slots
    //TODO: Rearange all functions and prob create a class for them and remmove hashmap class
    public partial class Form1 : Form
    {

        private HashMap Pairs;
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        private void Form1_Load()
        {
            dateTimePicker.MaxDate = DateTime.Today.AddYears(4);
            dateTimePicker.MinDate = DateTime.Today;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "ddd/ MMM / yyyy";
            Pairs = new HashMap();
            UsersCheckedListBox.CheckOnClick = true;
            TimesCheckedListBox.CheckOnClick = true;
            //TODO: have 2 lists that are based on a button that sets a bool to true or false of true have public times and only work for some dates
            AddUsersToUsersCheckedList();
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00","17:00","18:00","19:00","20:00","21:00"};
            TimesCheckedListBox.Items.AddRange(meetingTimes);
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string a = UserNameTxtbox.Text;
            string b = PasswordTxtbox.Text;
            UserExists(a, b);
            UserNameTxtbox.Text = "";
            PasswordTxtbox.Text = "";
        }

        private void DatePickerbtn_Click(object sender, EventArgs e)
        {
            
            int day = dateTimePicker.Value.Day;
            int month = dateTimePicker.Value.Month;
            int year = dateTimePicker.Value.Year;

            MessageBox.Show(""+day+ " " + month + " " + year);

            string checkedItemsTimes = string.Empty;
            foreach (object Item in TimesCheckedListBox.CheckedItems)
            {
                checkedItemsTimes += Item.ToString();
                checkedItemsTimes += ",";
            }
            MessageBox.Show(checkedItemsTimes);

            int AmountOfUsersChecked = UsersCheckedListBox.CheckedItems.Count;
            MessageBox.Show(AmountOfUsersChecked.ToString());
            string checkedItemsUsers = string.Empty;
            foreach (object Item in UsersCheckedListBox.CheckedItems)
            {
                checkedItemsUsers += Item.ToString();
                checkedItemsUsers += ",";
            }
            MessageBox.Show(checkedItemsUsers);
            //TODO: Pass the meeting name
            //string MeetingsDatabaseName = "";
            //string MeetingOwnerName = "";
            //TODO: Add to database that creates information with (CreateMeetingsDatabase(string meetingsName))
            //TODO: Adds meeting creators name then amountInMeeting then UsersInMeeting names then times of meetings
            //String insertUser = "Insert into "+ MeetingsDatabaseName+ " (MeetingOwner,AmountInMeeting,UsersInMeeting,TimeOfMeetings) values ('" + MeetingOwnerName + "','"+ AmountOfUsersChecked + "','" + checkedItemsUsers + "','" + checkedItemsTimes + ")";
        }  

        private void NewUserBtn_Click(object sender, EventArgs e)
        {
            string Username = newUsernameTxtbox.Text;
            string Firstname = newFirstnameTxtbox.Text;
            string LastName = newLastnameTxtbox.Text;
            string Password = newPasswordTxtbox.Text;
            string email = newEmailTxtbox.Text;
            if (Username != "" && Firstname != "" && LastName != "" && Password != "" && email != "")
                NewUser(Username, Firstname, LastName, Password, email);
            else
                MessageBox.Show("Fill all the data please");
            newUsernameTxtbox.Text = "";
            newFirstnameTxtbox.Text = "";
            newLastnameTxtbox.Text = "";
            newPasswordTxtbox.Text = "";
            newEmailTxtbox.Text = "";
        }

        private void NewUser(string Username,string Firstname,string LastName, string Password,string email)
        {
            bool itContains = false;
            string firstName = "";
            string lastName = "";
            string password = "";
            string Email = "";
            string oString = "Select * from MeetingsDatabase where Username=@username";
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                oCmd.Parameters.AddWithValue("@username", Username);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        firstName = oReader["FirstName"].ToString();
                        lastName = oReader["Surname"].ToString();
                        password = oReader["Password"].ToString();
                        Email = oReader["Email"].ToString();
                    }
                    if (firstName == Firstname && lastName == LastName && password == Password && Email == email)
                        itContains = true;
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            String amountIdsString = "Select Count(*) from MeetingsDatabase";
            SqlCommand sc1;
            cnn.Open();
            sc1 = new SqlCommand(amountIdsString, cnn);
            int amountIds = (int)sc1.ExecuteScalar();
            cnn.Close();
            if (itContains == false)
            {
                SqlCommand sc;
                String insertUser = "Insert into MeetingsDatabase (ID,Username,FirstName,Surname,Password,Email) values ('"+amountIds+ "','"+Username+"','"+ Firstname+ "','"+LastName+ "','"+Password+"','b6018405@my.shu.ac.uk')";
                try
                {
                    cnn.Open();
                    MessageBox.Show("Open");
                    sc = new SqlCommand(insertUser, cnn);
                    sc.ExecuteNonQuery();
                    sc.Dispose();
                    cnn.Close();
                    MessageBox.Show("Close");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }

        private void UserExists(string username, string password)
        {
            string firstName = "";
            string lastName = "";
            string email = "";
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            using (SqlConnection cnn = new SqlConnection(ConString))
            {
                string oString = "Select * from MeetingsDatabase where Username=@username";
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                oCmd.Parameters.AddWithValue("@username", username);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        firstName = oReader["FirstName"].ToString();
                        lastName = oReader["Surname"].ToString();
                        password = oReader["Password"].ToString();
                        email = oReader["Email"].ToString();
                    }

                    cnn.Close();
                }
                if ((username == "Mehmet1") && (lastName!=""))
                {
                    Init init1 = new Init(username, firstName, lastName, password, email);
                    MessageBox.Show(init1.ToString());
                }
                else if((username != "Mehmet1") && (lastName != ""))
                {
                    Recip recip1 = new Recip(username, firstName, lastName, password, email);
                    MessageBox.Show(recip1.ToString());
                }
                else
                {
                    MessageBox.Show("User doesn't exist.");
                }
            }  
        }

        private void CreateMeetingsNameBtn_Click(object sender, EventArgs e)
        {
            string meetingsName = createMeetingsNameTxtBox.Text;
            if (meetingsName != "")
                CreateMeetingsDatabase(meetingsName);
            else
                MessageBox.Show("Fill all the data please");
        }

        private void CreateMeetingsDatabase(string meetingsName)
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='" + meetingsName + "') SELECT 1 ELSE SELECT 0";
            using (SqlConnection con = new SqlConnection(ConString))
            {

                try
                {
                    con.Open();
                    SqlCommand MeetingCheck = new SqlCommand(cmdText, con);
                    int x = Convert.ToInt32(MeetingCheck.ExecuteScalar());
                    if (x == 1)
                    {
                        MessageBox.Show("Meeting called "+meetingsName+" already exists rename meeting");
                    }
                    else
                    {
                        MessageBox.Show("Meeting called " + meetingsName+ " is being set");
                        try
                        {
                            using (SqlCommand command = new SqlCommand("CREATE TABLE[dbo].["+ meetingsName + "] (MeetingOwner varchar(20), AmountInMeeting INT, UsersInMeeting varchar(255), TimeOfMeetings varchar(255));", con))
                                command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void DropMeeting(string meetingsName)
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='" + meetingsName + "') SELECT 1 ELSE SELECT 0";
            using (SqlConnection con = new SqlConnection(ConString))
            {

                try
                {
                    con.Open();
                    SqlCommand MeetingCheck = new SqlCommand(cmdText, con);
                    int x = Convert.ToInt32(MeetingCheck.ExecuteScalar());
                    if (x == 1)
                    {
                        MessageBox.Show("Canceling the meeting");
                        using (SqlCommand command = new SqlCommand("DROP TABLE[dbo].[" + meetingsName + "];", con))
                            command.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Meeting doesn't exist");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancelAMeetingBtn_Click(object sender, EventArgs e)
        {
            //TODO: Can turn this into a list based on owner of meeting
            string meetingsName = cancelAMeetingTextBox.Text;
            if (meetingsName != "")
                DropMeeting(meetingsName);
            else
                MessageBox.Show("Fill all the data please");
        }

        private void PublicBtn_Click(object sender, EventArgs e)
        {
            //TODO: Sets times to public times and dates to public dates Monday to friday 8 am to 5 pm If user picks none week day ask to pick again
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
        }

        private void PrivateBtn_Click(object sender, EventArgs e)
        {
            //TODO: Sets times to private times and dates to public dates Monday to Sunday 8 am to 9 pm
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            //Its as it is now
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
        }

        private void AddUsersToUsersCheckedList()
        {
            string oString = "Select * from MeetingsDatabase where ID > 0";
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string firstName = "";
            string lastName = "";
            string name = "";
            List<string> namesList = new List<string>();
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                SqlCommand oCmd = new SqlCommand(oString, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        firstName = oReader["FirstName"].ToString();
                        lastName = oReader["Surname"].ToString();
                        name = firstName + " " + lastName;
                        namesList.Add(name);
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //TODO: When rearraging i need have it not show current user
            foreach (String user in namesList)
            {
                //if(user != username)
                //    UsersCheckedListBox.Items.Add(user);
                UsersCheckedListBox.Items.Add(user);
            }
        }
    }

}
