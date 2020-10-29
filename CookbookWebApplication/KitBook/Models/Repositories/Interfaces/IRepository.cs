using System;
using System.Collections.Generic;

namespace KitBook.Models.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Read(Guid id);
        IEnumerable<T> Read();
        void Update(T entity);
        void Delete(Guid id);
    }
}