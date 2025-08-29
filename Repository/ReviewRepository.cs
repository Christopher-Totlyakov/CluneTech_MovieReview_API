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
/// Repository for review management.
/// </summary>
public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
{
    protected readonly RepositoryContext _context;
    public ReviewRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetReviewsForMovieAsync(long movieId)
    {
        return await _context.Reviews
            .Where(r => r.MovieId == movieId)
            .Include(r => r.User)
            .ToListAsync();
    }
}