using FluentResults;
using Rifa_On.Data.Dtos;
using Rifa_On.Models;

namespace Rifa_On.Services.Interfaces
{
    public interface ICadastroUsuarioService
    {
        Task<Result> CadastraUsuario(CreateUsuarioDto createUsuarioDto);
        Task<Result> AtivaContaUsuario(AtivaContaUsuario ativaContaUsuario);
    }
}
