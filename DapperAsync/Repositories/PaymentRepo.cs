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
    public class PaymentRepo : IRepoPayment
    {
        private readonly IConfiguration _config;
        public PaymentRepo(IConfiguration config)
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

        public int deletePayment(int id)
        {
            string sql = "delete from payment where payment_id = @Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Close();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public IEnumerable<dynamic> GetPayments()
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "select paym.paid_date, paym.amount, trn.trainee_name " +
                    "from payment paym, trainee trn, payment_type p_type where paym.trainee_id = trn.reg_id ;";
                conn.Open();
                var res = conn.Query<dynamic>(sql);

                conn.Close();
                return res;
            }
        }

        public int NewPayment(Payment payment)
        {
            string sql = "insert into payment (trainee_id,paid_date,remarks,type_id,amount) values (@tr_id,@pay_date,@remark,@type,@amount);";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { tr_id = payment.trainee_id, pay_date = payment.paid_date, remark = payment.remarks, type = payment.type_id, amount = payment.amount });
                conn.Close();
                return res;
            }
        }

        public int updatePayment(Payment payment)
        {
            string sql = "update payment set trainee_id=@tr_id,paid_date=@pay_date,remarks=@remark,type_id=@type,amount=@amount where payment_id = @pay_id;";
            using (IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { tr_id = payment.trainee_id, pay_date = payment.paid_date, remark = payment.remarks, type = payment.type_id, amount = payment.amount, pay_id = payment.payment_id });
                conn.Close();
                return res;
            }
        }
    }
}
