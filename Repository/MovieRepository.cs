using Contracts.Repository;
using Entities;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository;


/// <summary>
/// Repository for movie management.
/// </summary>
public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    protected readonly RepositoryContext _context;
    public MovieRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movie?> GetMovieWithReviewsAsync(int movieId)
    {
        return await _context.Movies
            .Include(m => m.Reviews)
            .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(m => m.Id == movieId);
    }
}