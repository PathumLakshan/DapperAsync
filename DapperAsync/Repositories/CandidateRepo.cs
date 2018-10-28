using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace DapperAsync.Repositories
{
    public class CandidateRepo : IRepoCandidate
    {
        #region Configuration
        private readonly IConfiguration _config;

        public CandidateRepo(IConfiguration config)
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
        // methods for Controller

        public int AddNewCandidate(Candidate candidate)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "insert into candidate (c_name,c_tele_no,c_nic,c_address) values(@name,@tel,@cnic.@cadres); ";
                conn.Open();
                int res = conn.Execute(sql, 
                    param: new {
                        name = candidate.c_name,
                        tel = candidate.c_tele_no,
                        cnic = candidate.c_nic,
                        cadres = candidate.c_address
                    });
                conn.Close();
                return res;
            }
        }

        public int deleteCandidate(int id)
        {
            string sql = "delete from candidate where c_id = @Id";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { Id = id });
                conn.Close();
                return res;
            }
        }

        public List<Candidate> GetCandidates()
        {
            using(IDbConnection conn= dbConnection)
            {
                string sql = "select c_id,c_name,c_tele_no,c_nic,c_address from candidate;";
                conn.Open();
                var res = conn.Query<Candidate>(sql).ToList();
                conn.Close();
                return res;
            }
        }

        public int updateCandidate(Candidate candidate)
        {

            string sql = "update candidate set c_name = @cname, c_tele_no = @ctel, c_nic = @cnic ,c_address =@cadres  where c_id = @cid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, 
                    param: new {
                        cname = candidate.c_name,
                        ctel = candidate.c_tele_no,
                        cid = candidate.c_id,
                        cnic = candidate.c_nic,
                        cadres = candidate.c_address
                    });
                conn.Close();
                return res;
            }
        }
        #endregion

        #region BLLMethods
        // Methods for BLL
        public bool CandidatebyName(string name)
        {
            string sql = "select case when exists(select * from [dbo].candidate where c_name = @namepara ) then cast(1 as bit) else cast(0 as bit )end";
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
