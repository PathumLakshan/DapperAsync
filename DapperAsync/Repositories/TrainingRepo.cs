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
    public class TrainingRepo : IRepoTraining
    {
        #region Configurations
        private readonly IConfiguration _config;

        public TrainingRepo(IConfiguration config)
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
        public int deleteTraining(int id)
        {
            string sql = "delete from training where trainer_id =@Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public List<dynamic> GetTrainingSchedule()
        {
            string sql = "select vehicle.v_reg, trainee.trainee_name, trainee.reg_id, trainer.trainer_name, training.[start-time],training.[end-time],training.[date],training.[status],training.present " +
                "from training inner join vehicle on vehicle.v_id = training.v_id inner join trainee on trainee.reg_id = training.trainee_id inner join trainer on trainer.trainer_id = training.trainer_id; ";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                /*var res = conn.Query<Training, Trainee, Vehicle, Trainer, Training>
                    (@sql, map: (training, trainee, vehicle, trainer) =>
                    {
                        training.Trainee = trainee;
                        training.Trainer = trainer;
                        training.Vehicle = vehicle;
                        return training;

                    }, splitOn: "").AsQueryable();*/
                var r = conn.Query(sql).ToList();
                conn.Close();
                return r;
            }
        }

        public int newTrainingSchedule(Training training)
        {
            string sql = "insert into training (v_id,trainee_id,trainer_id,[start-time],[end-time],date,status,present) " +
                "values(@vid,@trnid,@trnrid,@stime,@etime,@date,@status,@prsnt);";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new
                {
                    vid = training.v_id,
                    trnid = training.trainee_id,
                    trnrid = training.trainer_id,
                    stime = training.start_time,
                    etime = training.end_time,
                    date = training.date,
                    status = training.status,
                    prsnt = training.present
                });
                conn.Close();
                return res;
            }
        }

        public int updateTrainingSchedule(Training training)
        {
            string sql = "update training set v_id = @vid,trainee_id = @traineeid,trainer_id=@trainerid ,[start-time]= @starttime,[end-time]=@endtime,date=@datein,status=@status,present=@presentin";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new
                {
                    vid = training.v_id,
                    traineeid = training.trainee_id,
                    starttime = training.start_time,
                    endtime = training.end_time,
                    presentin = training.present,
                    status = training.status,
                    datein = training.date
                });
                conn.Close();
                return res;
            }
        }

        #endregion

        #region BLLMethods

        #endregion
    }
}
