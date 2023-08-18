using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.Models;
using Data_Access.Repository;


namespace Business_Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
        public async Task<IdentityResult> SignUpAsync(string username, string email, string password, string confirmPassword, bool isManager)
        {
            if (password != confirmPassword)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Passwords do not match." });
            }

            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Username already exists." });
            }

            var employee = new Employee
            {
                UserName = username,
                Email = email,
                Salary = "Default",
                JobTitle = "Default",
                ManagerId = null,
                Role = isManager ? "Manager" : "Employee" // Set the discriminator value
            };


            var result = await _userManager.CreateAsync(employee, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, employee.Role);
            }

            return result;
        }

        public async Task<IdentityResult> AddAdminAsync(string username , string password)
        {
            var user = new ApplicationUser { UserName = username};

            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Username already exists." });
            }

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                    await _userManager.AddToRoleAsync(user, "Admin");
            }
            return result;
        }
        public async Task<SignInResult> LogInAsync(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, true, false);
        }
        public async System.Threading.Tasks.Task LogOutAsync()
        {
             await _signInManager.SignOutAsync();
        }
    }
}

