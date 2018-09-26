using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Vehicle
    {
        public int v_id { get; set; }
        public string v_reg { get; set; }
        public int owner_id { get; set; }
        public string description { get; set; }
        
        public string owner_name { get; set; }

        [ForeignKey("owner_id")]
        public Owner Owner { get; set; }

        public List<Training> Trainings { get; set; }
    }
}
