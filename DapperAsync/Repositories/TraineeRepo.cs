﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DapperAsync.Repositories
{
    public class TraineeRepo : IRepoTrainee
    {
        #region Configurations
        private readonly IConfiguration _config;
        public TraineeRepo(IConfiguration config)
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
        public int deleteTrainee(int id)
        {
            string sql = "delete from trainee where reg_id =@Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public List<Trainee> GetTrainees()
        {
            string sql = "select reg_id, trainee_name, join_date,[num.of.hours],training_type from trainee";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Query<Trainee>(sql).ToList<Trainee>();
                conn.Close();
                return res;
            }
        }

        public int NewTrainee(Trainee trainee)
        {
            string sql = "insert into trainee ( trainee_name, join_date,[num.of.hours],training_type,cand_id) values (@tr_name,@j_date,@nfh,@type,@cand);";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { reg = trainee.reg_id, tr_name = trainee.trainee_name, j_date = trainee.join_date.Date, nfh = trainee.no_of_hours, type = trainee.training_type, cand = trainee.cand_id });
                conn.Close();
                return res;
            }
        }

        

        public int updateTrainee(Trainee trainee)
        {
            string sql = "update trainee set trainee_name = @trn_name, join_date = @j_date ,[num.of.hours] = @nfh ,training_type = @type where reg_id = @reg;";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { trn_name = trainee.trainee_name, j_date = trainee.join_date.Date, nfh = trainee.no_of_hours, type = trainee.training_type, reg = trainee.reg_id });
                conn.Close();
                return res;
            }
        }
        #endregion

        #region BLL Methods
        // Methods for BLL
        public bool TraineebyName(string name)
        {
            string sql = "select case when exists(select * from [dbo].trainee where trainee_name = @namepara ) then cast(1 as bit) else cast(0 as bit )end";
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
