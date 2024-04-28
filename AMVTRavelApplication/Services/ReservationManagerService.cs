using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;
using System.Collections.ObjectModel;
using System.Transactions;

namespace AMVTRavelApplication.Services
{
    public class ReservationManagerService :IReservationManagerService
    {
        private readonly IBookingService bookingService;
        private readonly ITourService tourService;
        private readonly IAccountManagerService accountManagerService;
        private readonly IMappingService mappingService;
        

        public ReservationManagerService(IBookingService bookingService, ITourService tourService, IAccountManagerService accountManagerService, IMappingService mappingService)
        {
            this.bookingService = bookingService;
            this.tourService = tourService;
            this.accountManagerService = accountManagerService;
            this.mappingService = mappingService;
        }

        public async Task<BookingDTO> BookTour(string email, string idTour)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email)) { throw new ArgumentNullException(nameof(email)); }
                var client = await accountManagerService.GetClientByEmailLoginAsync(email);
                var existReserve = await bookingService.GetBookingByIdClient(client.Id);
                var tourDTO = await tourService.GetTourById(idTour,true);
                if (existReserve== null || existReserve != null && !existReserve.IdTour.Equals(tourDTO.id))
                {
                    var tour = mappingService.MapTour(tourDTO);

                    var bookingDTO = new BookingDTO
                    {
                        BookingDate = DateTime.UtcNow,
                        IdClient = client.Id,
                        IdTour = tour.ID,
                        id = Guid.NewGuid().ToString()
                    };
                    var bookingAddedDTO = await bookingService.AddBookingAsync(bookingDTO);

                    if (bookingAddedDTO == null) {
                        throw new NullReferenceException("It was not possible make the reserve");
                    }
                    else
                    {

                        return bookingAddedDTO;
                    }

                }
                else { 
                    throw new Exception("The reserve already exist");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public async Task<ICollection<BookingDTO>> GetAllBookingAsync()
        {
            try
            {
                var bookingsGetted = await bookingService.GetAllBookingAsync();
                foreach (var booking in bookingsGetted)
                {
                    booking.Client = await accountManagerService.GetClientByidAsync(booking.IdClient);
                    booking.Tour = mappingService.MapTour(await tourService.GetTourById(booking.IdTour,true));
                }

                return bookingsGetted;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<BookingDTO> GetBookingById(string bookingDTOID)
        {
            try
            {
                var bookingGetted = await bookingService.GetBookingById(bookingDTOID);
                bookingGetted.Client = await accountManagerService.GetClientByidAsync(bookingGetted.IdClient);
                bookingGetted.Tour = mappingService.MapTour(await tourService.GetTourById(bookingGetted.IdTour, true));

                return bookingGetted;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
