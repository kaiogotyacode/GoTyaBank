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
        public async Task<IActionResult> novoUsuario([FromBody] NovoUsuarioVM usuarioVM)
        {

            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = usuarioVM.Nome,
                    Email = usuarioVM.Email,
                    CPF = usuarioVM.CPF,
                    CNPJ = usuarioVM.CNPJ,
                    isPessoaFisica = usuarioVM.IsPessoaFisica
                };

                if (usuario.isPessoaFisica)
                    usuario.CNPJ = null;
                else
                    usuario.CPF = null;

                try
                {
                    if (await _usuarioComumRepository.novoUsuario(usuario))
                        return Created("/API/[controller]/novoUsuario", usuario);
                }
                catch
                {
                    return BadRequest(usuarioVM);
                }

            }

            return BadRequest(usuarioVM);
        }

        [HttpPost]
        [Route("transferir")]
        public async Task<IActionResult> Transferir([FromBody] TransferenciaVM transferenciaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _usuarioComumRepository.Transferir(transferenciaVM))
                        return Accepted("/API/[controller]/transferir", transferenciaVM);

                }
                catch
                {
                    return BadRequest(new { message = "Erro ao realizar a transferência!", transferencia = transferenciaVM});
                }
            }

            return BadRequest(new { message = "Por favor, verifique os dados de ambos, tal como o valor da transferência e tente novamente!", transferencia = transferenciaVM });

        }
    }
}
