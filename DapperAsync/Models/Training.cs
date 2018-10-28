using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Training
    {
        [Required]
        public int v_id { get; set; }

        [Required]
        public int trainer_id { get; set; }

        [Required]
        public int trainee_id { get; set; }

        [Required]
        public DateTime start_time { get; set; }

        [Required]
        public DateTime end_time { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string status { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public bool present { get; set; }

        [ForeignKey("trainee_id")]
        public Trainee Trainee { get; set; }

        [ForeignKey("v_id")]
        public Vehicle Vehicle { get; set; }

        [ForeignKey("trainer_id")]
        public Trainer Trainer { get; set; }
    }
}