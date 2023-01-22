using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Rifa_On.Data.Dtos;
using Rifa_On.Models;

namespace Rifa_On.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
