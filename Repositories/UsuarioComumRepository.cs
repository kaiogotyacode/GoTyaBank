using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories
{
    public class UsuarioComumRepository : IUsuarioComumRepository
    {
        private readonly PicPayContext picPayContext;
        public UsuarioComumRepository(PicPayContext picPayContext)
        {
            this.picPayContext = picPayContext;
        }

        public Usuario buscarUsuario(int idUsuario)
        {
            try
            {
                var usuario = picPayContext.Usuarios.Where(u => u.Id == idUsuario).FirstOrDefault();

                if (usuario == null)
                    throw new Exception();

                return usuario;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public IActionResult novoUsuario(Usuario usuario)
        {
            
        }

        public IActionResult Transferir(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
