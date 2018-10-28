using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperAsync.Repositories.IRepositories;

namespace DapperAsync.BLL
{
    public interface IMasterRecBLL
    {
        bool Trainee_isExsiting(string name);
        bool Trainer_isExsiting(string name);
        bool Candidate_isExsiting(string name);
        bool Owner_isExsiting(string name);
        bool Vehicle_isExsiting(string name);

    }

    public class MasterRecBLL : IMasterRecBLL
    {
        private readonly IRepoTrainee _repoTrainee;
        private readonly IRepoTrainer _repoTrainer;
        private readonly IRepoCandidate _repoCandidate;
        private readonly IRepoOwner _repoOwner;
        private readonly IRepoVehicle _repoVehicle;
        //private readonly IRepoUser _repoUser;
        //private readonly IRepoRole _repoRole;

        public MasterRecBLL(
            IRepoTrainee repoTrainee,
            IRepoTrainer repoTrainer,
            IRepoCandidate repoCandidate,
            IRepoOwner repoOwner,
            IRepoVehicle repoVehicle)
        {
            _repoTrainee = repoTrainee;
            _repoTrainer = repoTrainer;
            _repoCandidate = repoCandidate;
            _repoOwner = repoOwner;
            _repoVehicle = repoVehicle;
        }

        public bool Candidate_isExsiting(string name)
        {
            if(_repoCandidate.CandidatebyName(name)) { return true; } else { return false; }
        }

        public bool Owner_isExsiting(string name)
        {
            if(_repoOwner.OwnerbyName(name)) { return true; } else { return false; }
        }

        public bool Trainee_isExsiting(string name)
        {
                if(_repoTrainee.TraineebyName(name) ) { return true; } else { return false; }       
        }

        public bool Trainer_isExsiting(string name)
        {
            if(_repoTrainer.TrainerbyName(name)) { return true; } else { return false; }
        }

        public bool Vehicle_isExsiting(string regNo)
        {
            if(_repoVehicle.VehiclebyRegNo(regNo)) { return true; } else { return false; }
        }
    }
}
