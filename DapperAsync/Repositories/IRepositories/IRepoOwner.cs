using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using Microsoft.Extensions.Configuration;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoOwner
    {
        List<Owner> GetOwners();
        int NewOwner(Owner owner);
        int updateOwner(Owner owner);
        int deleteOwner(int id);
    }
}
