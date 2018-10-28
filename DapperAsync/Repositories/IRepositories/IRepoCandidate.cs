using DapperAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoCandidate
    {
        List<Candidate> GetCandidates();
        int AddNewCandidate(Candidate candidate);
        int updateCandidate(Candidate candidate);
        int deleteCandidate(int id);

        bool CandidatebyName(string name);
    }
}
