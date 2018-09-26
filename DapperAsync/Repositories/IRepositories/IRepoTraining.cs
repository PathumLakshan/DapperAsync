using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    interface IRepoTraining
    {
        List<Training> GetTrainingSchedule();
        int newTrainingSchedule(Training training);
        bool updateTrainingSchedule(Training training);
    }
}
