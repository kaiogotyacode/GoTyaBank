using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly IUsuarioComumRepository _usuarioComumRepository;
        public TransferenciaController(IUsuarioComumRepository usuarioComumRepository)
        {
            _usuarioComumRepository = usuarioComumRepository;
        }

        [HttpPost]
        [Route("novoUsuario")]
        public IActionResult novoUsuario([FromQuery] NovoUsuarioVM usuario)
        {
            try
            {
                if (ModelState.IsValid)
                    _usuarioComumRepository.novoUsuario(
                        new UsuarioComum
                        {
                            Nome = usuario.Nome,
                            Email = usuario.Email,
                            CPF = usuario.CPF,
                            CNPJ = usuario.CNPJ,
                            isPessoaFisica = usuario.isPessoaFisica
                        });

                return Ok(new {message = "User successfully created!", usuario = usuario});

            }
            catch
            {
                return BadRequest(usuario);
            }

        }
    }
}
