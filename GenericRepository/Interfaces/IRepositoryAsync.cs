using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        IEnumerable<T> GetAsync();
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}