using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    public class Manager : ApplicationUser
    {
        public string ManagerId { get; set; }

        public string Department { get; set; }
    }
}
