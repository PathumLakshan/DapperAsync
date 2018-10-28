using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DapperAsync.Repositories
{
    public class LoginRepo : IRepoLogin
    {
        private readonly IConfiguration _config;
        private readonly IOptions<AppSettings> _options;

        public LoginRepo(IConfiguration config, IOptions<AppSettings> options)
        {
            _config = config;
            _options = options;

        }

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnString"));
            }
        }

        

        public dynamic Authenticate(string username, string password)
        {
            //var user = this.login(username, password).FirstOrDefault();

            var user = this.dynamics(username, password).FirstOrDefault();

            if ( user!=null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_options.Value.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.userName.ToString()),
                    new Claim(ClaimTypes.Role, user.roleDesc.ToString())
                    
                    //new Claim(ClaimTypes.Name, user.userId.ToString()),
                    //new Claim(ClaimTypes.Role, user.roleId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                user.Token = tokenHandler.WriteToken(token);

                return user;
            } else { return null; } 
            
        }
        
        public void createUser(User user)
        {
            string sql = "insert into user ('userName','password','roleid') values (@userName,@password,@role)";

            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                conn.Execute(sql, param: new { userName = user.userName, password = user.password, role = user.roleId });
                conn.Close();
            }
        }

        public int deleteUser(int id)
        {
            string sql = "delete from [dbo].[user] where userId = @userid";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var result = conn.Execute(sql, param: new { userid = id });
                conn.Close();
                return result;
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<dynamic> GetUsers()
        {
            string sql = "select [usr].userId, [usr].userName, [role].roleDesc from [dbo].[user] usr, [dbo].[role] role where usr.roleId = role.roleId";

            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var result = conn.Query(sql);
                conn.Close();
                return result.ToList<dynamic>();
            }
        }

        public IEnumerable<dynamic> dynamics(string uname, string password)
        {
            string sql = "select [user].userName, [role].roleDesc from dbo.[user], dbo.[role] where [username] = @user and [password] = @pswd and [user].roleId = role.roleId;";
            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Query<dynamic>(sql, param: new { user = uname, pswd = password }).ToList<dynamic>();
                conn.Close();
                return res;
            }
        }

        //public IEnumerable<User> login(string userName, string password)
        //{
        //    //string sql = "select case when exists(select * from [dbo].user where userName = @usernamepara and password = @passwordpara) then cast(1 as bit) else cast(0 as bit )end";
        //    string sql = " SELECT [user].userName, [user].roleId FROM dbo.[user] WHERE [username] =  @usernamepara and password = @passwordpara ";
        //    using (IDbConnection conn = dbConnection)
        //    {
        //        conn.Open();
        //        // var res = conn.ExecuteScalar(sql, param: new { usernamepara = userName, passwordpara = password });
        //        var res = conn.Query<User>(sql, param: new { usernamepara = userName, passwordpara = password }).ToList<User>();
        //        conn.Close();
        //        //int result = Int32.Parse(res.ToString());
        //        return res;
        //    }
        //}

        public void updateUser(int id, string password)
        {
            string sql = "update user set password = @passwordparam where userId = @useridparam";

            using(IDbConnection conn = dbConnection)
            {
                conn.Open();
                var res = conn.Execute(sql, param: new { passwordparam = password, useridparam = id });
                conn.Close();
                
            }
        }
    }

    public class AppSettings
    {
        public string Secret
        { get; set; }
    }
        
}
