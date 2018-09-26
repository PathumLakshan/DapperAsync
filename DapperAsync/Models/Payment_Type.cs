using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Payment_Type
    {
        public int type_id { get; set; }
        public string paym_type { get; set; }
        public string desc  { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
