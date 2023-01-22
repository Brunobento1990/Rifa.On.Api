using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rifa_On.Data.Dtos;
using Rifa_On.Models;
using Rifa_On.Services.Interfaces;

namespace Rifa_On.Services.Classes
{
    public class LoginUsuarioService : ILoginUsuarioService
    {
        private SignInManager<IdentityUser<int>> _singInManager;
        private ITokenService _tokenService;


        public LoginUsuarioService(SignInManager<IdentityUser<int>> singInManager, ITokenService tokenService = null)
        {
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        public async Task<Token> LoginUsuario(LoginUsuario loginUsuario)
        {
            try
            {
                var resultIdentity = await _singInManager.PasswordSignInAsync(
                loginUsuario.UserName, loginUsuario.Password, false, false);

                if (resultIdentity.Succeeded)
                {
                    var identityUser = await _singInManager
                    .UserManager
                    .Users
                    .FirstOrDefaultAsync
                    (x => x.NormalizedUserName == loginUsuario.UserName.ToUpper());

                    var token = _tokenService.CreateToken(identityUser);
                    token.Id = identityUser.Id;
                    return token;

                };

            }
            catch (Exception)
            {
                return null;
            }

            return null;

        }
    }
}
