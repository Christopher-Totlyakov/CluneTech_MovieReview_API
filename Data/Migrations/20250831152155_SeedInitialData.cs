using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Director", "DurationMinutes", "Genre", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1L, 8.5, null, "John Doe", 120, "Action", "https://example.com/posters/adventure.jpg", new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), "The Great Adventure" },
                    { 2L, 7.7999999999999998, null, "Jane Smith", 95, "Romance", "https://example.com/posters/romance.jpg", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Romantic Evening" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "AverageRating", "Description", "Genre", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[] { 1L, 9.0, "A thrilling mystery series in a haunted mansion.", "Mystery", "https://example.com/posters/mystery.jpg", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Mystery Manor" });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "Description", "PosterUrl", "ReleaseDate", "SeasonNumber", "SeriesId", "Title" },
                values: new object[] { 1L, "The mystery begins.", "https://example.com/posters/mystery_s1.jpg", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, 1L, "Season One" });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "AirDate", "Description", "DurationMinutes", "EpisodeNumber", "SeasonId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "The first clues appear.", 45, 1, 1L, "The Arrival" },
                    { 2L, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Mysteries deepen in the manor.", 50, 2, 1L, "Hidden Secrets" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
