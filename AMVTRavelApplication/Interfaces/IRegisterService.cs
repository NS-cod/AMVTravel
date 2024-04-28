using AMVTravelModels;
using Microsoft.AspNetCore.Identity;

namespace AMVTRavelApplication.Interfaces
{
    public interface IRegisterService
    {

        public Task<IdentityResult> CreateAsync(Client client, string password);
        public Task<Client> FindByEmailAsync(string mail);
        public Task<Client> FindByIdAsync(string id);
    }
}
