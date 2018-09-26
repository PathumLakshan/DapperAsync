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
    public class TraineeController : ControllerBase
    {
        private readonly IRepoTrainee _icontext;

        public TraineeController(IRepoTrainee icontext)
        {
            _icontext = icontext;
        }

        [HttpGet]
        public List<Trainee> GetAll()
        {
            return _icontext.GetTrainees();
        }

        [HttpPost]
        public int Post([FromBody] Trainee trainee)
        {
            return _icontext.NewTrainee(trainee);
        }

    }
}