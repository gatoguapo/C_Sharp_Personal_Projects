using System;
using System.Collections.Generic;
using Entidades;

namespace Negocio
{
    public class MailHandler
    {
        List<Mail> mailsList = new List<Mail>();
        public void addNewMail(string emailSender, string title, string subject, string body, DateTime date, string recipient)
        {
            mailsList.Add(new Mail(emailSender, title, subject, body, date, recipient));
        }

        public List<Mail> getNewMail()
        {
            return mailsList;
        }
    }
}
