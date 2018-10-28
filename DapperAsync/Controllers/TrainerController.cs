using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.BLL;
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
    public class TrainerController : ControllerBase
    {
        private readonly IRepoTrainer _iRepoTrainee;
        private readonly IMasterRecBLL _masterRecBLL;

        public TrainerController(IRepoTrainer iRepoTrainee, IMasterRecBLL masterRecBLL)
        {
            _iRepoTrainee = iRepoTrainee;
            _masterRecBLL = masterRecBLL;
        }

        [HttpGet]
        public List<Trainer> Get()
        {
            return _iRepoTrainee.GetTrainers();
        }

        [HttpPost]
        public string Post([FromBody] Trainer trainer)
        {
            if (!_masterRecBLL.Trainer_isExsiting(trainer.trainer_name))
            {
                return _iRepoTrainee.NewTrainer(trainer).ToString();
            }
            else
            {
                return "Already Exists !";
            }
            
        }

        [HttpPut]
        public string Put([FromBody] Trainer trainer)
        {
            if (_masterRecBLL.Trainer_isExsiting(trainer.trainer_name))
            {
                return _iRepoTrainee.updateTrainer(trainer).ToString();
            }
            else
            {
                return "No Such a Record !";
            }
            
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepoTrainee.deleteTrainer(id);
        }
    }
}