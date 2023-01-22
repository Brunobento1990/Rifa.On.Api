using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rifa_On.Data.Dtos;
using Rifa_On.Models;
using Rifa_On.Services.Interfaces;
using System.Web;

namespace Rifa_On.Services.Classes
{
    public class CadastroUsuarioService : ICadastroUsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private IEmailService _emailService;
        public CadastroUsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, IEmailService emailService = null)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<Result> AtivaContaUsuario(AtivaContaUsuario ativaContaUsuario)
        {
            var identityUser = await _userManager
                .Users.
                FirstOrDefaultAsync(x => x.Id == ativaContaUsuario.Id);

            var identityResult = await _userManager
                .ConfirmEmailAsync(identityUser, ativaContaUsuario.CodigoAtivacao);

            if (identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Não foi possível ativar sua conta, tente novamente mais tarde !");
        }

        public async Task<Result> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(createUsuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            var result = await _userManager.CreateAsync(usuarioIdentity, createUsuarioDto.Password);

            if (result.Succeeded) 
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);

                var encode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new string[] { usuarioIdentity.Email }, "Link de ativação"
                    , usuarioIdentity.Id, encode);

                return Result.Ok();

            };

            return Result.Fail("Ocorreu algum erro ao cadastrar o usuário, tente novamente mais tarde!");

        }
    }
}
