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
public class EpisodeRepository : RepositoryBase<Episode>, IEpisodeRepository
{
    private readonly RepositoryContext _context;

    public EpisodeRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Episode>> GetBySeasonIdAsync(long seasonId)
    {
        return await _context.Episodes
            .Where(e => e.SeasonId == seasonId)
            .ToListAsync();
    }
}
