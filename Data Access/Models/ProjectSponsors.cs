using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models
{
    [PrimaryKey("ProjectId", "SponsorId")]
    public class ProjectSponsors
    {
        [ForeignKey(nameof(Project))]
        [Key]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(Sponsor))]
        [Key]
        public int SponsorId { get; set; }
    }
}
