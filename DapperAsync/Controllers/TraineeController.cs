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
        private readonly IRepoTrainee _iRepoTrainee;

        public TraineeController(IRepoTrainee iRepoTrainee)
        {
            _iRepoTrainee = iRepoTrainee;
        }

        [HttpGet]
        public List<Trainee> GetAll()
        {
            return _iRepoTrainee.GetTrainees();
        }

        [HttpPost]
        public int Post([FromBody] Trainee trainee)
        {
            return _iRepoTrainee.NewTrainee(trainee);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepoTrainee.deleteTrainee(id);
        }

    }
}