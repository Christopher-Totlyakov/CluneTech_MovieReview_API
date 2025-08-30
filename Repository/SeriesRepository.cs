using Contracts.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class SeriesRepository : RepositoryBase<Series>, ISeriesRepository
{
    protected readonly RepositoryContext _context;
    public SeriesRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Series> GetSeriesWithReviewsAsync(long id)
    {
        return await _context.Series
            .Include(s => s.Reviews)
                .ThenInclude(r => r.User)
            .Include(s => s.Seasons)
                .ThenInclude(season => season.Episodes)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Series?> GetSeriesWithSeasonsAndEpisodesAsync(long id)
    {
        return await _context.Series
            .Include(s => s.Seasons)
                .ThenInclude(season => season.Episodes)
            .Include(s => s.Reviews)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}