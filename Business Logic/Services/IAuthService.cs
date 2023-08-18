using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> SignUpAsync(string username, string email, string password, string confirmPassword,bool isManager);
        Task<IdentityResult> AddAdminAsync(string username, string password);
        Task<SignInResult> LogInAsync(string username, string password);
        Task LogOutAsync();
    }
}
