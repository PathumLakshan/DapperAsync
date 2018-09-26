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
    public class EmployeeRepo
    {
        /*private readonly IConfiguration _config;

        public EmployeeRepo(IConfiguration config)
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
        */


       /* public async Task<Employee> GetEmployee(int id)
        {
          
        }*/
        /*
        public List<Employee> GetEmployeeList()
        {
              using(IDbConnection conn = dbConnection)
            {
                string sql = "select * from Employee;";
                conn.Open();
                var res = conn.Query<Employee>(sql).ToList();
                conn.Close();
                return res;
            }
        }

    

        public int newEmployee(Employee employee)
        {
            using(IDbConnection conn = dbConnection)
            {
                string sql = "insert into Employee (Id,Name) values(@id,@name)";
                conn.Open();
                int res =  conn.Execute(sql, param: new { id = employee.ID, name = employee.Name });
                conn.Close();
                return res;
            }
        }*/
    }
}
