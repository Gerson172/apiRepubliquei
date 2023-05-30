using System.Net.Mail;

namespace apiRepubliquei
{
    internal class SmtpSender
    {
        private SmtpClient smtpClient;

        public SmtpSender(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }
    }
}