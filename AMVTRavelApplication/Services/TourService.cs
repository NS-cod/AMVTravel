using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;
using AMVTravelsRepositories.Implementation;
using AMVTravelsRepositories.Interfaces;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace AMVTRavelApplication.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository tourRepository;
        private readonly IMappingService mappingService;
        public TourService(ITourRepository TourRepository, IMappingService mappingService)
        {
            this.tourRepository = TourRepository;
            this.mappingService = mappingService;
        }
        public async Task<Tour> AddTourAsync(TourDTO tourDTO)
        {
            try
            {
                var tour = mappingService.MapTour(tourDTO);
                var tourExist = await tourRepository.GetByCod(tour);
                if (tourExist != null)
                {
                    throw new Exception("Already exist a Tour with this cod");
                }
                else
                {
                    var addedTour = await tourRepository.Add(tour);
                    return addedTour;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteTourAsync(TourDTO tourDTO)
        {
            try
            {
                var tourToDelete = mappingService.MapTour(tourDTO);
                await tourRepository.Delete(tourToDelete);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public async Task<TourDTO> EditTourAsync(TourDTO tourDTO)
        {
            try
            {
                var tour = mappingService.MapTour(tourDTO);
                var tourExistBy = await tourRepository.GetAsync(t => t.Cod == tour.Cod && t.ID != tour.ID,true);
                if (tourExistBy.Count>0)
                {
                    throw new Exception("the cod already exist");
                }
                tour.UpdatedDate = DateTime.Now;
                var tourEdited = await tourRepository.Update(tour);
                if (tourEdited != null)
                {
                    var tourEditedDTO = mappingService.MapTourDTO(tourEdited);

                    return tourEditedDTO;
                }
                else
                {
                    throw new Exception("The tour cannot be updated");
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public async Task<ICollection<TourDTO>> GetAllTours()
        {
            try
            {

                var tours = await tourRepository.GetAll();
                var toursDTO = new Collection<TourDTO>();
                foreach (var tour in tours)
                {
                    var tourDto = mappingService.MapTourDTO(tour);
                    toursDTO.Add(tourDto);
                }
                return toursDTO;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public async Task<TourDTO> GetTourAsync(TourDTO tourDTO)
        {
            try
            {
                var tour = mappingService.MapTour(tourDTO);
                var tourGeted =  await tourRepository.Get(tour.ID);
                var tourGetedDTO = mappingService.MapTourDTO(tourGeted);
                return tourGetedDTO;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public async Task<TourDTO> GetTourById(string id)
        {
            try
            {
                var tour = await tourRepository.Get(id);
                var tourDTO = mappingService.MapTourDTO(tour);
                return tourDTO;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }

        public async Task<TourDTO> GetTourById(string id, bool disableTracking)
        {
            try
            {
                var tour = await tourRepository.Get(id,disableTracking);
                var tourDTO = mappingService.MapTourDTO(tour);
                return tourDTO;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }
    }
}
