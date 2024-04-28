using AMVTravelModels;
using System.ComponentModel;

namespace AMVTRavelApplication.Models
{
    public class BookingDTO
    {
        public required string id { get; set; }
        public  Client? Client { get; set; }
        public required string IdClient { get; set; }
        public required string IdTour { get; set; }
        public  Tour? Tour { get; set; }
        [DisplayName("Booking Date")]
        public required DateTime BookingDate { get; set; }
    }
}
