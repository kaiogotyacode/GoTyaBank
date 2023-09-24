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

        public Usuario buscarUsuario(int idUsuario) => picPayContext.Usuarios.Where(u => u.Id == idUsuario).FirstOrDefault(new Usuario());



        public bool novoUsuario(Usuario usuario)
        {
            try
            {
                picPayContext.Usuarios.Add(usuario);
                picPayContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Transferir(int idPayer, int idPayee, decimal amount)
        {
            var payer = picPayContext.Usuarios.FirstOrDefault(x => x.Id == idPayer);
            var payee = picPayContext.Usuarios.FirstOrDefault(x => x.Id == idPayee);

            if (payer != null && payee != null) {
                if(payer.Saldo >=  amount)
                {
                    try
                    {
                        payer.Saldo -= amount;
                        payee.Saldo += amount;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
