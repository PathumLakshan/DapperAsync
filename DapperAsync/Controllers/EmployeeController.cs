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
    [Route("api/employess")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /*
        private readonly IDContext _icontext;

        public EmployeeController(IDContext icontext)
        {
            _icontext = icontext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetbyId(int id)
        {
            //return await _iRepo.GetEmployee(id);
        }

        [HttpPost]
        public int Post([FromBody]Employee newEmployee)
        {
            //return  _iRepo.newEmployee(newEmployee);
        }

        [HttpGet]
        public List<Employee> GetAllEmployee()
        {
            return _icontext.GetRepository<Employee>.GetAll();
        }*/
    }
}