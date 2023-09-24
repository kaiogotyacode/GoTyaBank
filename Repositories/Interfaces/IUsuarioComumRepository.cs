using CodeChallenge02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface IUsuarioComumRepository
    {
        public bool novoUsuario(Usuario usuario); 
        public Usuario buscarUsuario(int idUsuario);
        public bool Transferir(int idPayer, int idPayee, decimal amount);
    }
}
