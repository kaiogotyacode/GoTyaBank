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

        #region Post Methods
        [HttpPost]
        [Route("CreateLojista")]
        public async Task<IActionResult> CreateLojista([FromQuery] LojistaVM lojistaVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var lojista = await _usuarioComumRepository.CreateLojista(lojistaVM);

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
            return Ok();
        }

        #endregion Post Methods

        /// <summary>
        /// Busca um Usuário a partir de uma chave existente (CPF ou CNPJ).
        /// </summary>
        /// <param name="userID">CNPJ ou CPF do usuário.</param>
        /// <returns>Retorna uma mensagem validando se o usuário existe, e seu respectivo nome. </returns>
        [HttpGet]
        [Route("GetUserByID")]
        public async Task<IActionResult> GetUserByID([FromBody]string userID)
        {
            
            return Ok();
        }

    }
}
