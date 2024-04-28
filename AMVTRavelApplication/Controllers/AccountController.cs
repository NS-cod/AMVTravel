using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMVTRavelApplication.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IAccountManagerService accountManagerService;


        public AccountController(IAccountManagerService accountManagerService)
        {
            this.accountManagerService = accountManagerService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {

                var signInResult = await accountManagerService.SignInAsync(loginDTO);

                if (signInResult.Succeeded)
                {
                    var clientAdded = await accountManagerService.GetClientByEmailLoginAsync(loginDTO);
                    HttpContext.Session.SetString("Client", clientAdded.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Login", loginDTO);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {

            var result = await accountManagerService.RegisterAsync(registerDto);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Register", registerDto);
            }
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
