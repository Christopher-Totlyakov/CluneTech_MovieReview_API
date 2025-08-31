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
    [StringLength(50, MinimumLength = 3, ErrorMessage = "User name must be between 3 and 50 characters.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; } = null!;
}
