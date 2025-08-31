using Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Defines authentication-related operations such as registration and login.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Registers a new user with the specified registration details.
    /// </summary>
    /// <param name="dto">The registration information.</param>
    /// <returns>
    /// An <see cref="AuthResponseDto"/> containing authentication data if registration is successful.
    /// </returns>
    Task<AuthResponseDto> RegisterAsync(RegisterDto dto);

    /// <summary>
    /// Authenticates a user with the specified login credentials.
    /// </summary>
    /// <param name="dto">The login credentials.</param>
    /// <returns>
    /// An <see cref="AuthResponseDto"/> containing authentication data if login is successful.
    /// </returns>
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
}
