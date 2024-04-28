using AMVTravelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelsRepositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        public Task<Booking> GetByIdClient(string idClient);
    }
}
