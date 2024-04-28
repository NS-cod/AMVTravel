using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelModels
{
    public class Tour : BaseModel
    {
        public required String Name {  get; set; }
        public required String Cod {  get; set; }
        public required String Destination { get; set; }
        public required Double Price { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public Collection<Booking>? Bookings { get; set; }


    }
}
