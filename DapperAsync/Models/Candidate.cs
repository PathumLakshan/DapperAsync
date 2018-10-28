using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Candidate
    {
        public int c_id { get; set; }
        public string c_name { get; set; }
        public int c_tele_no { get; set; }
        public string c_nic { get; set; }
        public string c_address { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}
