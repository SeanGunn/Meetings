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
    //TODO: Systems constrains mmet
    //TODO: Integrity maintained
    //TODO: Recip may withdraw and exclude some slots
    //TODO: DROP OUT?
    //TODO: SEPERATE DATA
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
            dateTimePicker.CustomFormat = "ddd/ MMM / yyyy   |   HH:mm";
            Pairs = new HashMap();
            //when forms loads up reads the files
            //database
            try
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(@"F:\MyWork\GitHub\Meetings\Data.txt"))
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
            int hour = dateTimePicker.Value.Hour;
            int min = dateTimePicker.Value.Minute;

            MessageBox.Show(""+day+ " " + month + " " + year + " " + hour + " " + min);
        }
    }
}
