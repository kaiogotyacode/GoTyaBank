using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge02.Repositories
{
    public class UsuarioComumRepository : IUsuarioComumRepository
    {
        private readonly PicPayContext picPayContext;
        public UsuarioComumRepository(PicPayContext picPayContext)
        {
            this.picPayContext = picPayContext;
        }

        public async Task<Usuario?> buscarUsuarioCNPJ(string CNPJ) => await picPayContext.Usuarios.Where(u => u.CNPJ == CNPJ).FirstOrDefaultAsync();
        public async Task<Usuario?> buscarUsuarioCPF(string CPF) => await picPayContext.Usuarios.Where(u => u.CPF == CPF).FirstOrDefaultAsync();


        public async Task<bool> novoUsuario(UsuarioComum usuario)
        {
            try
            {
                await picPayContext.Usuarios.AddAsync(usuario);
                await picPayContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> Transferir(string idPayer, string idPayee, decimal amount)
        {
            var payer = await picPayContext.Usuarios.FirstOrDefaultAsync(x => x.CPF == idPayer || x.CNPJ == idPayer);
            var payee = await picPayContext.Usuarios.FirstOrDefaultAsync(x => x.CPF == idPayee || x.CNPJ == idPayee);

            if (payer.Saldo >= amount)
            {
                payer.Saldo -= amount;
                payee.Saldo += amount;

                picPayContext.Update(payee);
                picPayContext.Update(payer);
                await picPayContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
