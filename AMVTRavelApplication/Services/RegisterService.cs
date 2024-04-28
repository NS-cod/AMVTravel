using AMVTRavelApplication.Interfaces;
using AMVTravelModels;
using Microsoft.AspNetCore.Identity;

namespace AMVTRavelApplication.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<Client> userManager;

        public RegisterService(UserManager<Client> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> CreateAsync(Client client, string password)
        {
            try
            {
                
                var result = await userManager.CreateAsync(client, password);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Client> FindByEmailAsync(string mail)
        {
            try
            {
                var client =  await userManager.FindByEmailAsync(mail);
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<Client> FindByIdAsync(string id)
        {
            try
            {
                var client = await userManager.FindByIdAsync(id);
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
