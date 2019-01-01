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
            this.MeetingsListBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateRemovedUsersBtn = new System.Windows.Forms.Button();
            this.UpdateTimesAndDataBtn = new System.Windows.Forms.Button();
            this.RemoveSelfMeetingBtn = new System.Windows.Forms.Button();
            this.PefenAndExclTimesBtn = new System.Windows.Forms.Button();
            this.CreateUserInitBtn = new System.Windows.Forms.Button();
            this.CreateUserRecipBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(34, 198);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(216, 48);
            this.Loginbtn.TabIndex = 0;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // UserNameTxtbox
            // 
            this.UserNameTxtbox.Location = new System.Drawing.Point(94, 72);
            this.UserNameTxtbox.Name = "UserNameTxtbox";
            this.UserNameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.UserNameTxtbox.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(115, 38);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(60, 13);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "User Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(115, 114);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordTxtbox
            // 
            this.PasswordTxtbox.Location = new System.Drawing.Point(93, 148);
            this.PasswordTxtbox.Name = "PasswordTxtbox";
            this.PasswordTxtbox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTxtbox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "ddd/ MMM / yyyy   |   HH:mm";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(419, 427);
            this.dateTimePicker.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            // 
            // DatePickerbtn
            // 
            this.DatePickerbtn.Location = new System.Drawing.Point(328, 617);
            this.DatePickerbtn.Name = "DatePickerbtn";
            this.DatePickerbtn.Size = new System.Drawing.Size(285, 98);
            this.DatePickerbtn.TabIndex = 6;
            this.DatePickerbtn.Text = "Set users in meetings and time and date of meeting";
            this.DatePickerbtn.UseVisualStyleBackColor = true;
            this.DatePickerbtn.Click += new System.EventHandler(this.DatePickerbtn_Click);
            // 
            // newUsernamelabel
            // 
            this.newUsernamelabel.AutoSize = true;
            this.newUsernamelabel.Location = new System.Drawing.Point(103, 277);
            this.newUsernamelabel.Name = "newUsernamelabel";
            this.newUsernamelabel.Size = new System.Drawing.Size(81, 13);
            this.newUsernamelabel.TabIndex = 7;
            this.newUsernamelabel.Text = "Enter username";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(103, 366);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(80, 13);
            this.newPasswordLabel.TabIndex = 8;
            this.newPasswordLabel.Text = "Enter Firstname";
            // 
            // newUsernameTxtbox
            // 
            this.newUsernameTxtbox.Location = new System.Drawing.Point(92, 319);
            this.newUsernameTxtbox.Name = "newUsernameTxtbox";
            this.newUsernameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newUsernameTxtbox.TabIndex = 9;
            // 
            // newPasswordTxtbox
            // 
            this.newPasswordTxtbox.Location = new System.Drawing.Point(92, 555);
            this.newPasswordTxtbox.Name = "newPasswordTxtbox";
            this.newPasswordTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordTxtbox.TabIndex = 10;
            // 
            // newFirstnameTxtbox
            // 
            this.newFirstnameTxtbox.Location = new System.Drawing.Point(94, 399);
            this.newFirstnameTxtbox.Name = "newFirstnameTxtbox";
            this.newFirstnameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newFirstnameTxtbox.TabIndex = 11;
            // 
            // newLastnameTxtbox
            // 
            this.newLastnameTxtbox.Location = new System.Drawing.Point(94, 475);
            this.newLastnameTxtbox.Name = "newLastnameTxtbox";
            this.newLastnameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newLastnameTxtbox.TabIndex = 12;
            // 
            // newEmailTxtbox
            // 
            this.newEmailTxtbox.Location = new System.Drawing.Point(93, 632);
            this.newEmailTxtbox.Name = "newEmailTxtbox";
            this.newEmailTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newEmailTxtbox.TabIndex = 13;
            // 
            // newFirstnameLabel
            // 
            this.newFirstnameLabel.AutoSize = true;
            this.newFirstnameLabel.Location = new System.Drawing.Point(102, 433);
            this.newFirstnameLabel.Name = "newFirstnameLabel";
            this.newFirstnameLabel.Size = new System.Drawing.Size(81, 13);
            this.newFirstnameLabel.TabIndex = 14;
            this.newFirstnameLabel.Text = "Enter Lastname";
            // 
            // newLastnameLabel
            // 
            this.newLastnameLabel.AutoSize = true;
            this.newLastnameLabel.Location = new System.Drawing.Point(103, 514);
            this.newLastnameLabel.Name = "newLastnameLabel";
            this.newLastnameLabel.Size = new System.Drawing.Size(81, 13);
            this.newLastnameLabel.TabIndex = 15;
            this.newLastnameLabel.Text = "Enter Password";
            // 
            // newEmailLabel
            // 
            this.newEmailLabel.AutoSize = true;
            this.newEmailLabel.Location = new System.Drawing.Point(115, 595);
            this.newEmailLabel.Name = "newEmailLabel";
            this.newEmailLabel.Size = new System.Drawing.Size(60, 13);
            this.newEmailLabel.TabIndex = 16;
            this.newEmailLabel.Text = "Enter Email";
            // 
            // newUserBtn
            // 
            this.newUserBtn.Location = new System.Drawing.Point(34, 671);
            this.newUserBtn.Name = "newUserBtn";
            this.newUserBtn.Size = new System.Drawing.Size(216, 53);
            this.newUserBtn.TabIndex = 17;
            this.newUserBtn.Text = "Create a new user";
            this.newUserBtn.UseVisualStyleBackColor = true;
            this.newUserBtn.Click += new System.EventHandler(this.NewUserBtn_Click);
            // 
            // UsersCheckedListBox
            // 
            this.UsersCheckedListBox.FormattingEnabled = true;
            this.UsersCheckedListBox.Location = new System.Drawing.Point(312, 475);
            this.UsersCheckedListBox.Name = "UsersCheckedListBox";
            this.UsersCheckedListBox.Size = new System.Drawing.Size(136, 124);
            this.UsersCheckedListBox.TabIndex = 18;
            // 
            // TimesCheckedListBox
            // 
            this.TimesCheckedListBox.FormattingEnabled = true;
            this.TimesCheckedListBox.Location = new System.Drawing.Point(501, 475);
            this.TimesCheckedListBox.Name = "TimesCheckedListBox";
            this.TimesCheckedListBox.Size = new System.Drawing.Size(134, 124);
            this.TimesCheckedListBox.TabIndex = 19;
            // 
            // createMeetingsNameBtn
            // 
            this.createMeetingsNameBtn.Location = new System.Drawing.Point(407, 340);
            this.createMeetingsNameBtn.Name = "createMeetingsNameBtn";
            this.createMeetingsNameBtn.Size = new System.Drawing.Size(142, 39);
            this.createMeetingsNameBtn.TabIndex = 20;
            this.createMeetingsNameBtn.Text = "Create Meetings Name";
            this.createMeetingsNameBtn.UseVisualStyleBackColor = true;
            this.createMeetingsNameBtn.Click += new System.EventHandler(this.CreateMeetingsNameBtn_Click);
            // 
            // createMeetingsNameLabel
            // 
            this.createMeetingsNameLabel.AutoSize = true;
            this.createMeetingsNameLabel.Location = new System.Drawing.Point(416, 235);
            this.createMeetingsNameLabel.Name = "createMeetingsNameLabel";
            this.createMeetingsNameLabel.Size = new System.Drawing.Size(116, 13);
            this.createMeetingsNameLabel.TabIndex = 21;
            this.createMeetingsNameLabel.Text = "Create a meeting name";
            // 
            // createMeetingsNameTxtBox
            // 
            this.createMeetingsNameTxtBox.Location = new System.Drawing.Point(432, 289);
            this.createMeetingsNameTxtBox.Name = "createMeetingsNameTxtBox";
            this.createMeetingsNameTxtBox.Size = new System.Drawing.Size(100, 20);
            this.createMeetingsNameTxtBox.TabIndex = 22;
            // 
            // publicBtn
            // 
            this.publicBtn.Location = new System.Drawing.Point(328, 152);
            this.publicBtn.Name = "publicBtn";
            this.publicBtn.Size = new System.Drawing.Size(121, 39);
            this.publicBtn.TabIndex = 23;
            this.publicBtn.Text = "Public meetings";
            this.publicBtn.UseVisualStyleBackColor = true;
            this.publicBtn.Click += new System.EventHandler(this.PublicBtn_Click);
            // 
            // privateBtn
            // 
            this.privateBtn.Location = new System.Drawing.Point(501, 155);
            this.privateBtn.Name = "privateBtn";
            this.privateBtn.Size = new System.Drawing.Size(112, 39);
            this.privateBtn.TabIndex = 24;
            this.privateBtn.Text = "Privite Meetings";
            this.privateBtn.UseVisualStyleBackColor = true;
            this.privateBtn.Click += new System.EventHandler(this.PrivateBtn_Click);
            // 
            // cancelAMeetingBtn
            // 
            this.cancelAMeetingBtn.Location = new System.Drawing.Point(1086, 209);
            this.cancelAMeetingBtn.Name = "cancelAMeetingBtn";
            this.cancelAMeetingBtn.Size = new System.Drawing.Size(105, 39);
            this.cancelAMeetingBtn.TabIndex = 27;
            this.cancelAMeetingBtn.Text = "Cancel a meeting";
            this.cancelAMeetingBtn.UseVisualStyleBackColor = true;
            this.cancelAMeetingBtn.Click += new System.EventHandler(this.CancelAMeetingBtn_Click);
            // 
            // UsersCheckedListBoxUpdate
            // 
            this.UsersCheckedListBoxUpdate.FormattingEnabled = true;
            this.UsersCheckedListBoxUpdate.Location = new System.Drawing.Point(695, 263);
            this.UsersCheckedListBoxUpdate.Name = "UsersCheckedListBoxUpdate";
            this.UsersCheckedListBoxUpdate.Size = new System.Drawing.Size(120, 94);
            this.UsersCheckedListBoxUpdate.TabIndex = 28;
            // 
            // TimesCheckedListBoxUpdate
            // 
            this.TimesCheckedListBoxUpdate.FormattingEnabled = true;
            this.TimesCheckedListBoxUpdate.Location = new System.Drawing.Point(875, 289);
            this.TimesCheckedListBoxUpdate.Name = "TimesCheckedListBoxUpdate";
            this.TimesCheckedListBoxUpdate.Size = new System.Drawing.Size(120, 94);
            this.TimesCheckedListBoxUpdate.TabIndex = 29;
            // 
            // dateTimePickerUpdate
            // 
            this.dateTimePickerUpdate.CustomFormat = "ddd/ MMM / yyyy   |   HH:mm";
            this.dateTimePickerUpdate.Location = new System.Drawing.Point(821, 263);
            this.dateTimePickerUpdate.Name = "dateTimePickerUpdate";
            this.dateTimePickerUpdate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerUpdate.TabIndex = 30;
            // 
            // UsersInMeetingTransferBtn
            // 
            this.UsersInMeetingTransferBtn.Location = new System.Drawing.Point(695, 211);
            this.UsersInMeetingTransferBtn.Name = "UsersInMeetingTransferBtn";
            this.UsersInMeetingTransferBtn.Size = new System.Drawing.Size(101, 35);
            this.UsersInMeetingTransferBtn.TabIndex = 31;
            this.UsersInMeetingTransferBtn.Text = "Remove a user from a meeting";
            this.UsersInMeetingTransferBtn.UseVisualStyleBackColor = true;
            this.UsersInMeetingTransferBtn.Click += new System.EventHandler(this.UpdateUsersInMeetingBtn_Click);
            // 
            // UpdateDateTimeBtn
            // 
            this.UpdateDateTimeBtn.Location = new System.Drawing.Point(852, 202);
            this.UpdateDateTimeBtn.Name = "UpdateDateTimeBtn";
            this.UpdateDateTimeBtn.Size = new System.Drawing.Size(132, 53);
            this.UpdateDateTimeBtn.TabIndex = 32;
            this.UpdateDateTimeBtn.Text = "Change the date or time of a meeting";
            this.UpdateDateTimeBtn.UseVisualStyleBackColor = true;
            this.UpdateDateTimeBtn.Click += new System.EventHandler(this.UpdateDateTimeBtn_Click);
            // 
            // CheckedListBoxMeetingsList
            // 
            this.CheckedListBoxMeetingsList.FormattingEnabled = true;
            this.CheckedListBoxMeetingsList.Location = new System.Drawing.Point(864, 38);
            this.CheckedListBoxMeetingsList.Name = "CheckedListBoxMeetingsList";
            this.CheckedListBoxMeetingsList.Size = new System.Drawing.Size(120, 94);
            this.CheckedListBoxMeetingsList.TabIndex = 33;
            // 
            // MeetingsListBtn
            // 
            this.MeetingsListBtn.Location = new System.Drawing.Point(875, 155);
            this.MeetingsListBtn.Name = "MeetingsListBtn";
            this.MeetingsListBtn.Size = new System.Drawing.Size(98, 33);
            this.MeetingsListBtn.TabIndex = 34;
            this.MeetingsListBtn.Text = "All your meetings";
            this.MeetingsListBtn.UseVisualStyleBackColor = true;
            this.MeetingsListBtn.Click += new System.EventHandler(this.MeetingsListBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(872, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "All your meetings";
            // 
            // UpdateRemovedUsersBtn
            // 
            this.UpdateRemovedUsersBtn.Location = new System.Drawing.Point(712, 374);
            this.UpdateRemovedUsersBtn.Name = "UpdateRemovedUsersBtn";
            this.UpdateRemovedUsersBtn.Size = new System.Drawing.Size(103, 45);
            this.UpdateRemovedUsersBtn.TabIndex = 37;
            this.UpdateRemovedUsersBtn.Text = "Update removed users from meeting";
            this.UpdateRemovedUsersBtn.UseVisualStyleBackColor = true;
            this.UpdateRemovedUsersBtn.Click += new System.EventHandler(this.UpdateRemovedUsersBtn_Click);
            // 
            // UpdateTimesAndDataBtn
            // 
            this.UpdateTimesAndDataBtn.Location = new System.Drawing.Point(883, 396);
            this.UpdateTimesAndDataBtn.Name = "UpdateTimesAndDataBtn";
            this.UpdateTimesAndDataBtn.Size = new System.Drawing.Size(112, 39);
            this.UpdateTimesAndDataBtn.TabIndex = 38;
            this.UpdateTimesAndDataBtn.Text = "Update times and data off meetings";
            this.UpdateTimesAndDataBtn.UseVisualStyleBackColor = true;
            this.UpdateTimesAndDataBtn.Click += new System.EventHandler(this.UpdateTimesAndDataBtn_Click);
            // 
            // RemoveSelfMeetingBtn
            // 
            this.RemoveSelfMeetingBtn.Location = new System.Drawing.Point(728, 523);
            this.RemoveSelfMeetingBtn.Name = "RemoveSelfMeetingBtn";
            this.RemoveSelfMeetingBtn.Size = new System.Drawing.Size(137, 52);
            this.RemoveSelfMeetingBtn.TabIndex = 39;
            this.RemoveSelfMeetingBtn.Text = "Remove self from meeting";
            this.RemoveSelfMeetingBtn.UseVisualStyleBackColor = true;
            this.RemoveSelfMeetingBtn.Click += new System.EventHandler(this.RemoveSelfMeetingBtn_Click);
            // 
            // PefenAndExclTimesBtn
            // 
            this.PefenAndExclTimesBtn.Location = new System.Drawing.Point(997, 523);
            this.PefenAndExclTimesBtn.Name = "PefenAndExclTimesBtn";
            this.PefenAndExclTimesBtn.Size = new System.Drawing.Size(129, 52);
            this.PefenAndExclTimesBtn.TabIndex = 40;
            this.PefenAndExclTimesBtn.Text = "Prefernce and exclusion times";
            this.PefenAndExclTimesBtn.UseVisualStyleBackColor = true;
            this.PefenAndExclTimesBtn.Click += new System.EventHandler(this.PefenAndExclTimesBtn_Click);
            // 
            // CreateUserInitBtn
            // 
            this.CreateUserInitBtn.Location = new System.Drawing.Point(344, 55);
            this.CreateUserInitBtn.Name = "CreateUserInitBtn";
            this.CreateUserInitBtn.Size = new System.Drawing.Size(104, 72);
            this.CreateUserInitBtn.TabIndex = 41;
            this.CreateUserInitBtn.Text = "Create some meetings";
            this.CreateUserInitBtn.UseVisualStyleBackColor = true;
            this.CreateUserInitBtn.Click += new System.EventHandler(this.CreateUserInitBtn_Click);
            // 
            // CreateUserRecipBtn
            // 
            this.CreateUserRecipBtn.Location = new System.Drawing.Point(501, 55);
            this.CreateUserRecipBtn.Name = "CreateUserRecipBtn";
            this.CreateUserRecipBtn.Size = new System.Drawing.Size(112, 72);
            this.CreateUserRecipBtn.TabIndex = 42;
            this.CreateUserRecipBtn.Text = "View meeting you are currently in";
            this.CreateUserRecipBtn.UseVisualStyleBackColor = true;
            this.CreateUserRecipBtn.Click += new System.EventHandler(this.CreateUserRecipBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1234, 802);
            this.Controls.Add(this.CreateUserRecipBtn);
            this.Controls.Add(this.CreateUserInitBtn);
            this.Controls.Add(this.PefenAndExclTimesBtn);
            this.Controls.Add(this.RemoveSelfMeetingBtn);
            this.Controls.Add(this.UpdateTimesAndDataBtn);
            this.Controls.Add(this.UpdateRemovedUsersBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MeetingsListBtn);
            this.Controls.Add(this.CheckedListBoxMeetingsList);
            this.Controls.Add(this.UpdateDateTimeBtn);
            this.Controls.Add(this.UsersInMeetingTransferBtn);
            this.Controls.Add(this.dateTimePickerUpdate);
            this.Controls.Add(this.TimesCheckedListBoxUpdate);
            this.Controls.Add(this.UsersCheckedListBoxUpdate);
            this.Controls.Add(this.cancelAMeetingBtn);
            this.Controls.Add(this.privateBtn);
            this.Controls.Add(this.publicBtn);
            this.Controls.Add(this.createMeetingsNameTxtBox);
            this.Controls.Add(this.createMeetingsNameLabel);
            this.Controls.Add(this.createMeetingsNameBtn);
            this.Controls.Add(this.TimesCheckedListBox);
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
            this.Controls.Add(this.DatePickerbtn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.PasswordTxtbox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserNameTxtbox);
            this.Controls.Add(this.Loginbtn);
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
        private System.Windows.Forms.Button MeetingsListBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdateRemovedUsersBtn;
        private System.Windows.Forms.Button UpdateTimesAndDataBtn;
        private System.Windows.Forms.Button RemoveSelfMeetingBtn;
        private System.Windows.Forms.Button PefenAndExclTimesBtn;
        private System.Windows.Forms.Button CreateUserInitBtn;
        private System.Windows.Forms.Button CreateUserRecipBtn;
    }
}

