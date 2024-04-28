using AMVTravelDBContext;
using AMVTravelModels;
using AMVTravelsRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelsRepositories.Implementation
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        private readonly AMVTravelDBContextIndentity _contextIndentity;

        public TourRepository(AMVTravelDBContextIndentity contextIndentity): base(contextIndentity)
        {
            _contextIndentity = contextIndentity;
        }

        public async Task<Tour> GetByCod(Tour tour)
        {
            var tourExist = await this._contextIndentity.Set<Tour>().Where( t=> t.Cod == tour.Cod).FirstOrDefaultAsync();
            return tourExist;
        }
    }
}
