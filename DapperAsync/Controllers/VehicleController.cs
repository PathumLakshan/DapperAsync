using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IRepoVehicle _irepo;

        public VehicleController(IRepoVehicle irepo)
        {
            _irepo = irepo;
        }

        [HttpGet]
        public List<Vehicle> Get()
        {
            return _irepo.GetVehicles();
        }

        [HttpPost]
        public int Post([FromBody] Vehicle vehicle)
        {
            return _irepo.newVehicle(vehicle);
        }
        [HttpPut]
        public int Put([FromBody] Vehicle vehicle)
        {
            return _irepo.updateVehicle(vehicle);
        }
    }
}