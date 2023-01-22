using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Rifa_On.Data.Dtos;
using Rifa_On.Models;
using Rifa_On.Services.Interfaces;

namespace Rifa_On.Controllers
{
    public class UsuarioController : Controller
    {
        
        private ICadastroUsuarioService _CadastroUsuario;
        private ILoginUsuarioService _loginUsuarioServicelogin;

        public UsuarioController(ICadastroUsuarioService cadastroUsuario,
            ILoginUsuarioService loginUsuarioServicelogin)
        {
            _CadastroUsuario = cadastroUsuario;
            _loginUsuarioServicelogin = loginUsuarioServicelogin;
        }

        [HttpPost("/Usuario/Cadastrar")]
        public async Task<IActionResult> CadastraUsuario([FromBody]CreateUsuarioDto createUsuarioDto)
        {
            Result result = await _CadastroUsuario.CadastraUsuario(createUsuarioDto);

            if (result.IsSuccess) return Ok();

            return BadRequest(result);

        }
        [HttpPost("/Usuario/Login")]
        public async Task<IActionResult> LoginUsuario([FromBody] LoginUsuario loginUsuario)
        {
            var result = await  _loginUsuarioServicelogin.LoginUsuario(loginUsuario);

            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized("E-mail ou usuário inválidos !");

        }
        [HttpGet("/Usuario/AtivaConta")]
        public async Task<IActionResult> AtivaConta([FromQuery] AtivaContaUsuario ativaContaUsuario)
        {
            var result = await _CadastroUsuario.AtivaContaUsuario(ativaContaUsuario);

            if (result.IsSuccess) return Ok("Ativação concluída, a Rifa.On agradece sua confirmação e deseja uma boa sorte !");

            return BadRequest(result);
        }
    }
}
