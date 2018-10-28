using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.BLL;
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
        private readonly IMasterRecBLL _masterRecBLL;

        public VehicleController(IRepoVehicle irepo, IMasterRecBLL masterRecBLL)
        {
            _irepo = irepo;
            _masterRecBLL = masterRecBLL;
        }

        [HttpGet]
        public List<dynamic> Get()
        {
            return _irepo.GetVehicles();
        }

        [HttpPost]
        public string Post([FromBody] Vehicle vehicle)
        {
            if (!_masterRecBLL.Vehicle_isExsiting(vehicle.v_reg))
            {
                return _irepo.newVehicle(vehicle).ToString();
            }
            else
            {
                return "Record Already Exists !";
            }
            
        }
        [HttpPut]
        public string Put([FromBody] Vehicle vehicle)
        {
            if (_masterRecBLL.Vehicle_isExsiting(vehicle.v_reg))
            {
                return _irepo.updateVehicle(vehicle).ToString();
            }
            else
            {
                return "No such a record !";
            }
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _irepo.deleteVehicle(id);
        }
    }
}