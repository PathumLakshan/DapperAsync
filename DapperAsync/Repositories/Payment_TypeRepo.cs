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
    public class Payment_TypeRepo : IRepoPayment_Type
    {
        private readonly IConfiguration _config;

        public Payment_TypeRepo(IConfiguration config)
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

        public int deletePaymet_Type(int id)
        {
            string sql = "delete from payment_type where type_id = @Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public List<Payment_Type> GetPayment_Types()
        {
           using(IDbConnection conn = dbConnection)
            {
                string sql = "select type_id,paym_type,[desc],amount from payment_type";
                conn.Open();
                var res = conn.Query<Payment_Type>(sql).ToList();
                conn.Close();
                return res;
            }
        }

        public int NewPayment_Type(Payment_Type payment_Type)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "insert into payment_type (paym_type,desc) values (@type,@desc);";
                conn.Open();
                var res = conn.Execute(sql, param: new { type = payment_Type.paym_type, desc = payment_Type.desc });
                conn.Close();
                return res;
            }
        }

        public int updatePayment_Type(Payment_Type payment_Type)
        {
            string sql = "update payment_type set paym_type = @ptype, desc = @des where type_id = @tid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res =  conn.Execute(sql, param: new { ptype = payment_Type.paym_type, des = payment_Type.desc, tid = payment_Type.type_id });
                conn.Close();
                return res;
            }
        }
    }
}
