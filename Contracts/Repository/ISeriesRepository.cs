using Contracts.Repository.Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository;

public interface ISeriesRepository : IRepositoryBase<Series>
{
    Task<Series?> GetSeriesWithReviewsAsync(long id);
    Task<Series?> GetSeriesWithSeasonsAndEpisodesAsync(long id);
}
