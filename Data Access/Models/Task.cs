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
    [PrimaryKey("ProjectId", "Name")]
    public class Task
    {
        [ForeignKey(nameof(Project))]
        [Key]
        public int ProjectId { get; set; }

        [Key]
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
    }
}
