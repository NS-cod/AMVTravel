using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTRavelApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMVTRavelApplication.Controllers
{
    public class BookingController : Controller
    {
        // GET: BookingController
        private readonly IBookingService _bookingService;
        private readonly IReservationManagerService _reservationManagerService;

        public BookingController(IBookingService bookingService, IReservationManagerService reservationManagerService)
        {
            this._bookingService = bookingService;
            this._reservationManagerService = reservationManagerService;
        }

        // GET: BookingController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                return View(await _reservationManagerService.GetBookingById(id));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
       
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookingsDTO = await _reservationManagerService.GetAllBookingAsync();

                return View(bookingsDTO);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tourId)
        {
            try
            {
                var clientEmail = HttpContext.Session.GetString("Client");
                var idTour = tourId;
                var bookDTO = await _reservationManagerService.BookTour(clientEmail, idTour);
                return RedirectToAction("GetAllBookings");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"]= ex.Message;

                return RedirectToAction("Error","Home");
            }
        }

        // GET: BookingController/Delete/5
        public async Task <IActionResult> Delete(string id)
        {
            try
            {
                return View(await _reservationManagerService.GetBookingById(id));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(BookingDTO bookingDTO)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(bookingDTO);
                return RedirectToAction("GetAllBookings");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
