using GenericRepository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GenericRepository.Classes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnString"));
            }
        }

        public bool Add(TEntity entity)
        {
            //throw new NotImplementedException();
            using (IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute();
            }
        }

        public bool Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
