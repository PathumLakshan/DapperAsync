using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Owner
    {
        public int owner_id { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public string owner_name { get; set; }

        [Required, MaxLength(20), MinLength(10)]
        public string owner_nic { get; set; }

        [Required, MaxLength(50), MinLength(10)]
        public string owner_address { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
