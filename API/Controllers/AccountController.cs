using API.DTOs;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager, TokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new AppUser
        {
            UserName = dto.Username,
            FullName = dto.FullName,
            Email = dto.Email
        };

        var result = await userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var role = string.IsNullOrWhiteSpace(dto.Role) ? "Student" : dto.Role;
        await userManager.AddToRoleAsync(user, role);

        var token = await tokenService.CreateTokenAsync(user, userManager);

        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await userManager.FindByNameAsync(dto.Username);
        if (user == null) return Unauthorized("Invalid credentials");

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded) return Unauthorized("Invalid credentials");

        var token = await tokenService.CreateTokenAsync(user, userManager);

        return Ok(new { token });
    }
}
