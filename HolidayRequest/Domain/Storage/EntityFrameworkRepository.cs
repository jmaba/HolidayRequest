using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Domain.Storage
{
    public class EntityFrameworkRepository : DbContext, IRepository
    {
        public EntityFrameworkRepository()
            : base("CompanyContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<HolidayRequest> HolidayRequests { get; set; }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAll<T>() where T : class
        {
            Set<T>().RemoveRange(Set<T>());
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}