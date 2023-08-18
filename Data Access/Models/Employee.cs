using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    public class Employee : ApplicationUser
    {
        public string Salary { get; set; }
        public string JobTitle { get; set; }

        [ForeignKey(nameof(Employee))]
        public string ManagerId { get; set; }
    }
}
