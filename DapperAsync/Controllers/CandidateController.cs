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
    public class CandidateController : ControllerBase
    {
        private readonly IRepoCandidate _iRepo;
        private readonly IMasterRecBLL _masterRecBLL;

        public CandidateController(IRepoCandidate iRepo, IMasterRecBLL masterRecBLL)
        {
            _iRepo = iRepo;
            _masterRecBLL = masterRecBLL;
        }

        // GET: api/Candidate
        [HttpGet]
        public List<Candidate> Get()
        {
            return _iRepo.GetCandidates();
        }

        // GET: api/Candidate/5
       /* [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Candidate
        [HttpPost]
        public string Post([FromBody] Candidate candidate)
        {
            if (!_masterRecBLL.Candidate_isExsiting(candidate.c_name))
            {
                return _iRepo.AddNewCandidate(candidate).ToString();
            }
            else { return "Record Already Exists !"; }
        }

        // PUT: api/Candidate/5
        [HttpPut("{id}")]
        public string Put([FromBody] Candidate candidate)
        {
            if (_masterRecBLL.Candidate_isExsiting(candidate.c_name))
            {
                return _iRepo.updateCandidate(candidate).ToString();
            }
            else { return "No Such a Record!"; }
          
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _iRepo.deleteCandidate(id);
        }
    }
}
