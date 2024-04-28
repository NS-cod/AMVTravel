using AMVTravelModels;
using Microsoft.AspNetCore.Identity;

namespace AMVTRavelApplication.Interfaces
{
    public interface ILoginService
    {
        public Task<SignInResult> PasswordSignInAsync(Client client, string password, bool bolean, bool lockOutFailure);
    }
}
