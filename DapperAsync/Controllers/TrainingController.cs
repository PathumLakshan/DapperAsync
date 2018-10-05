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
    public class TrainingController : ControllerBase
    {
        private readonly IRepoTraining _iRepo;

        public TrainingController(IRepoTraining iRepo)
        {
            _iRepo = iRepo;
        } 

        [HttpGet]
        public List<dynamic> Get()
        {
            return _iRepo.GetTrainingSchedule();
        }

        [HttpPost]
        public int Post([FromBody] Training training)
        {
            return _iRepo.newTrainingSchedule(training);
        }

        [HttpPut]
        public int Put([FromBody] Training training)
        {
            return _iRepo.updateTrainingSchedule(training);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.deleteTraining(id);
        }
    }
}