using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "The Great Adventure", ReleaseDate = new DateTime(2022, 5, 20, 0, 0, 0, DateTimeKind.Utc), Genre = "Action", Director = "John Doe", DurationMinutes = 120, AverageRating = 8.5, PosterUrl = "https://example.com/posters/adventure.jpg" },
            new Movie { Id = 2, Title = "Romantic Evening", ReleaseDate = new DateTime(2021, 2, 14, 0, 0, 0, DateTimeKind.Utc), Genre = "Romance", Director = "Jane Smith", DurationMinutes = 95, AverageRating = 7.8, PosterUrl = "https://example.com/posters/romance.jpg" }
        );

        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 1, Title = "Mystery Manor", ReleaseDate = new DateTime(2023, 1, 10, 0, 0, 0, DateTimeKind.Utc), Genre = "Mystery", AverageRating = 9.0, PosterUrl = "https://example.com/posters/mystery.jpg", Description = "A thrilling mystery series in a haunted mansion." }
        );

        modelBuilder.Entity<Season>().HasData(
            new Season { Id = 1, SeriesId = 1, SeasonNumber = 1, Title = "Season One", ReleaseDate = new DateTime(2023, 1, 10, 0, 0, 0, DateTimeKind.Utc), PosterUrl = "https://example.com/posters/mystery_s1.jpg", Description = "The mystery begins." }
        );

        modelBuilder.Entity<Episode>().HasData(
            new Episode { Id = 1, SeasonId = 1, EpisodeNumber = 1, Title = "The Arrival", AirDate = new DateTime(2023, 1, 10, 0, 0, 0, DateTimeKind.Utc), DurationMinutes = 45, Description = "The first clues appear." },
            new Episode { Id = 2, SeasonId = 1, EpisodeNumber = 2, Title = "Hidden Secrets", AirDate = new DateTime(2023, 1, 17, 0, 0, 0, DateTimeKind.Utc), DurationMinutes = 50, Description = "Mysteries deepen in the manor." }
        );
    }

}

