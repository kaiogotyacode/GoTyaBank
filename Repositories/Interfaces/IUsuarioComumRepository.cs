using CodeChallenge02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface IUsuarioComumRepository
    {
        public IActionResult novoUsuario(Usuario usuario); 
        public Usuario buscarUsuario(int idUsuario);
        public IActionResult Transferir(int idUsuario);
    }
}
