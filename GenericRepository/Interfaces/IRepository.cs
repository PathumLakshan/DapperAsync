using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
