using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMVTRavelApplication.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService tourService;


        public TourController(ITourService tourService)
        {
            this.tourService = tourService;
        }

        // GET: TourController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TourController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
            {

                return View(await tourService.GetTourById(id));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // GET: TourController/Create
        public ActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> GetAllTours()
        {
            try
            {
                var tours = await tourService.GetAllTours();

                return View(tours);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public ActionResult BookTour()
        {
            return View();
        }

        // POST: TourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(TourDTO tourDTO)
        {
            try
            {
                var addedTour =await tourService.AddTourAsync(tourDTO);
                return RedirectToAction("GetAllTours");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // GET: TourController/Edit/5
        public async Task <IActionResult> Edit(string id)
        {
            try
            {
                return View( await tourService.GetTourById(id));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // POST: TourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TourDTO tourDTO)
        {
            try
            {
                var tourEdited = await  tourService.EditTourAsync(tourDTO);
                return RedirectToAction("GetAllTours");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // GET: TourController/Delete/5
        public async Task <IActionResult> Delete(string id)
        {
            try
            {

                return View( await tourService.GetTourById(id));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // POST: TourController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TourDTO tourDTO)
        {
            try
            {
                await tourService.DeleteTourAsync(tourDTO);
                return RedirectToAction("GetAllTours");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
