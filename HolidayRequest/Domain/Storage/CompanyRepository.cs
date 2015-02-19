using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Storage
{
    public class CompanyStorage
    {
        private readonly IRepository repository;

        public CompanyStorage()
        {
            repository = StorageLocator.Get();
        }

        public void AddEmployee(Employee employee)
        {
            repository.Add(employee);
        }

        public void AddManager(Manager manager)
        {
            repository.Add(manager);
        }

        public IEnumerable<HolidayRequest> GetAllHolidayRequests()
        {
            return repository.GetAll<HolidayRequest>();
        }

        public void AddHolidayRequest(HolidayRequest holidayRequest)
        {
            repository.Add(holidayRequest);
            repository.Save();
        }

        public void UpdateHolidayRequest(HolidayRequest holidayRequest)
        {
            repository.Update(holidayRequest);
            repository.Save();
        }

        public void CleanupStorage()
        {
            repository.DeleteAll<HolidayRequest>();
            repository.DeleteAll<Employee>();
            repository.DeleteAll<Manager>();
            repository.Save();
        }

        public void StoreChanges()
        {
            repository.Save();
        }
    }
}