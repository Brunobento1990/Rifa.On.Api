using Microsoft.AspNetCore.Identity;
using Rifa_On.Models;

namespace Rifa_On.Services.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(IdentityUser<int> user);
    }
}
