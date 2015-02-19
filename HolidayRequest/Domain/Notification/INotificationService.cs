using Domain.Entities;

namespace Domain.Notification
{
    public interface INotificationService
    {
        void SendNotification(NotificationMessage message);
    }
}