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

namespace Meetings
{
    //TODO: Recip may withdraw and exclude some slots
    //TODO: Add new users to hash
    //TODO: Add new users to text file
    //TODO: Last: Add a new text file based on meetings
    public partial class Form1 : Form
    {

        private HashMap Pairs;
        //Dictionary<String, String> Pairs = new Dictionary<String, String>();
        private Users User;
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
            //when forms loads up reads the files
            //database
            try
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(@"C:\Users\sean\source\repos\Meetings\Data.txt"))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    while (!(streamReader.EndOfStream))
                    {
                        var line = streamReader.ReadLine();

                        string[] splitString = line.Split('#');
                        string split0 = splitString[0];
                        string split1 = splitString[1];

                        Pairs.Add(split0, split1);
                    }
                    fileStream.Close();
                    // Process line
                }
                
            }
            catch (Exception A)
            {
                MessageBox.Show("Exception: " + A.Message);
            }
            UsersCheckedListBox.CheckOnClick = true;
            TimesCheckedListBox.CheckOnClick = true;
            //TODO: Add users to list over Fruits
            string[] myFruit = { "Apples", "Oranges", "Tomato" };
            UsersCheckedListBox.Items.AddRange(myFruit);
            string[] meetingTimes = { "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00","17:00","18:00","19:00","20:00","21:00"};
            TimesCheckedListBox.Items.AddRange(meetingTimes);
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string a = UserNameTxtbox.Text;
            string b = PasswordTxtbox.Text;
            Pairs.UserIsInTheHash(a, b);
        }


        private void Form1_Closed()
        {
            //when form closed closes the files and saves them
            //database
            Pairs.RemoveHashMapAstextfile();
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
                checkedItemsTimes += " ";
            }
            MessageBox.Show(checkedItemsTimes);


            string checkedItemsUsers = string.Empty;
            foreach (object Item in UsersCheckedListBox.CheckedItems)
            {
                checkedItemsUsers += Item.ToString();
                checkedItemsUsers += " ";
            }
            MessageBox.Show(checkedItemsUsers);
        }
    }
}
