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
    public class CandidateController : ControllerBase
    {
        private readonly IRepoCandidate _iRepo;

        public CandidateController(IRepoCandidate iRepo)
        {
            _iRepo = iRepo;
        }

        // GET: api/Candidate
        [HttpGet]
        public List<Candidate> Get()
        {
            return _iRepo.GetCandidates();
        }

        // GET: api/Candidate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Candidate
        [HttpPost]
        public int Post([FromBody] Candidate candidate)
        {
           return _iRepo.AddNewCandidate(candidate);
        }

        // PUT: api/Candidate/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Candidate candidate)
        {
            return _iRepo.updateCandidate(candidate);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
