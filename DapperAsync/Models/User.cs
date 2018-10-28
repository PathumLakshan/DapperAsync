using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class User
    {
        public int userId { get; set; }

        [Required,MaxLength(30),MinLength(5)]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int roleId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required,MaxLength(20),MinLength(10)]
        public string nic { get; set; }

        [ForeignKey("roleId")]
        public Role Role { get; set; }
    }
}
