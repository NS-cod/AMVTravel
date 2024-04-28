using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AMVTravelModels
{
    public class Client : IdentityUser
    {
        [DisplayName("User Name")]
        public override string? UserName { get => base.UserName; set => base.UserName = value; }
        public Collection<Booking>? Bookings { get; set; }
    }
}
