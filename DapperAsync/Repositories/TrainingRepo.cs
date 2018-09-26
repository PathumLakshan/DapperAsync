using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;
using DapperAsync.Repositories.IRepositories;

namespace DapperAsync.Repositories
{
    public class TrainingRepo : IRepoTraining
    {
        public List<Training> GetTrainingSchedule()
        {
            throw new NotImplementedException();
        }

        public int newTrainingSchedule(Training training)
        {
            throw new NotImplementedException();
        }

        public bool updateTrainingSchedule(Training training)
        {
            throw new NotImplementedException();
        }
    }
}
