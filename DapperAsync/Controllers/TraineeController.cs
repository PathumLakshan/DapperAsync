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
    public class TraineeController : ControllerBase
    {
        private readonly IRepoTrainee _iRepoTrainee;
        private readonly IMasterRecBLL _masterRecBLL;

        public TraineeController(IRepoTrainee iRepoTrainee, IMasterRecBLL masterRecBLL)
        {
            _iRepoTrainee = iRepoTrainee;
            _masterRecBLL = masterRecBLL;
        }

        [HttpGet]
        public List<Trainee> GetAll()
        {
            return _iRepoTrainee.GetTrainees();
        }

        [HttpPost]
        public string Post([FromBody] Trainee trainee)
        {
            if (!_masterRecBLL.Trainee_isExsiting(trainee.trainee_name))
            {
                return _iRepoTrainee.NewTrainee(trainee).ToString();
            }
            else
            {
                return "Record Already Exists !";
            }
        }

        [HttpPut]
        public string Put([FromBody] Trainee trainee)
        {
            if (_masterRecBLL.Trainee_isExsiting(trainee.trainee_name))
            {
                return _iRepoTrainee.updateTrainee(trainee).ToString();
            }
            else
            {
                return "No Such a Record !";
            }

        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepoTrainee.deleteTrainee(id);
        }

    }
}