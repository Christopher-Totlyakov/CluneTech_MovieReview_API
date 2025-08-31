using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>
/// Provides functionality to create JWT tokens for authenticated users.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>
    /// Creates a JSON Web Token (JWT) for the specified authenticated user.
    /// </summary>
    /// <param name="user">The authenticated <see cref="ApplicationUser"/> for whom the token is generated.</param>
    /// <returns>
    /// A <see cref="string"/> representing the JWT.
    /// </returns>
    Task<string> CreateTokenAsync(ApplicationUser user);
}
