using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Models
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int trainee_id { get; set; }
        public DateTime paid_date { get; set; }
        public string remarks { get; set; }
        public int type_id { get; set; }
        public float amount { get; set; }

        [ForeignKey("trainee_id")]
        public Trainee Trainee { get; set; }

        [ForeignKey("type_id")]
        public Payment_Type Payment_Type { get; set; }
    }
}
