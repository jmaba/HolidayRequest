using Domain.Entities;
using Domain.Notification;

namespace HolidayRequestUnitTests
{
    class NotificationServiceMock : INotificationService
    {
        public void SendNotification(NotificationMessage message)
        {
            //Nothing...
        }
    }
}