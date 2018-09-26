using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoVehicle
    {
        List<Vehicle> GetVehicles();
        int newVehicle(Vehicle vehicle);
        int updateVehicle(Vehicle vehicle);
    }
}
