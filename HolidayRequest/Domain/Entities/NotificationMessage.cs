namespace Domain.Entities
{
    public class NotificationMessage
    {
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public NotificationMessage(string from , string to , string subject, string body)
        {
            Sender = from;
            Receiver = to;
            Subject = subject;
            Body = body;
        }
    }
}