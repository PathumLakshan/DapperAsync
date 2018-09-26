using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;

namespace DapperAsync.Repositories
{
    public class TrainerRepo : IRepoTrainer
    {
        public List<Trainer> GetTrainers()
        {
            throw new NotImplementedException();
            //string sql = "select ";
        }

        public int NewTrainer(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public bool updateTrainer(Trainer trainer)
        {
            throw new NotImplementedException();
        }
    }
}
