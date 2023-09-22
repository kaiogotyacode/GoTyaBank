using CodeChallenge02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface ILojistaRepository
    {
        public IActionResult novoLojista(Usuario usuario); 
        public Usuario buscarLojista(int idUsuario);       
    }
}
