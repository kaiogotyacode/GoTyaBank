using CodeChallenge02.Models;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface IUsuarioComumRepository
    {
        public Task<UsuarioComum?> CreateUsuarioComum(UsuarioComumVM usuarioComumVM);        
        public Task<bool> GetUserByID(string? userID, string? email);
    }
}
