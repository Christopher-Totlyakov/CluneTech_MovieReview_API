using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;
  public static class IdentitySeedExtensions
    {
        public static async Task SeedUsersAndReviewsAsync<TContext>(this IServiceProvider serviceProvider)
            where TContext : DbContext
        {
            var context = serviceProvider.GetRequiredService<TContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var userId = "a5e9f530-da01-48a2-9ed8-a3e0c9341640";

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Id = userId,
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "YourSecurePassword123!");
            }

            if (!context.Set<Review>().Any())
            {
                context.Set<Review>().AddRange(
                    new Review { Id = 1, MovieId = 1, UserId = userId, Comment = "Absolutely loved it!", Rating = 9, CreatedAt = DateTime.UtcNow },
                    new Review { Id = 2, MovieId = 2, UserId = userId, Comment = "Sweet and heartwarming.", Rating = 8, CreatedAt = DateTime.UtcNow },
                    new Review { Id = 3, SeriesId = 1, UserId = userId, Comment = "Can't wait for the next episode!", Rating = 10, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }
        }
    }
