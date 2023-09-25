using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.ViewModels;
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


        public async Task<bool> novoUsuario(Usuario usuario)
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

        public async Task<bool> Transferir(TransferenciaVM transferenciaVM)
        {
            //Se o usuário for lojista, não permitir o cadastro.

            var payer = await picPayContext.Usuarios.FirstOrDefaultAsync(x => x.CPF == transferenciaVM.CadastroPagador || x.CNPJ == transferenciaVM.CadastroPagador);
            var payee = await picPayContext.Usuarios.FirstOrDefaultAsync(x => x.CPF == transferenciaVM.CadastroBeneficiario || x.CNPJ == transferenciaVM.CadastroBeneficiario);

            if (payer.Saldo >= transferenciaVM.ValorTransferencia)
            {
                payer.Saldo -= transferenciaVM.ValorTransferencia;
                payee.Saldo += transferenciaVM.ValorTransferencia;

                picPayContext.Update(payee);
                picPayContext.Update(payer);
                await picPayContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
