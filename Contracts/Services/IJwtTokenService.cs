using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services;

/// <summary>Creates JWT tokens for authenticated users.</summary>
public interface IJwtTokenService
{
    Task<string> CreateTokenAsync(ApplicationUser user);
}
