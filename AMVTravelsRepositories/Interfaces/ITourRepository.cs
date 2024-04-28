using AMVTravelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelsRepositories.Interfaces
{
    public interface ITourRepository : IBaseRepository<Tour>
    {
        public Task <Tour> GetByCod(Tour tour);
    }
}
