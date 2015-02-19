using System.Collections.Generic;

namespace Domain.Storage
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void DeleteAll<T>() where T : class;
        void Save();
    }
}