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
        Users user1;
        Init init1;
        Recip recip1;
        private Database database1;
        public Form1()
        {
            InitializeComponent();
            Form1_Load();
        }

        private void Form1_Load()
        {
            database1 = new Database("");
            dateTimePicker.MaxDate = DateTime.Today.AddYears(4);
            dateTimePicker.MinDate = DateTime.Today;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "ddd/ MMM / yyyy";
            dateTimePickerUpdate.MaxDate = DateTime.Today.AddYears(4);
            dateTimePickerUpdate.MinDate = DateTime.Today;
            dateTimePickerUpdate.Format = DateTimePickerFormat.Custom;
            dateTimePickerUpdate.CustomFormat = "ddd/ MMM / yyyy";
            UsersCheckedListBox.CheckOnClick = true;
            TimesCheckedListBox.CheckOnClick = true;
            UsersCheckedListBoxUpdate.CheckOnClick = true;
            TimesCheckedListBoxUpdate.CheckOnClick = true;
            CheckedListBoxMeetingsList.CheckOnClick = true;
            AddUsersToUsersCheckedList();
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00","17:00","18:00","19:00","20:00","21:00"};
            init1 = new Init("","Mehmet", "Ozcan", "","");
            recip1 = new Recip("", "", "", "", "");
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
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string MeetingsDatabaseName = database1.GetName();
            String howManyMeetingsSet = "Select COUNT("+ MeetingsDatabaseName + "ID)  from" + MeetingsDatabaseName + ";";
            Int32 count = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(ConString);

                SqlCommand comm = new SqlCommand(howManyMeetingsSet, cnn);

                cnn.Open();
                count = Convert.ToInt32(comm.ExecuteScalar());
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (count <= 1)
            {
                //TODO: IF public was pressed need to vaidate insertUser string or else it will be the wrong date
                int day = dateTimePicker.Value.Day;
                int month = dateTimePicker.Value.Month;
                int year = dateTimePicker.Value.Year;

                MessageBox.Show("" + day + " " + month + " " + year);

                string checkedItemsTimes = string.Empty;
                foreach (object Item in TimesCheckedListBox.CheckedItems)
                {
                    checkedItemsTimes += Item.ToString().Trim();
                    checkedItemsTimes += ",";
                }
                MessageBox.Show(checkedItemsTimes);

                int AmountOfUsersChecked = UsersCheckedListBox.CheckedItems.Count;
                int AmountOfUsersPossiable = UsersCheckedListBox.Items.Count;
                MessageBox.Show(AmountOfUsersChecked.ToString());
                string checkedItemsUsers = string.Empty;
                foreach (object Item in UsersCheckedListBox.CheckedItems)
                {
                    checkedItemsUsers += Item.ToString().Trim();
                    checkedItemsUsers += ",";
                }
                MessageBox.Show(checkedItemsUsers);
                int amountIds = 1;
                String amountInAlready = "Select Count(*) from" + MeetingsDatabaseName + ";";
                try
                {
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand sc1;
                    cnn.Open();
                    sc1 = new SqlCommand(amountInAlready, cnn);
                    amountIds = (int)sc1.ExecuteScalar();
                    amountIds++;
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                String insertMeetingsPart1 = "Insert into " + MeetingsDatabaseName + " (MeetingName, MeetingDate ,MeetingOwner,AmountInMeeting,MaxPossiableUsers,IsTheMeetingPublic,";
                String insertMeetingsPart2 = "";
                String user = "UsersInMeeting";
                String insertMeetingsPart3 = "";
                String time = "TimeOfMeetings";
                int a = 0;
                String dateOfMeeting = "'" + day + "/" + month + "/" + year;
                for (int i = 0; i < UsersCheckedListBox.Items.Count; i++)
                {
                    a = i + 1;
                    insertMeetingsPart2 += "" + user + a;
                    insertMeetingsPart2 += ",";
                }
                a = 0;
                for (int i = 0; i < TimesCheckedListBox.Items.Count; i++)
                {
                    a = i + 1;
                    insertMeetingsPart3 += "" + time + a;
                    if (a != TimesCheckedListBox.Items.Count)
                        insertMeetingsPart3 += ",";
                }
                String insertMeetingsPart4 = ") values ('" + MeetingsDatabaseName + "'," + dateOfMeeting + "','" + init1.GetFullName() + "', '" + AmountOfUsersChecked + "', '" + AmountOfUsersPossiable + "', '" + database1.GetPublic() + "', '";
                string InsertPartUsersFix = "";
                string InsertPartTimesFix = "";
                int b = 0;
                List<string> ListOfCheckedItems = new List<string>();
                List<string> ListOfPossiableCheckedItems = new List<string>();
                foreach (object ItemChecked in UsersCheckedListBox.CheckedItems)
                {
                    ListOfCheckedItems.Add(ItemChecked.ToString());
                }
                foreach (object Item in UsersCheckedListBox.Items)
                {
                    ListOfPossiableCheckedItems.Add(Item.ToString());
                }
                foreach (string Item in ListOfPossiableCheckedItems)
                {

                    if (ListOfCheckedItems.Contains(Item.ToString()))
                    {
                        InsertPartUsersFix += Item.ToString();
                        InsertPartUsersFix += "', '";
                    }
                    else
                    {
                        InsertPartUsersFix += "', '";
                    }

                }
                ListOfCheckedItems.Clear();
                ListOfPossiableCheckedItems.Clear();
                List<string> ListOfCheckedItemsTimes = new List<string>();
                List<string> ListOfPossiableCheckedItemsTimes = new List<string>();
                foreach (object ItemChecked in TimesCheckedListBox.CheckedItems)
                {
                    ListOfCheckedItemsTimes.Add(ItemChecked.ToString());
                }
                foreach (object Item in TimesCheckedListBox.Items)
                {
                    ListOfPossiableCheckedItemsTimes.Add(Item.ToString());
                }
                int TimesListAmount = TimesCheckedListBox.Items.Count;
                int counter = 0;
                int counterPlus = 0;
                foreach (string Item in ListOfPossiableCheckedItemsTimes)
                {
                    counter++;
                    counterPlus = counter;
                    if (ListOfCheckedItemsTimes.Contains(Item.ToString()))
                    {
                        InsertPartTimesFix += Item.ToString();
                        if ((counterPlus + 1) <= TimesListAmount)
                            InsertPartTimesFix += "', '";
                    }
                    else
                    {
                        InsertPartTimesFix += "";
                        if (b != (TimesListAmount) - counter)
                            InsertPartTimesFix += "', '";
                        else
                            MessageBox.Show(InsertPartTimesFix);

                    }

                }
                ListOfCheckedItemsTimes.Clear();
                ListOfPossiableCheckedItemsTimes.Clear();
                //MessageBox.Show(insertMeetingsPart8);
                String insertUsersFull = insertMeetingsPart1 + insertMeetingsPart2 + insertMeetingsPart3 + insertMeetingsPart4 + InsertPartUsersFix + InsertPartTimesFix + "')";
                MessageBox.Show(insertUsersFull);
                try
                {
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand oCmd = new SqlCommand(insertUsersFull, cnn);
                    cnn.Open();
                    oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //later have so anyone can be MeetingOwner using buttons
                TimesCheckedListBox.ClearSelected();
                UsersCheckedListBox.ClearSelected();
                foreach (int i in TimesCheckedListBox.CheckedIndices)
                {
                    TimesCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                }
                foreach (int i in UsersCheckedListBox.CheckedIndices)
                {
                    UsersCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                MessageBox.Show("There is already a meeting time set");
            }
            
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
            //TODO: ADD IN OTHER TEXTBOXES
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
            if (itContains == false)
            {
                SqlCommand sc;
                String insertUser = "Insert into MeetingsDatabase (Username,FirstName,Surname,Password,Email) values ('"+Username+"','"+ Firstname+ "','"+LastName+ "','"+Password+"','b6018405@my.shu.ac.uk')";
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
            string Password = "";
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
                        Password = oReader["Password"].ToString();
                        email = oReader["Email"].ToString();
                    }

                    cnn.Close();
                }
                if(Password.Trim() == password)
                {
                    user1 =  new Users(username, firstName, lastName, password, email);
                }
                else
                {
                    MessageBox.Show("User doesn't exist.");
                }
            }  ////TODO: need to add button option here to set as either init or recip
                ////That means a bit of rewiting so the later code and I know if the user is a init or recip
                //if ((username == "Mehmet1") && (lastName!=""))
                //{
                //    //later change so anyone can be init
                //    init1 = new Init(username, firstName, lastName, password, email);
                //    MessageBox.Show(init1.ToString());
                //    MeetingList();
                //}
                //else if((username != "Mehmet1") && (lastName != ""))
                //{
                //    recip1 = new Recip(username, firstName, lastName, password, email);
                //    MessageBox.Show(recip1.ToString());
                //    //TODO: DEACTERATE OTHER BUTTIONS AND LISTS
                //    //TODO: SHOWS ALL THEIR MEETINGS THEY ARE IN
                //}
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
                            String insertMeetingsPart1 = "CREATE TABLE[dbo].["+ meetingsName + "] ("+ meetingsName + "ID int IDENTITY(1,1) PRIMARY KEY, MeetingName varchar(20), MeetingDate varchar(20), MeetingOwner varchar(20), AmountInMeeting INT,MaxPossiableUsers int, IsTheMeetingPublic varchar(20),";
                            String insertMeetingsPart2 = "";
                            String user = "UsersInMeeting";
                            String insertMeetingsPart3 = "";
                            String time = "TimeOfMeetings";
                            int a = 0;
                            for (int i = 0; i < UsersCheckedListBox.Items.Count; i++)
                            {
                                a = i + 1;
                                insertMeetingsPart2 += "" + user + a;
                                insertMeetingsPart2 += " varchar(20)";
                                insertMeetingsPart2 += ",";
                            }
                            a = 0;
                            for (int i = 0; i < TimesCheckedListBox.Items.Count; i++)
                            {
                                a = i + 1;
                                insertMeetingsPart3 += "" + time + a;
                                insertMeetingsPart3 += " varchar(20)";
                                if (a != TimesCheckedListBox.Items.Count)
                                    insertMeetingsPart3 += ",";
                                else
                                    insertMeetingsPart3 += "); ";
                            }
                            String insertMeetingsFull = insertMeetingsPart1 + insertMeetingsPart2 + insertMeetingsPart3 ;
                            MessageBox.Show(insertMeetingsFull);
                            using (SqlCommand command = new SqlCommand(insertMeetingsFull, con))
                                command.ExecuteNonQuery();
                            MessageBox.Show("Hi");
                            String addToGlobalTableList = "Insert into GlobalTableList (MeetingOwner,MeetingName) values ('" + init1.GetFullName() + "','" + meetingsName + "');";
                            using (SqlCommand command = new SqlCommand(addToGlobalTableList, con))
                                command.ExecuteNonQuery();
                            MeetingList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    database1.SetName(""+meetingsName);
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
            string command2 = "Delete from GlobalTableList where MeetingName='" + meetingsName + "';";
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
                        if(meetingsName == database1.GetName())
                        {
                            database1.SetName("");
                        }
                        using(SqlCommand com2 = new SqlCommand(command2, con))
                            com2.ExecuteNonQuery();

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
        {//TODO: Can turn this into a list based on owner of meeting
            List<string> ListOfMeetingsToDrop = new List<string>();
            foreach(Object item in CheckedListBoxMeetingsList.CheckedItems)
            {
                ListOfMeetingsToDrop.Add(item.ToString());
            }
            foreach(string a in ListOfMeetingsToDrop)
            {
                DropMeeting(a);
            }
            MeetingList();
            CheckedListBoxMeetingsList.ClearSelected();
            foreach (int i in CheckedListBoxMeetingsList.CheckedIndices)
            {
                CheckedListBoxMeetingsList.SetItemCheckState(i, CheckState.Unchecked);
            }
            UsersCheckedListBoxUpdate.Items.Clear();
        }

        private void PublicBtn_Click(object sender, EventArgs e)
        {
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            UsersCheckedListBox.Items.Clear();
            AddUsersToUsersCheckedList();
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
            database1.SetPublic("true");
        }

        private void PrivateBtn_Click(object sender, EventArgs e)
        {
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            UsersCheckedListBox.Items.Clear();
            AddUsersToUsersCheckedList();
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
            database1.SetPublic("false");
        }
        
        private void AddUsersToUsersCheckedList()
        {
            string oString = "Select * from MeetingsDatabase where UserID > 0";
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
                //if(user != init1.GetFullName())
                //    UsersCheckedListBox.Items.Add(user);
                UsersCheckedListBox.Items.Add(user);
            }
        }

        private void UpdateUsersInMeetingBtn_Click(object sender, EventArgs e)
        {
            UsersCheckedListBoxUpdate.Items.Clear();
            List<string> usersInThatMeeting = new List<string>();
            List<string> usersDistiant = new List<string>();
            //TODO: TURNS ON REMOVE USERS
            if (CheckedListBoxMeetingsList.CheckedItems.Count <= 1)
            {
                
                AllYourMeetingsUsersList(usersInThatMeeting, usersDistiant);
                foreach (string b in usersInThatMeeting)
                {
                    MessageBox.Show(b);
                }
                MessageBox.Show(usersInThatMeeting.Count.ToString());
                UsersInMeetingTransferBtn.Enabled = true;
                UpdateDateTimeBtn.Enabled = true;
            }
            else
                MessageBox.Show("Only one at a time please");
            MeetingList();
            CheckedListBoxMeetingsList.ClearSelected();
            foreach (int i in CheckedListBoxMeetingsList.CheckedIndices)
            {
                CheckedListBoxMeetingsList.SetItemCheckState(i, CheckState.Unchecked);
            }

            foreach (String user in usersDistiant)
            {
                //if(user != init1.GetFullName())
                //    UsersCheckedListBox.Items.Add(user);
                UsersCheckedListBoxUpdate.Items.Add(user);
            }

            //TODO: When rearraging i need have it not show current user

        }

        private void AllYourMeetingsUsersList(List<string> usersInThatMeeting, List<string> usersDistiant)
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            List<string> namesMeetingDatabase = new List<string>();
            
            string meetingName = "";
            string personName = "";
            int intAmountInMeeting = 0;
            int a = 1;
            int b = 1;
            foreach (object Item in CheckedListBoxMeetingsList.CheckedItems)
            {
                meetingName += Item.ToString();
                namesMeetingDatabase.Add(meetingName);
            }
            foreach (String nameOfMeeting in namesMeetingDatabase)
            {
                String command = "Select * from " + nameOfMeeting + ";";
                database1.SetRemoveMeetingName(nameOfMeeting);
                SqlConnection cnn = new SqlConnection(ConString);
                try
                {
                    SqlCommand oCmd = new SqlCommand(command, cnn);
                    cnn.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            a = 1;
                            b = 1;
                            intAmountInMeeting = oReader.GetInt32(4);
                            
                            while (a <= (intAmountInMeeting))
                            {
                                personName = oReader.GetString((b + 6));
                                if ((usersInThatMeeting.Contains(personName) && (personName == ""))||(personName == ""))
                                {
                                    b++;
                                }
                                else
                                {
                                    usersInThatMeeting.Add(personName);
                                    a++;
                                    b++;
                                }
                            }
                            usersDistiant.AddRange(usersInThatMeeting.Distinct().ToList());
                            
                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
        private void MeetingsListBtn_Click(object sender, EventArgs e)
        {//TODO: change the cancel button to off then turn it on when do its todo
         //if (CheckedListBoxMeetingsList.CheckedItems.Count <= 1)
         //{
         //    List<string> usersInThatMeeting = new List<string>();
         //    AllYourMeetingsUsersList(usersInThatMeeting);
         //    foreach (string b in usersInThatMeeting)
         //    {
         //        MessageBox.Show(b);
         //    }
         //    MessageBox.Show(usersInThatMeeting.Count.ToString());

            //}
            //else
            //    MessageBox.Show("Only one at a time please");
            //CheckedListBoxMeetingsList.ClearSelected();
            //foreach (int i in CheckedListBoxMeetingsList.CheckedIndices)
            //{
            //    CheckedListBoxMeetingsList.SetItemCheckState(i, CheckState.Unchecked);
            //}
        }

        private void MeetingList()
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string com = "Select * from GlobalTableList;";
            List<string> namesListInDatabase = new List<string>();
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                string meetingOwner = "";
                string meetingName = "";
                SqlCommand oCmd = new SqlCommand(com, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        meetingOwner = oReader["MeetingOwner"].ToString();
                        if (meetingOwner == init1.GetFullName())
                        {
                            meetingName = oReader["MeetingName"].ToString();
                            namesListInDatabase.Add(meetingName);
                        }
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            CheckedListBoxMeetingsList.Items.Clear();
            //TODO: When rearraging i need have it not show current user
            foreach (String meeting in namesListInDatabase)
            {
                CheckedListBoxMeetingsList.Items.Add(meeting);
            }
        }

        private void UpdateDateTimeBtn_Click(object sender, EventArgs e)
        {
            //TODO: CHANGES DATE AND TIME
            if (CheckedListBoxMeetingsList.CheckedItems.Count <= 1)
            {
                meetingTimesListBox.Items.Clear();
                List<string> nameOfMeetings = new List<string>();
                List<string> datesOfMeetings = new List<string>();
                foreach (object item in CheckedListBoxMeetingsList.CheckedItems)
                {
                    nameOfMeetings.Add(item.ToString());
                    database1.AddUpdateMeetingName(item.ToString());
                }
                AllYourMeetingsDateList(nameOfMeetings, datesOfMeetings);
                
            }
            else
                MessageBox.Show("Only one at a time please");
            
        }

        private void AllYourMeetingsDateList(List<string> nameOfMeetings, List<string> datesOfMeetings)
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            foreach (String nameOfMeeting in nameOfMeetings)
            {
                String command = "Select * from " + nameOfMeeting + ";";
                database1.SetRemoveMeetingName(nameOfMeeting);
                SqlConnection cnn = new SqlConnection(ConString);
                try
                {
                    SqlCommand oCmd = new SqlCommand(command, cnn);
                    cnn.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        String dateOfMeetings = "";
                        while (oReader.Read())
                        {
                            dateOfMeetings = oReader.GetString(2);
                            datesOfMeetings.Add(dateOfMeetings);
                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            foreach(string a in datesOfMeetings)
            {
                meetingTimesListBox.Items.Add(a);
            }
        }

        private void UpdateRemovedUsersBtn_Click(object sender, EventArgs e)
        {
            //TODO: REMOVE CLICKED USER FROM DATABASE
            List<string> usersRemoveMeeting = new List<string>();
            List<int> intAmountInMeetingList = new List<int>();
            int intAmountInMeeting = 0;
            int amountIn = 0;
            foreach (object Item in UsersCheckedListBoxUpdate.CheckedItems)
            {
                usersRemoveMeeting.Add(Item.ToString());
            }
            
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string com = "Update "+database1.GetRemoveMeetingName()+" set ;";
            
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                String command = "Select * from " + database1.GetRemoveMeetingName() + ";";
                SqlCommand oCmd = new SqlCommand(command, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        intAmountInMeeting = oReader.GetInt32(4);
                        if (intAmountInMeeting > amountIn)
                            amountIn = intAmountInMeeting;
                        intAmountInMeetingList.Add(intAmountInMeeting);
                    }
                    cnn.Close();
                }
                string command2 = "UPDATE " + database1.GetRemoveMeetingName() + " SET " + SetRemoveSetUpdate(usersRemoveMeeting, amountIn) +", AmountInMeeting ="+ (intAmountInMeeting- UsersCheckedListBoxUpdate.CheckedItems.Count) + " WHERE MeetingOwner = '" + init1.GetFullName() + "';";
                MessageBox.Show(command2);
                cnn.Open();
                using (SqlCommand com2 = new SqlCommand(command2, cnn))
                    com2.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            UsersCheckedListBox.ClearSelected();
            foreach (int i in TimesCheckedListBox.CheckedIndices)
            {
                TimesCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            MeetingList();
            UsersCheckedListBoxUpdate.Items.Clear();
        }

        private void UpdateTimesAndDataBtn_Click(object sender, EventArgs e)
        {
            List<string> timesOfMeetingChange = new List<string>();
            foreach(object item in TimesCheckedListBoxUpdate.CheckedItems)
            {
                timesOfMeetingChange.Add(item.ToString());
            }
            int day = dateTimePickerUpdate.Value.Day;
            int month = dateTimePickerUpdate.Value.Month;
            int year = dateTimePickerUpdate.Value.Year;
            int maxAmoutOfHours = 0 ;
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string publicOrNot = "";
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                string command = "Select * from " + database1.GetUpdateMeetingName(0) + ";";

                SqlCommand oCmd = new SqlCommand(command, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        publicOrNot = oReader.GetString(6);
                        database1.SetPublic(publicOrNot);
                    }

                }

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (database1.GetPublic() == "true")
            {
                maxAmoutOfHours = 10;
            }
            else
            {
                maxAmoutOfHours = 14;
            }
            
            UpdateMeetingTimesAndDate(timesOfMeetingChange, day, month, year, maxAmoutOfHours);
            //TODO: CHANGE TIME OF MEETING
            database1.ClearUpdateMeetingDate();
            database1.ClearUpdateMeetingName();
        }

        private void RemoveSelfMeetingBtn_Click(object sender, EventArgs e)
        {
            //TODO: Reads the users name then removes from the meeting have it donr last since i need to set up the recip first
        }

        private string SetRemoveSetUpdate(List<string> usersRemoveMeeting, int AmountIn)
        {
            List<string> everyUserInMeeting = new List<string>();
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            int intAmountInMeeting = 0;
            string allUsersNames = "";
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                String command = "Select * from " + database1.GetRemoveMeetingName() + ";";
                SqlCommand oCmd = new SqlCommand(command, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    int aba = 0;
                    int stringNamesStart = 7;
                    while (oReader.Read())
                    {
                        intAmountInMeeting = oReader.GetInt32(4);
                        while(aba < intAmountInMeeting)
                        {
                            allUsersNames= oReader.GetString(stringNamesStart);
                            if(allUsersNames == "")
                            {
                                everyUserInMeeting.Add(stringNamesStart.ToString());
                            }
                            else
                            {
                                everyUserInMeeting.Add(allUsersNames);
                                aba++;
                            }
                            stringNamesStart++;
                            
                        }
                        
                    }
                    string mm = "";
                    foreach(string m in everyUserInMeeting)
                    {
                        mm += m + "";
                    }
                    MessageBox.Show(mm);
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //TODO: chnage it so it only does its row. read the idices that the users name is then set a as that number, This is basicly the same for time and date would just chnage the date to the new pick
            string b = "";
            int ifMoreThan1user = 0;
            foreach(string users in usersRemoveMeeting)
            {
                int positionOfUser = 0;
                
                int maxUsersInMeeting = everyUserInMeeting.Count;
                int counter = 0;
                while (counter < maxUsersInMeeting)
                {
                    if (everyUserInMeeting.ElementAt(positionOfUser).Equals(users)&& (usersRemoveMeeting.Count == 1))
                    {
                        int a = positionOfUser + 1;
                        b += "UsersInMeeting" + a + "= ''";
                    }
                    if((usersRemoveMeeting.Count > 1)&& (everyUserInMeeting.ElementAt(positionOfUser).Equals(users)))
                    {
                        int a = positionOfUser + 1;
                        ++ifMoreThan1user;
                        if(ifMoreThan1user == 1)
                        {
                            b += "UsersInMeeting" + a + "= ''";
                        }
                        else
                        {
                            b += ", UsersInMeeting" + a + "= ''";
                        }
                    }
                    ++positionOfUser;
                    counter++;
                }
                
            }
            MessageBox.Show(b);
            return b;
        }

        private void PefenAndExclTimesBtn_Click(object sender, EventArgs e)
        {
            //TODO: read facebook messager since i wrote the answer their
        }

        private void CreateUserInitBtn_Click(object sender, EventArgs e)
        {
            //TODO: SHOWS ONLY CREATE MEMU
            init1 = new Init(user1.GetUsername(),user1.GetFName(),user1.GetLName(),user1.GetPassword(),user1.GetEmail());
            MeetingList();
        }

        private void CreateUserRecipBtn_Click(object sender, EventArgs e)
        {
            //TODO: SHOWS ONLY MEETINGS IN MEMU
            recip1 = new Recip(user1.GetUsername(), user1.GetFName(), user1.GetLName(), user1.GetPassword(), user1.GetEmail());
            //TODO: make sure meeting list works with recip
            //MeetingList();
        }

        private void EditMeetingsBtn_Click(object sender, EventArgs e)
        {
            //TODO: SHOWS ONLY EDIT MEMU
        }

        private void MeetingTimesListUpdateBtn_Click(object sender, EventArgs e)
        {
            foreach(object item in meetingTimesListBox.CheckedItems)
            {
                database1.AddUpdateMeetingDate(item.ToString());
            }
            MeetingTimesListUpdateBtn.Enabled = false;
            List<string> meetingTimes = new List<string>();
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string publicOrNot = "";
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                string command = "Select * from " + database1.GetUpdateMeetingName(0) + ";";

                SqlCommand oCmd = new SqlCommand(command, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        publicOrNot = oReader.GetString(6);
                        database1.SetPublic(publicOrNot);
                    }

                }

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (database1.GetPublic() == "true")
            {
                string[] meetingTimes1 = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
                meetingTimes.AddRange(meetingTimes1);
            }
            else
            {
                string[] meetingTimes1 = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
                meetingTimes.AddRange(meetingTimes1);
            }
            foreach(string a in meetingTimes)
            {
                TimesCheckedListBoxUpdate.Items.Add(a);
            }

            //TODO: Add if the meeting is public or private to the database then more the numbers 1 over
        }

        private void ViewUsersPrefAndExclBtn_Click(object sender, EventArgs e)
        {
            //TODO: Reads users exclusion and prefence i wrote it up in facebook messager
        }

        public void UpdateMeetingTimesAndDate(List<string> timesOfMeetingChange, int day, int month, int year, int maxAmoutOfHours)
        {
            int b = 0;
            int location = b;
            foreach (string a in timesOfMeetingChange)
            {
                string name = database1.GetUpdateMeetingName(b);
                string date = database1.GetUpdateMeetingDate(b);
                location++;
                String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
                string com = "Update " + name + " set MeetingDate = '" + day + "/" + month + "/" + year + "' ;";
                string com2 = "Update " + name + " set " + SetTimesForDatabase(maxAmoutOfHours, timesOfMeetingChange, b) + " where "+name+"id = "+ location + ";";
                MessageBox.Show(com2);
                SqlConnection cnn = new SqlConnection(ConString);
                cnn.Open();
                using (SqlCommand command = new SqlCommand(com, cnn))
                    command.ExecuteNonQuery();
                cnn.Close();
                cnn.Open();
                using (SqlCommand command2 = new SqlCommand(com2, cnn))
                    command2.ExecuteNonQuery();
                cnn.Close();
                b++;
            }

        }
        private string SetTimesForDatabase(int maxAmoutOfHours, List<string> timesOfMeetingChange, int b)
        {
            string name = database1.GetUpdateMeetingName(b);
            List<string> dataAlreadyInMeeting = new List<string>();
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            string com = "Select * from " + name + ";";
            //TODO: chnage it so it only does its row. read the idices that the users name is then set a as that number, This is basicly the same for time and date would just chnage the date to the new pick
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                SqlCommand oCmd = new SqlCommand(com, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    int a = 0;
                    int c = 0;
                    string eitherBlankOrWillBeBlank = "";
                    int startFrom = 0;
                    while (oReader.Read())
                    {
                        startFrom = oReader.GetInt32(5);
                        while (a < (maxAmoutOfHours))
                        {
                            eitherBlankOrWillBeBlank = oReader.GetString((c + 7 + startFrom));
                            dataAlreadyInMeeting.Add(eitherBlankOrWillBeBlank);
                            a++;
                            c++;
                        }
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string ba = "";
            int ifMoreThan1user = 0;
            int counter = 0;
            int positionOfUser = 0;
            List<string> TimesCheckedListList = new List<string>();
            foreach (object item in TimesCheckedListBoxUpdate.Items)
            {
                TimesCheckedListList.Add(item.ToString());
            }
            foreach (string users in timesOfMeetingChange)
            {
                while (counter < maxAmoutOfHours)
                {

                    if (TimesCheckedListList.ElementAt(positionOfUser).Equals(users) && (timesOfMeetingChange.Count == 1))
                    {
                        int a = positionOfUser + 1;
                        ++ifMoreThan1user;
                        if (ifMoreThan1user == 1)
                        {
                            ba += "TimeOfMeetings" + a + "= '" + users + "'";
                        }
                        else
                        {
                            ba += ", TimeOfMeetings" + a + "= '" + users + "'";
                        }
                    }
                    else if ((timesOfMeetingChange.Count > 1) && (TimesCheckedListList.ElementAt(positionOfUser).Equals(users)))
                    {
                        int a = positionOfUser + 1;
                        ++ifMoreThan1user;
                        if (ifMoreThan1user == 1)
                        {
                            ba += "TimeOfMeetings" + a + "= '" + users + "'";
                        }
                        else
                        {
                            ba += ", TimeOfMeetings" + a + "= '" + users + "'";
                        }
                    }
                    else
                    {
                        int a = positionOfUser + 1;
                        ++ifMoreThan1user;
                        if (ifMoreThan1user == 1)
                        {
                            ba += "TimeOfMeetings" + a + "= ''";
                        }
                        else
                        {
                            ba += ", TimeOfMeetings" + a + "= ''";
                        }
                    }
                    counter++;
                    positionOfUser++;
                }
            }
                MessageBox.Show(ba);
            return ba;
        }
    }
}
