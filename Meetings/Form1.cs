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
            //TODO: IF public was pressed need to vaidate insertUser string or else it will be the wrong date
            int day = dateTimePicker.Value.Day;
            int month = dateTimePicker.Value.Month;
            int year = dateTimePicker.Value.Year;

            MessageBox.Show(""+day+ " " + month + " " + year);

            string checkedItemsTimes = string.Empty;
            foreach (object Item in TimesCheckedListBox.CheckedItems)
            {
                checkedItemsTimes += Item.ToString().Trim();
                checkedItemsTimes += ",";
            }
            MessageBox.Show(checkedItemsTimes);

            int AmountOfUsersChecked = UsersCheckedListBox.CheckedItems.Count;
            MessageBox.Show(AmountOfUsersChecked.ToString());
            string checkedItemsUsers = string.Empty;
            foreach (object Item in UsersCheckedListBox.CheckedItems)
            {
                checkedItemsUsers += Item.ToString().Trim();
                checkedItemsUsers += ",";
            }
            MessageBox.Show(checkedItemsUsers);
            string MeetingsDatabaseName = database1.GetName();
            String insertMeetingsPart1 = "Insert into " + MeetingsDatabaseName + " (MeetingDate ,MeetingOwner,AmountInMeeting,";
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
                if(a != TimesCheckedListBox.Items.Count)
                    insertMeetingsPart3 += ",";
            }
            String insertMeetingsPart4 = ") values ("+ dateOfMeeting+"','"+init1.GetFullName()+"', '" + AmountOfUsersChecked + "', '";
            //String insertMeetingsPart5 = "";
            //String insertMeetingsPart6 = "";
            //foreach (object Item in UsersCheckedListBox.CheckedItems)
            //{
            //    insertMeetingsPart5 += Item.ToString();
            //    insertMeetingsPart5 += "', '";
            //}
            //for (int i = 0; i < (UsersCheckedListBox.Items.Count)- UsersCheckedListBox.CheckedItems.Count; i++)
            //{
            //    insertMeetingsPart6 += "NULL ', '";
            //}
            //String insertMeetingsPart7 = "";
            //int b = 0;
            //foreach (object Item in TimesCheckedListBox.CheckedItems)
            //{   b += 1;
            //    insertMeetingsPart7 += Item.ToString().Trim();
            //    if(b != TimesCheckedListBox.CheckedItems.Count)
            //        insertMeetingsPart7 += "', '";
                
            //}
            //String insertMeetingsPart8 = "";
            //b = 0;
            //for (int i = 0; i < (TimesCheckedListBox.Items.Count) - TimesCheckedListBox.CheckedItems.Count; i++)
            //{
            //    if ( b!= ((TimesCheckedListBox.Items.Count) - TimesCheckedListBox.CheckedItems.Count))
            //        insertMeetingsPart8 += "', '";
            //    insertMeetingsPart8 += "NULL";
                
            //}
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
                    InsertPartUsersFix += "NULL ', '";
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
                    if((counterPlus + 1) <= TimesListAmount)
                        InsertPartTimesFix += "', '";
                }
                else
                {
                    InsertPartTimesFix += "NULL";
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
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
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
                user1 =  new Users(username, firstName, lastName, password, email);
                //TODO: need to add button option here to set as either init or recip
                //That means a bit of rewiting so the later code and I know if the user is a init or recip
                if ((username == "Mehmet1") && (lastName!=""))
                {
                    //later change so anyone can be init
                    init1 = new Init(username, firstName, lastName, password, email);
                    MessageBox.Show(init1.ToString());
                    MeetingList();
                }
                else if((username != "Mehmet1") && (lastName != ""))
                {
                    recip1 = new Recip(username, firstName, lastName, password, email);
                    MessageBox.Show(recip1.ToString());
                    //TODO: DEACTERATE OTHER BUTTIONS AND LISTS
                    //TODO: SHOWS ALL THEIR MEETINGS THEY ARE IN
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
                            String insertMeetingsPart1 = "CREATE TABLE[dbo].["+ meetingsName + "] (MeetingDate varchar(20), MeetingOwner varchar(20), AmountInMeeting INT,";
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
            //if (CheckedListBoxMeetingsList.CheckedItems.Count <= 1)
            //{
            //    List<string> usersInThatMeeting = new List<string>();
            //    AllYourMeetingsUsersList(usersInThatMeeting);
            //    foreach (string b in usersInThatMeeting)
            //    {
            //        MessageBox.Show(b);
            //    }
            //    MessageBox.Show(usersInThatMeeting.Count.ToString());
            //    UsersInMeetingTransferBtn.Enabled = true;
            //    UpdateDateTimeBtn.Enabled = true;
            //}
            //else
            //    MessageBox.Show("Only one at a time please");
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
        }

        private void PublicBtn_Click(object sender, EventArgs e)
        {
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
        }

        private void PrivateBtn_Click(object sender, EventArgs e)
        {
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
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
                //if(user != init1.GetFullName())
                //    UsersCheckedListBox.Items.Add(user);
                UsersCheckedListBox.Items.Add(user);
            }
        }

        private void UpdateUsersInMeetingBtn_Click(object sender, EventArgs e)
        {

            List<string> usersInThatMeeting = new List<string>();
            //TODO: TURNS ON REMOVE USERS
            if(CheckedListBoxMeetingsList.CheckedItems.Count <= 1)
            {
                
                AllYourMeetingsUsersList(usersInThatMeeting);
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

            foreach (String user in usersInThatMeeting)
            {
                //if(user != init1.GetFullName())
                //    UsersCheckedListBox.Items.Add(user);
                UsersCheckedListBoxUpdate.Items.Add(user);
            }

            //TODO: When rearraging i need have it not show current user

        }

        private void AllYourMeetingsUsersList(List<string> usersInThatMeeting)
        {
            String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
            List<string> namesMeetingDatabase = new List<string>();
            
            string meetingName = "";
            string personName = "";
            int intAmountInMeeting = 0;
            int a = 1;
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
                            intAmountInMeeting = oReader.GetInt32(2);
                            
                            while (a <= (intAmountInMeeting))
                            {
                                personName = oReader.GetString((a + 2));
                                if (usersInThatMeeting.Contains(personName))
                                {
                                    a++;
                                }
                                else
                                {
                                    usersInThatMeeting.Add(personName);
                                    a++;
                                }
                            }
                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            foreach (string b in usersInThatMeeting)
            {
                MessageBox.Show(b);
            }
            MessageBox.Show(usersInThatMeeting.Count.ToString());
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
                List<string> usersInThatMeeting = new List<string>();
                AllYourMeetingsUsersList(usersInThatMeeting);
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
            CheckedListBoxMeetingsList.ClearSelected();
            foreach (int i in CheckedListBoxMeetingsList.CheckedIndices)
            {
                CheckedListBoxMeetingsList.SetItemCheckState(i, CheckState.Unchecked);
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
                        intAmountInMeeting = oReader.GetInt32(2);
                        if (intAmountInMeeting > amountIn)
                            amountIn = intAmountInMeeting;
                        intAmountInMeetingList.Add(intAmountInMeeting);
                    }
                    cnn.Close();
                }
                string command2 = "UPDATE " + database1.GetRemoveMeetingName() + " SET " + SetRemoveSetUpdate(usersRemoveMeeting, amountIn) + " WHERE MeetingOwner = '"+init1.GetFullName()+"';";
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
        }

        private void UpdateTimesAndDataBtn_Click(object sender, EventArgs e)
        {
            //TODO: CHANGE TIME OF MEETING
        }

        private void RemoveSelfMeetingBtn_Click(object sender, EventArgs e)
        {
            //TODO: Reads the users name then removes from the meeting have it donr last since i need to set up the recip first
        }

        private string SetRemoveSetUpdate(List<string> usersRemoveMeeting, int AmountIn)
        {
            //TODO: chnage it so it only does its row. read the idices that the users name is then set a as that number, This is basicly the same for time and date would just chnage the date to the new pick
            string b = "";
            //string usersUse = "";
            //int amount0fnames = 0;
            //foreach(string users in usersRemoveMeeting)
            //{
            //    usersUse += users+ " ";
            //    ++amount0fnames;
            //}
            //int a = 1;
            //while (a <= AmountIn)
            //{
            //    if(a<= amount0fnames)
            //    {

            //    }
            //    b += "UsersInMeeting" + a + " = 'NULL' ";
            //    ++a;
            //    if (a <= AmountIn)
            //        b += ",";
            //}
            return b;
        }

        private void PefenAndExclTimesBtn_Click(object sender, EventArgs e)
        {

        }

        private void CreateUserInitBtn_Click(object sender, EventArgs e)
        {
            init1 = new Init(user1.GetUsername(),user1.GetFName(),user1.GetLName(),user1.GetPassword(),user1.GetEmail());
        }

        private void CreateUserRecipBtn_Click(object sender, EventArgs e)
        {
            recip1 = new Recip(user1.GetUsername(), user1.GetFName(), user1.GetLName(), user1.GetPassword(), user1.GetEmail());
        }
    }
}
