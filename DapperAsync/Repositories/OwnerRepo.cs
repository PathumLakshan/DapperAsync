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
        #region Confiurations
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
        #endregion

        #region ControllerMethods

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
                string sql = "select owner_id,owner_name,owner_nic,owner_address from owner";
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
                string sql = "insert into owner ( owner_name,owner_nic,owner_address) values (@name,@nic,@adrs);";
                conn.Open();
                var res = conn.Execute(sql, 
                    param: new {
                        name = owner.owner_name,
                        nic = owner.owner_nic,
                        adrs = owner.owner_address
                    });
                conn.Close();
                return res;
            }
        }

        public int updateOwner(Owner owner)
        {
            string sql = "update owner set owner_name = @oname, owner_nic = @nic,owner_address = @adrs where owner_id = @oid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, 
                    param: new {
                        oid = owner.owner_id,
                        oname = owner.owner_name,
                        nic = owner.owner_nic,
                        adrs = owner.owner_address
                    });
                conn.Close();
                return res;
            }
        }
        #endregion

        #region BLLMethods

        public bool OwnerbyName(string name)
        {
            string sql = "select case when exists(select * from [dbo].owner where owner_name = @namepara ) then cast(1 as bit) else cast(0 as bit )end";
            using (IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.ExecuteScalar(sql, param: new { namepara = name }).ToString();
                conn.Close();
                return Boolean.Parse(res);
            }
        }
        #endregion
    }
}
