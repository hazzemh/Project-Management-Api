using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models
{
    [PrimaryKey("SponsorId", "PhoneNumber")]
    public class SponsorPhones
    {
        [ForeignKey(nameof(Sponsor))]
        [Key]
        public int SponsorId { get; set; }

        [Key]
        public string PhoneNumber { get; set;}
    }
}
