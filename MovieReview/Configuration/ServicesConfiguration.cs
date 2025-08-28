using Contracts.Repository;
using Contracts.Services;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repository;
using Services;
using System.ComponentModel.Design;

namespace MovieReview.Configuration;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

    }
}
