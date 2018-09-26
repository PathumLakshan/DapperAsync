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

        public List<Payment_Type> GetPayment_Types()
        {
           using(IDbConnection conn = dbConnection)
            {
                string sql = "select paym_type, desc from payment_type";
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

        public bool updatePayment_Type(Payment_Type payment_Type)
        {
            throw new NotImplementedException();
        }
    }
}
