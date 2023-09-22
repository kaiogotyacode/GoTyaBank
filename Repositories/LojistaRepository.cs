using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories
{
    public class LojistaRepository : ILojistaRepository
    {
        public Usuario buscarLojista(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public IActionResult novoLojista(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
