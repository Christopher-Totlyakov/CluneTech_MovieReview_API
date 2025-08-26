using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

/// <summary>
/// Application user that extends ASP.NET Core IdentityUser
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Date when the user registered
    /// </summary>
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Navigation: Reviews written by the user
    /// </summary>
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
