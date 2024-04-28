using AMVTRavelApplication.Models;
using AMVTravelModels;

namespace AMVTRavelApplication.Interfaces
{
    public interface IMappingService
    {
        public Tour MapTour(TourDTO tourDTO);
        public TourDTO MapTourDTO(Tour tour);
        public Booking MapBooking(BookingDTO bookingDTO);
        public BookingDTO MapBookingDTO(Booking booking);
       
    }
}
