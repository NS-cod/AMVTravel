using AMVTRavelApplication.Interfaces;
using AMVTravelModels;
using Microsoft.AspNetCore.Identity;

namespace AMVTRavelApplication.Services;

public class LoginService : ILoginService
{
    private readonly SignInManager<Client> signInManager;

    public LoginService(SignInManager<Client> signInManager)
    {
        this.signInManager = signInManager;
    }

    public async Task<SignInResult> PasswordSignInAsync(Client client, string password, bool bolean, bool lockOutFailure)
    {
        try
        {
            var result = await signInManager.PasswordSignInAsync(client, password, bolean, lockOutFailure);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}



