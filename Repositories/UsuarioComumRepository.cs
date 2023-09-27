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

        public async Task<bool> HasUsuarioComum(UsuarioComumVM usuarioComumVM)
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
                if (transferenciaVM.payerID == transferenciaVM.payeeID)
                    return false;

                var payer = await picPayContext.UsuariosComuns.Where(x => x.CPF == transferenciaVM.payerID).FirstOrDefaultAsync();

                var hasPayee = false;

                switch (transferenciaVM.payeeID.Length)
                {
                    case 14:
                        hasPayee = await picPayContext.UsuariosComuns.Where(x => x.CPF == transferenciaVM.payerID).AnyAsync();
                        break;
                    case 18:
                        hasPayee = await picPayContext.Lojistas.Where(x => x.CNPJ == transferenciaVM.payeeID).AnyAsync();
                        break;
                    default:
                        return false;
                }

                if (payer == null || !hasPayee)
                    return false;

                var payeeCPF = (transferenciaVM.payeeID.Length == 14) ? picPayContext.UsuariosComuns.Where(x => x.CPF == transferenciaVM.payeeID).FirstOrDefault() : null;
                var payeeCNPJ = (transferenciaVM.payeeID.Length == 18) ? picPayContext.Lojistas.Where(x => x.CNPJ == transferenciaVM.payeeID).FirstOrDefault() : null;

                if (!(payer.Saldo >= transferenciaVM.Amount))
                    return false;

                payer.Saldo -= transferenciaVM.Amount;

                if (payeeCPF != null)
                {
                    payeeCPF.Saldo += transferenciaVM.Amount;
                    picPayContext.UsuariosComuns.Update(payeeCPF);
                }
                else if (payeeCNPJ != null)
                {
                    payeeCNPJ.Saldo += transferenciaVM.Amount;
                    picPayContext.Lojistas.Update(payeeCNPJ);
                }
                else
                    return false;

                //Só vamos salvar, caso o Email Service tiver êxito.

                await picPayContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;

            }

        }
    }
}
