using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    interface IRepoTrainer
    {
        List<Trainer> GetTrainers();
        int NewTrainer(Trainer trainer);
        bool updateTrainer(Trainer trainer);
    }
}
