using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    [PrimaryKey("EmployeeId", "ProjectId", "Name")]
    public class TaskProgress
    {
        [ForeignKey(nameof(Employee))]
        [Key]
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(Project))]
        [Key]
        public int ProjectId { get; set; }

        [Key]
        public string Name { get; set; }

        public int Hours { get; set; }
    }
}
