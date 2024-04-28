using AMVTRavelApplication.Models;
using AMVTravelModels;
using AMVTravelsRepositories.Interfaces;

namespace AMVTRavelApplication.Interfaces
{
    public interface ITourService 
    {
        public  Task<Tour> AddTourAsync(TourDTO tourDTO);
        public  Task<ICollection<TourDTO>> GetAllTours();
        public Task<TourDTO> GetTourAsync(TourDTO tourDTO);
        public Task<TourDTO> EditTourAsync(TourDTO tourDTO);
        public Task DeleteTourAsync(TourDTO tourDTO);

        public Task<TourDTO> GetTourById(string id);
        public Task<TourDTO> GetTourById(string id, bool disableTracking);
     
      
    }
}
