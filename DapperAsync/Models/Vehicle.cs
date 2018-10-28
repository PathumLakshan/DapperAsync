using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Vehicle
    {
        public int v_id { get; set; }

        [Required, MaxLength(10), MinLength(6)]
        public string v_reg { get; set; }

        [Required]
        public int owner_id { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public string description { get; set; }

        [ForeignKey("owner_id")]
        public Owner Owner { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
