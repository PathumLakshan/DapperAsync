using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories;
using DapperAsync.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperAsync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        public IRepoOwner _iownerRepo;
        public OwnerController(IRepoOwner iownerRepo)
        {
            _iownerRepo = iownerRepo;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return _iownerRepo.GetOwners();

        }

        //[HttpPost]
       /* public int AddOwner([FromBody]Owner owner)
        {
            //return _iRepo.NewOwner(owner);
        }*/
    }
}