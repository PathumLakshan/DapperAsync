﻿using DapperAsync.Models;
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
        bool updateCandidate(Candidate candidate);
    }
}
