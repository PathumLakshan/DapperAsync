using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        /* 
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;
        */
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : IConfiguration
    {
        TContext Context { get; }
    }
}
