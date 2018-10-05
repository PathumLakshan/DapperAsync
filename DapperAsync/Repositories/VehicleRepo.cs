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
    public class VehicleRepo : IRepoVehicle
    {
        private readonly IConfiguration _config;

        public VehicleRepo(IConfiguration config)
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

        public int deleteVehicle(int id)
        {
            string sql = "delete from vehicle where v_id=@vid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { vid = id });
                conn.Close();
                return res;
            }
        }

        public List<dynamic> GetVehicles()
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "select v.v_reg,v.description, o.owner_name from vehicle v, owner o where v.owner_id = o.owner_id;";
                conn.Open();
                var res = conn.Query<dynamic>(sql);
                conn.Close();
                return res.ToList<dynamic>();
            }
            
        }

        public int newVehicle(Vehicle vehicle)
        {
            using (IDbConnection conn = dbConnection)
            {
                string sql = "insert into vehicle (v_reg,owner_id,description) values(@reg,@owner_id,@desc); ";
                conn.Open();
                int res = conn.Execute(sql, param: new { reg = vehicle.v_reg,owner_id = vehicle.owner_id, desc = vehicle.description });
                conn.Close();
                return res;
            }
        }

        public int updateVehicle(Vehicle vehicle)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "update vehicle set owner_id = @owner_id where v_id = @v_id;";
                conn.Open();
                var res = conn.Execute(sql, param: new { owner_id = vehicle.owner_id, v_id = vehicle.v_id });
                conn.Close();
                return res;
            }

        }
    }

    
}
