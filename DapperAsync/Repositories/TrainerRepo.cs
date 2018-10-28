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
        #region Configuratoins
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
        #endregion

        #region ControllerMethods
        // Methods for Controller

        public List<Trainer> GetTrainers()
        {
            string sql = "select trainer_id,trainer_name,trainer_nic,trainer_address from trainer";
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
            string sql = "insert into trainer (trainer_name,trainer_nic,trainer_address) values (@name,@nic,@adrs)";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new
                {
                    name = trainer.trainer_name,
                    nic = trainer.trainer_nic,
                    adrs = trainer.trainer_address
                });
                conn.Close();
                return res;
            }
        }

        public int updateTrainer(Trainer trainer)
        {
            string sql = "update trainer set trainer_name = @tname, trainer_nic = @nic, trainer_address = @adrs where trainer_id = @tid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, 
                    param: new {
                        tid = trainer.trainer_id,
                        tname = trainer.trainer_name,
                        nic = trainer.trainer_nic,
                        adrs = trainer.trainer_address                        
                    });
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
        #endregion

        #region BLLMethods
        // methods for BLL

        public bool TrainerbyName(string name)
        {
            string sql = "select case when exists(select * from [dbo].trainer where trainer_name = @namepara ) then cast(1 as bit) else cast(0 as bit )end";
            using (IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.ExecuteScalar(sql, param: new { namepara = name }).ToString();
                conn.Close();
                return Boolean.Parse(res); ;
            }
        }

        #endregion
    }
}
