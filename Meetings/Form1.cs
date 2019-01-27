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
    public partial class Form1 : Form
    {
        Users user1;
        Init init1;
        Recip recip1;
        private Database database1;
        String ConString = "Data Source=.\\SQLEXPRESS;Database=Meetings;Integrated Security=True";
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
            dateTimePickerUpdate.MaxDate = DateTime.Today.AddYears(1);
            dateTimePickerUpdate.MinDate = DateTime.Today;
            dateTimePickerUpdate.Format = DateTimePickerFormat.Custom;
            dateTimePickerUpdate.CustomFormat = "ddd/ MMM / yyyy";
            UsersCheckedListBox.CheckOnClick = true;
            TimesCheckedListBox.CheckOnClick = true;
            UsersCheckedListBoxUpdate.CheckOnClick = true;
            TimesCheckedListBoxUpdate.CheckOnClick = true;
            CheckedListBoxMeetingsList.CheckOnClick = true;
            TimesCheckedListBoxUpdate.CheckOnClick = true;
            ExCheckedListBox.CheckOnClick = true;
            PrefCheckedListBox.CheckOnClick = true;
            AddUsersToUsersCheckedList();
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00","17:00","18:00","19:00","20:00","21:00"};
            init1 = new Init("","", "", "","");
            recip1 = new Recip("", "", "", "", "");
            TimesCheckedListBox.Items.AddRange(meetingTimes);
            string cmdText = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='GlobalTableList') SELECT 1 ELSE SELECT 0";
            string cmdText2 = @"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
                       WHERE TABLE_NAME='MeetingsDatabase') SELECT 1 ELSE SELECT 0";
            string command = "CREATE TABLE[dbo].[GlobalTableList] (GlobalTableID int IDENTITY(1,1) PRIMARY KEY,MeetingOwner varchar(20), MeetingName varchar(20), Users varchar(100), MeetingPrefAndExDatabaseName varchar(100));";
            string command2 = "CREATE TABLE[dbo].[MeetingsDatabase] (UserID int IDENTITY(1,1) PRIMARY KEY,Username varchar(20), FirstName varchar(20), Surname varchar(20), Password varchar(20), Email varchar(20));";
            using (SqlConnection con = new SqlConnection(ConString))
            {

                try
                {
                    con.Open();
                    SqlCommand GlobalTableListCheck = new SqlCommand(cmdText, con);
                    int x = Convert.ToInt32(GlobalTableListCheck.ExecuteScalar());
                    if (x == 0)
                    {
                        using (SqlCommand com = new SqlCommand(command, con))
                            com.ExecuteNonQuery();
                    }
                    con.Close();
                    con.Open();
                    SqlCommand MeetingsDatabaseCheck = new SqlCommand(cmdText2, con);
                    int y = Convert.ToInt32(MeetingsDatabaseCheck.ExecuteScalar());
                    if (y == 0)
                    {
                        using (SqlCommand com2 = new SqlCommand(command2, con))
                            com2.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

            string MeetingsDatabaseName = database1.GetName();
            Int32 count = 0;
            if (count <= 1)
            {
                //TODO: IF public was pressed need to vaidate insertUser string or else it will be the wrong date
                int day = dateTimePicker.Value.Day;
                int month = dateTimePicker.Value.Month;
                int year = dateTimePicker.Value.Year;
                bool tryAgain = false;
                if(database1.GetPublic() == "true")
                {
                    if (dateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday)
                        tryAgain = true;
                    if(dateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
                        tryAgain = true;
                }

                string checkedItemsTimes = string.Empty;
                foreach (object Item in TimesCheckedListBox.CheckedItems)
                {
                    checkedItemsTimes += Item.ToString().Trim();
                    checkedItemsTimes += ",";
                }
                int AmountOfUsersChecked = UsersCheckedListBox.CheckedItems.Count;
                int AmountOfUsersPossiable = UsersCheckedListBox.Items.Count;
                string checkedItemsUsers = string.Empty;
                foreach (object Item in UsersCheckedListBox.CheckedItems)
                {
                    checkedItemsUsers += Item.ToString().Trim();
                    checkedItemsUsers += ",";
                }
                int amountIds = 1;
                if(tryAgain == false)
                {
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
                            //else
                                //MessageBox.Show(InsertPartTimesFix);

                        }

                    }
                    ListOfCheckedItemsTimes.Clear();
                    ListOfPossiableCheckedItemsTimes.Clear();
                    String insertUsersFull = insertMeetingsPart1 + insertMeetingsPart2 + insertMeetingsPart3 + insertMeetingsPart4 + InsertPartUsersFix + InsertPartTimesFix + "')";
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
                    string usersInMeetingGlobalTable = "' ";
                    int g = 0;
                    foreach (object item in UsersCheckedListBox.CheckedItems)
                    {
                        g++;
                        usersInMeetingGlobalTable += " " + item.ToString();
                        if (g != UsersCheckedListBox.CheckedItems.Count)
                        {
                            usersInMeetingGlobalTable += " / ";
                        }
                    }
                    usersInMeetingGlobalTable += "'";
                    string GlobalTableList = "GlobalTableList";
                    String addingUsersToMeeting = "Update " + GlobalTableList + " Set Users = " + usersInMeetingGlobalTable + "where  MeetingName = '" + MeetingsDatabaseName + "';";
                    try
                    {
                        SqlConnection cnn = new SqlConnection(ConString);
                        SqlCommand oCmd = new SqlCommand(addingUsersToMeeting, cnn);
                        cnn.Open();
                        oCmd.ExecuteNonQuery();
                        oCmd.Dispose();
                        cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
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
                    dateTimePicker.Visible = false;
                    dateTimePicker.Enabled = false;
                    UsersCheckedListBox.Enabled = false;
                    UsersCheckedListBox.Visible = false;
                    TimesCheckedListBox.Visible = false;
                    TimesCheckedListBox.Enabled = false;
                    DatePickerbtn.Enabled = false;
                    DatePickerbtn.Visible = false;
                    CreateUserInitBtn.Enabled = true;
                    EditMeetingsBtn.Enabled = true;
                    CreateUserRecipBtn.Enabled = true;
                    button1.Enabled = true;
                    button1.Visible = true;
                    CreateUserInitBtn.Visible = true;
                    EditMeetingsBtn.Visible = true;
                    CreateUserRecipBtn.Visible = true;
                    button3.Enabled = false;
                    button3.Visible = false;
                }
                else
                {
                    MessageBox.Show("Public meetings are week days only");
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
            {
                NewUser(Username, Firstname, LastName, Password, email);
                newUsernamelabel.Enabled = false;
                newUsernameTxtbox.Enabled = false;
                newPasswordLabel.Enabled = false;
                newFirstnameTxtbox.Enabled = false;
                newFirstnameLabel.Enabled = false;
                newLastnameTxtbox.Enabled = false;
                newLastnameLabel.Enabled = false;
                newPasswordTxtbox.Enabled = false;
                newEmailLabel.Enabled = false;
                newEmailTxtbox.Enabled = false;
                newUserBtn.Enabled = false;

                newUsernamelabel.Visible = false;
                newUsernameTxtbox.Visible = false;
                newPasswordLabel.Visible = false;
                newFirstnameTxtbox.Visible = false;
                newFirstnameLabel.Visible = false;
                newLastnameLabel.Visible = false;
                newLastnameTxtbox.Visible = false;
                newLastnameLabel.Visible = false;
                newPasswordTxtbox.Visible = false;
                newEmailLabel.Visible = false;
                newEmailTxtbox.Visible = false;
                newUserBtn.Visible = false;
            }
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
            else
            {
                MessageBox.Show("Already a user with these details made.");
            }
        }
        
        private void UserExists(string username, string password)
        {
            string Password = "";
            string firstName = "";
            string lastName = "";
            string email = "";
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
                    button2.Enabled = false;
                    Loginbtn.Enabled = false;
                    PasswordTxtbox.Enabled = false;
                    PasswordLabel.Enabled = false;
                    UserNameTxtbox.Enabled = false;
                    UserNameLabel.Enabled = false;

                    button2.Visible = false;
                    Loginbtn.Visible = false;
                    PasswordTxtbox.Visible = false;
                    PasswordLabel.Visible = false;
                    UserNameTxtbox.Visible = false;
                    UserNameLabel.Visible = false;

                    CreateUserInitBtn.Enabled = true;
                    EditMeetingsBtn.Enabled = true;
                    CreateUserRecipBtn.Enabled = true;
                    button1.Enabled = true;
                    button1.Visible = true;
                    CreateUserInitBtn.Visible = true;
                    EditMeetingsBtn.Visible = true;
                    CreateUserRecipBtn.Visible = true;
                    Logoutbtn.Visible = true;
                    Logoutbtn.Enabled = true;

                    newUsernamelabel.Enabled = false;
                    newUsernameTxtbox.Enabled = false;
                    newPasswordLabel.Enabled = false;
                    newFirstnameTxtbox.Enabled = false;
                    newFirstnameLabel.Enabled = false;
                    newLastnameTxtbox.Enabled = false;
                    newLastnameLabel.Enabled = false;
                    newPasswordTxtbox.Enabled = false;
                    newEmailLabel.Enabled = false;
                    newEmailTxtbox.Enabled = false;
                    newUserBtn.Enabled = false;

                    newUsernamelabel.Visible = false;
                    newUsernameTxtbox.Visible = false;
                    newPasswordLabel.Visible = false;
                    newFirstnameTxtbox.Visible = false;
                    newFirstnameLabel.Visible = false;
                    newLastnameLabel.Visible = false;
                    newLastnameTxtbox.Visible = false;
                    newLastnameLabel.Visible = false;
                    newPasswordTxtbox.Visible = false;
                    newEmailLabel.Visible = false;
                    newEmailTxtbox.Visible = false;
                    newUserBtn.Visible = false;
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
            {
                CreateMeetingsDatabase(meetingsName);
            }
            else
                MessageBox.Show("Fill all the data please");
        }
        
        private void CreateMeetingsDatabase(string meetingsName)
        {
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
                            using (SqlCommand command = new SqlCommand(insertMeetingsFull, con))
                                command.ExecuteNonQuery();
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
                string createPrefAndExcDatabase = "CREATE TABLE[dbo].[" + meetingsName + "UsersAnswers] (ID int IDENTITY(1,1) PRIMARY KEY, MeetingAnswersUser varchar(20), MeetingAnswersDate varchar(20), MeetingAnswersPrefForDate varchar(200), MeetingAnswersExcForDate varchar(200) );";
                try
                {
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand oCmd = new SqlCommand(createPrefAndExcDatabase, cnn);
                    cnn.Open();
                    oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                string GlobalTableList = "GlobalTableList";
                string PerfAndExMeetingName = meetingsName + "UsersAnswers";
                String AddingPrefExclMeetingToGlobalList = "Update " + GlobalTableList + " Set  MeetingPrefAndExDatabaseName = '"+PerfAndExMeetingName+ "' where MeetingName = '" + meetingsName + "';";
                try
                {
                    SqlConnection cnn = new SqlConnection(ConString);
                    SqlCommand oCmd = new SqlCommand(AddingPrefExclMeetingToGlobalList, cnn);
                    cnn.Open();
                    oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                createMeetingsNameLabel.Visible = false;
                createMeetingsNameLabel.Enabled = false;
                createMeetingsNameTxtBox.Visible = false;
                createMeetingsNameTxtBox.Enabled = false;
                createMeetingsNameBtn.Enabled = false;
                createMeetingsNameBtn.Visible = false;
                dateTimePicker.Visible = true;
                dateTimePicker.Enabled = true;
                UsersCheckedListBox.Visible = true;
                UsersCheckedListBox.Enabled = true;
                TimesCheckedListBox.Visible = true;
                TimesCheckedListBox.Enabled = true;
                DatePickerbtn.Visible = true;
                DatePickerbtn.Enabled = true;
            }
           
        }
        
        private void DropMeeting(string meetingsName)
        {

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
                        using (SqlCommand command3 = new SqlCommand("DROP TABLE[dbo].[" + meetingsName + "UsersAnswers];", con))
                            command3.ExecuteNonQuery();
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
            publicBtn.Enabled = false;
            publicBtn.Visible = false;
            privateBtn.Enabled = false;
            privateBtn.Visible = false;
            createMeetingsNameBtn.Enabled = true;
            createMeetingsNameBtn.Visible = true;
            createMeetingsNameLabel.Enabled = true;
            createMeetingsNameLabel.Visible = true;
            createMeetingsNameTxtBox.Enabled = true;
            createMeetingsNameTxtBox.Visible = true;
        }

        private void PrivateBtn_Click(object sender, EventArgs e)
        {
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            UsersCheckedListBox.Items.Clear();
            AddUsersToUsersCheckedList();
            TimesCheckedListBox.Items.Clear();
            TimesCheckedListBox.Items.AddRange(meetingTimes);
            database1.SetPublic("false");
            publicBtn.Enabled = false;
            publicBtn.Visible = false;
            privateBtn.Enabled = false;
            privateBtn.Visible = false;
            createMeetingsNameLabel.Visible = true;
            createMeetingsNameLabel.Enabled = true;
            createMeetingsNameTxtBox.Enabled = true;
            createMeetingsNameTxtBox.Visible = true;
            createMeetingsNameBtn.Enabled = true;
            createMeetingsNameBtn.Visible = true;
        }
        
        private void AddUsersToUsersCheckedList()
        {
            string oString = "Select * from MeetingsDatabase where UserID > 0";
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
            
            foreach (String user in namesList)
            {
                UsersCheckedListBox.Items.Add(user);
            }
        }

        private void UpdateUsersInMeetingBtn_Click(object sender, EventArgs e)
        {
            UsersCheckedListBoxUpdate.Items.Clear();
            List<string> usersInThatMeeting = new List<string>();
            List<string> usersDistiant = new List<string>();
            if (CheckedListBoxMeetingsList.CheckedItems.Count > 1)
            {
                MessageBox.Show("One at a time please.");
            }
            else if (CheckedListBoxMeetingsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("One at a time please.");
            }
            else
            {
                AllYourMeetingsUsersList(usersInThatMeeting, usersDistiant);
                foreach (string b in usersInThatMeeting)
                {
                    MessageBox.Show(b);
                }
                MessageBox.Show(usersInThatMeeting.Count.ToString());

                UsersInMeetingTransferBtn.Visible = false;
                UsersInMeetingTransferBtn.Enabled = false;
                UsersCheckedListBoxUpdate.Enabled = true;
                UsersCheckedListBoxUpdate.Visible = true;
                UpdateRemovedUsersBtn.Enabled = true;
                UpdateRemovedUsersBtn.Visible = true;

            }
            MeetingList();
            CheckedListBoxMeetingsList.ClearSelected();
            foreach (int i in CheckedListBoxMeetingsList.CheckedIndices)
            {
                CheckedListBoxMeetingsList.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (String user in usersDistiant)
            {

                UsersCheckedListBoxUpdate.Items.Add(user);
            }
        }

        private void AllYourMeetingsUsersList(List<string> usersInThatMeeting, List<string> usersDistiant)
        {
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
        

        private void MeetingList()
        {
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

            foreach (String meeting in namesListInDatabase)
            {
                CheckedListBoxMeetingsList.Items.Add(meeting);
            }
        }

        private void UpdateDateTimeBtn_Click(object sender, EventArgs e)
        {
            if (CheckedListBoxMeetingsList.CheckedItems.Count > 1)
            {
                MessageBox.Show("One at a time please.");
            }
            else if (CheckedListBoxMeetingsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("One at a time please.");
            }
            else
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
                UpdateDateTimeBtn.Visible = false;
                UpdateDateTimeBtn.Enabled = false;
                meetingTimesListBox.Visible = true;
                meetingTimesListBox.Enabled = true;
                MeetingTimesListUpdateBtn.Enabled = true;
                MeetingTimesListUpdateBtn.Visible = true;

            }   
        }

        private void AllYourMeetingsDateList(List<string> nameOfMeetings, List<string> datesOfMeetings)
        {
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
            List<string> usersRemoveMeeting = new List<string>();
            List<int> intAmountInMeetingList = new List<int>();
            int intAmountInMeeting = 0;
            int amountIn = 0;
            foreach (object Item in UsersCheckedListBoxUpdate.CheckedItems)
            {
                usersRemoveMeeting.Add(Item.ToString());
            }
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
                cnn.Open();
                using (SqlCommand com2 = new SqlCommand(command2, cnn))
                    com2.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("User removed from meeting.");
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
            UsersCheckedListBoxUpdate.Items.Clear();
            MeetingList();
            UsersCheckedListBoxUpdate.Items.Clear();
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Enabled =   false;
            CreateUserRecipBtn.Enabled = false;
            button1.Enabled = false;
            button1.Visible = false;
            CreateUserInitBtn.Visible = false;
            EditMeetingsBtn.Visible = false;
            CreateUserRecipBtn.Visible = false;
            button3.Enabled = true;
            button3.Visible = true;
            publicBtn.Visible = false;
            publicBtn.Enabled = false;
            privateBtn.Visible = false;
            privateBtn.Enabled = false;
            createMeetingsNameLabel.Enabled = false;
            createMeetingsNameLabel.Visible = false;
            createMeetingsNameTxtBox.Visible = false;
            createMeetingsNameTxtBox.Enabled = false;
            createMeetingsNameBtn.Enabled = false;
            createMeetingsNameBtn.Visible = false;
            dateTimePicker.Visible = false;
            dateTimePicker.Enabled = false;
            UsersCheckedListBox.Enabled = false;
            UsersCheckedListBox.Visible = false;
            DatePickerbtn.Visible = false;
            DatePickerbtn.Enabled = false;
            label2.Enabled = false;
            label2.Visible = false;
            CheckedListBoxMeetingsList.Enabled = true;
            CheckedListBoxMeetingsList.Visible = true;
            UsersInMeetingTransferBtn.Enabled = true;
            UsersInMeetingTransferBtn.Visible = true;
            UsersCheckedListBoxUpdate.Visible = false;
            UsersCheckedListBoxUpdate.Enabled = false;
            UpdateRemovedUsersBtn.Enabled = false;
            UpdateRemovedUsersBtn.Visible = false;
            UpdateDateTimeBtn.Enabled = true;
            UpdateDateTimeBtn.Visible = true;
            meetingTimesListBox.Visible = false;
            meetingTimesListBox.Enabled = false;
            MeetingTimesListUpdateBtn.Enabled = false;
            MeetingTimesListUpdateBtn.Visible = false;
            dateTimePickerUpdate.Enabled = false;
            dateTimePickerUpdate.Visible = false;
            TimesCheckedListBoxUpdate.Enabled = false;
            TimesCheckedListBoxUpdate.Visible = false;
            UpdateTimesAndDataBtn.Enabled = false;
            UpdateTimesAndDataBtn.Visible = false;
            cancelAMeetingBtn.Enabled = true;
            cancelAMeetingBtn.Visible = true;
            ViewUsersPrefAndExclBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Enabled = false;
            PefenAndExclTimesBtn.Enabled = false;
            PefenAndExclTimesBtn.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
            PrefCheckedListBox.Visible = false;
            PrefCheckedListBox.Enabled = false;
            ExCheckedListBox.Visible = false;
            ExCheckedListBox.Enabled = false;
            PrefExclVaidateBtn.Enabled = false;
            PrefExclVaidateBtn.Visible = false;
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
            TimesCheckedListBoxUpdate.Items.Clear();
            database1.ClearUpdateMeetingDate();
            database1.ClearUpdateMeetingName();
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Enabled = false;
            button1.Visible = false;
            CreateUserInitBtn.Visible = false;
            EditMeetingsBtn.Visible = false;
            CreateUserRecipBtn.Visible = false;
            button3.Enabled = true;
            button3.Visible = true;
            publicBtn.Visible = false;
            publicBtn.Enabled = false;
            privateBtn.Visible = false;
            privateBtn.Enabled = false;
            createMeetingsNameLabel.Enabled = false;
            createMeetingsNameLabel.Visible = false;
            createMeetingsNameTxtBox.Visible = false;
            createMeetingsNameTxtBox.Enabled = false;
            createMeetingsNameBtn.Enabled = false;
            createMeetingsNameBtn.Visible = false;
            dateTimePicker.Visible = false;
            dateTimePicker.Enabled = false;
            UsersCheckedListBox.Enabled = false;
            UsersCheckedListBox.Visible = false;
            DatePickerbtn.Visible = false;
            DatePickerbtn.Enabled = false;
            label2.Enabled = false;
            label2.Visible = false;
            CheckedListBoxMeetingsList.Enabled = true;
            CheckedListBoxMeetingsList.Visible = true;
            UsersInMeetingTransferBtn.Enabled = true;
            UsersInMeetingTransferBtn.Visible = true;
            UsersCheckedListBoxUpdate.Visible = false;
            UsersCheckedListBoxUpdate.Enabled = false;
            UpdateRemovedUsersBtn.Enabled = false;
            UpdateRemovedUsersBtn.Visible = false;
            UpdateDateTimeBtn.Enabled = true;
            UpdateDateTimeBtn.Visible = true;
            meetingTimesListBox.Visible = false;
            meetingTimesListBox.Enabled = false;
            MeetingTimesListUpdateBtn.Enabled = false;
            MeetingTimesListUpdateBtn.Visible = false;
            dateTimePickerUpdate.Enabled = false;
            dateTimePickerUpdate.Visible = false;
            TimesCheckedListBoxUpdate.Enabled = false;
            TimesCheckedListBoxUpdate.Visible = false;
            UpdateTimesAndDataBtn.Enabled = false;
            UpdateTimesAndDataBtn.Visible = false;
            cancelAMeetingBtn.Enabled = true;
            cancelAMeetingBtn.Visible = true;
            ViewUsersPrefAndExclBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Enabled = false;
            PefenAndExclTimesBtn.Enabled = false;
            PefenAndExclTimesBtn.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
            PrefCheckedListBox.Visible = false;
            PrefCheckedListBox.Enabled = false;
            ExCheckedListBox.Visible = false;
            ExCheckedListBox.Enabled = false;
            PrefExclVaidateBtn.Enabled = false;
            PrefExclVaidateBtn.Visible = false;
        }

        private void RemoveSelfMeetingBtn_Click(object sender, EventArgs e)
        {
            //TODO: Reads the users name then removes from the meeting have it donr last since i need to set up the recip first
        }

        private string SetRemoveSetUpdate(List<string> usersRemoveMeeting, int AmountIn)
        {
            List<string> everyUserInMeeting = new List<string>();
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
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            return b;
        }

        private void PefenAndExclTimesBtn_Click(object sender, EventArgs e)
        {
            List<string> ListOfTimes = new List<string>();
            List<string> TimesDistiant = new List<string>();
            List<string> TimesRemovedNoString = new List<string>();
            if (CheckedListBoxMeetingsList.CheckedItems.Count > 1)
            {
                MessageBox.Show("One at a time please.");
            }
            else if (CheckedListBoxMeetingsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("One at a time please.");
            }
            else
            {
                PrefCheckedListBox.Items.Clear();
                ExCheckedListBox.Items.Clear();
                int intAmountInMeeting = 0;
                int counter = 0;
                int scalar = 0;
                int areaWeAreLooking = 0;
                string date = "";
                string times = "";
                string publicOrNot = "";
                int maxAmoutOfHours = 0;
                string checkedItemsForLooking = "";
                foreach (object item in CheckedListBoxMeetingsList.CheckedItems)
                {
                    checkedItemsForLooking += item.ToString();
                }
                database1.SetVaidateMeetingName(checkedItemsForLooking);
                SqlConnection cnn = new SqlConnection(ConString);
                try
                {

                    String command = "Select * from " + checkedItemsForLooking + ";";
                    SqlCommand oCmd = new SqlCommand(command, cnn);
                    cnn.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            publicOrNot = oReader.GetString(6);
                            database1.SetPublic(publicOrNot);
                            if (database1.GetPublic() == "true")
                            {
                                maxAmoutOfHours = 10;
                            }
                            else
                            {
                                maxAmoutOfHours = 14;
                            }
                            intAmountInMeeting = oReader.GetInt32(4);
                            areaWeAreLooking = 6;
                            intAmountInMeeting = intAmountInMeeting + areaWeAreLooking;
                            scalar = intAmountInMeeting;
                            date = oReader.GetString(2);
                            database1.SetVaidateMeetingDate(date);
                            while (counter < maxAmoutOfHours)
                            {
                                ++counter;
                                ++scalar;
                                times = oReader.GetString(scalar).ToString();
                                ListOfTimes.Add(times);
                            }
                        }
                        TimesDistiant.AddRange(ListOfTimes.Distinct());
                        TimesDistiant.Remove("");
                        TimesRemovedNoString.AddRange(TimesDistiant.ToList());
                        foreach(string a in TimesRemovedNoString)
                        {
                            PrefCheckedListBox.Items.Add(a);
                            ExCheckedListBox.Items.Add(a);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                PefenAndExclTimesBtn.Visible = false;
                PefenAndExclTimesBtn.Enabled = false;
                label1.Enabled = true;
                label1.Visible = true;
                PrefCheckedListBox.Visible = true;
                PrefCheckedListBox.Enabled = true;
                label3.Enabled = true;
                label3.Visible = true;
                ExCheckedListBox.Visible = true;
                ExCheckedListBox.Enabled = true;
                PrefExclVaidateBtn.Enabled = true;
                PrefExclVaidateBtn.Visible = true;

            }
        }

        private void CreateUserInitBtn_Click(object sender, EventArgs e)
        {
            init1 = new Init(user1.GetUsername(),user1.GetFName(),user1.GetLName(),user1.GetPassword(),user1.GetEmail());
            CreateUserInitBtn.Visible = false;
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Visible = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Visible = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            publicBtn.Enabled = true;
            publicBtn.Visible = true;
            privateBtn.Enabled = true;
            privateBtn.Visible = true;
            button3.Visible = true;
            button3.Enabled = true;
        }

        private void CreateUserRecipBtn_Click(object sender, EventArgs e)
        {
            init1 = new Init(user1.GetUsername(), user1.GetFName(), user1.GetLName(), user1.GetPassword(), user1.GetEmail());
            MeetingList();
            CreateUserInitBtn.Visible = false;
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Visible = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Visible = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            label2.Enabled = true;
            label2.Visible = true;
            CheckedListBoxMeetingsList.Enabled = true;
            CheckedListBoxMeetingsList.Visible = true;
            ViewUsersPrefAndExclBtn.Enabled = true;
            ViewUsersPrefAndExclBtn.Visible = true;
            button3.Visible = true;
            button3.Enabled = true;
        }

        private void EditMeetingsBtn_Click(object sender, EventArgs e)
        {
            init1 = new Init(user1.GetUsername(), user1.GetFName(), user1.GetLName(), user1.GetPassword(), user1.GetEmail());
            MeetingList();
            CreateUserInitBtn.Visible = false;
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Visible = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Visible = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            button3.Visible = true;
            button3.Enabled = true;
            label2.Visible = true;
            label2.Enabled = true;
            CheckedListBoxMeetingsList.Enabled = true;
            CheckedListBoxMeetingsList.Visible = true;
            UsersInMeetingTransferBtn.Visible = true;
            UsersInMeetingTransferBtn.Enabled = true;
            UpdateDateTimeBtn.Enabled = true;
            UpdateDateTimeBtn.Visible = true;
            cancelAMeetingBtn.Visible = true;
            cancelAMeetingBtn.Enabled = true;
        }

        private void MeetingTimesListUpdateBtn_Click(object sender, EventArgs e)
        {
            if (meetingTimesListBox.CheckedItems.Count > 1)
            {
                MessageBox.Show("One at a time please.");
            }
            else if (meetingTimesListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("One at a time please.");
            }
            else
            {
                foreach (object item in meetingTimesListBox.CheckedItems)
                {
                    database1.AddUpdateMeetingDate(item.ToString());
                }
                meetingTimesListBox.Items.Clear();
                TimesCheckedListBoxUpdate.Items.Clear();
                MeetingTimesListUpdateBtn.Enabled = false;
                List<string> meetingTimes = new List<string>();
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
                MeetingTimesListUpdateBtn.Visible = false;
                MeetingTimesListUpdateBtn.Enabled = false;
                dateTimePickerUpdate.Enabled = true;
                dateTimePickerUpdate.Visible = true;
                TimesCheckedListBoxUpdate.Enabled = true;
                TimesCheckedListBoxUpdate.Visible = true;
                UpdateTimesAndDataBtn.Visible = true;
                UpdateTimesAndDataBtn.Enabled = true;
                meetingTimesListBox.Visible = false;
                meetingTimesListBox.Enabled = false;
            }
            
        }

        private void ViewUsersPrefAndExclBtn_Click(object sender, EventArgs e)
        {
            if (CheckedListBoxMeetingsList.CheckedItems.Count > 1)
            {
                MessageBox.Show("One at a time please.");
            }
            else if (CheckedListBoxMeetingsList.CheckedItems.Count == 0)
            {
                MessageBox.Show("One at a time please.");
            }
            else
            {
                int amountInMeeting = 0;
                string Output = "";
                string ViewEveryUserInMeetingsAnswer = "";
                foreach (object item in CheckedListBoxMeetingsList.CheckedItems)
                {
                    ViewEveryUserInMeetingsAnswer += item.ToString();
                }
                List<String> ListOfAnswers = new List<string>();
                string Answers = "";
                string Name = "";
                string Date = "";
                String Pref = "";
                string Excl = "";
                String com = "Select * from " + ViewEveryUserInMeetingsAnswer + "UsersAnswers;";
                String com2 = "Select * from " + ViewEveryUserInMeetingsAnswer + ";";
                SqlConnection cnn = new SqlConnection(ConString);
                try
                {
                    SqlCommand oCmd = new SqlCommand(com, cnn);
                    cnn.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Name = oReader.GetString(1);
                            Date = oReader.GetString(2);
                            Pref = oReader.GetString(3);
                            Excl = oReader.GetString(4);
                            Answers = "For date " + Date + ", " + Name.Trim() + "'s\nPreferences are " + Pref + " and their Exclusions are " + Excl + ".";
                            ListOfAnswers.Add(Answers);
                        }
                        cnn.Close();
                    }
                    SqlCommand oCmd2 = new SqlCommand(com2, cnn);
                    cnn.Open();
                    using (SqlDataReader oReader = oCmd2.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            amountInMeeting = oReader.GetInt32(4);

                        }
                        cnn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if(ListOfAnswers.Count < amountInMeeting)
                {
                    MessageBox.Show("Not every person has answered yet.");
                }
                else
                {
                    foreach(string a in ListOfAnswers)
                    {
                        Output += a + "\n";
                    }
                    MessageBox.Show(Output);
                    CreateUserInitBtn.Enabled = true;
                    EditMeetingsBtn.Enabled = true;
                    CreateUserRecipBtn.Enabled = true;
                    button1.Enabled = true;
                    button1.Visible = true;
                    CreateUserInitBtn.Visible = true;
                    EditMeetingsBtn.Visible = true;
                    CreateUserRecipBtn.Visible = true;
                    button3.Enabled = false;
                    button3.Visible = false;
                    publicBtn.Visible = false;
                    publicBtn.Enabled = false;
                    privateBtn.Visible = false;
                    privateBtn.Enabled = false;
                    createMeetingsNameLabel.Enabled = false;
                    createMeetingsNameLabel.Visible = false;
                    createMeetingsNameTxtBox.Visible = false;
                    createMeetingsNameTxtBox.Enabled = false;
                    createMeetingsNameBtn.Enabled = false;
                    createMeetingsNameBtn.Visible = false;
                    dateTimePicker.Visible = false;
                    dateTimePicker.Enabled = false;
                    UsersCheckedListBox.Enabled = false;
                    UsersCheckedListBox.Visible = false;
                    DatePickerbtn.Visible = false;
                    DatePickerbtn.Enabled = false;
                    label2.Enabled = false;
                    label2.Visible = false;
                    CheckedListBoxMeetingsList.Enabled = false;
                    CheckedListBoxMeetingsList.Visible = false;
                    UsersInMeetingTransferBtn.Enabled = false;
                    UsersInMeetingTransferBtn.Visible = false;
                    UsersCheckedListBoxUpdate.Visible = false;
                    UsersCheckedListBoxUpdate.Enabled = false;
                    UpdateRemovedUsersBtn.Enabled = false;
                    UpdateRemovedUsersBtn.Visible = false;
                    UpdateDateTimeBtn.Enabled = false;
                    UpdateDateTimeBtn.Visible = false;
                    meetingTimesListBox.Visible = false;
                    meetingTimesListBox.Enabled = false;
                    MeetingTimesListUpdateBtn.Enabled = false;
                    MeetingTimesListUpdateBtn.Visible = false;
                    dateTimePickerUpdate.Enabled = false;
                    dateTimePickerUpdate.Visible = false;
                    TimesCheckedListBoxUpdate.Enabled = false;
                    TimesCheckedListBoxUpdate.Visible = false;
                    UpdateTimesAndDataBtn.Enabled = false;
                    UpdateTimesAndDataBtn.Visible = false;
                    cancelAMeetingBtn.Enabled = false;
                    cancelAMeetingBtn.Visible = false;
                    ViewUsersPrefAndExclBtn.Visible = false;
                    ViewUsersPrefAndExclBtn.Enabled = false;
                    PefenAndExclTimesBtn.Enabled = false;
                    PefenAndExclTimesBtn.Visible = false;
                    label1.Enabled = false;
                    label1.Visible = false;
                    label3.Enabled = false;
                    label3.Visible = false;
                    PrefCheckedListBox.Visible = false;
                    PrefCheckedListBox.Enabled = false;
                    ExCheckedListBox.Visible = false;
                    ExCheckedListBox.Enabled = false;
                    PrefExclVaidateBtn.Enabled = false;
                    PrefExclVaidateBtn.Visible = false;
                }
            }
        }

        public void UpdateMeetingTimesAndDate(List<string> timesOfMeetingChange, int day, int month, int year, int maxAmoutOfHours)
        {
            int b = 0;
            int location = b;
            foreach (string a in timesOfMeetingChange)
            {
                string name = database1.GetUpdateMeetingName(0);
                string date = database1.GetUpdateMeetingDate(0);
                location++;
                string com = "Update " + name + " set MeetingDate = '" + day + "/" + month + "/" + year + "' ;";
                string com2 = "Update " + name + " set " + SetTimesForDatabase(maxAmoutOfHours, timesOfMeetingChange, b) + " where "+name+"id = "+ location + ";";
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
            MessageBox.Show("Meetings times and dates been updated");
        }
        private string SetTimesForDatabase(int maxAmoutOfHours, List<string> timesOfMeetingChange, int b)
        {
            string name = database1.GetUpdateMeetingName(0);
            List<string> dataAlreadyInMeeting = new List<string>();
            string com = "Select * from " + name + ";";
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
                            eitherBlankOrWillBeBlank = oReader.GetString((c + 6 + startFrom));
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
            //TODO: FIX
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
            return ba;
        }
        private void MeetingListView()
        {
            string com = "Select * from GlobalTableList;";
            List<string> namesListInDatabase = new List<string>();
            SqlConnection cnn = new SqlConnection(ConString);
            try
            {
                string userFN = recip1.GetFName();
                string userLN = recip1.GetLName();
                string meetingUsers = "";
                string meetingName = "";
                SqlCommand oCmd = new SqlCommand(com, cnn);
                cnn.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        meetingUsers = oReader["Users"].ToString();
                        if (meetingUsers.Contains(userFN) && meetingUsers.Contains(userLN))
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
            foreach (String meeting in namesListInDatabase)
            {   
                CheckedListBoxMeetingsList.Items.Add(meeting);
            }
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            init1 = new Init("", "", "", "", "");
            recip1 = new Recip("", "", "", "", "");
            UserNameLabel.Visible = true;
            UserNameLabel.Enabled = true;
            UserNameTxtbox.Enabled = true;
            UserNameTxtbox.Visible = true;
            PasswordLabel.Visible = true;
            PasswordLabel.Enabled = true;
            PasswordTxtbox.Enabled = true;
            PasswordTxtbox.Visible = true;
            Loginbtn.Enabled = true;
            Loginbtn.Visible = true;
            button2.Visible = true;
            button2.Enabled = true;
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Enabled = false;
            button1.Visible =   false;
            CreateUserInitBtn.Visible =     false;
            EditMeetingsBtn.Visible = false;
            CreateUserRecipBtn.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            publicBtn.Visible = false;
            publicBtn.Enabled = false;
            privateBtn.Visible = false;
            privateBtn.Enabled = false;
            createMeetingsNameLabel.Enabled = false;
            createMeetingsNameLabel.Visible = false;
            createMeetingsNameTxtBox.Visible = false;
            createMeetingsNameTxtBox.Enabled = false;
            createMeetingsNameBtn.Enabled = false;
            createMeetingsNameBtn.Visible = false;
            dateTimePicker.Visible = false;
            dateTimePicker.Enabled = false;
            UsersCheckedListBox.Enabled = false;
            UsersCheckedListBox.Visible = false;
            DatePickerbtn.Visible = false;
            DatePickerbtn.Enabled = false;
            label2.Enabled = false;
            label2.Visible = false;
            CheckedListBoxMeetingsList.Enabled = false;
            CheckedListBoxMeetingsList.Visible = false;
            UsersInMeetingTransferBtn.Enabled = false;
            UsersInMeetingTransferBtn.Visible = false;
            UsersCheckedListBoxUpdate.Visible = false;
            UsersCheckedListBoxUpdate.Enabled = false;
            UpdateRemovedUsersBtn.Enabled = false;
            UpdateRemovedUsersBtn.Visible = false;
            UpdateDateTimeBtn.Enabled = false;
            UpdateDateTimeBtn.Visible = false;
            meetingTimesListBox.Visible = false;
            meetingTimesListBox.Enabled = false;
            MeetingTimesListUpdateBtn.Enabled = false;
            MeetingTimesListUpdateBtn.Visible = false;
            dateTimePickerUpdate.Enabled = false;
            dateTimePickerUpdate.Visible = false;
            TimesCheckedListBoxUpdate.Enabled = false;
            TimesCheckedListBoxUpdate.Visible = false;
            UpdateTimesAndDataBtn.Enabled = false;
            UpdateTimesAndDataBtn.Visible = false;
            cancelAMeetingBtn.Enabled = false;
            cancelAMeetingBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Enabled = false;
            PefenAndExclTimesBtn.Enabled = false;
            PefenAndExclTimesBtn.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
            PrefCheckedListBox.Visible = false;
            PrefCheckedListBox.Enabled = false;
            ExCheckedListBox.Visible = false;
            ExCheckedListBox.Enabled = false;
            PrefExclVaidateBtn.Enabled = false;
            PrefExclVaidateBtn.Visible = false;
            Logoutbtn.Enabled = false;
            Logoutbtn.Visible = false;
        }

        private void PrefExclVaidateBtn_Click(object sender, EventArgs e)
        {
            if ((PrefCheckedListBox.CheckedItems.Count >= 1) || (ExCheckedListBox.CheckedItems.Count >= 1))
            {
                bool theyEqual = false;
                string meetingName = database1.GetVaidateMeetingName() + "UsersAnswers";
                string date = database1.GetVaidateMeetingDate();
                string pref = "";
                string excl = "";
                List<string> PrefList = new List<string>();
                List<string> ExclList = new List<string>();
                foreach (object item in PrefCheckedListBox.CheckedItems)
                {
                    pref = item.ToString();
                    PrefList.Add(pref);
                }
                foreach (object item in ExCheckedListBox.CheckedItems)
                {
                    excl = item.ToString();
                    ExclList.Add(excl);
                }
                foreach (string a in PrefList)
                {
                    foreach (string b in ExclList)
                    {
                        if (a.Equals(b))
                        {

                            theyEqual = true;
                        }
                    }
                }
                if (theyEqual == true)
                {
                    MessageBox.Show("Preference and exculution can't equal enter again.");
                }
                else
                {
                    string PrefListComplete = "";
                    string ExListComplete = "";
                    int counter = 0;
                    foreach (string a in PrefList)
                    {
                        ++counter;
                        if(counter == PrefList.Count)
                        {
                            PrefListComplete += a;
                        }
                        else
                        {
                            PrefListComplete += a + " ,";
                        }
                        
                    }
                    counter = 0;
                    foreach (string a in ExclList)
                    {
                        ++counter;
                        if (counter == ExclList.Count)
                        {
                            ExListComplete += a;
                        }
                        else
                        {
                            ExListComplete += a + " ,";
                        }

                    }
                    string com = "Insert into "+meetingName+ " (MeetingAnswersUser,MeetingAnswersDate,MeetingAnswersPrefForDate,MeetingAnswersExcForDate) values ('"+ recip1.GetFName()+"','"+ date + "','"+ PrefListComplete + "','"+ ExListComplete + "');";
                    SqlConnection cnn = new SqlConnection(ConString);
                    try
                    {
                        SqlCommand oCmd = new SqlCommand(com, cnn);
                        cnn.Open();
                        oCmd.ExecuteNonQuery();
                        oCmd.Dispose();
                        cnn.Close();
                        MessageBox.Show("Your preference and exculution was accepted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    PrefCheckedListBox.Items.Clear();
                    ExCheckedListBox.Items.Clear();
                    CreateUserInitBtn.Enabled = true;
                    EditMeetingsBtn.Enabled = true;
                    CreateUserRecipBtn.Enabled = true;
                    button1.Enabled = true;
                    button1.Visible = true;
                    CreateUserInitBtn.Visible = true;
                    EditMeetingsBtn.Visible = true;
                    CreateUserRecipBtn.Visible = true;
                    button3.Enabled = false;
                    button3.Visible = false;
                    publicBtn.Visible = false;
                    publicBtn.Enabled = false;
                    privateBtn.Visible = false;
                    privateBtn.Enabled = false;
                    createMeetingsNameLabel.Enabled = false;
                    createMeetingsNameLabel.Visible = false;
                    createMeetingsNameTxtBox.Visible = false;
                    createMeetingsNameTxtBox.Enabled = false;
                    createMeetingsNameBtn.Enabled = false;
                    createMeetingsNameBtn.Visible = false;
                    dateTimePicker.Visible = false;
                    dateTimePicker.Enabled = false;
                    UsersCheckedListBox.Enabled = false;
                    UsersCheckedListBox.Visible = false;
                    DatePickerbtn.Visible = false;
                    DatePickerbtn.Enabled = false;
                    label2.Enabled = false;
                    label2.Visible = false;
                    CheckedListBoxMeetingsList.Enabled = false;
                    CheckedListBoxMeetingsList.Visible = false;
                    UsersInMeetingTransferBtn.Enabled = false;
                    UsersInMeetingTransferBtn.Visible = false;
                    UsersCheckedListBoxUpdate.Visible = false;
                    UsersCheckedListBoxUpdate.Enabled = false;
                    UpdateRemovedUsersBtn.Enabled = false;
                    UpdateRemovedUsersBtn.Visible = false;
                    UpdateDateTimeBtn.Enabled = false;
                    UpdateDateTimeBtn.Visible = false;
                    meetingTimesListBox.Visible = false;
                    meetingTimesListBox.Enabled = false;
                    MeetingTimesListUpdateBtn.Enabled = false;
                    MeetingTimesListUpdateBtn.Visible = false;
                    dateTimePickerUpdate.Enabled = false;
                    dateTimePickerUpdate.Visible = false;
                    TimesCheckedListBoxUpdate.Enabled = false;
                    TimesCheckedListBoxUpdate.Visible = false;
                    UpdateTimesAndDataBtn.Enabled = false;
                    UpdateTimesAndDataBtn.Visible = false;
                    cancelAMeetingBtn.Enabled =     false;
                    cancelAMeetingBtn.Visible = false;
                    ViewUsersPrefAndExclBtn.Visible = false;
                    ViewUsersPrefAndExclBtn.Enabled = false;
                    PefenAndExclTimesBtn.Enabled = false;
                    PefenAndExclTimesBtn.Visible = false;
                    label1.Enabled = false;
                    label1.Visible = false;
                    label3.Enabled = false;
                    label3.Visible = false;
                    PrefCheckedListBox.Visible = false;
                    PrefCheckedListBox.Enabled = false;
                    ExCheckedListBox.Visible = false;
                    ExCheckedListBox.Enabled = false;
                    PrefExclVaidateBtn.Enabled = false;
                    PrefExclVaidateBtn.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Enter at least one for both preference and Exculusion");
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            recip1 = new Recip(user1.GetUsername(), user1.GetFName(), user1.GetLName(), user1.GetPassword(), user1.GetEmail());
            MeetingListView();
            CreateUserInitBtn.Visible = false;
            CreateUserInitBtn.Enabled = false;
            EditMeetingsBtn.Visible = false;
            EditMeetingsBtn.Enabled = false;
            CreateUserRecipBtn.Visible = false;
            CreateUserRecipBtn.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            label2.Enabled = true;
            label2.Visible = true;
            CheckedListBoxMeetingsList.Enabled = true;
            CheckedListBoxMeetingsList.Visible = true;
            PefenAndExclTimesBtn.Visible = true;
            PefenAndExclTimesBtn.Enabled = true;
            button3.Visible = true;
            button3.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            newUsernamelabel.Enabled = true;
            newUsernameTxtbox.Enabled = true;
            newPasswordLabel.Enabled = true;
            newFirstnameTxtbox.Enabled = true;
            newFirstnameLabel.Enabled = true;
            newLastnameTxtbox.Enabled = true;
            newLastnameLabel.Enabled = true;
            newPasswordTxtbox.Enabled = true;
            newEmailLabel.Enabled = true;
            newEmailTxtbox.Enabled = true;
            newUserBtn.Enabled = true;

            newUsernamelabel.Visible = true;
            newUsernameTxtbox.Visible = true;
            newPasswordLabel.Visible = true;
            newFirstnameTxtbox.Visible = true;
            newFirstnameLabel.Visible = true;
            newLastnameLabel.Visible = true;
            newLastnameTxtbox.Visible = true;
            newLastnameLabel.Visible = true;
            newPasswordTxtbox.Visible = true;
            newEmailLabel.Visible = true;
            newEmailTxtbox.Visible = true;
            newUserBtn.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimesCheckedListBox.Visible = false;
            TimesCheckedListBox.Enabled = false;
            CreateUserInitBtn.Enabled = true;
            EditMeetingsBtn.Enabled = true;
            CreateUserRecipBtn.Enabled = true;
            button1.Enabled = true;
            button1.Visible = true;
            CreateUserInitBtn.Visible = true;
            EditMeetingsBtn.Visible = true;
            CreateUserRecipBtn.Visible = true;
            button3.Enabled = false;
            button3.Visible = false;
            publicBtn.Visible = false;
            publicBtn.Enabled = false;
            privateBtn.Visible = false;
            privateBtn.Enabled = false;
            createMeetingsNameLabel.Enabled = false;
            createMeetingsNameLabel.Visible = false;
            createMeetingsNameTxtBox.Visible = false;
            createMeetingsNameTxtBox.Enabled = false;
            createMeetingsNameBtn.Enabled = false;
            createMeetingsNameBtn.Visible = false;
            dateTimePicker.Visible = false;
            dateTimePicker.Enabled = false;
            UsersCheckedListBox.Enabled = false;
            UsersCheckedListBox.Visible = false;
            DatePickerbtn.Visible = false;
            DatePickerbtn.Enabled = false;
            label2.Enabled = false;
            label2.Visible = false;
            CheckedListBoxMeetingsList.Enabled = false;
            CheckedListBoxMeetingsList.Visible = false;
            UsersInMeetingTransferBtn.Enabled = false;
            UsersInMeetingTransferBtn.Visible = false;
            UsersCheckedListBoxUpdate.Visible = false;
            UsersCheckedListBoxUpdate.Enabled = false;
            UpdateRemovedUsersBtn.Enabled = false;
            UpdateRemovedUsersBtn.Visible = false;
            UpdateDateTimeBtn.Enabled = false;
            UpdateDateTimeBtn.Visible = false;
            meetingTimesListBox.Visible = false;
            meetingTimesListBox.Enabled = false;
            MeetingTimesListUpdateBtn.Enabled = false;
            MeetingTimesListUpdateBtn.Visible = false;
            dateTimePickerUpdate.Enabled = false;
            dateTimePickerUpdate.Visible = false;
            TimesCheckedListBoxUpdate.Enabled = false;
            TimesCheckedListBoxUpdate.Visible = false;
            UpdateTimesAndDataBtn.Enabled = false;
            UpdateTimesAndDataBtn.Visible = false;
            cancelAMeetingBtn.Enabled = false;
            cancelAMeetingBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Visible = false;
            ViewUsersPrefAndExclBtn.Enabled = false;
            PefenAndExclTimesBtn.Enabled = false;
            PefenAndExclTimesBtn.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            label3.Enabled = false;
            label3.Visible = false;
            PrefCheckedListBox.Visible = false;
            PrefCheckedListBox.Enabled = false;
            ExCheckedListBox.Visible = false;
            ExCheckedListBox.Enabled = false;
            PrefExclVaidateBtn.Enabled = false;
            PrefExclVaidateBtn.Visible = false;
        }
    }
    
}
