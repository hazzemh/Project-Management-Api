using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Role { get; set; }
    }
}
