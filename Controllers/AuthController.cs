using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic.Services;
using Project_Management_Api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Project_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService _authService)
        {
            this._authService = _authService;
        }

        [HttpPost("Sign-Up")]
        public async Task<IActionResult> SignUp(SignUpDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }
            var result = await _authService.SignUpAsync(dto.Username, dto.Email, dto.Password, dto.ConfirmPassword,dto.isManager);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("Add-Admin")]
        public async Task<IActionResult> AddAdmin(AdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(errors);
            }
            var result = await _authService.AddAdminAsync(dto.Username,dto.Password);
            if (result.Succeeded)
            {
                return Ok("Admin registered successfully");
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(errors);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login( LoginDto dto)
        {
            var result = await _authService.LogInAsync(dto.Username, dto.Password);
            if (result.Succeeded)
            {
                return Ok("User logged in successfully");
            }
            else
            {
                return BadRequest("Invalid Username or Password");
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await _authService.LogOutAsync();
            return Ok("User logged out successfully");
        }
    }
}
