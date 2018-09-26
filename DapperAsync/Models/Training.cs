using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Training
    {
        public int v_id { get; set; }
        public int trainer_id { get; set; }
        public int trinee_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public bool present { get; set; }

        [ForeignKey("trainee_id")]
        public Trainee Trainee { get; set; }
        [ForeignKey("v_id")]
        public Vehicle Vehicle { get; set; }
    }
}