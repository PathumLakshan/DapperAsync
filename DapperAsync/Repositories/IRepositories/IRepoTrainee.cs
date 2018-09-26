using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Repositories.IRepositories
{
    public interface IRepoTrainee
    {
        List<Trainee> GetTrainees();
        int NewTrainee(Trainee trainee);
        int updateTrainee(Trainee trainee);
    }
}
