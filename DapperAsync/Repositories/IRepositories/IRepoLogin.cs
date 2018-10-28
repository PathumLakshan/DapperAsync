using DapperAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoLogin
    {
        //IEnumerable<User> login(string userName, string password);
        IEnumerable<dynamic> dynamics(string uname, string password);

        dynamic Authenticate(string username, string password);
        IEnumerable<User> GetAll();

        List<dynamic> GetUsers();
        void createUser(User user);
        void updateUser(int id, string password);
        int deleteUser(int id);
    }
}
