using AMVTRavelApplication.Models;
using AMVTravelModels;
using Microsoft.AspNetCore.Identity;

namespace AMVTRavelApplication.Interfaces
{
    public interface IAccountManagerService
    {
        public Task<SignInResult> SignInAsync(LoginDTO loginDTO);
        public Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO);
        public Task<Client> GetClientByEmailLoginAsync(LoginDTO loginDTO);
        public Task<Client> GetClientByEmailLoginAsync(RegisterDTO registerDTO);
        public Task<Client> GetClientByEmailLoginAsync(string email);
        public Task<Client> GetClientByidAsync(string id);

       
    }
}
