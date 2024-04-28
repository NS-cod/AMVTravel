using System.ComponentModel;

namespace AMVTRavelApplication.Models
{
    public class TourDTO
    {
        public required string id { get; set; }
        public required string Name { get; set; }
        public required string Cod { get; set; }
        public required string Destination { get; set; }
        public double Price { get; set; }
        [DisplayName("Start Date")]
        public  DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public  DateTime EndDate { get; set; }
        public  string? ClientId { get; set; }
    }
}
