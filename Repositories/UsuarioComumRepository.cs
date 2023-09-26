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
        public async Task<Lojista?> CreateLojista(LojistaVM lojistaVM)
        {
            var lojista = new Lojista
            {
                Nome = lojistaVM.Nome,
                Email = lojistaVM.Email,
                CNPJ = lojistaVM.CNPJ,
                isPessoaFisica = false
            };

            await picPayContext.Lojistas.AddAsync(lojista);
            await picPayContext.SaveChangesAsync();

            return lojista;
        }

        public Task<UsuarioComum?> CreateUsuarioComum(UsuarioComumVM usuarioComumVM)
        {
            throw new NotImplementedException();
        }

        #endregion Post Methods

        public async Task<GetUserVM?> GetUserByID(string userID)
        {
            if (userID.Length != 14 && userID.Length != 18)
                throw new ArgumentException("userID doesn't agree with the business rule.");

            var usuario = new GetUserVM();

            if (userID.Length == 14)
            {
                var usuarioComum = await picPayContext.UsuariosComuns.Where(x => x.CPF == userID).FirstOrDefaultAsync();

                if (usuarioComum != null)
                {
                    usuario.userID = usuarioComum.CPF;
                    usuario.Name = usuarioComum.Nome;
                }

                return usuario;
            }

            var lojista = await picPayContext.Lojistas.Where(x => x.CNPJ == userID).FirstOrDefaultAsync();

            if (lojista != null)
            {
                usuario.userID = lojista.CNPJ;
                usuario.Name = lojista.Nome;
            }

            return usuario;
        }
    }
}
