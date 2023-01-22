using Rifa_On.Data.Dtos;
using Rifa_On.Models;

namespace Rifa_On.Services.Interfaces
{
    public interface ILoginUsuarioService
    {
        Task<Token> LoginUsuario(LoginUsuario loginUsuario);
    }
}
