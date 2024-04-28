using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;
using AMVTravelsRepositories.Implementation;
using AMVTravelsRepositories.Interfaces;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace AMVTRavelApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMappingService _mappingService;

        public BookingService (IBookingRepository bookingRepository, IMappingService mappingService)
        {
            _bookingRepository = bookingRepository;
            _mappingService = mappingService;
        }

        public async Task<BookingDTO> AddBookingAsync(BookingDTO bookingDTO)
        {
            try
            {
                var booking = _mappingService.MapBooking(bookingDTO);
                var bookingAdded = await _bookingRepository.Add(booking);

                var bookingAddedDTO = _mappingService.MapBookingDTO(bookingAdded);

                return bookingAddedDTO;

            }
            catch (Exception ex) { throw new Exception(ex.Message,ex); }
        }

        public async Task DeleteBookingAsync(BookingDTO bookingDTOId)
        {
            try
            {
                var bookingToDelete = _mappingService.MapBooking(bookingDTOId);
                await _bookingRepository.Delete(bookingToDelete);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<ICollection<BookingDTO>> GetAllBookingAsync()
        {
            try
            {
                var bookings = await _bookingRepository.GetAll();
                var bookingsDTO = new Collection<BookingDTO>();
                foreach (var booking in bookings)
                {
                    bookingsDTO.Add(_mappingService.MapBookingDTO(booking));
                }
                return bookingsDTO;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<BookingDTO> GetBookingById(string bookingDTOID)
        {
            try
            {
                var bookingGetted = await _bookingRepository.Get(bookingDTOID);
                var bookingGettedDTO = _mappingService.MapBookingDTO(bookingGetted);

                return bookingGettedDTO;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<BookingDTO> GetBookingByIdClient(string bookingDTOIdClient)
        {
            try
            {
                var bookingGetted = await _bookingRepository.Get(bookingDTOIdClient);
                if (bookingGetted == null)
                {
                    return null;
                }
                else
                {
                    var bookingGettedDTO = _mappingService.MapBookingDTO(bookingGetted);

                    return bookingGettedDTO;

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
