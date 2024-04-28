using AMVTRavelApplication.Interfaces;
using AMVTRavelApplication.Models;
using AMVTravelModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AMVTRavelApplication.Services
{
    public class AccountManagerService : IAccountManagerService
    {
        private readonly IRegisterService userManager;
        private readonly ILoginService signInManager;

        public AccountManagerService(IRegisterService userManager, ILoginService signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Client> GetClientByEmailLoginAsync(LoginDTO loginDTO)
        {
            var client = await userManager.FindByEmailAsync(loginDTO.Email);
            return client;
        }

        public async Task<Client> GetClientByEmailLoginAsync(RegisterDTO registerDTO)
        {
            var client = await userManager.FindByEmailAsync(registerDTO.Email);
            return client;
        }
         public async Task<Client> GetClientByEmailLoginAsync(string email)
        {
            var client = await userManager.FindByEmailAsync(email);
            return client;
        }

        public Task<Client> GetClientByidAsync(string id)
        {
            var client = userManager.FindByIdAsync(id);
            return client;
        }

        public Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var client = new Client
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Name
            };
            var result = userManager.CreateAsync(client, registerDTO.Password);
            return result;
        }

        public async Task<SignInResult> SignInAsync(LoginDTO loginDTO)
        {
            if (!ValidateModel(loginDTO))
                return SignInResult.Failed;

            var client = await userManager.FindByEmailAsync(loginDTO.Email);

            if (client == null)
                return SignInResult.Failed;

            return await signInManager.PasswordSignInAsync(client, loginDTO.Password, false, false);
        }

        private bool ValidateModel(LoginDTO loginDTO)
        {
            if (!new EmailAddressAttribute().IsValid(loginDTO.Email))
                return false;

            if (string.IsNullOrWhiteSpace(loginDTO.Password))
                return false;

            return true;
        }

        
    }
}
