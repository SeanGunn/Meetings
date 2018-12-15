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
            this.dateTimePicker.Location = new System.Drawing.Point(449, 38);
            this.dateTimePicker.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker.TabIndex = 5;
            this.dateTimePicker.Value = new System.DateTime(2018, 12, 14, 0, 0, 0, 0);
            // 
            // DatePickerbtn
            // 
            this.DatePickerbtn.Location = new System.Drawing.Point(356, 615);
            this.DatePickerbtn.Name = "DatePickerbtn";
            this.DatePickerbtn.Size = new System.Drawing.Size(285, 98);
            this.DatePickerbtn.TabIndex = 6;
            this.DatePickerbtn.Text = "button1";
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
            this.newPasswordTxtbox.Location = new System.Drawing.Point(92, 394);
            this.newPasswordTxtbox.Name = "newPasswordTxtbox";
            this.newPasswordTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordTxtbox.TabIndex = 10;
            // 
            // newFirstnameTxtbox
            // 
            this.newFirstnameTxtbox.Location = new System.Drawing.Point(92, 476);
            this.newFirstnameTxtbox.Name = "newFirstnameTxtbox";
            this.newFirstnameTxtbox.Size = new System.Drawing.Size(100, 20);
            this.newFirstnameTxtbox.TabIndex = 11;
            // 
            // newLastnameTxtbox
            // 
            this.newLastnameTxtbox.Location = new System.Drawing.Point(94, 553);
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
            // 
            // UsersCheckedListBox
            // 
            this.UsersCheckedListBox.FormattingEnabled = true;
            this.UsersCheckedListBox.Location = new System.Drawing.Point(356, 88);
            this.UsersCheckedListBox.Name = "UsersCheckedListBox";
            this.UsersCheckedListBox.Size = new System.Drawing.Size(136, 484);
            this.UsersCheckedListBox.TabIndex = 18;
            // 
            // TimesCheckedListBox
            // 
            this.TimesCheckedListBox.FormattingEnabled = true;
            this.TimesCheckedListBox.Location = new System.Drawing.Point(507, 88);
            this.TimesCheckedListBox.Name = "TimesCheckedListBox";
            this.TimesCheckedListBox.Size = new System.Drawing.Size(134, 484);
            this.TimesCheckedListBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1234, 802);
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
    }
}

