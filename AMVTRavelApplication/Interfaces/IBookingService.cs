using AMVTRavelApplication.Models;
using AMVTravelModels;
using AMVTravelsRepositories.Interfaces;
using System.Linq.Expressions;

namespace AMVTRavelApplication.Interfaces
{
    public interface IBookingService
    {
        public Task<BookingDTO> AddBookingAsync(BookingDTO bookingDTO);
        public Task<BookingDTO> GetBookingById(string bookingDTOId);
        public Task<BookingDTO> GetBookingByIdClient(string bookingDTOIdClient);
        public Task DeleteBookingAsync(BookingDTO bookingDTOId);
        public Task<ICollection<BookingDTO>> GetAllBookingAsync();
    }
}
