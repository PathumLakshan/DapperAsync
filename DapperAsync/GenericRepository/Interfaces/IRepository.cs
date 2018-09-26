using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(string s);
        bool Add(T entity, string s);
        bool Delete(T entity, string s);
        bool Update(T entity, string s);
    }
}
