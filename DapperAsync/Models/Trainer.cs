using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Trainer
    {
        public int trainer_id { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public string trainer_name { get; set; }

        [Required, MaxLength(20), MinLength(10)]
        public string trainer_nic { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public string trainer_address { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
