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

namespace Meetings
{
    public partial class Form1 : Form
    {
        private HashMap Pairs;
        //Dictionary<String, String> Pairs = new Dictionary<String, String>();
        private Users User;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

            //when forms loads up reads the files
            //database
            string line;
            try
            {
                var sr = new StreamReader(@"C:\\Data.txt");
                line = sr.ReadLine();
                Pairs.Add("sean", "temp");
                //seperates the text into each one(name-username-password-email)
                while (line != null)
                {
                    //Read the next line
                    line = sr.ReadLine();
                    string[] splitString = line.Split('-');
                    Pairs.Add(splitString[0], splitString[1]);
                    //seperates the text into each one(name-username-password-email)
                }
                //close the file
                sr.Close();
            }
            catch (Exception A)
            {
                MessageBox.Show("Exception: " + A.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            //when form closed closes the files and saves them
            //database
            Pairs.RemoveHashMapAstextfile();
        }
    }
}
