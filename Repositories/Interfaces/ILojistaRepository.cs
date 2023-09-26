using CodeChallenge02.Models;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface ILojistaRepository
    {
        public Task<Lojista?> CreateLojista(LojistaVM lojistaVM);
        public Task<bool> GetLojistaByID(LojistaVM lojistaVM);

    }
}
