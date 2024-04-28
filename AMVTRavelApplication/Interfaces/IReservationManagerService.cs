using AMVTRavelApplication.Models;
using AMVTravelModels;

namespace AMVTRavelApplication.Interfaces
{
    public interface IReservationManagerService
    {
       
      
        public Task<BookingDTO> BookTour(string idClient, string idTour);

        public  Task<ICollection<BookingDTO>> GetAllBookingAsync();
        public Task<BookingDTO> GetBookingById(string bookingDTOID);


    }
}
