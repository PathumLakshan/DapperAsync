using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAsync.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepoLogin _iRepoLogin;

        public LoginController(IRepoLogin iRepoLogin)
        {
            _iRepoLogin = iRepoLogin;
        }

        [HttpPost]
        public void Create([FromBody]User user)
        {
            _iRepoLogin.createUser(user);
        }

        /*[HttpPost]
        [Route("userLogin")]
        public int userLogin([FromBody]User user)
        {
            return _iRepoLogin.login(user.userName, user.password);
        }*/

        [AllowAnonymous]
        [HttpPost]
        [Route("authentication")]
        public IActionResult Authentication([FromBody]User user)
        {
            var luser = _iRepoLogin.Authenticate(user.userName, user.password);
            if(luser == null)
            {
                return BadRequest(new { message= "Credentials wrong !" });
            } else
            {
                return Ok(luser);
            }
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
           return _iRepoLogin.deleteUser(id);
        }

        [HttpGet]
        public List<dynamic> GetUsers()
        {
            return _iRepoLogin.GetUsers();
        }

        [HttpPut]
        public void Update([FromBody]int id, string password)
        {
            _iRepoLogin.updateUser(id, password);
        }

        
    }
}