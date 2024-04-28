using AMVTravelDBContext;
using AMVTravelModels;
using AMVTravelsRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelsRepositories.Implementation
{
    public class BookingRepository : BaseRepository<Booking> ,IBookingRepository
    {
        private readonly AMVTravelDBContextIndentity _contextIndentity;

        public BookingRepository(AMVTravelDBContextIndentity  contextIndentity): base(contextIndentity)
        {
            this._contextIndentity = contextIndentity;
        }

        //public async Task<Booking> GetByIdClient(string idClient)
        //{
        //    try
        //    {
        //        var entity = await _contextIndentity.Set<Booking>().Where(booking => booking.IdClient == idClient).FirstOrDefaultAsync();

        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
