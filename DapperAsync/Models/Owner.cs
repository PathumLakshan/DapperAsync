using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Owner
    {
        public int owner_id { get; set; }
        public string owner_name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
