using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class DUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
