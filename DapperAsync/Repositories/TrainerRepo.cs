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
    public class TrainerRepo : IRepoTrainer
    {
        private readonly IConfiguration _config;

        public TrainerRepo(IConfiguration config)
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

        public List<Trainer> GetTrainers()
        {
            string sql = "select trainer_id,trainer_name from trainer";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Query<Trainer>(sql).ToList<Trainer>();
                conn.Close();
                return res;
            }

        }

        public int NewTrainer(Trainer trainer)
        {
            string sql = "insert into trainer ( trainer_name) values ( @name)";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new
                {
                    //id = trainer.trainer_id,
                    name = trainer.trainer_name
                });
                conn.Close();
                return res;
            }
        }

        public int updateTrainer(Trainer trainer)
        {
            string sql = "update trainer set trainer_name = @tname where trainer_id = @tid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { tname = trainer.trainer_name, tid = trainer.trainer_id });
                conn.Close();
                return res;
            }
        }

        public int deleteTrainer(int id)
        {
            string sql = "delete from trainer where trainer_id=@trainerId";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res =  conn.Execute(sql, param: new { trainerId = id });
                conn.Close();
                return res;
            }
        }

    }
}
