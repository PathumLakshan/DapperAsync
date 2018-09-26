using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Trainee
    {
        public int reg_id { get; set; }
        public string trainee_name { get; set; }
        public DateTime join_date { get; set; }
        public float no_of_hours { get; set; }
        public int cand_id { get; set; }
        public string training_type { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Training> Trainings { get; set; }
        

        [ForeignKey("cand_id")]
        public Candidate Candidate { get; set; }

    }
}
