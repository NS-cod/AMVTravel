using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelModels
{
    public class Booking : BaseModel
    {
        public  Client? Client { get; set; }
        public required string IdClient { get; set; }
        public required string IdTour { get; set; }
        public  Tour? Tour { get; set; }
        public required DateTime BookingDate { get; set; }
    }
}
