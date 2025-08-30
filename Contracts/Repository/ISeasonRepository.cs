using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

public interface ISeasonRepository : IRepositoryBase<Season>
{
    Task<Season?> GetByIdWithEpisodesAsync(long id);
    Task<IEnumerable<Season>> GetBySeriesIdAsync(long seriesId);
}
