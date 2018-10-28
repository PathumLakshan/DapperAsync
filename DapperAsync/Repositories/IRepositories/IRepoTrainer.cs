using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoTrainer
    {
        List<Trainer> GetTrainers();
        int NewTrainer(Trainer trainer);
        int updateTrainer(Trainer trainer);
        int deleteTrainer(int id);

        bool TrainerbyName(string name);
    }
}
