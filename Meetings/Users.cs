using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace Meetings
{
    abstract class Users
    {
        protected HashMap Pairs;
        //private Dictionary<String, String> Pairs;
        protected string Fname;
        protected string Lname;
        protected string Fullname;
        protected string username;
        protected string password;
        protected string email;
        protected int tempLogin = 5;

        public Users()
        {
            username = "N/A";
            Fname = "N/A";
            Lname = "N/A";
            password = "";
            email = "seangunn095@gmail.com";
        }

        public Users(string username, string Fname, string Lname, string password, string email)
        {
            this.username = username;
            this.Fname = Fname;
            this.Lname = Lname;
            this.password = password;
            this.email = email;
            SetFullName(Fname, Lname);
        }

        public void SetFName(String value)
        {
            this.Fname = value;
            MessageBox.Show(value);
        }
        public string GetFName()
        {
            return this.Fname;
        }
        public void SetLName(String value)
        {
            this.Lname = value;
        }
        public string GetLName()
        {
            return this.Lname;
        }
        public void SetUsername(String value)
        {
            this.username = value;
        }
        public string GetUsername()
        {
            return this.username;
        }

        public void SetPassword(String value)
        {
            this.password = value;
        }
        public string GetPassword()
        {
            return this.password;
        }

        public void SetFullName(String value, String value2)
        {
            this.Fullname = value + value2;
        }

        public string GetFullName()
        {
            return this.Fullname;
        }

        public void SetEmail(String value)
        {
            value.Trim();
            if (value.Contains("@gmail.com"))
                this.email = value;
            else
                throw new Exception("Must be a valid gmail account.");
        }
        public string GetEmail()
        {
            return this.email;
        }

        public void SetTempLogin(int value)
        {
            this.tempLogin = value;
        }

        public static void SendEmail(string email, int tempLogin)
        {
            MailMessage message = new MailMessage(email, "seangunn095@gmail.com");
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com"
            };
            message.Subject = "Temp Login";
            message.Body = tempLogin.ToString();
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex.ToString());
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(Fname + " " + Lname +"\n");
            sb.AppendLine("Username: ");
            sb.Append(username+"\n");
            sb.AppendLine("Email");
            sb.Append(email);
            return sb.ToString();
        }
    }
}
