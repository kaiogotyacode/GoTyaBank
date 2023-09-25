using CodeChallenge02.Models;
using CodeChallenge02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface IUsuarioComumRepository
    {
        public Task<bool> novoUsuario(Usuario usuario); 
        public Task<Usuario?> buscarUsuarioCNPJ(string CNPJ);
        public Task<Usuario?> buscarUsuarioCPF(string CPF);
        public Task<bool> Transferir(TransferenciaVM transferenciaVM);
    }
}
