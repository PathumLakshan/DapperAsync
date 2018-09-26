using GenericRepository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace DapperAsync.GenericRepository.Classes
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

        public bool Add(TEntity entity, string s)
        {
            
            using (IDbConnection conn = dbConnection)
            {
                conn.Open();
                int res = conn.Execute(s, param: entity);
                conn.Close();
                if (res != 0)
                { return true; }
                else { return false;  }
            }
            
        }

        public bool Delete(TEntity entity, string s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(string s)
        {
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Query<TEntity>(s);
                conn.Close();
                return res;
            }
        }

        public bool Update(TEntity entity, string s)
        {
            throw new NotImplementedException();
        }
    }
}
