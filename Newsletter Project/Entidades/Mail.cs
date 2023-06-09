using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Mail
    {
        private string title;
        private string body;
        private string recipient;
        private string emailSender;
        private string subject;
        private DateTime date;

        public Mail(string emailSender, string title, string subject, string body, DateTime date, string recipient)
        {
            this.title = title;
            this.body = body;
            this.recipient = recipient;
            this.emailSender = emailSender;
            this.subject = subject;
            this.date = date;
        }

        public string pTitle { get => title; set => title = value; }
        public string pBody { get => body; set => body = value; }
        public string pRecipient { get => recipient; set => recipient = value; }
        public string pEmailSender { get => emailSender; set => emailSender = value; }
        public string pSubject { get => subject; set => subject = value; }
        public DateTime pDate { get => date; set => date = value; }
    }
}
