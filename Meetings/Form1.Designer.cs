namespace Meetings
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loginbtn = new System.Windows.Forms.Button();
            this.UserNameTxtbox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTxtbox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DatePickerbtn = new System.Windows.Forms.Button();
            this.newUsernamelabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newUsernameTxtbox = new System.Windows.Forms.TextBox();
            this.newPasswordTxtbox = new System.Windows.Forms.TextBox();
            this.newFirstnameTxtbox = new System.Windows.Forms.TextBox();
            this.newLastnameTxtbox = new System.Windows.Forms.TextBox();
            this.newEmailTxtbox = new System.Windows.Forms.TextBox();
            this.newFirstnameLabel = new System.Windows.Forms.Label();
            this.newLastnameLabel = new System.Windows.Forms.Label();
            this.newEmailLabel = new System.Windows.Forms.Label();
            this.newUserBtn = new System.Windows.Forms.Button();
            this.UsersCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.TimesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.createMeetingsNameBtn = new System.Windows.Forms.Button();
            this.createMeetingsNameLabel = new System.Windows.Forms.Label();
            this.createMeetingsNameTxtBox = new System.Windows.Forms.TextBox();
            this.publicBtn = new System.Windows.Forms.Button();
            this.privateBtn = new System.Windows.Forms.Button();
            this.cancelAMeetingBtn = new System.Windows.Forms.Button();
            this.UsersCheckedListBoxUpdate = new System.Windows.Forms.CheckedListBox();
            this.TimesCheckedListBoxUpdate = new System.Windows.Forms.CheckedListBox();
            this.dateTimePickerUpdate = new System.Windows.Forms.DateTimePicker();
            this.UsersInMeetingTransferBtn = new System.Windows.Forms.Button();
            this.UpdateDateTimeBtn = new System.Windows.Forms.Button();
            this.CheckedListBoxMeetingsList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateRemovedUsersBtn = new System.Windows.Forms.Button();
            this.UpdateTimesAndDataBtn = new System.Windows.Forms.Button();
            this.PefenAndExclTimesBtn = new System.Windows.Forms.Button();
            this.CreateUserInitBtn = new System.Windows.Forms.Button();
            this.CreateUserRecipBtn = new System.Windows.Forms.Button();
            this.EditMeetingsBtn = new System.Windows.Forms.Button();
            this.meetingTimesListBox = new System.Windows.Forms.CheckedListBox();
            this.MeetingTimesListUpdateBtn = new System.Windows.Forms.Button();
            this.ViewUsersPrefAndExclBtn = new System.Windows.Forms.Button();
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.PrefCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ExCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.PrefExclVaidateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(340, 458);
            this.Loginbtn.Margin = new System.Windows.Forms.Padding(6);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(432, 92);
            this.Loginbtn.TabIndex = 0;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // UserNameTxtbox
            // 
            this.UserNameTxtbox.Location = new System.Drawing.Point(466, 169);
            this.UserNameTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.UserNameTxtbox.Name = "UserNameTxtbox";
            this.UserNameTxtbox.Size = new System.Drawing.Size(196, 31);
            this.UserNameTxtbox.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(512, 62);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(119, 25);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "User Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(512, 265);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(106, 25);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTxtbox
            // 
            this.PasswordTxtbox.Location = new System.Drawing.Point(464, 329);
            this.PasswordTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.PasswordTxtbox.Name = "PasswordTxtbox";
            this.PasswordTxtbox.Size = new System.Drawing.Size(196, 31);
            this.PasswordTxtbox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "ddd/ MMM / yyyy   |   HH:mm";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(382, 602);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(256, 31);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            this.dateTimePicker.Visible = false;
            // 
            // DatePickerbtn
            // 
            this.DatePickerbtn.Enabled = false;
            this.DatePickerbtn.Location = new System.Drawing.Point(248, 965);
            this.DatePickerbtn.Margin = new System.Windows.Forms.Padding(6);
            this.DatePickerbtn.Name = "DatePickerbtn";
            this.DatePickerbtn.Size = new System.Drawing.Size(570, 188);
            this.DatePickerbtn.TabIndex = 6;
            this.DatePickerbtn.Text = "Set users in meetings and time and date of meeting";
            this.DatePickerbtn.UseVisualStyleBackColor = true;
            this.DatePickerbtn.Visible = false;
            this.DatePickerbtn.Click += new System.EventHandler(this.DatePickerbtn_Click);
            // 
            // newUsernamelabel
            // 
            this.newUsernamelabel.AutoSize = true;
            this.newUsernamelabel.Enabled = false;
            this.newUsernamelabel.Location = new System.Drawing.Point(462, 717);
            this.newUsernamelabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.newUsernamelabel.Name = "newUsernamelabel";
            this.newUsernamelabel.Size = new System.Drawing.Size(164, 25);
            this.newUsernamelabel.TabIndex = 7;
            this.newUsernamelabel.Text = "Enter username";
            this.newUsernamelabel.Visible = false;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Enabled = false;
            this.newPasswordLabel.Location = new System.Drawing.Point(470, 869);
            this.newPasswordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(164, 25);
            this.newPasswordLabel.TabIndex = 8;
            this.newPasswordLabel.Text = "Enter Firstname";
            this.newPasswordLabel.Visible = false;
            // 
            // newUsernameTxtbox
            // 
            this.newUsernameTxtbox.Enabled = false;
            this.newUsernameTxtbox.Location = new System.Drawing.Point(466, 787);
            this.newUsernameTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.newUsernameTxtbox.Name = "newUsernameTxtbox";
            this.newUsernameTxtbox.Size = new System.Drawing.Size(196, 31);
            this.newUsernameTxtbox.TabIndex = 9;
            this.newUsernameTxtbox.Visible = false;
            // 
            // newPasswordTxtbox
            // 
            this.newPasswordTxtbox.Enabled = false;
            this.newPasswordTxtbox.Location = new System.Drawing.Point(464, 1235);
            this.newPasswordTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.newPasswordTxtbox.Name = "newPasswordTxtbox";
            this.newPasswordTxtbox.Size = new System.Drawing.Size(196, 31);
            this.newPasswordTxtbox.TabIndex = 10;
            this.newPasswordTxtbox.Visible = false;
            // 
            // newFirstnameTxtbox
            // 
            this.newFirstnameTxtbox.Enabled = false;
            this.newFirstnameTxtbox.Location = new System.Drawing.Point(464, 938);
            this.newFirstnameTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.newFirstnameTxtbox.Name = "newFirstnameTxtbox";
            this.newFirstnameTxtbox.Size = new System.Drawing.Size(196, 31);
            this.newFirstnameTxtbox.TabIndex = 11;
            this.newFirstnameTxtbox.Visible = false;
            // 
            // newLastnameTxtbox
            // 
            this.newLastnameTxtbox.Enabled = false;
            this.newLastnameTxtbox.Location = new System.Drawing.Point(464, 1092);
            this.newLastnameTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.newLastnameTxtbox.Name = "newLastnameTxtbox";
            this.newLastnameTxtbox.Size = new System.Drawing.Size(196, 31);
            this.newLastnameTxtbox.TabIndex = 12;
            this.newLastnameTxtbox.Visible = false;
            // 
            // newEmailTxtbox
            // 
            this.newEmailTxtbox.Enabled = false;
            this.newEmailTxtbox.Location = new System.Drawing.Point(466, 1371);
            this.newEmailTxtbox.Margin = new System.Windows.Forms.Padding(6);
            this.newEmailTxtbox.Name = "newEmailTxtbox";
            this.newEmailTxtbox.Size = new System.Drawing.Size(196, 31);
            this.newEmailTxtbox.TabIndex = 13;
            this.newEmailTxtbox.Visible = false;
            // 
            // newFirstnameLabel
            // 
            this.newFirstnameLabel.AutoSize = true;
            this.newFirstnameLabel.Enabled = false;
            this.newFirstnameLabel.Location = new System.Drawing.Point(470, 1015);
            this.newFirstnameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.newFirstnameLabel.Name = "newFirstnameLabel";
            this.newFirstnameLabel.Size = new System.Drawing.Size(163, 25);
            this.newFirstnameLabel.TabIndex = 14;
            this.newFirstnameLabel.Text = "Enter Lastname";
            this.newFirstnameLabel.Visible = false;
            // 
            // newLastnameLabel
            // 
            this.newLastnameLabel.AutoSize = true;
            this.newLastnameLabel.Enabled = false;
            this.newLastnameLabel.Location = new System.Drawing.Point(480, 1185);
            this.newLastnameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.newLastnameLabel.Name = "newLastnameLabel";
            this.newLastnameLabel.Size = new System.Drawing.Size(163, 25);
            this.newLastnameLabel.TabIndex = 15;
            this.newLastnameLabel.Text = "Enter Password";
            this.newLastnameLabel.Visible = false;
            // 
            // newEmailLabel
            // 
            this.newEmailLabel.AutoSize = true;
            this.newEmailLabel.Enabled = false;
            this.newEmailLabel.Location = new System.Drawing.Point(498, 1335);
            this.newEmailLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.newEmailLabel.Name = "newEmailLabel";
            this.newEmailLabel.Size = new System.Drawing.Size(122, 25);
            this.newEmailLabel.TabIndex = 16;
            this.newEmailLabel.Text = "Enter Email";
            this.newEmailLabel.Visible = false;
            // 
            // newUserBtn
            // 
            this.newUserBtn.Enabled = false;
            this.newUserBtn.Location = new System.Drawing.Point(340, 1419);
            this.newUserBtn.Margin = new System.Windows.Forms.Padding(6);
            this.newUserBtn.Name = "newUserBtn";
            this.newUserBtn.Size = new System.Drawing.Size(432, 102);
            this.newUserBtn.TabIndex = 17;
            this.newUserBtn.Text = "Create a new user";
            this.newUserBtn.UseVisualStyleBackColor = true;
            this.newUserBtn.Visible = false;
            this.newUserBtn.Click += new System.EventHandler(this.NewUserBtn_Click);
            // 
            // UsersCheckedListBox
            // 
            this.UsersCheckedListBox.Enabled = false;
            this.UsersCheckedListBox.FormattingEnabled = true;
            this.UsersCheckedListBox.Location = new System.Drawing.Point(194, 683);
            this.UsersCheckedListBox.Margin = new System.Windows.Forms.Padding(6);
            this.UsersCheckedListBox.Name = "UsersCheckedListBox";
            this.UsersCheckedListBox.Size = new System.Drawing.Size(268, 212);
            this.UsersCheckedListBox.TabIndex = 18;
            this.UsersCheckedListBox.Visible = false;
            // 
            // TimesCheckedListBox
            // 
            this.TimesCheckedListBox.Enabled = false;
            this.TimesCheckedListBox.FormattingEnabled = true;
            this.TimesCheckedListBox.Location = new System.Drawing.Point(640, 683);
            this.TimesCheckedListBox.Margin = new System.Windows.Forms.Padding(6);
            this.TimesCheckedListBox.Name = "TimesCheckedListBox";
            this.TimesCheckedListBox.Size = new System.Drawing.Size(264, 212);
            this.TimesCheckedListBox.TabIndex = 19;
            this.TimesCheckedListBox.Visible = false;
            // 
            // createMeetingsNameBtn
            // 
            this.createMeetingsNameBtn.Enabled = false;
            this.createMeetingsNameBtn.Location = new System.Drawing.Point(426, 506);
            this.createMeetingsNameBtn.Margin = new System.Windows.Forms.Padding(6);
            this.createMeetingsNameBtn.Name = "createMeetingsNameBtn";
            this.createMeetingsNameBtn.Size = new System.Drawing.Size(284, 75);
            this.createMeetingsNameBtn.TabIndex = 20;
            this.createMeetingsNameBtn.Text = "Create Meetings Name";
            this.createMeetingsNameBtn.UseVisualStyleBackColor = true;
            this.createMeetingsNameBtn.Visible = false;
            this.createMeetingsNameBtn.Click += new System.EventHandler(this.CreateMeetingsNameBtn_Click);
            // 
            // createMeetingsNameLabel
            // 
            this.createMeetingsNameLabel.AutoSize = true;
            this.createMeetingsNameLabel.Enabled = false;
            this.createMeetingsNameLabel.Location = new System.Drawing.Point(436, 329);
            this.createMeetingsNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.createMeetingsNameLabel.Name = "createMeetingsNameLabel";
            this.createMeetingsNameLabel.Size = new System.Drawing.Size(235, 25);
            this.createMeetingsNameLabel.TabIndex = 21;
            this.createMeetingsNameLabel.Text = "Create a meeting name";
            this.createMeetingsNameLabel.Visible = false;
            // 
            // createMeetingsNameTxtBox
            // 
            this.createMeetingsNameTxtBox.Enabled = false;
            this.createMeetingsNameTxtBox.Location = new System.Drawing.Point(464, 437);
            this.createMeetingsNameTxtBox.Margin = new System.Windows.Forms.Padding(6);
            this.createMeetingsNameTxtBox.Name = "createMeetingsNameTxtBox";
            this.createMeetingsNameTxtBox.Size = new System.Drawing.Size(196, 31);
            this.createMeetingsNameTxtBox.TabIndex = 22;
            this.createMeetingsNameTxtBox.Visible = false;
            // 
            // publicBtn
            // 
            this.publicBtn.Enabled = false;
            this.publicBtn.Location = new System.Drawing.Point(170, 154);
            this.publicBtn.Margin = new System.Windows.Forms.Padding(6);
            this.publicBtn.Name = "publicBtn";
            this.publicBtn.Size = new System.Drawing.Size(242, 75);
            this.publicBtn.TabIndex = 23;
            this.publicBtn.Text = "Public meetings";
            this.publicBtn.UseVisualStyleBackColor = true;
            this.publicBtn.Visible = false;
            this.publicBtn.Click += new System.EventHandler(this.PublicBtn_Click);
            // 
            // privateBtn
            // 
            this.privateBtn.Enabled = false;
            this.privateBtn.Location = new System.Drawing.Point(678, 154);
            this.privateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.privateBtn.Name = "privateBtn";
            this.privateBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.privateBtn.Size = new System.Drawing.Size(224, 75);
            this.privateBtn.TabIndex = 24;
            this.privateBtn.Text = "Privite Meetings";
            this.privateBtn.UseVisualStyleBackColor = true;
            this.privateBtn.Visible = false;
            this.privateBtn.Click += new System.EventHandler(this.PrivateBtn_Click);
            // 
            // cancelAMeetingBtn
            // 
            this.cancelAMeetingBtn.Enabled = false;
            this.cancelAMeetingBtn.Location = new System.Drawing.Point(678, 548);
            this.cancelAMeetingBtn.Margin = new System.Windows.Forms.Padding(6);
            this.cancelAMeetingBtn.Name = "cancelAMeetingBtn";
            this.cancelAMeetingBtn.Size = new System.Drawing.Size(210, 75);
            this.cancelAMeetingBtn.TabIndex = 27;
            this.cancelAMeetingBtn.Text = "Cancel a meeting";
            this.cancelAMeetingBtn.UseVisualStyleBackColor = true;
            this.cancelAMeetingBtn.Visible = false;
            this.cancelAMeetingBtn.Click += new System.EventHandler(this.CancelAMeetingBtn_Click);
            // 
            // UsersCheckedListBoxUpdate
            // 
            this.UsersCheckedListBoxUpdate.Enabled = false;
            this.UsersCheckedListBoxUpdate.FormattingEnabled = true;
            this.UsersCheckedListBoxUpdate.Location = new System.Drawing.Point(198, 683);
            this.UsersCheckedListBoxUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.UsersCheckedListBoxUpdate.Name = "UsersCheckedListBoxUpdate";
            this.UsersCheckedListBoxUpdate.Size = new System.Drawing.Size(236, 160);
            this.UsersCheckedListBoxUpdate.TabIndex = 28;
            this.UsersCheckedListBoxUpdate.Visible = false;
            // 
            // TimesCheckedListBoxUpdate
            // 
            this.TimesCheckedListBoxUpdate.CheckOnClick = true;
            this.TimesCheckedListBoxUpdate.Enabled = false;
            this.TimesCheckedListBoxUpdate.FormattingEnabled = true;
            this.TimesCheckedListBoxUpdate.Location = new System.Drawing.Point(432, 1092);
            this.TimesCheckedListBoxUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.TimesCheckedListBoxUpdate.Name = "TimesCheckedListBoxUpdate";
            this.TimesCheckedListBoxUpdate.Size = new System.Drawing.Size(236, 160);
            this.TimesCheckedListBoxUpdate.TabIndex = 29;
            this.TimesCheckedListBoxUpdate.Visible = false;
            // 
            // dateTimePickerUpdate
            // 
            this.dateTimePickerUpdate.CustomFormat = "ddd/ MMM / yyyy   |   HH:mm";
            this.dateTimePickerUpdate.Enabled = false;
            this.dateTimePickerUpdate.Location = new System.Drawing.Point(340, 1015);
            this.dateTimePickerUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePickerUpdate.Name = "dateTimePickerUpdate";
            this.dateTimePickerUpdate.Size = new System.Drawing.Size(396, 31);
            this.dateTimePickerUpdate.TabIndex = 30;
            this.dateTimePickerUpdate.Visible = false;
            // 
            // UsersInMeetingTransferBtn
            // 
            this.UsersInMeetingTransferBtn.Enabled = false;
            this.UsersInMeetingTransferBtn.Location = new System.Drawing.Point(172, 548);
            this.UsersInMeetingTransferBtn.Margin = new System.Windows.Forms.Padding(6);
            this.UsersInMeetingTransferBtn.Name = "UsersInMeetingTransferBtn";
            this.UsersInMeetingTransferBtn.Size = new System.Drawing.Size(202, 67);
            this.UsersInMeetingTransferBtn.TabIndex = 31;
            this.UsersInMeetingTransferBtn.Text = "Remove a user from a meeting";
            this.UsersInMeetingTransferBtn.UseVisualStyleBackColor = true;
            this.UsersInMeetingTransferBtn.Visible = false;
            this.UsersInMeetingTransferBtn.Click += new System.EventHandler(this.UpdateUsersInMeetingBtn_Click);
            // 
            // UpdateDateTimeBtn
            // 
            this.UpdateDateTimeBtn.Location = new System.Drawing.Point(386, 548);
            this.UpdateDateTimeBtn.Margin = new System.Windows.Forms.Padding(6);
            this.UpdateDateTimeBtn.Name = "UpdateDateTimeBtn";
            this.UpdateDateTimeBtn.Size = new System.Drawing.Size(264, 102);
            this.UpdateDateTimeBtn.TabIndex = 32;
            this.UpdateDateTimeBtn.Text = "Change the date or time of a meeting";
            this.UpdateDateTimeBtn.UseVisualStyleBackColor = true;
            this.UpdateDateTimeBtn.Visible = false;
            this.UpdateDateTimeBtn.Click += new System.EventHandler(this.UpdateDateTimeBtn_Click);
            // 
            // CheckedListBoxMeetingsList
            // 
            this.CheckedListBoxMeetingsList.Enabled = false;
            this.CheckedListBoxMeetingsList.FormattingEnabled = true;
            this.CheckedListBoxMeetingsList.Location = new System.Drawing.Point(464, 244);
            this.CheckedListBoxMeetingsList.Margin = new System.Windows.Forms.Padding(6);
            this.CheckedListBoxMeetingsList.Name = "CheckedListBoxMeetingsList";
            this.CheckedListBoxMeetingsList.Size = new System.Drawing.Size(236, 160);
            this.CheckedListBoxMeetingsList.TabIndex = 33;
            this.CheckedListBoxMeetingsList.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(476, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "All your meetings";
            this.label2.Visible = false;
            // 
            // UpdateRemovedUsersBtn
            // 
            this.UpdateRemovedUsersBtn.Enabled = false;
            this.UpdateRemovedUsersBtn.Location = new System.Drawing.Point(192, 890);
            this.UpdateRemovedUsersBtn.Margin = new System.Windows.Forms.Padding(6);
            this.UpdateRemovedUsersBtn.Name = "UpdateRemovedUsersBtn";
            this.UpdateRemovedUsersBtn.Size = new System.Drawing.Size(206, 87);
            this.UpdateRemovedUsersBtn.TabIndex = 37;
            this.UpdateRemovedUsersBtn.Text = "Update removed users from meeting";
            this.UpdateRemovedUsersBtn.UseVisualStyleBackColor = true;
            this.UpdateRemovedUsersBtn.Visible = false;
            this.UpdateRemovedUsersBtn.Click += new System.EventHandler(this.UpdateRemovedUsersBtn_Click);
            // 
            // UpdateTimesAndDataBtn
            // 
            this.UpdateTimesAndDataBtn.Enabled = false;
            this.UpdateTimesAndDataBtn.Location = new System.Drawing.Point(440, 1285);
            this.UpdateTimesAndDataBtn.Margin = new System.Windows.Forms.Padding(6);
            this.UpdateTimesAndDataBtn.Name = "UpdateTimesAndDataBtn";
            this.UpdateTimesAndDataBtn.Size = new System.Drawing.Size(224, 75);
            this.UpdateTimesAndDataBtn.TabIndex = 38;
            this.UpdateTimesAndDataBtn.Text = "Update times and data off meetings";
            this.UpdateTimesAndDataBtn.UseVisualStyleBackColor = true;
            this.UpdateTimesAndDataBtn.Visible = false;
            this.UpdateTimesAndDataBtn.Click += new System.EventHandler(this.UpdateTimesAndDataBtn_Click);
            // 
            // PefenAndExclTimesBtn
            // 
            this.PefenAndExclTimesBtn.Enabled = false;
            this.PefenAndExclTimesBtn.Location = new System.Drawing.Point(306, 552);
            this.PefenAndExclTimesBtn.Margin = new System.Windows.Forms.Padding(6);
            this.PefenAndExclTimesBtn.Name = "PefenAndExclTimesBtn";
            this.PefenAndExclTimesBtn.Size = new System.Drawing.Size(258, 141);
            this.PefenAndExclTimesBtn.TabIndex = 40;
            this.PefenAndExclTimesBtn.Text = "Prefernce and exclusion times";
            this.PefenAndExclTimesBtn.UseVisualStyleBackColor = true;
            this.PefenAndExclTimesBtn.Visible = false;
            this.PefenAndExclTimesBtn.Click += new System.EventHandler(this.PefenAndExclTimesBtn_Click);
            // 
            // CreateUserInitBtn
            // 
            this.CreateUserInitBtn.Enabled = false;
            this.CreateUserInitBtn.Location = new System.Drawing.Point(-6, 4);
            this.CreateUserInitBtn.Margin = new System.Windows.Forms.Padding(6);
            this.CreateUserInitBtn.Name = "CreateUserInitBtn";
            this.CreateUserInitBtn.Size = new System.Drawing.Size(208, 138);
            this.CreateUserInitBtn.TabIndex = 41;
            this.CreateUserInitBtn.Text = "Create some meetings";
            this.CreateUserInitBtn.UseVisualStyleBackColor = true;
            this.CreateUserInitBtn.Visible = false;
            this.CreateUserInitBtn.Click += new System.EventHandler(this.CreateUserInitBtn_Click);
            // 
            // CreateUserRecipBtn
            // 
            this.CreateUserRecipBtn.Enabled = false;
            this.CreateUserRecipBtn.Location = new System.Drawing.Point(678, 4);
            this.CreateUserRecipBtn.Margin = new System.Windows.Forms.Padding(6);
            this.CreateUserRecipBtn.Name = "CreateUserRecipBtn";
            this.CreateUserRecipBtn.Size = new System.Drawing.Size(224, 138);
            this.CreateUserRecipBtn.TabIndex = 42;
            this.CreateUserRecipBtn.Text = "View meeting you set";
            this.CreateUserRecipBtn.UseVisualStyleBackColor = true;
            this.CreateUserRecipBtn.Visible = false;
            this.CreateUserRecipBtn.Click += new System.EventHandler(this.CreateUserRecipBtn_Click);
            // 
            // EditMeetingsBtn
            // 
            this.EditMeetingsBtn.Enabled = false;
            this.EditMeetingsBtn.Location = new System.Drawing.Point(220, 4);
            this.EditMeetingsBtn.Margin = new System.Windows.Forms.Padding(6);
            this.EditMeetingsBtn.Name = "EditMeetingsBtn";
            this.EditMeetingsBtn.Size = new System.Drawing.Size(218, 138);
            this.EditMeetingsBtn.TabIndex = 43;
            this.EditMeetingsBtn.Text = "Edit some set meetings";
            this.EditMeetingsBtn.UseVisualStyleBackColor = true;
            this.EditMeetingsBtn.Visible = false;
            this.EditMeetingsBtn.Click += new System.EventHandler(this.EditMeetingsBtn_Click);
            // 
            // meetingTimesListBox
            // 
            this.meetingTimesListBox.Enabled = false;
            this.meetingTimesListBox.FormattingEnabled = true;
            this.meetingTimesListBox.Location = new System.Drawing.Point(478, 683);
            this.meetingTimesListBox.Margin = new System.Windows.Forms.Padding(6);
            this.meetingTimesListBox.Name = "meetingTimesListBox";
            this.meetingTimesListBox.Size = new System.Drawing.Size(236, 160);
            this.meetingTimesListBox.TabIndex = 44;
            this.meetingTimesListBox.Visible = false;
            // 
            // MeetingTimesListUpdateBtn
            // 
            this.MeetingTimesListUpdateBtn.Enabled = false;
            this.MeetingTimesListUpdateBtn.Location = new System.Drawing.Point(444, 875);
            this.MeetingTimesListUpdateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.MeetingTimesListUpdateBtn.Name = "MeetingTimesListUpdateBtn";
            this.MeetingTimesListUpdateBtn.Size = new System.Drawing.Size(218, 117);
            this.MeetingTimesListUpdateBtn.TabIndex = 45;
            this.MeetingTimesListUpdateBtn.Text = "Pick the meetings you want to change";
            this.MeetingTimesListUpdateBtn.UseVisualStyleBackColor = true;
            this.MeetingTimesListUpdateBtn.Visible = false;
            this.MeetingTimesListUpdateBtn.Click += new System.EventHandler(this.MeetingTimesListUpdateBtn_Click);
            // 
            // ViewUsersPrefAndExclBtn
            // 
            this.ViewUsersPrefAndExclBtn.Enabled = false;
            this.ViewUsersPrefAndExclBtn.Location = new System.Drawing.Point(452, 552);
            this.ViewUsersPrefAndExclBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ViewUsersPrefAndExclBtn.Name = "ViewUsersPrefAndExclBtn";
            this.ViewUsersPrefAndExclBtn.Size = new System.Drawing.Size(232, 146);
            this.ViewUsersPrefAndExclBtn.TabIndex = 46;
            this.ViewUsersPrefAndExclBtn.Text = "View all the preference and excusions of users in the meeting";
            this.ViewUsersPrefAndExclBtn.UseVisualStyleBackColor = true;
            this.ViewUsersPrefAndExclBtn.Visible = false;
            this.ViewUsersPrefAndExclBtn.Click += new System.EventHandler(this.ViewUsersPrefAndExclBtn_Click);
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Enabled = false;
            this.Logoutbtn.Location = new System.Drawing.Point(914, 4);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(6);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(330, 125);
            this.Logoutbtn.TabIndex = 47;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Visible = false;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // PrefCheckedListBox
            // 
            this.PrefCheckedListBox.CheckOnClick = true;
            this.PrefCheckedListBox.Enabled = false;
            this.PrefCheckedListBox.FormattingEnabled = true;
            this.PrefCheckedListBox.Location = new System.Drawing.Point(198, 812);
            this.PrefCheckedListBox.Margin = new System.Windows.Forms.Padding(6);
            this.PrefCheckedListBox.Name = "PrefCheckedListBox";
            this.PrefCheckedListBox.Size = new System.Drawing.Size(236, 160);
            this.PrefCheckedListBox.TabIndex = 48;
            this.PrefCheckedListBox.Visible = false;
            // 
            // ExCheckedListBox
            // 
            this.ExCheckedListBox.CheckOnClick = true;
            this.ExCheckedListBox.Enabled = false;
            this.ExCheckedListBox.FormattingEnabled = true;
            this.ExCheckedListBox.Location = new System.Drawing.Point(654, 812);
            this.ExCheckedListBox.Margin = new System.Windows.Forms.Padding(6);
            this.ExCheckedListBox.Name = "ExCheckedListBox";
            this.ExCheckedListBox.Size = new System.Drawing.Size(236, 160);
            this.ExCheckedListBox.TabIndex = 49;
            this.ExCheckedListBox.Visible = false;
            // 
            // PrefExclVaidateBtn
            // 
            this.PrefExclVaidateBtn.Enabled = false;
            this.PrefExclVaidateBtn.Location = new System.Drawing.Point(434, 1092);
            this.PrefExclVaidateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.PrefExclVaidateBtn.Name = "PrefExclVaidateBtn";
            this.PrefExclVaidateBtn.Size = new System.Drawing.Size(240, 117);
            this.PrefExclVaidateBtn.TabIndex = 50;
            this.PrefExclVaidateBtn.Text = "Vaidate your meeting times";
            this.PrefExclVaidateBtn.UseVisualStyleBackColor = true;
            this.PrefExclVaidateBtn.Visible = false;
            this.PrefExclVaidateBtn.Click += new System.EventHandler(this.PrefExclVaidateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(176, 752);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 51;
            this.label1.Text = "Preference times";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(672, 752);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Exclusion times";
            this.label3.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(468, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 138);
            this.button1.TabIndex = 53;
            this.button1.Text = "Respond to meetings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 569);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(432, 112);
            this.button2.TabIndex = 54;
            this.button2.Text = "New user";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(6, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(332, 125);
            this.button3.TabIndex = 55;
            this.button3.Text = "Back to menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(640, 552);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(269, 136);
            this.button4.TabIndex = 56;
            this.button4.Text = "Drop out of meeting";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1254, 1542);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.CreateUserRecipBtn);
            this.Controls.Add(this.CreateUserInitBtn);
            this.Controls.Add(this.UpdateTimesAndDataBtn);
            this.Controls.Add(this.UpdateRemovedUsersBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsersInMeetingTransferBtn);
            this.Controls.Add(this.UsersCheckedListBoxUpdate);
            this.Controls.Add(this.cancelAMeetingBtn);
            this.Controls.Add(this.privateBtn);
            this.Controls.Add(this.publicBtn);
            this.Controls.Add(this.createMeetingsNameTxtBox);
            this.Controls.Add(this.createMeetingsNameLabel);
            this.Controls.Add(this.createMeetingsNameBtn);
            this.Controls.Add(this.UsersCheckedListBox);
            this.Controls.Add(this.newUserBtn);
            this.Controls.Add(this.newEmailLabel);
            this.Controls.Add(this.newLastnameLabel);
            this.Controls.Add(this.newFirstnameLabel);
            this.Controls.Add(this.newEmailTxtbox);
            this.Controls.Add(this.newLastnameTxtbox);
            this.Controls.Add(this.newFirstnameTxtbox);
            this.Controls.Add(this.newPasswordTxtbox);
            this.Controls.Add(this.newUsernameTxtbox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.newUsernamelabel);
            this.Controls.Add(this.PasswordTxtbox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserNameTxtbox);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EditMeetingsBtn);
            this.Controls.Add(this.dateTimePickerUpdate);
            this.Controls.Add(this.MeetingTimesListUpdateBtn);
            this.Controls.Add(this.PrefExclVaidateBtn);
            this.Controls.Add(this.TimesCheckedListBoxUpdate);
            this.Controls.Add(this.DatePickerbtn);
            this.Controls.Add(this.PrefCheckedListBox);
            this.Controls.Add(this.TimesCheckedListBox);
            this.Controls.Add(this.ExCheckedListBox);
            this.Controls.Add(this.meetingTimesListBox);
            this.Controls.Add(this.CheckedListBoxMeetingsList);
            this.Controls.Add(this.PefenAndExclTimesBtn);
            this.Controls.Add(this.UpdateDateTimeBtn);
            this.Controls.Add(this.ViewUsersPrefAndExclBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.TextBox UserNameTxtbox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTxtbox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button DatePickerbtn;
        private System.Windows.Forms.Label newUsernamelabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox newUsernameTxtbox;
        private System.Windows.Forms.TextBox newPasswordTxtbox;
        private System.Windows.Forms.TextBox newFirstnameTxtbox;
        private System.Windows.Forms.TextBox newLastnameTxtbox;
        private System.Windows.Forms.TextBox newEmailTxtbox;
        private System.Windows.Forms.Label newFirstnameLabel;
        private System.Windows.Forms.Label newLastnameLabel;
        private System.Windows.Forms.Label newEmailLabel;
        private System.Windows.Forms.Button newUserBtn;
        private System.Windows.Forms.CheckedListBox UsersCheckedListBox;
        private System.Windows.Forms.CheckedListBox TimesCheckedListBox;
        private System.Windows.Forms.Button createMeetingsNameBtn;
        private System.Windows.Forms.Label createMeetingsNameLabel;
        private System.Windows.Forms.TextBox createMeetingsNameTxtBox;
        private System.Windows.Forms.Button publicBtn;
        private System.Windows.Forms.Button privateBtn;
        private System.Windows.Forms.Button cancelAMeetingBtn;
        private System.Windows.Forms.CheckedListBox UsersCheckedListBoxUpdate;
        private System.Windows.Forms.CheckedListBox TimesCheckedListBoxUpdate;
        private System.Windows.Forms.DateTimePicker dateTimePickerUpdate;
        private System.Windows.Forms.Button UsersInMeetingTransferBtn;
        private System.Windows.Forms.Button UpdateDateTimeBtn;
        private System.Windows.Forms.CheckedListBox CheckedListBoxMeetingsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateRemovedUsersBtn;
        private System.Windows.Forms.Button UpdateTimesAndDataBtn;
        private System.Windows.Forms.Button PefenAndExclTimesBtn;
        private System.Windows.Forms.Button CreateUserInitBtn;
        private System.Windows.Forms.Button CreateUserRecipBtn;
        private System.Windows.Forms.Button EditMeetingsBtn;
        private System.Windows.Forms.CheckedListBox meetingTimesListBox;
        private System.Windows.Forms.Button MeetingTimesListUpdateBtn;
        private System.Windows.Forms.Button ViewUsersPrefAndExclBtn;
        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.CheckedListBox PrefCheckedListBox;
        private System.Windows.Forms.CheckedListBox ExCheckedListBox;
        private System.Windows.Forms.Button PrefExclVaidateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

