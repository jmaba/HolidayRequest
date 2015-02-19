using Domain.Entities;
using Domain.Notification;

namespace HolidayRequestUnitTests
{
    class MockNotificationService : INotificationService
    {
        public void SendNotification(NotificationMessage message)
        {
            //Nothing...
        }
    }
}