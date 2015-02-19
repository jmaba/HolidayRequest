using Domain.Entities;
using Domain.Notification;
using Domain.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HolidayRequestUnitTests
{
    [TestClass]
    public class HolidayRequestsUnitTests
    {
        private readonly Employee employee;
        private readonly Manager manager;
        private readonly CompanyStorage companyStorage;
        private readonly HolidayInterval holidayInterval;

        public HolidayRequestsUnitTests()
        {
            ServiceLocator.NotificationService = new NotificationServiceMock();

            companyStorage = new CompanyStorage();
            companyStorage.CleanupStorage();

            manager = new Manager { EmailAddress = "adrian.barglazan@iquestgroup.com", Name = "Manager" };
            employee = new Employee { Name = "Costel", EmailAddress = "jm_aba@yahoo.com", Manager = manager };
            holidayInterval = new HolidayInterval() { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) };
            
            companyStorage.AddManager(manager);
            companyStorage.AddEmployee(employee);
            companyStorage.StoreChanges();
        }

        [TestMethod]
        public void RequestHoliday_HolidayRequestIsCreated()
        {
            employee.RequestNewHoliday(holidayInterval);

            Assert.AreEqual(1, companyStorage.GetAllHolidayRequests().Count());
        }

        [TestMethod]
        public void RejectHoliday_HolidayRequestIsRejected()
        {
            employee.RequestNewHoliday(holidayInterval);

            var holidayRequest = companyStorage.GetAllHolidayRequests().First(h => h.State == HolidayState.Submitted);
            manager.RejectHolidayRequest(holidayRequest);

            Assert.AreEqual(HolidayState.Rejected, holidayRequest.State);
        }

        [TestMethod]
        public void ApproveHoliday_HolidayRequestIsRejected()
        {
            employee.RequestNewHoliday(holidayInterval);

            var holidayRequest = companyStorage.GetAllHolidayRequests().First(h => h.State == HolidayState.Submitted);
            manager.ApproveHolidayRequest(holidayRequest);

            Assert.AreEqual(HolidayState.Approved, holidayRequest.State);
        }
    }
}
