namespace Domain.Notification
{
    public static class ServiceLocator
    {
        private static INotificationService notificationService;

        public static INotificationService NotificationService
        {
            get { return notificationService ?? (notificationService = new EmailNotification()); }
            set { notificationService = value; }
        }
    }
}