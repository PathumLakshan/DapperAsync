using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoTraining
    {
        List<dynamic> GetTrainingSchedule();
        int newTrainingSchedule(Training training);
        int updateTrainingSchedule(Training training);
        int deleteTraining(int id);
    }
}
