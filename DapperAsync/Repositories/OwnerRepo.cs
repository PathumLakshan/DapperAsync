using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;

namespace DapperAsync.Repositories
{
    public class OwnerRepo : IRepoOwner
    {
        private readonly IConfiguration _config;

        public OwnerRepo(IConfiguration config)
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

        public int deleteOwner(int id)
        {
            string sql = "delete from owner where owner_id =@Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Close();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public List<Owner> GetOwners()
        {
           using(IDbConnection conn = dbConnection)
            {
                string sql = "select owner_id,owner_name from owner";
                conn.Open();
                var res = conn.Query<Owner>(sql);
                conn.Close();
                return res.ToList();
            }
        }

        public int NewOwner(Owner owner)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "insert into owner (owner_id, owner_name) values (@id,@name);";
                conn.Open();
                var res = conn.Execute(sql, param: new { id = owner.owner_id,name = owner.owner_name });
                conn.Close();
                return res;
            }
        }

        public int updateOwner(Owner owner)
        {
            string sql = "update owner set owner_name = @oname where owner_id = @oid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { oname = owner.owner_name, oid = owner.owner_id });
                conn.Close();
                return res;
            }
        }
    }
}
