using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;


public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IJwtTokenService _jwt;

    public AuthService(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager,
                       IJwtTokenService jwt)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwt = jwt;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.UserName))
            throw new ValidationException("Username is required.");
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ValidationException("Email is required.");
        if (string.IsNullOrWhiteSpace(dto.Password) || dto.Password.Length < 6)
            throw new ValidationException("Password must be at least 6 characters.");

        var existing = await _userManager.FindByNameAsync(dto.UserName);
        if (existing != null) throw new ValidationException("Username already taken.");

        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            RegisteredAt = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new ValidationException(errors);
        }
        // await _userManager.AddToRoleAsync(user, "User");

        var token = await _jwt.CreateTokenAsync(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            UserName = user.UserName!,
            Email = user.Email!,
            Token = token
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password))
            throw new ValidationException("Username and password are required.");

        var user = await _userManager.FindByNameAsync(dto.UserName);
        if (user == null) throw new KeyNotFoundException("User not found.");

        var check = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);
        if (!check.Succeeded) throw new UnauthorizedAccessException("Invalid credentials.");

        var token = await _jwt.CreateTokenAsync(user);

        return new AuthResponseDto
        {
            UserId = user.Id,
            UserName = user.UserName!,
            Email = user.Email!,
            Token = token
        };
    }
}