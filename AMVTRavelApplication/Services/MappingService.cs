using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;

namespace AMVTRavelApplication.Services
{
    public class MappingService : IMappingService
    {
      
        public Booking MapBooking(BookingDTO bookingDTO)
        {
            try
            {
                if (bookingDTO !=null)
                {
                    Booking booking = new Booking { 
                     BookingDate = bookingDTO.BookingDate,
                     Client= bookingDTO.Client,
                     IdClient = bookingDTO.IdClient,
                     ID = bookingDTO.id ?? Guid.NewGuid().ToString(),
                     Tour = bookingDTO.Tour,
                     IdTour = bookingDTO.IdTour,
                    CreatedDate = DateTime.Now,
                    };
                    return booking;

                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch(Exception ex) {
               
                throw new Exception(ex.Message, ex); };
        }

        public BookingDTO MapBookingDTO(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    BookingDTO bookingDTO = new BookingDTO
                    {
                        BookingDate = booking.BookingDate,
                        Client = booking.Client,
                        IdClient = booking.IdClient,
                        id = booking.ID,
                        Tour = booking.Tour,
                        IdTour = booking.IdTour,
                    };
                    return bookingDTO;
                    
                }
                else
                {
                    throw new NullReferenceException();
                }

            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); };
        }

        public Tour MapTour(TourDTO tourDTO)
        {
            try
            {
                if (tourDTO != null)
                {
                    Tour tour = new Tour
                    {

                        ID = tourDTO.id == null ? Guid.NewGuid().ToString() : tourDTO.id,
                        Destination = tourDTO.Destination,
                        EndDate = tourDTO.EndDate,
                        Name = tourDTO.Name,
                        Price = tourDTO.Price,
                        StartDate = tourDTO.StartDate,
                        CreatedDate = DateTime.Now,
                        Cod = tourDTO.Cod

                    };
                    return tour;

                }
                else { throw new NullReferenceException(); }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public TourDTO MapTourDTO(Tour tour)
        {
            try
            {
                if (tour != null)
                {
                    var tourDTO = new TourDTO
                    {
                        id = tour.ID,
                        Destination = tour.Destination,
                        EndDate = tour.EndDate,
                        Name = tour.Name,
                        Price = tour.Price,
                        StartDate = tour.StartDate,
                        Cod = tour.Cod
                    };
                    return tourDTO;

                }
                else
                {
                    throw new NullReferenceException();
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

      
    }
}
