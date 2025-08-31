using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Auth;
public class RegisterDto
{
    [Required(ErrorMessage = "User name is required.")]
    [StringLength(ValidationConstants.UserNameMaxLength, MinimumLength = ValidationConstants.UserNameMinLength, 
            ErrorMessage = "User name must be between {2} and {1} characters.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(ValidationConstants.PasswordMaxLength, MinimumLength = ValidationConstants.PasswordMinLength,
        ErrorMessage = "Password must be between {2} and {1} characters.")]
    public string Password { get; set; } = null!;
}
