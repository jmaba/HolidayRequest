using Domain.Entities;
using System.Net.Mail;

namespace Domain.Notification
{
    class EmailNotification : INotificationService
    {
        public void SendNotification(NotificationMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                //TODO Needs configuration - maybe offer other possibilities of auth (eg user/password)
                using (var mailMessage = new MailMessage(message.Sender, message.Receiver, message.Subject, message.Body))
                {
                    smtpClient.Send(mailMessage);
                }
            }
        }
    }
}