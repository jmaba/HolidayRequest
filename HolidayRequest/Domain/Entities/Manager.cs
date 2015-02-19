using Domain.Notification;
using Domain.Storage;

namespace Domain.Entities
{
    public class Manager : Employee
    {
        public void RejectHolidayRequest(HolidayRequest holidayRequest)
        {
            holidayRequest.State = HolidayState.Rejected;

            StoreHolidayRequestChanges(holidayRequest);

            ServiceLocator.NotificationService.SendNotification(holidayRequest.GetRejectMessage());
        }

        public void ApproveHolidayRequest(HolidayRequest holidayRequest)
        {
            holidayRequest.State = HolidayState.Approved;

            StoreHolidayRequestChanges(holidayRequest);

            ServiceLocator.NotificationService.SendNotification(holidayRequest.GetApprovedMessage());
        }

        private static void StoreHolidayRequestChanges(HolidayRequest holidayRequest)
        {
            var companyRepository = new CompanyStorage();
            companyRepository.UpdateHolidayRequest(holidayRequest);
        }
    }
}