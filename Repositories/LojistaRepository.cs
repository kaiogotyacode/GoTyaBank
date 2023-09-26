using CodeChallenge02.Database;
using CodeChallenge02.Models;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge02.Repositories
{
    public class LojistaRepository : ILojistaRepository
    {
        private readonly PicPayContext picPayContext;
        public LojistaRepository(PicPayContext picPayContext)
        {
            this.picPayContext = picPayContext;
        }
        public async Task<Lojista?> CreateLojista(LojistaVM lojistaVM)
        {
            if (await picPayContext.Lojistas.Where(x => x.Email == lojistaVM.Email || x.CNPJ == lojistaVM.CNPJ).AnyAsync())
                throw new Exception("User ID or E-mail already exists.");

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

        public async Task<bool> GetLojistaByID(LojistaVM lojistaVM)
        {
            var hasEmail = await picPayContext.Usuarios.Where(x => x.Email == lojistaVM.Email).AnyAsync();
            var hasID = await picPayContext.Lojistas.Where(x => x.CNPJ == lojistaVM.CNPJ).AnyAsync();

            if (hasEmail || hasID)
                return true;

            return false;
        }
    }
}
