using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeChallenge02.Repositories
{
    public class UsuarioComumRepository : IUsuarioComumRepository
    {
        private readonly PicPayContext picPayContext;
        public UsuarioComumRepository(PicPayContext picPayContext)
        {
            this.picPayContext = picPayContext;
        }
        #region Post Methods      

        public async Task<UsuarioComum?> CreateUsuarioComum(UsuarioComumVM usuarioComumVM)
        {
            var usuarioComum = new UsuarioComum
            {
                Nome = usuarioComumVM.Nome,
                Email = usuarioComumVM.Email,
                CPF = usuarioComumVM.CPF,
                isPessoaFisica = true
            };

            await picPayContext.UsuariosComuns.AddAsync(usuarioComum);
            await picPayContext.SaveChangesAsync();

            return usuarioComum;
        }

        #endregion Post Methods

        public async Task<bool> GetUsuarioComumByID(UsuarioComumVM usuarioComumVM)
        {
            var hasEmail = await picPayContext.Usuarios.Where(x => x.Email == usuarioComumVM.Email).AnyAsync();
            var hasID = await picPayContext.UsuariosComuns.Where(x => x.CPF == usuarioComumVM.CPF).AnyAsync();

            if (hasEmail || hasID)
                return true;

            return false;
        }

        public async Task<bool> Transferir(TransferenciaVM transferenciaVM)
        {
            try
            {
                var payer = await picPayContext.UsuariosComuns.Where(x => x.CPF == transferenciaVM.payerID).FirstOrDefaultAsync();

                var hasPayee = false;

                switch (transferenciaVM.payeeID.Length)
                {
                    case 14:
                        hasPayee = await picPayContext.UsuariosComuns.Where(x => x.CPF == transferenciaVM.payerID).AnyAsync();
                        break;
                    case 18:
                        hasPayee = await picPayContext.Lojistas.Where(x => x.CNPJ == transferenciaVM.payerID).AnyAsync();
                        break;
                    default:
                        return false;
                }

                if (payer == null || !hasPayee)
                    return false;

                if (!(payer.Saldo >= transferenciaVM.Amount))
                    return false;


                // Realiza a transferencia. Resolver complexidade do PAYEE CNPJ/CPF 
                payer.Saldo -= transferenciaVM.Amount;




                return true;
            }
            catch
            {
                return false;

            }

        }
    }
}
