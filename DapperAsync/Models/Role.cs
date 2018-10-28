using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAsync.Models
{
    public class Role
    {
        public int roleId { get; set; }
        [Required,MaxLength(15),MinLength(10)]
        public string roleDesc { get; set; }

        public List<User> Users { get; set; }
    }
}
