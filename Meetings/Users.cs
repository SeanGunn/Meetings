using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Meetings
{
    abstract class Users
    {
        //private Dictionary<String, String> Pairs;
        protected string name;
        protected string username;
        protected string password;
        protected string email;
        protected int tempLogin = 5;
        
        public void SetName(String value)
        {
            this.name = value;
        }
        public string GetName()
        {
            return this.name;
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
            sb.Append(name);
            sb.AppendLine("Username: ");
            sb.Append(username);
            sb.AppendLine("Email");
            sb.Append(email);
            return sb.ToString();
        }
    }
}
