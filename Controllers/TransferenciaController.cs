using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly IUsuarioComumRepository _usuarioComumRepository;
        private readonly ILojistaRepository _lojistaRepository;
        public TransferenciaController(IUsuarioComumRepository usuarioComumRepository, ILojistaRepository lojistaRepository)
        {
            _usuarioComumRepository = usuarioComumRepository;
            _lojistaRepository = lojistaRepository;
        }

      
        [HttpPost]
        [Route("CreateLojista")]
        public async Task<IActionResult> CreateLojista([FromBody] LojistaVM lojistaVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _lojistaRepository.GetLojistaByID(lojistaVM))
                    return Conflict(new { error = "UserID or E-mail already exists!", lojista = lojistaVM});

                var lojista = await _lojistaRepository.CreateLojista(lojistaVM);

                return Created("/API/[controller]/CreateLojista", lojista);
            }
            catch
            {
                return BadRequest(lojistaVM);
            }

        }

        [HttpPost]
        [Route("CreateUsuarioComum")]
        public async Task<IActionResult> CreateUsuarioComum(UsuarioComumVM usuarioComumVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (await _usuarioComumRepository.GetUsuarioComumByID(usuarioComumVM))
                    return Conflict(new { error = "UserID or E-mail already exists!", usuario = usuarioComumVM });

                var usuario = await _usuarioComumRepository.CreateUsuarioComum(usuarioComumVM);
                return Created("/API/[controller]/CreateUsuarioComum", usuario);

            }
            catch
            {
                return BadRequest(usuarioComumVM);
            }

        }

  
            

    }
}
