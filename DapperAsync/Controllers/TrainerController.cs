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
    public class TrainerController : ControllerBase
    {
        private readonly IRepoTrainer _iRepo;

        public TrainerController(IRepoTrainer repo)
        {
            _iRepo = repo;
        }

        [HttpGet]
        public List<Trainer> Get()
        {
            return _iRepo.GetTrainers();
        }

        [HttpPost]
        public int Post([FromBody] Trainer trainer)
        {
            return _iRepo.NewTrainer(trainer);
        }

        [HttpPut]
        public int Put([FromBody] Trainer trainer)
        {
            return _iRepo.updateTrainer(trainer);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.deleteTrainer(id);
        }
    }
}