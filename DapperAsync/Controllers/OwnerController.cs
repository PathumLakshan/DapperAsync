using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.BLL;
using DapperAsync.Models;
using DapperAsync.Repositories;
using DapperAsync.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperAsync.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IRepoOwner _iownerRepo;
        private readonly IMasterRecBLL _masterRecBLL;

        public OwnerController(IRepoOwner iownerRepo,IMasterRecBLL masterRecBLL)
        {
            _iownerRepo = iownerRepo;
            _masterRecBLL = masterRecBLL;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return _iownerRepo.GetOwners();

        }

        [HttpPost]
        public string AddOwner([FromBody]Owner owner)
        {
            if (!_masterRecBLL.Owner_isExsiting(owner.owner_name))
            {
                return _iownerRepo.NewOwner(owner).ToString();
            }
            else
            {
                return "Record Already Exists!";
            }
        }

        [HttpPut]
        public string Put([FromBody] Owner owner)
        {
            if (_masterRecBLL.Owner_isExsiting(owner.owner_name))
            {
                return _iownerRepo.updateOwner(owner).ToString();
            }
            else
            {
                return "No Such a Record !";
            }
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iownerRepo.deleteOwner(id);
        }
    }
}