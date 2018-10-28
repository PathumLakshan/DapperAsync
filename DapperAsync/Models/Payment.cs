using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DapperAsync.Models;

namespace DapperAsync.Models
{
    public class Payment
    {
        [Required]
        public int payment_id { get; set; }

        [Required]
        public int trainee_id { get; set; }

        [Required]
        public DateTime paid_date { get; set; }

        [MaxLength(20),MinLength(10)]
        public string remarks { get; set; }

        [Required]
        public int type_id { get; set; }

        [Required,Range(100.0,100000.0)]
        public float amount { get; set; }

        [ForeignKey("trainee_id")]
        public Trainee Trainee { get; set; }

        [ForeignKey("type_id")]
        public Payment_Type Payment_Type { get; set; }
    }
}
