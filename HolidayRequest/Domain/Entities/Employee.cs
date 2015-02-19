using Domain.Notification;
using Domain.Storage;

namespace Domain.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public Employee Manager { get; set; }

        public void RequestNewHoliday(HolidayInterval holidayInterval)
        {
            var holidayRequest = new HolidayRequest
            {
                Employee = this, 
                Interval = holidayInterval,
                State = HolidayState.Submitted
            };

            PersistHolidayRequest(holidayRequest);

            ServiceLocator.NotificationService.SendNotification(holidayRequest.GetSubmittedMessage());
        }

        private static void PersistHolidayRequest(HolidayRequest holidayRequest)
        {
            CompanyStorage companyStorage = new CompanyStorage();
            companyStorage.AddHolidayRequest(holidayRequest);
        }
    }
}