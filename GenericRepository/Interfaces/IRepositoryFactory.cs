using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        /*
         *IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class; 
         */
    }
}
