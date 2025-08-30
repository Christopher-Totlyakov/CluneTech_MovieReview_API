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

public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
{
    private readonly RepositoryContext _context;

    public SeasonRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Season?> GetByIdWithEpisodesAsync(long id)
    {
        return await _context.Seasons
            .Include(s => s.Episodes)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Season>> GetBySeriesIdAsync(long seriesId)
    {
        return await _context.Seasons
            .Where(s => s.SeriesId == seriesId)
            .Include(s => s.Episodes)
            .ToListAsync();
    }
}
