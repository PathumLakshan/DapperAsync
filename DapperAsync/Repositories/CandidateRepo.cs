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

        public int AddNewCandidate(Candidate candidate)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "insert into candidate (c_name,c_tele_no) values(@name,@tel); ";
                conn.Open();
                int res = conn.Execute(sql, param: new { name = candidate.c_name, tel = candidate.c_tele_no });
                conn.Close();
                return res;
            }
        }

        public List<Candidate> GetCandidates()
        {
            using(IDbConnection conn= dbConnection)
            {
                string sql = "select c_id,c_name,c_tele_no from candidate;";
                conn.Open();
                var res = conn.Query<Candidate>(sql).ToList();
                conn.Close();
                return res;
            }
        }

        public bool updateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
